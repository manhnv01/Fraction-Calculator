using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculator
{
    internal class UCLN
    {
        // Tìm ước chung lớn nhất bằng phép trừ
        public int UCLN_Sub(int a, int b)
        {
            // Nếu a = 0 => ucln(a,b) = b
            // Nếu b = 0 => ucln(a,b) = a
            if (a == 0 || b == 0)
            {
                return a + b;
            }
            while (a != b)
            {
                if (a > b)
                {
                    a -= b; // a = a - b
                }
                else
                {
                    b -= a;
                }
            }
            return a; // return a or b, bởi vì lúc này a và b bằng nhau
        }

        // Tìm ước chung lớn nhất bằng phép chia
        public int UCLN_Div(int a, int b)
        {
            // Lặp tới khi 1 trong 2 số bằng 0
            while (a * b != 0)
            {
                if (a > b)
                {
                    a %= b; // a = a % b
                }
                else
                {
                    b %= a;
                }
            }
            return a + b; // return a + b, bởi vì lúc này hoặc a hoặc b đã bằng 0.
        }

        // Minh họa thuật toán bằng đệ quy
        public int UCLN_Euclid(int a, int b)
        {
            if (b == 0) return a;
            return UCLN_Euclid(b, a % b);
        }

        //Minh họa thuật toán bằng vòng lặp
        public int UCLN_Euclid_Ext(int a, int b)
        {
            int tmp;
            while (b != 0)
            {
                tmp = a % b;
                a = b;
                b = tmp;
            }
            return a;
        }
    }
}
