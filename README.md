# THÔNG TIN SINH VIÊN
---
* **Họ và tên:** Nguyễn Gia Bảo Tường
* **Mã số sinh viên:** 31251020414
* **Lớp học phần:** Cấu trúc dữ liệu và giải thuật

# HƯỚNG DẪN BIÊN DỊCH VÀ CHẠY CHƯƠNG TRÌNH
---
1. Mở thư mục bài tập (Bai1, Bai2, Bai3, Bai4) bằng Visual Studio hoặc Visual Studio Code.
2. Đảm bảo máy tính đã cài đặt .NET SDK.
3. Nhấn nút **Start (F5)** trong Visual Studio (nhớ Set Startup Project cho bài cần chạy) hoặc mở Terminal gõ lệnh `dotnet run` để chạy chương trình.
4. Nhập dữ liệu theo các dòng thông báo trên màn hình (Console).

# MÔ TẢ GIẢI PHÁP, ĐỘ PHỨC TẠP & KIỂM THỬ
---

## Bài 1: Thống kê và đảo mảng

* **Giải pháp:** Sử dụng một vòng lặp `for` duy nhất để duyệt qua mảng tính min, max, tổng, và đếm các loại phần tử. Dùng hai con trỏ `left` và `right` đổi chỗ chéo nhau để đảo mảng tại chỗ, điều kiện dừng là khi hai con trỏ chạm nhau.
* **Độ phức tạp:** Thời gian $\Theta(n)$ do duyệt và đảo mảng tuyến tính. Bộ nhớ phụ $\Theta(1)$ vì thao tác trực tiếp trên mảng gốc, không dùng mảng phụ.

**Ca kiểm thử:**

| Ca | Đầu vào | Kết quả mong đợi | Kết quả thực tế | Nhận xét |
| :--- | :--- | :--- | :--- | :--- |
| 1 | `3 7 2 9 5` | min 2; max 9; đảo 5 9 2 7 3 | Đạt | Ca thường |
| 2 | `-5 0 5 0` | âm 1; dương 1; bằng 0 là 2 | Đạt | Có số âm và 0 |
| 3 | `8` | min = max = 8; đảo 8 | Đạt | Một phần tử |
| 4 | `-4 -2 -9` | max -2; trung bình -5.00 | Đạt | Toàn số âm |

---

## Bài 2: Chèn và xóa trên mảng

* **Giải pháp:** 
  * `Insert`: Dịch phần tử từ phải sang trái (`i--`) bắt đầu từ vị trí `count` để tránh ghi đè dữ liệu.
  * `RemoveAt`: Dịch phần tử từ trái sang phải (`i++`) bắt đầu từ `index` để lấp khoảng trống.
  * Bắt lỗi `ArgumentOutOfRangeException` và `InvalidOperationException` theo yêu cầu.
* **Độ phức tạp:** Thời gian $\Theta(count - index + 1)$ cho Insert và $\Theta(count - index)$ cho RemoveAt (Trường hợp xấu nhất là $O(n)$ khi thao tác ở đầu mảng). Bộ nhớ phụ $\Theta(1)$.

**Ca kiểm thử:**

| Ca | Đầu vào | Kết quả mong đợi | Kết quả thực tế | Nhận xét |
| :--- | :--- | :--- | :--- | :--- |
| Thường | mảng 5 pt, chèn 99 (idx 2), xóa (idx 1) | Chèn/xóa đúng, bảo toàn mảng | Đạt | Chạy đúng logic |
| Biên | Chèn tại đầu / cuối | Dịch toàn bộ / không dịch | Đạt | Xử lý tốt/xấu đúng |
| Biên | Xóa tại đầu / cuối | Dịch `count-1` / 0 phần tử | Đạt | Xử lý tốt/xấu đúng |
| Lỗi | Xóa tại `index = count` hoặc `< 0` | `ArgumentOutOfRangeException` | Đạt | Bắt đúng lỗi biên |
| Lỗi | Chèn khi `count == data.Length` | `InvalidOperationException` | Đạt | Bắt đúng mảng đầy |

---

## Bài 3: Quản lý List Student

* **Giải pháp:** Khởi tạo lớp `Student`. Sử dụng `List<Student>` để quản lý. Xây dựng các hàm tách biệt. Không sử dụng thư viện LINQ mà dùng vòng lặp `for` thuần để đối chiếu `Id` (chống trùng lặp), tìm kiếm chuỗi con (bằng `.Contains()` và `.ToLower()`) và xóa sinh viên. 
* **Độ phức tạp:** Thêm/Sửa/Xóa và Tìm kiếm đều tốn thời gian $O(n)$ do phải duyệt vòng lặp kiểm tra mã. Hàm Thống kê tính điểm trung bình duyệt mảng 1 lần tốn $\Theta(n)$. Bộ nhớ phụ $\Theta(1)$.

**Ca kiểm thử:**

| Ca | Đầu vào | Kết quả mong đợi | Kết quả thực tế | Nhận xét |
| :--- | :--- | :--- | :--- | :--- |
| Thường | Thêm 5 SV, tìm tên có thật | Thêm thành công, hiển thị đúng | Đạt | Chạy chuẩn xác |
| Lỗi | Thêm SV trùng mã Id | Từ chối, báo lỗi trùng mã | Đạt | Chặn trùng lặp |
| Lỗi | Nhập điểm < 0 hoặc > 10 | Từ chối, báo lỗi điểm số | Đạt | Bảo vệ dữ liệu |
| Biên | Xóa mã Id không tồn tại | Thông báo không tìm thấy | Đạt | Xử lý êm mượt |
| Biên | Thống kê danh sách rỗng | Báo "Danh sach rong" | Đạt | Tránh lỗi chia cho 0 |

---

## Bài 4: Mảng động và Capacity

* **Giải pháp:** Sử dụng mảng tĩnh `T[] items` làm lõi. Hàm `EnsureCapacity()` kiểm tra nếu `Count == Capacity` thì tạo mảng mới có kích thước nhân đôi (`Capacity * 2`), chép dữ liệu cũ sang và trỏ lại vùng nhớ. Tích hợp ném ngoại lệ ở `Indexer` để bảo vệ truy cập.
* **Độ phức tạp:** Thao tác Add trung bình khấu hao là $O(1)$. Việc cấp phát mở rộng mảng diễn ra hiếm hoi tiêu tốn thời gian $O(n)$ và bộ nhớ phụ tạm thời $O(n)$. Indexer truy cập trực tiếp tốn $O(1)$.

**Ca kiểm thử:**

| Ca | Đầu vào | Kết quả mong đợi | Kết quả thực tế | Nhận xét |
| :--- | :--- | :--- | :--- | :--- |
| Thường | Add số 1 đến 10 | Capacity nhảy 4 $\rightarrow$ 8 $\rightarrow$ 16 | Đạt | Cấp phát mảng chuẩn |
| Thường | Cập nhật `arr[2]` = 999 | Lưu và in đúng giá trị mới | Đạt | Indexer hoạt động |
| Biên | Mở rộng mảng cũ | Dữ liệu cũ không bị xáo trộn | Đạt | Chép dữ liệu tốt |
| Lỗi | Khởi tạo Capacity = -5 | Báo `ArgumentOutOfRangeException` | Đạt | Khống chế đầu vào |
| Lỗi | Đọc `arr[arr.Count]` | Báo `ArgumentOutOfRangeException` | Đạt | Bảo vệ giới hạn mảng |
