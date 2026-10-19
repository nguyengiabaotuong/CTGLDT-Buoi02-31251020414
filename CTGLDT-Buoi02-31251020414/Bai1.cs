using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
internal class Btapbuoi2
{
    static void Main1()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        //Nhập phần tử n và n phần tử
        Console.Write("Nhập số phần tử của mảng(1<=n<=100000): ");
        int n = int.Parse(Console.ReadLine());
        if (n < 1 || n > 100000)
            return;
        int[] arr = new int[n];
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"Số nguyên thứ {i + 1}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }
        thongke(arr);
        daomang(arr);
    }
    static void daomang(int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;
        while (left < right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            left++;
            right--;
        }
        for (int i = 0; i < arr.Length; i++)
            Console.Write($"{arr[i]} ");
        Console.WriteLine();
    }
    static void thongke(int [] arr)
    {
        long sum = 0;
        int min = arr[0];
        int max = arr[0];
        int countPos = 0, countNeg = 0, countZero = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
            if (arr[i] < min) min = arr[i];
            if (arr[i] > max) max = arr[i];
            if (arr[i] > 0) countPos++;
            else if (arr[i] < 0) countNeg++;
            else countZero++;
        }
        double average = (double)sum / arr.Length;
        Console.WriteLine($"Tong: {sum}");
        Console.WriteLine($"Min: {min}, Max: {max}");
        Console.WriteLine($"Trung binh: {average:F2}");
        Console.WriteLine($"So phan tu am: {countNeg}, So phan tu duong: {countPos}, So phan tu 0: {countZero}");
    }
}