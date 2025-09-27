# webbts1
## TẠO SOLUTION GỒM CÁC DỰ ÁN SAU:
1. DLL đa năng, từ khóa: thư viện cửa sổ c# -> Thư viện lớp (.NET Framework) bắt buộc sử dụng .NET Framework 2.0 : giải bài toán bất kỳ, độc lạ càng tốt, phải có dấu ấn cá nhân trong kết quả, biên dịch ra DLL. DLL độc lập vì nó không nhập, không xuất, nó nhận đầu vào truyền vào thuộc tính của nó và trả về dữ liệu thuộc tính khác hoặc thông tin trả về giá trị của hàm. Nó độc lập sẽ được sử dụng trên bảng điều khiển dạng ứng dụng (lệnh giao diện dòng - đen sì), cũng được sử dụng trên màn hình ứng dụng (dạng cửa sổ), và cũng được sử dụng trên biểu mẫu web (web chạy qua iis).
2Console app, bắt buộc sử dụng .NET Framework 2.0 , use DLL trên: nhập dữ liệu đầu vào, gọi DLL, hiển thị kết quả, phải có dấu cá nhân. từ khóa: c# window Console => Console App (.NET Framework) , biên dịch ra EXE
3. Windows Form Application, bắt buộc sử dụng .NET Framework 2.0 **, sử dụng đa năng DLL trên, kéo các điều khiển vào để có thể lấy đầu vào, gọi đầu vào truyền DLL để lấy kq, hiển thị biểu mẫu cửa sổ kq ra, phải có dấu cá nhân; từ khóa: c# window Desktop => Windows Form Application (.NET Framework) , biên dịch ra EXE
4. Web đơn giản, bắt buộc sử dụng .NET Framework 2.0 , sử dụng máy chủ web là IIS, sử dụng máy chủ tệp để tự tạo miền, gắn miền này vào iis, tệp index.html có sử dụng html css js để xây dựng giao diện đầu vào cho bài toán, sử dụng mã js để xử lý dữ liệu, js để gửi phụ trợ. backend là api.aspx, trong code của api.aspx.cs sẽ lấy các đầu vào mà js gửi lên, sau đó sử dụng đa năng DLL ở trên. kết quả gửi lại json cho khách hàng, js phía khách hàng sẽ nhận được hậu xử lý json này để thay đổi giao diện theo dữ liệu nhận dược, phải có dấu hiệu cá nhân. từ khóa: c# window web => Ứng dụng web ASP.NET (.NET Framework) + link tham khảo chatgpt thầy gửi. dự án web này được biên dịch bằng DLL, phải kết hợp với IIS mới được chạy.
## BÀI LÀM
SOLUTION GỒM
1. TNTConsoleApp
2. TNTLibrary
3. TNTWebApp
4. TNTWFormsApp
<img width="504" height="627" alt="image" src="https://github.com/user-attachments/assets/e20e61c7-54f8-479d-a4a0-14f32f6a49c6" />


## TẠO THÀNH CÔNG Solution và Project DLL class libary (TNTLibrary)

<img width="1918" height="1080" alt="image" src="https://github.com/user-attachments/assets/c5f76742-1fdb-4458-91f1-4526ef909f91" />

## TẠO THÀNH CÔNG Project Consiole App.NET Framewwork 2.0 (TNTConsoleApp)

<img width="1271" height="796" alt="image" src="https://github.com/user-attachments/assets/3d07efa9-1298-428f-8e30-d4ecfcae038f" />
<img width="1379" height="918" alt="image" src="https://github.com/user-attachments/assets/846f895a-af53-4929-a1d6-f2f30d8d3d07" />

## TẠO THÀNH CÔNG Project Windows Form Application.NET Framework 2.0(TNTWFormsApp)

<img width="1829" height="931" alt="image" src="https://github.com/user-attachments/assets/a3902773-9573-4ec6-b363-5941b98af024" />
<img width="568" height="309" alt="image" src="https://github.com/user-attachments/assets/5715a0d4-9a08-4552-9848-450e2269b36f" />

## TẠO THÀNH CÔNG Project Web App ASP.NET Web APPlication .NET Framewwork 2.0(TNTWebApp)

<img width="1560" height="701" alt="image" src="https://github.com/user-attachments/assets/1d2b091e-41f6-4d7b-a9c9-e0f0c4118089" />

## CÀI IIS CHO WEB

<img width="1408" height="722" alt="image" src="https://github.com/user-attachments/assets/9f8b8d84-2ab9-4996-ba71-2adafc6092ac" />

## KẾT QUẢ
<img width="1912" height="1079" alt="image" src="https://github.com/user-attachments/assets/795cb682-a500-48a7-a2e4-79b51d36ce21" />
