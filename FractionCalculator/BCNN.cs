using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculator
{
    internal class BCNN
    {
        UCLN UCLN = new UCLN();

        // Tìm BCNN bằng vòng lặp
        public int BCNN_For(int a, int b)
        {
            int i, max, BCNN = 1;
            max = (a > b) ? a : b;
            for (i = max; ; i += max)
            {
                if (i % a == 0 && i % b == 0)
                {
                    BCNN = i;
                    break;
                }
            }
            return BCNN;
        }

        // Tìm BCNN bằng UCLN
        public int BCNN_UCLN(int a, int b)
        {
            return a * b / UCLN.UCLN_Sub(a,b);
        }
    }
}
