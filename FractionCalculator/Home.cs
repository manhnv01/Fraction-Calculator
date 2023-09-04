using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractionCalculator
{
    public partial class Home : Form
    {
        UCLN UCLN = new UCLN();
        BCNN BCNN = new BCNN();
        public Home()
        {
            InitializeComponent();

        }
        private void btnReverse_Click(object sender, EventArgs e)
        {
            string tmp = txtTS1.Text.ToString();
            txtTS1.Text = txtTS2.Text.ToString();
            txtTS2.Text = tmp;
            tmp = txtMS1.Text.ToString();
            txtMS1.Text = txtMS2.Text.ToString();
            txtMS2.Text = tmp;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Home_Load(sender, e);
            panel.Visible = false;
            txtTS1.Text = string.Empty;
            txtTS2.Text = string.Empty;
            txtMS1.Text = string.Empty;
            txtMS2.Text = string.Empty;
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            Home_Load(sender, e);
            Calculate(1); // Phép cộng (1)
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            Home_Load(sender, e);
            Calculate(2); // Phép trừ (2)
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            Home_Load(sender, e);
            Calculate(3); // Phép nhân (4)
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            Home_Load(sender, e);
            Calculate(4); // Phép chia (4)
        }
        private void btnCommon_Click(object sender, EventArgs e)
        {
            Home_Load(sender, e);
            Calculate(5); // Phép quy đồng (5)
            panel.Visible = false;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            Home_Load(sender, e);
            Calculate(6); // Phép quy đồng (5)
            panel.Visible = false;
        }

        private void txtTS1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Các phím được nhập là phím điều khiển, phím số và dấu -
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // Đảm bảo dấu - chỉ được nhập đầu tiên và chỉ nhập 1 lần
            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
            {
                e.Handled = true;
            }
        }

        private void txtMS1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Các phím được nhập là phím điều khiển, phím số và dấu -
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // Đảm bảo dấu - chỉ được nhập đầu tiên và chỉ nhập 1 lần
            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
            {
                e.Handled = true;
            }
        }

        private void txtTS2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Các phím được nhập là phím điều khiển, phím số và dấu -
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // Đảm bảo dấu - chỉ được nhập đầu tiên và chỉ nhập 1 lần
            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
            {
                e.Handled = true;
            }
        }

        private void txtMS2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Các phím được nhập là phím điều khiển, phím số và dấu -
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // Đảm bảo dấu - chỉ được nhập đầu tiên và chỉ nhập 1 lần
            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
            {
                e.Handled = true;
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            up.Visible = false;
            a.Text = string.Empty;
            b.Text = string.Empty;
            c.Text = string.Empty;
            d.Text = string.Empty;
            g.Text = string.Empty;
            h.Text = string.Empty;
            j.Text = string.Empty;
        }

        private void Calculate(int number)
        {
            panel.Visible = true;
            // Lấy giá trị 2 phân số nhập vào
            string sts1 = txtTS1.Text.ToString();
            string sms1 = txtMS1.Text.ToString();
            string sts2 = txtTS2.Text.ToString();
            string sms2 = txtMS2.Text.ToString();

            if (sts1 == "" || sts2 == "" || sms1 == "" || sms2 == "")
            {
                panel.Visible = false;
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int ts1 = int.Parse(sts1);
                int ms1 = int.Parse(sms1);
                int ts2 = int.Parse(sts2);
                int ms2 = int.Parse(sms2);

                if(ms1 < 0)
                {
                    ts1 = -ts1;
                    ms1 = -ms1;
                }
                if (ms2 < 0)
                {
                    ts2 = -ts2;
                    ms2 = -ms2;
                }

                if (ms1 == 0 || ms2 == 0)
                {
                    panel.Visible = false;
                    MessageBox.Show("Mẫu số phải khác 0 !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int tskq = 1;
                    int mskq = 1;
                    string point = "+";
                    string cal = "Tính tổng";
                    switch (number)
                    {
                        case 1: // Phép cộng
                            point = "+";
                            cal = "Tính tổng";
                            if (ms1 == ms2)
                            {
                                // Tính toán
                                tskq = ts1 + ts2;
                                mskq = ms1;
                                a.Text = Bracket(ts1) + " + " + Bracket(ts2);
                                b.Text = ms1.ToString();
                            }
                            else
                            {
                                int bcnn = BCNN.BCNN_For(Math.Abs(ms1), Math.Abs(ms2));
                                int tsp1 = bcnn / ms1;
                                int tsp2 = bcnn / ms2;

                                tskq = (ts1 * tsp1) + (ts2 * tsp2);
                                mskq = bcnn;

                                // Gán giá trị cách tính 
                                a.Text = Bracket(ts1) + " * " + tsp1 + " + " + Bracket(ts2) + " * " + tsp2;
                                b.Text = bcnn.ToString();
                            }
                            break;
                        case 2: // Phép trừ
                            point = "-";
                            cal = "Tính hiệu";
                            if (ms1 == ms2)
                            {
                                // Tính toán
                                tskq = ts1 - ts2;
                                mskq = ms1;
                                a.Text = Bracket(ts1) + " - " + Bracket(ts2);
                                b.Text = ms1.ToString();
                            }
                            else
                            {
                                int bcnn = BCNN.BCNN_For(Math.Abs(ms1), Math.Abs(ms2));
                                int tsp1 = bcnn / ms1;
                                int tsp2 = bcnn / ms2;

                                tskq = (ts1 * tsp1) - (ts2 * tsp2);
                                mskq = bcnn;

                                // Gán giá trị cách tính 
                                a.Text = Bracket(ts1) + " * " + tsp1 + " - " + Bracket(ts2) + " * " + tsp2;
                                b.Text = bcnn.ToString();
                            }
                            break;
                        case 3: // Phép nhân
                            point = "*";
                            cal = "Tính tích";
                            tskq = ts1 * ts2;
                            mskq = ms1 * ms2;

                            // Gán giá trị cách tính 
                            a.Text = Bracket(ts1) + " * " + Bracket(ts2);
                            b.Text = Bracket(ms1) + " * " + Bracket(ms2);
                            break;
                        case 4: // Phép chia
                            point = ":";
                            cal = "Tính thương";
                            tskq = ts1 * ms2;
                            mskq = ms1 * ts2;

                            if (mskq < 0)
                            {
                                tskq = -tskq;
                                mskq = -mskq;
                            }

                            // Gán giá trị cách tính 
                            a.Text = Bracket(ts1) + " * " + Bracket(ms2);
                            b.Text = Bracket(ms1) + " * " + Bracket(ts2);
                            break;
                        case 5: // Phép quy đồng
                            if (ms1 == ms2)
                            {
                                panel.Visible = false;
                                MessageBox.Show("Hai phân số đã được quy đồng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                int bcnn = BCNN.BCNN_For(Math.Abs(ms1), Math.Abs(ms2));
                                int tsp1 = bcnn / ms1;
                                int tsp2 = bcnn / ms2;

                                txtTS1.Text = (ts1 * tsp1).ToString();
                                txtMS1.Text = (ms1 * tsp1).ToString();
                                txtTS2.Text = (ts2 * tsp2).ToString();
                                txtMS2.Text = (ms2 * tsp2).ToString();
                            }
                            break;
                        case 6: // Phép so sánh
                            if (ts1 == ts2 && ms1 == ms2)
                            {;
                                point = "=";
                                panel.Visible = false;
                                MessageBox.Show("Hai phân số bằng nhau !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if(ts1 == ts2)
                            {
                                if(ts1 > 0)
                                {
                                    if (ms1 > ms2)
                                    {
                                        point = "<";
                                        panel.Visible = false;
                                        MessageBox.Show("Phân số 1 < Phân số 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        point = ">";
                                        panel.Visible = false;
                                        MessageBox.Show("Phân số 1 > Phân số 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    if (ms1 > ms2)
                                    {
                                        point = ">";
                                        panel.Visible = false;
                                        MessageBox.Show("Phân số 1 > Phân số 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        point = "<";
                                        panel.Visible = false;
                                        MessageBox.Show("Phân số 1 < Phân số 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            else if (ms1 == ms2)
                            {
                                if (ts1 > ts2)
                                {
                                    point = ">";
                                    panel.Visible = false;
                                    MessageBox.Show("Phân số 1 > Phân số 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    point = "<";
                                    panel.Visible = false;
                                    MessageBox.Show("Phân số 1 < Phân số 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                Calculate(5);
                                Calculate(6);
                            }
                            break;
                        default:
                            // Code to execute if expression doesn't match any case
                            break;
                    }
                    string[] rowHeader = new string[] { cal };
                    string[] rowValuesTS = new string[] {"", "","", ts1.ToString(), "", ts2.ToString(), "", tskq.ToString() };
                    string[] bracket = new string[] { "", "", "", "--------", point, "--------", "=", "--------" };
                    string[] rowValuesMS = new string[] { "", "", "", ms1.ToString(), "", ms2.ToString(), "", mskq.ToString() };
                    string[] rowValuesNone = new string[] { "" };
                    panel.Visible = true;
                    c.Text = tskq.ToString();
                    d.Text = mskq.ToString();
                    int ucln = UCLN.UCLN_Sub(Math.Abs(tskq), Math.Abs(mskq));
                    if (ucln > 1)
                    {
                        int tsrg = tskq / ucln;
                        int msrg = mskq / ucln;

                        g.Text = tsrg.ToString();
                        h.Text = msrg.ToString();
                        panel1.Visible = true;

                        rowValuesTS = new string[] { "", "", "", ts1.ToString(), "", ts2.ToString(), "", tsrg.ToString() };
                        rowValuesMS = new string[] { "", "", "", ms1.ToString(), "", ms2.ToString(), "", msrg.ToString() };

                        if (tsrg % msrg == 0)
                        {
                            j.Text = (tsrg / msrg).ToString();
                            up.Visible = true;

                            rowValuesTS = new string[] { "", "", "", ts1.ToString(), "", ts2.ToString(), "" };
                            bracket = new string[] { "", "", "", "--------", point, "--------", "=", (tsrg / msrg).ToString() };
                            rowValuesMS = new string[] { "", "", "", ms1.ToString(), "", ms2.ToString(), "" };
                        }
                    }
                  
                    if(number == 5)
                    {
                        rowHeader = new string[] { "Quy đồng" };
                        rowValuesTS = new string[] { "", ts1.ToString(),  "", txtTS1.Text.ToString(), "", ts2.ToString(), "", txtTS2.Text.ToString() };
                        bracket = new string[] { "", "--------", "=",  "--------", "và", "--------", "=", "--------" };
                        rowValuesMS = new string[] { "", ms1.ToString(), "", txtMS1.Text.ToString(), "", ms2.ToString(), "", txtMS2.Text.ToString() };
                    }
                    if (number == 6)
                    {
                        rowHeader = new string[] { "So sánh" };
                        rowValuesTS = new string[] { "", "", "", "", "", ts1.ToString(), "", ts2.ToString()};
                        bracket = new string[] { "", "", "", "", "", "--------", point, "--------"};
                        rowValuesMS = new string[] { "", "", "", "", "", ms1.ToString(), "", ms2.ToString()};
                    }

                    // Thêm dòng mới vào DataGridView tại vị trí 0 (lên đầu)
                    dgvHistory.Rows.Insert(0, rowHeader);
                    dgvHistory.Rows.Insert(1, rowValuesTS);
                    dgvHistory.Rows.Insert(2, bracket);
                    dgvHistory.Rows.Insert(3, rowValuesMS);
                    dgvHistory.Rows.Insert(4, rowValuesNone);
                }
            }
        }

        private string Bracket(int number)
        {
            if(number < 0)
            {
                return "("+ number + ")";
            }
            else
                return number.ToString();
        }
    }
}
