<%@ WebHandler Language="C#" Class="TNTWebApp.api" %>
using System;
using System.Web;
using System.Reflection;
using System.IO;
using System.Text;

namespace TNTWebApp
{
    public class api : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.Cache.SetNoStore();

            try
            {
                string name = context.Request["name"];
                if (name == null) name = "";

                if (string.IsNullOrEmpty(name))
                {
                    throw new Exception("Thiếu tham số 'name'.");
                }

                // Đường dẫn tới DLL bên trong thư mục bin
                string binPath = context.Server.MapPath("~/bin/TNTLibrary.dll");
                if (!File.Exists(binPath))
                {
                    throw new Exception("Không tìm thấy TNTLibrary.dll trong /bin.");
                }

                Assembly lib = Assembly.LoadFrom(binPath);
                Type calcType = lib.GetType("TNTLibrary.HappinessCalculator");
                if (calcType == null)
                {
                    throw new Exception("Không tìm thấy class TNTLibrary.HappinessCalculator trong DLL.");
                }

                object calc = Activator.CreateInstance(calcType);

                // Gán InputName nếu tồn tại
                PropertyInfo inputProp = calcType.GetProperty("InputName");
                if (inputProp != null && inputProp.CanWrite)
                {
                    inputProp.SetValue(calc, name, null);
                }

                // Gọi phương thức Calculate nếu có
                MethodInfo calcMethod = calcType.GetMethod("Calculate");
                if (calcMethod != null)
                {
                    calcMethod.Invoke(calc, null);
                }

                // Lấy chỉ số HappinessIndex nếu có
                int index = 0;
                PropertyInfo idxProp = calcType.GetProperty("HappinessIndex");
                if (idxProp != null)
                {
                    object idxVal = idxProp.GetValue(calc, null);
                    if (idxVal != null)
                    {
                        // safe convert
                        try { index = Convert.ToInt32(idxVal); } catch { index = 0; }
                    }
                }

                // Tạo message trả về
                string message = "Đã tính xong cho " + name;

                // Tạo JSON thủ công (escape)
                string json = "{" +
                    "\"ok\":true," +
                    "\"message\":\"" + EscapeForJson(message) + "\"," +
                    "\"index\":" + index.ToString() +
                    "}";

                context.Response.Write(json);
            }
            catch (Exception ex)
            {
                string err = ex.Message ?? "Lỗi không xác định";
                string jsonErr = "{" +
                    "\"ok\":false," +
                    "\"error\":\"" + EscapeForJson(err) + "\"" +
                    "}";
                context.Response.Write(jsonErr);
            }
        }

        private static string EscapeForJson(string s)
        {
            if (s == null) return "";
            // Only the necessary escapes for JSON
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                switch (c)
                {
                    case '\\': sb.Append("\\\\"); break;
                    case '\"': sb.Append("\\\""); break;
                    case '\r': sb.Append("\\r"); break;
                    case '\n': sb.Append("\\n"); break;
                    case '\t': sb.Append("\\t"); break;
                    default:
                        // Control chars
                        if (c < 32)
                        {
                            sb.AppendFormat("\\u{0:x4}", (int)c);
                        }
                        else sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}
