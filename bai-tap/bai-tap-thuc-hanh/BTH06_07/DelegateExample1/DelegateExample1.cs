using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate
{
    /*
     * Khai báo uỷ nhiệm phương thức Calculation()
     * cho phép tham chiếu đến tất cả các phương thức
     * có cùng kiểu dữ liệu trả về và danh sách tham số
     */
    public delegate int Calculation(int a, int b);

    class DelegateExample1
    {
        /* 
         * Đối tương của delegate Calculation được tạo ra
         * và tham chiếu đến phương thức Add()
         */
        static int Add(int a, int b)
        {
            return a + b;
        }

        /* 
         * Đối tương của delegate Calculation được tạo ra
         * và tham chiếu đến phương thức Sub()
         */
        static int Sub(int a, int b)
        {
            return a - b;
        }

        /*
         * Sử dụng delegate để truyền phương thức Calculation() vào
         * và xem phương thức Calculation() như là tham số
         * của phương thức Calculate()
         * 
         * Phương thức Calculate() có hai tham số kiểu int
         * và một tham số thuộc kiểu delegate Calculation
         */
        static int Calculate(int a, int b, Calculation cal)
        {
            return cal(a, b);
        }

        static void Main(string[] args)
        {
            // Truyền vào tham số a, b và phương thức Add()
            int c = Calculate(9, 4, Add);
            Console.WriteLine("9 + 4 = " + c);

            // Truyền vào tham số a, b và phương thức Sub()
            int d = Calculate(9, 4, Sub);
            Console.WriteLine("9 - 4 = " + d);

            Console.ReadLine();
        }
    }
}
