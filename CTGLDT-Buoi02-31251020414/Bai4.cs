using System;
using System.Collections.Generic;
using System.Text;
internal class Bai4
{
    public class DynamicArray<T>
    {
        // Mảng tĩnh nội bộ làm vùng nhớ vật lý lưu dữ liệu.
        private T[] items;
        // Số phần tử thực sự có giá trị mà mảng đang chứa.
        public int Count { get; private set; }
        // Dung lượng tối đa hiện tại của mảng nội bộ.
        public int Capacity => items.Length;
        public DynamicArray(int capacity = 4)
        {
            // Kiểm tra biên, từ chối cấp phát nếu dung lượng yêu cầu là số âm.
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("capacity", "Dung luong khong duoc am.");
            // Cấp phát mảng tĩnh mới với sức chứa được chỉ định.
            items = new T[capacity];
            // Khởi tạo số lượng phần tử ban đầu là 0.
            Count = 0;
        }
        public void Add(T item)
        {
            // Kiểm tra và thực hiện mở rộng mảng tĩnh nếu vùng nhớ đã đầy.
            EnsureCapacity();
            // Đưa phần tử vào ô trống ở cuối và tự động tăng số đếm.
            items[Count++] = item;
        }
        private void EnsureCapacity()
        {
            // Tiến hành mở rộng chỉ khi số phần tử thực tế chạm trần dung lượng.
            if (Count == Capacity)
            {
                // Mảng mới sẽ có dung lượng nhân đôi (hoặc bằng 4 nếu mảng cũ đang là 0).
                int newCapacity = Capacity == 0 ? 4 : Capacity * 2;
                // Cấp phát vùng nhớ mới lớn hơn (tiêu tốn O(n) bộ nhớ tạm).
                T[] newItems = new T[newCapacity];
                // Chép tuần tự các phần tử cũ sang mảng mới để bảo toàn dữ liệu.
                for (int i = 0; i < Count; i++)
                {
                    // Đảm bảo thứ tự các phần tử cũ không bị xáo trộn.
                    newItems[i] = items[i];
                }
                // Trỏ con trỏ mảng nội bộ sang mảng mới. Mảng cũ sẽ được Garbage Collector thu hồi.
                items = newItems;
            }
        }
        public T this[int index]
        {
            get
            {
                // Nếu lấy dữ liệu ở vị trí ngoài vùng phần tử hợp lệ, ném ngoại lệ giới hạn mảng.
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index", "Chỉ số đọc không hợp lệ.");
                // Trả về trực tiếp phần tử trong bộ nhớ với chi phí O(1).
                return items[index];
            }
            set
            {
                // Nếu ghi dữ liệu vào vị trí ngoài vùng phần tử hợp lệ, ném ngoại lệ giới hạn mảng.
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index", "Chỉ số ghi không hợp lệ.");
                // Cập nhật giá trị phần tử với chi phí O(1).
                items[index] = value;
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            DynamicArray<int> arr = new DynamicArray<int>(4);

            // Thêm 10 số để chứng kiến quá trình Capacity tăng từ 4 -> 8 -> 16.
            for (int i = 1; i <= 10; i++)
            {
                arr.Add(i * 10);
                Console.WriteLine($"Them {i * 10} -> Count: {arr.Count}, Capacity: {arr.Capacity}");
            }
            // Đọc và cập nhật phần tử qua indexer
            Console.WriteLine($"Phan tu tai index 2 hien tai: {arr[2]}");
            arr[2] = 999; // Cập nhật (Set)
            Console.WriteLine($"Phan tu tai index 2 sau cap nhat: {arr[2]}");

            // Kiểm tra ngoại lệ biên (Indexer với index = Count)
            try
            {
                Console.WriteLine("Thu doc phan tu tai vi tri index bang Count:");
                int x = arr[arr.Count]; // Lỗi
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bắt được lỗi: {ex.GetType().Name} - {ex.Message}");
            }
        }
    }
}

