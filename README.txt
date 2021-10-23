-Các bước trước khi chạy Code
Bước 1 : Thay đổi connectionString trong appstring
Bước 2: Chạy lệnh update-database trong Package Manager Console
Done --> Dưới SQL có Database là TP_Carriage_API. 
Vô SQL chạy câu query
USE [TP_Carriage_API]
GO
INSERT [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'15fc3751-2ad4-4784-8ca3-e479d5e69dc5', N'SuperAdmin', N'SUPERADMIN', N'84b8a7a8-b1ea-4ee7-979d-1533c737f485')
INSERT [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4d843441-16b6-4e0f-b9a4-e067d271573b', N'Admin', N'ADMIN', N'537d537e-f673-48be-bcde-d72e7fdf5be4')
INSERT [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'82fd4939-8534-4adb-80b2-222f1d60784c', N'Basic', N'BASIC', N'54a7c772-0853-4c68-8ba1-c0456e431aa8')
INSERT [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'93112122-61f4-4582-a582-bd399f35098c', N'Moderator', N'MODERATOR', N'6df06996-9be9-42aa-9543-8b29f0413c96')
GO
Sau đó chạy code lên để lấy API.


localhost/api/Accounts => GET (Lấy danh sách)
localhost/api/Accounts/{id} => GET (Lấy 1 đối tượng theo id)
localhost/api/Accounts => POST(Thêm 1 đối tượng)
localhost/api/Accounts/{id} => PUT (Update)
localhost/api/Accounts/{id} => DELETE (Xóa 1 đối tượng)


Thay Accounts bằng các Controller sau đây 

Accounts
BenXes
BangGias
Chats
ChiTietVes
ChuyenXes
DiaDiems
Ghes
LichTrinhs
LoaiGhes
Messagegroups
Mesages
NhanXets
NhaXes
VeXe
Xes




Api Momo Request
localhost/api/ChiTietVes/ThanhToan => POST (Tạo ra mã QR Code)
=> Body request gồm GiaVe và GhiChu
Example Body
{
   "GiaVe":1000000,
   "GhiChu":"Day la mot vi du"
}


Api tạo tk và đăng nhập
localhost/api/Accounts/GetAllUsers ==> GET Lấy tất cả User

localhost/api/Accounts/Register ==> POST (đăng kí tài khoản)
Example Body
{
              "Email" : "nguyenhoaiphu123@gmail.com",
              "Password":"Abcd@1234",
              "ConfirmPassword" : "Abcd@1234",
              "TenKh" : "Nguyễn Hoài Phú",
              "Cmnd" : "277789654",
              "DiaChi" : "quận Tân Bình",
              "GioiTinh":1               
}
localhost/api/Accounts/Authenticate==> POST (Đăng nhập)
Example Body
{
      "Email" : "nguyenhoaiphu123@gmail.com",
      "Password":"Abcd@1234"
}



localhost/api/Accounts/ResetPassword => POST (Gửi mail resetpassword)
Example Body
{
         "Email":"0306181290"
}

localhost/api/Accounts/Reset-Password => POST (Gửi request thay đổi mật khẩu)
Example Body
{
     "Email":"0306181290",
     "Token":"Token này lấy ở trong mail gửi user", 
     "newPassword":"nhập mật khẩu mới"
}



localhost/api/ChuyenXes/TheoNgayHopLe ==> GET ==> Lấy ra list chuyến xe từ hôm nay trở đi
localhost/api/Xes/NhaXes/{id} ==> GET(truyền vào id của nhà xe) ==> Lấy ra list xe của nhà xe
localhost/api/ChuyenXes/NhaXes/{id} ==> GET(truyền vào id của nhà xe) ==> Lấy ra list chuyến xe của nhà xe
localhost/api/VeXes/ChuyenXes/{id} ==> GET(truyền vào id của chuyến xe) ==> Lấy ra tất cả các vé của chuyến xe đó
localhost/api/VeXes/NhaXes/{id} ==> GET(truyền vào id của nhà xe) ==> Lấy ra tất cả các vé của nhà xe
localhost/api/ChiTietVes/ChuyenXes/{id} ==> GET(truyền vào id của chuyến xe) ==> Lấy ra tất cả các chi tiết vé của chuyến xe đó
localhost/api/BangGias/NhaXes/{id} ==>GET(truyền vào id của nhà xe )==> Lấy ra tất cả các bảng giá của nhà xe
localhost/api/VeXes/Accounts/{email} ==> GET(truyền vào email của nhà xe) ==> Lấy ra tất cả các vé của account đó
localhost/api/NhaXes/Email/{email} ==> GET(Truyền vào email của nhà xe) ==> Lấy ra thông tin của nhà xe theo email

localhost/api/ChiTietVes/MoneyList ==> GET ==> Lấy ra t doanh thu mỗi tháng từ tháng A,năm A đến tháng B,năm B (Điều kiện Năm B-Năm A=1)
{
   "Thang1":"",
   "Nam1":"",
   "Thang2":"",
   "Nam2":""
}

localhost/api/ChiTietVes/Money ==> GET ==> Lấy ra  doanh thu của Tháng A năm A
{
   "Thang":"",
   "Nam":"",
"
}

localhost/Api/Accounts/GetCustomer ==> GEt ==> Lấy ra tất cả account có loại là Khách hàng(Quyen=1)
