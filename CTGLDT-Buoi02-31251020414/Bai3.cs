using System;
using System.Collections.Generic;
using System.Text;
public class Student
{
    // Lưu mã duy nhất dùng để nhận diện sinh viên.
    public string Id { get; set; } = "";
    // Lưu họ tên dùng cho hiển thị và tìm kiếm.
    public string FullName { get; set; } = "";
    // Lưu điểm tổng kết trong đoạn từ 0 đến 10.
    public double Score { get; set; }
}
internal class Btapbuoi23
{
    static List<Student> students = new List<Student>();
    static void Main3()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        static void AddStudent(List<Student> students)
    {
        Console.Write("Nhap ma SV: ");
        string id = Console.ReadLine();
        // Duyệt toàn bộ danh sách để tìm mã trùng lặp 
        for (int i = 0; i < students.Count; i++)
        {
            // Nếu mã nhập vào đã khớp với một sinh viên trong danh sách
            if (students[i].Id == id)
            {
                Console.WriteLine("Loi: Ma sinh vien da ton tai!");
                return; // Ngắt hàm, từ chối thêm mới
            }
        }
        Console.Write("Nhap ho ten: ");
        string name = Console.ReadLine();
        Console.Write("Nhap diem (0-10): ");
        double score = double.Parse(Console.ReadLine());
        // Kiểm tra tính hợp lệ của điểm số
        if (score < 0 || score > 10)
        {
            Console.WriteLine("Loi: Diem phai thuoc doan [0, 10]!");
            return; // Ngắt hàm, từ chối thêm mới
        }
        // Đẩy đối tượng sinh viên hợp lệ vào cuối List 
        students.Add(new Student { Id = id, FullName = name, Score = score });
        Console.WriteLine("Them thanh cong!");
    }
    static void UpdateStudent(List<Student> students)
    {
        Console.Write("Nhap ma SV can cap nhat: ");
        string id = Console.ReadLine();
        // Duyệt qua danh sách để xác định vị trí sinh viên cần sửa
        for (int i = 0; i < students.Count; i++)
        {
            // Nếu tìm thấy sinh viên có mã khớp
            if (students[i].Id == id)
            {
                Console.Write("Nhap ho ten moi: ");
                // Gán đè chuỗi họ tên mới
                students[i].FullName = Console.ReadLine();
                Console.Write("Nhap diem moi (0-10): ");
                double newScore = double.Parse(Console.ReadLine());
                // Chỉ cập nhật điểm nếu điểm nhập mới hợp lệ
                if (newScore >= 0 && newScore <= 10)
                    students[i].Score = newScore;
                else
                    Console.WriteLine("Diem moi khong hop le, chi cap nhat ten.");
                return; // Xử lý xong thì thoát hàm
            }
        }
        Console.WriteLine("Khong tim thay sinh vien!");
    }
    static void RemoveStudent(List<Student> students)
    {
        Console.Write("Nhap ma SV can xoa: ");
        string id = Console.ReadLine();
        // Duyệt danh sách tìm phần tử cần xóa
        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].Id == id)
            {
                // Hàm RemoveAt sẽ xóa phần tử và tự động dồn các phần tử phía sau lên O(n)
                students.RemoveAt(i);
                Console.WriteLine("Xoa thanh cong!");
                return;
            }
        }
        Console.WriteLine("Khong tim thay ma sinh vien de xoa!");
    }
    static void SearchStudent(List<Student> students)
    {
        Console.Write("Nhap ten can tim: ");
        // Đưa từ khóa về chữ thường để so sánh không phân biệt hoa/thường
        string keyword = Console.ReadLine().ToLower();
        bool found = false;
        // Duyệt danh sách (không dùng LINQ)
        for (int i = 0; i < students.Count; i++)
        {
            // Ép tên sinh viên về chữ thường và kiểm tra chứa chuỗi con
            if (students[i].FullName.ToLower().Contains(keyword))
            {
                // In ra thông tin sinh viên phù hợp
                Console.WriteLine($"[{students[i].Id}] {students[i].FullName} - {students[i].Score}");
                found = true; // Đánh dấu cờ là có kết quả
            }
        }
        // Nếu cờ không bật, tức là duyệt hết nhưng không tìm thấy
        if (!found) Console.WriteLine("Khong tim thay ai phu hop.");
    }
    static void DisplayStats(List<Student> students)
    {
        // Xử lý danh sách rỗng để tránh lỗi chia cho 0 khi tính trung bình
        if (students.Count == 0)
        {
            Console.WriteLine("Danh sach rong.");
            return;
        }
        double sum = 0;
        int countPass = 0;
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"[{students[i].Id}] {students[i].FullName} - {students[i].Score}");
            // Cộng dồn điểm vào biến tổng
            sum += students[i].Score;
            // Tăng biến đếm nếu sinh viên có điểm từ 5 trở lên
            if (students[i].Score >= 5) countPass++;
        }
        // Xuất thông tin thống kê với điểm trung bình làm tròn 2 chữ số
        Console.WriteLine($"Si so: {students.Count}");
        Console.WriteLine($"Trung binh: {(sum / students.Count):F2}");
        Console.WriteLine($"So luong dat: {countPass}");
    }
        // Khởi tạo danh sách động chứa đối tượng Student
        List<Student> students = new List<Student>();
        while (true)
        {
            Console.WriteLine("--- MENU ---");
            Console.WriteLine("1. Them | 2. Sua | 3. Xoa | 4. Tim | 5. Xem | 0. Thoat");
            Console.Write("Chon: ");
            switch (Console.ReadLine())
            {
                case "1": AddStudent(students); break;
                case "2": UpdateStudent(students); break;
                case "3": RemoveStudent(students); break;
                case "4": SearchStudent(students); break;
                case "5": DisplayStats(students); break;
                case "0": return; // Kết thúc chương trình
            }
        }
    }
}
