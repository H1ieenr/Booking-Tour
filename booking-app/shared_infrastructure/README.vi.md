# 🚀 Nền tảng Đặt Tour Du Lịch: Kiến trúc Microservices

Hệ thống đặt tour du lịch hiệu năng cao, được thiết kế để giải quyết bài toán mở rộng và bảo trì trong môi trường phân tán. Dự án này áp dụng những kỹ thuật tiên tiến nhất trong hệ sinh thái **.NET 10**.

---

## 🏗 Tư duy Kiến trúc

Thay vì xây dựng một khối Monolith cồng kềnh, dự án này được chia nhỏ thành các **Microservices**. Mỗi service chịu trách nhiệm cho một phạm vi nghiệp vụ (Bounded Context) riêng biệt.

### 🧩 Các mô hình thiết kế cốt lõi
* **Domain-Driven Design (DDD):** Đặt nghiệp vụ làm trung tâm. Sử dụng **Aggregates** để đảm bảo tính toàn vẹn dữ liệu và **Value Objects** để mô tả các thuộc tính phức tạp.
* **CQRS:** Tách biệt luồng Đọc và Ghi. Điều này giúp tối ưu hóa Database cho việc truy vấn (Read) mà không làm ảnh hưởng đến logic nghiệp vụ phức tạp khi ghi dữ liệu (Write).
* **Clean Architecture:** Đảm bảo mã nguồn dễ kiểm thử (Unit Test) bằng cách tách biệt Domain khỏi các tác nhân bên ngoài như Database hay UI.

---

## 🛠 Danh sách Công nghệ

* **Backend:** .NET 10, C# 13, Web API.
* **Xử lý nội bộ:** **MediatR** giúp giảm sự phụ thuộc trực tiếp (Decoupling) giữa các class.
* **Dữ liệu:** SQL Server phối hợp cùng EF Core 10 (Code First).
* **Frontend:** Angular với kiến trúc Component-based hiện đại.
* **Triển khai:** Docker hóa toàn bộ dịch vụ để dễ dàng triển khai trên môi trường Cloud.

---

## 🔄 Luồng xử lý chi tiết

### 1. Luồng Ghi (Command - Thay đổi trạng thái)
Ví dụ khi người dùng nhấn "Đặt Tour":
1.  **API:** Nhận yêu cầu và đóng gói thành một `Command`.
2.  **MediatR:** Chuyển `Command` đến đúng `Handler` phụ trách.
3.  **Domain:** Hệ thống nạp dữ liệu từ DB lên thành các đối tượng nghiệp vụ, kiểm tra các quy tắc (ví dụ: "Tour còn chỗ không?", "Hạn đặt tour còn không?").
4.  **Infrastructure:** Nếu mọi thứ hợp lệ, dữ liệu mới được lưu xuống SQL Server.

### 2. Luồng Đọc (Query - Lấy dữ liệu)
Ví dụ khi xem "Danh sách Tour":
1.  Hệ thống sử dụng các truy vấn tinh gọn (Dapper hoặc EF NoTracking).
2.  Dữ liệu được map thẳng vào các **DTOs** (Data Transfer Objects) để trả về phía Angular, bỏ qua các bước kiểm tra nghiệp vụ phức tạp để đạt tốc độ tối đa.

---

## 🚦 Lộ trình phát triển
- [x] **Giai đoạn 1:** Thiết lập cấu trúc thư mục chuẩn DDD và các Building Blocks.
- [ ] **Giai đoạn 2:** Hoàn thành các API demo cho Tour và Booking.
- [ ] **Giai đoạn 3:** Xây dựng hệ thống đăng nhập/phân quyền (Identity Service).
- [ ] **Giai đoạn 4:** Tích hợp RabbitMQ để các Service có thể "nói chuyện" với nhau một cách bất đồng bộ.
- [ ] **Giai đoạn 5:** Triển khai Monitoring (ELK Stack hoặc Prometheus).