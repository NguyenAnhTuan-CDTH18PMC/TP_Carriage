-Các bước trước khi chạy Code
Bước 1 : Thay đổi connectionString trong appstring
Bước 2: Chạy lệnh update-database trong Package Manager Console
Done --> Dưới SQL có Database là TP_Carriage_API. Sau đó chạy code lên để lấy API.


localhost/api/Accounts => GET (Lấy danh sách)
localhost/api/Accounts/{id} => GET (Lấy 1 đối tượng theo id)
localhost/api/Accounts/{id} => PUT (Thêm 1 đối tượng)
localhost/api/Accounts => POST (Update)
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


Api tạo tk và đăng nhập
localhost/api/Accounts/GetAllUsers ==> GET Lấy tất cả User
localhost/api/Accounts/Register ==> POST (đăng kí tài khoản)
localhost/api/Accounts/Authenticate==> POST (Đăng nhập)