using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateExample2
{
    /*
     * Khai báo uỷ nhiệm phương thức delCalculation()
     * cho phép tham chiếu đến tất cả các phương thức
     * có cùng kiểu dữ liệu trả về và danh sách tham số
     */
    public delegate int delCalculation(int So1, int So2);

    class DelegateExample2
    {
        /* 
         * Đối tương của delegate Calculation được tạo ra
         * và tham chiếu đến phương thức Cong()
         */
        public int Cong(int So1, int So2)
        {
            return So1 + So2;
        }

        /* 
         * Đối tương của delegate Calculation được tạo ra
         * và tham chiếu đến phương thức Tru()
         */
        public int Tru(int So1, int So2)
        {
            return So1 - So2;
        }

        static void Main(string[] args)
        {
            // Tạo đối tượng objTinhToan từ lớp DelegateExample2
            DelegateExample2 objTinhToan = new DelegateExample2();

            /*
             * Tạo đối tượng objDelCong
             * để delegate cho phương thức Cong()
             */
            delCalculation objDelCong = objTinhToan.Cong;
            int KQ_Cong = objDelCong(10, 5);
            Console.WriteLine("Cong KQ: 10 + 5 = {0}", KQ_Cong);

            /*
             * Tạo đối tượng objDelTru
             * để delegate cho phương thức Tru()
             */
            delCalculation objDelTru = objTinhToan.Tru;
            int KQ_Tru = objDelTru(10, 5);
            Console.WriteLine("Tru KQ: 10 - 5  = {0}", KQ_Tru);

            Console.ReadKey();
        }
    }
}
