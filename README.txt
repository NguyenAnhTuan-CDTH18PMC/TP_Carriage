-Các bước trước khi chạy Code
Bước 1 : Thay đổi connectionString trong appstring
Bước 2: Chạy lệnh update-database trong Package Manager Console
Done --> Dưới SQL có Database là TP_Carriage_API. Sau đó chạy code lên để lấy API.


localhost/api/Accounts => GET (Lấy danh sách)
localhost/api/Accounts/{id} => GET (Lấy 1 đối tượng theo id)
localhost/api/Accounts/{id} => POST(Thêm 1 đối tượng)
localhost/api/Accounts => PUT (Update)
localhost/api/Accounts/{id} => DELETE (Xóa 1 đối tượng)


Thay Accounts bằng các Controller sau đây 

Accounts
BenXes
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