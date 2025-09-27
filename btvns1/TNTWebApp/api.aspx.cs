using System;
using System.IO;
using System.Reflection;
using System.Web;

namespace TNTWebApp
{
    public class api : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;

            try
            {
                string name = context.Request["name"] ?? "";

                // Load DLL
                string binPath = context.Server.MapPath("~/bin/TNTLibrary.dll");
                Assembly lib = Assembly.LoadFrom(binPath);

                Type calcType = lib.GetType("TNTLibrary.HappinessCalculator");
                if (calcType == null)
                    throw new Exception("Không tìm thấy class TNTLibrary.HappinessCalculator trong DLL.");

                object calc = Activator.CreateInstance(calcType);

                // Gán input
                var inputNameProp = calcType.GetProperty("InputName");
                inputNameProp.SetValue(calc, name, null);

                // Gọi tính toán
                calcType.GetMethod("Calculate").Invoke(calc, null);

                // Lấy kết quả
                int index = (int)calcType.GetProperty("HappinessIndex").GetValue(calc, null);
                string message = (string)calcType.GetMethod("GetMessage").Invoke(calc, null);

                string json = "{"
                    + "\"ok\":true,"
                    + "\"message\":\"" + EscapeForJson(message) + "\","
                    + "\"index\":" + index
                    + "}";

                context.Response.Write(json);
            }
            catch (Exception ex)
            {
                string json = "{"
                    + "\"ok\":false,"
                    + "\"error\":\"" + EscapeForJson(ex.Message) + "\""
                    + "}";
                context.Response.Write(json);
            }
        }

        private static string EscapeForJson(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
        }

        public bool IsReusable { get { return false; } }
    }
}
