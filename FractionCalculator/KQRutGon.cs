using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FractionCalculator.KQRutGon;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace FractionCalculator
{
    public partial class KQRutGon : Form
    {
        private List<Fraction> results = new List<Fraction>();

        public KQRutGon()
        {
            InitializeComponent();
        }
        public static string a;
        public static string b;
        public static int fnumber;
        private List<int> FindCommonDivisors(Fraction fraction)
        {
            List<int> divisors = new List<int>();

            int gcd = CalculateGCD(Math.Abs(fraction.Numerator), Math.Abs(fraction.Denominator));

            for (int i = 2; i <= gcd; i++)
            {
                if (gcd % i == 0)
                {
                    divisors.Add(i);
                }
            }

            return divisors;
        }

        private int CalculateGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private void UpdateDataGridView()
        {
            dtgvKQ.Rows.Clear();
            foreach (var fraction in results)
            {
                if (fraction.Numerator == fraction.Denominator)
                {
                    dtgvKQ.Rows.Add("1");
                    break;
                }
                // nếu mẫu bằng 1 thì in ra tử 
                else if (fraction.Denominator == 1)
                {
                    string formattedFraction1 = fraction.Numerator + "";
                    dtgvKQ.Rows.Add(formattedFraction1);
                    break;
                }
                // nếu tử số = mẫu * -1 thì in ra -1
                else if (fraction.Numerator == -1 * (fraction.Denominator))
                {
                    dtgvKQ.Rows.Add("-1");
                    break;
                }
                else
                {
                    string formattedFraction = fraction.Numerator + "/" + fraction.Denominator;
                    dtgvKQ.Rows.Add(formattedFraction);
                }
            }
        }

        public void RGClick()
        {
            if (int.TryParse(a, out int numerator) && int.TryParse(b, out int denominator))
            {
                // Đảo ngược dấu của tử số và mẫu số nếu mẫu số là số âm
                if (denominator < 0)
                {
                    numerator = -numerator;
                    denominator = -denominator;
                }

                if (numerator == denominator)
                {
                    if (numerator < 0)
                    {
                        // Nếu tử số và mẫu số bằng nhau và là số âm, in ra -1
                        results.Clear();
                        results.Add(new Fraction(-1, 1));
                    }
                    else
                    {
                        // Nếu tử số và mẫu số bằng nhau và không là số âm, in ra 1
                        results.Clear();
                        results.Add(new Fraction(1, 1));
                    }
                }
                else
                {
                    Fraction inputFraction = new Fraction(numerator, denominator);
                    results.Clear(); // Xóa kết quả cũ

                    List<int> commonDivisors = FindCommonDivisors(inputFraction);

                    if (commonDivisors.Count > 0)
                    {
                        foreach (int divisor in commonDivisors)
                        {
                            // In ra các kết quả rút gọn khi chia cho ước chung
                            Fraction simplifiedFraction = new Fraction(numerator / divisor, denominator / divisor);
                            results.Add(simplifiedFraction);
                        }
                    }
                    else
                    {
                        // Nếu không có số tối giản, thì in ra phân số nhập vào ban đầu
                        results.Add(inputFraction);
                    }
                }
                UpdateDataGridView();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một phân số hợp lệ.");
            }
        }

        public class Fraction
        {
            public int Numerator { get; set; }
            public int Denominator { get; set; }

            public Fraction(int numerator, int denominator)
            {
                if (denominator < 0)
                {
                    numerator = -numerator;
                    denominator = -denominator;
                }

                Numerator = numerator;
                Denominator = denominator;
            }

        }

        private void dtgvKQ_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string kq = dtgvKQ.CurrentRow.Cells[0].Value.ToString();
            char delimiter = '/'; // Ký tự phân cách
            
            Home form1 = new Home();
            string[] substrings = kq.Split(delimiter);

            if (substrings.Length == 1)
                form1.SetFraction(fnumber, substrings[0], "1");
            else
                form1.SetFraction(fnumber, substrings[0], substrings[1]);
            form1.Show();
        }
    }
}