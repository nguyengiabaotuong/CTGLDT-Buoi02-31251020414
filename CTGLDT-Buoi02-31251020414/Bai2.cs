using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
internal class Btapbuoi22
{
    static void Insert(int[] data, ref int count, int index, int value)
    {
        // Phát sinh ngoại lệ nếu vị trí chèn nằm ngoài vùng dữ liệu hợp lệ hiện tại (từ 0 đến count).
        if (index < 0 || index > count)
            throw new ArgumentOutOfRangeException("index", "Chỉ số chèn không hợp lệ!");
        // Phát sinh ngoại lệ nếu số phần tử thực tế đã đạt mức tối đa sức chứa của mảng.
        if (count >= data.Length)
            throw new InvalidOperationException("Mảng đã đầy, không thể chèn thêm.");
        // Duyệt từ cuối mảng lùi về vị trí index, dịch phần tử sang phải để nhường chỗ.
        for (int i = count; i > index; i--)
        {
            // Sao chép giá trị của phần tử phía trước đè lên phần tử phía sau.
            data[i] = data[i - 1];
        }
        // Ghi giá trị mới vào vị trí index đã được làm trống một cách an toàn.
        data[index] = value;
        // Tăng số lượng phần tử hợp lệ lên 1 sau khi đã thêm dữ liệu thành công.
        count++;
    }
    static void RemoveAt(int[] data, ref int count, int index)
    {
        // Phát sinh ngoại lệ nếu vị trí xóa không nằm trong các phần tử đang tồn tại (0 đến count - 1).
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException("index", "Chỉ số xóa không hợp lệ!");
        // Duyệt từ vị trí cần xóa tiến về cuối mảng, dịch phần tử sang trái để lấp lỗ hổng.
        for (int i = index; i < count - 1; i++)
        {
            // Kéo giá trị của phần tử phía sau đè lên phần tử hiện tại phía trước.
            data[i] = data[i + 1];
        }
        // Giảm số lượng phần tử hợp lệ đi 1 sau khi phần tử cuối cùng đã được dịch lên.
        count--;
    }
    static void PrintArray(int[] data, int count)
    {
        // Chỉ lặp qua các phần tử có dữ liệu thực sự để in ra màn hình.
        for (int i = 0; i < count; i++)
        {
            // In giá trị phần tử cùng khoảng trắng phân cách.
            Console.Write(data[i] + " ");
        }
        // Xuống dòng kết thúc mảng.
        Console.WriteLine();
    }
    static void Main2()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        // Cấp phát mảng tĩnh chứa được 10 phần tử nhưng khởi tạo sẵn 5 giá trị đầu.
        int[] data = new int[10] { 4, 7, 2, 9, 5, 0, 0, 0, 0, 0 };
        // Đặt số lượng phần tử hợp lệ ban đầu là 5.
        int count = 5;
        Console.WriteLine("Mang ban dau: ");
        PrintArray(data, count);
        // Bọc trong try-catch để chương trình không sập khi thử nghiệm ca kiểm thử biên.
        try
        {
            Console.WriteLine("-> Chen 99 tai index 2:");
            Insert(data, ref count, 2, 99);
            PrintArray(data, count);
            Console.WriteLine("-> Xoa phan tu tai index 1:");
            RemoveAt(data, ref count, 1);
            PrintArray(data, count);
            Console.WriteLine("-> Thu xoa phan tu tai index = count (loi bien):");
            RemoveAt(data, ref count, count);
        }
        catch (Exception ex) // Bắt các lỗi ngoại lệ phát sinh từ thao tác sai lệch.
        {
            Console.WriteLine("Loi phat sinh: " + ex.GetType().Name + " - " + ex.Message);
        }
    }
}