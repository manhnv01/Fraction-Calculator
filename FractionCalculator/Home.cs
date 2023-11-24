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
            label2.Visible = false;
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
            panel.Visible = false;

            // Lấy giá trị 2 phân số nhập vào
            string sts1 = txtTS1.Text.ToString();
            string sms1 = txtMS1.Text.ToString();
            string sts2 = txtTS2.Text.ToString();
            string sms2 = txtMS2.Text.ToString();

            if (sts1 == "" || sts2 == "" || sms1 == "" || sms2 == "")
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    int ts1 = int.Parse(sts1);
                    int ms1 = int.Parse(sms1);
                    int ts2 = int.Parse(sts2);
                    int ms2 = int.Parse(sms2);
                    if (ms1 < 0)
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
                        MessageBox.Show("Mẫu số phải khác 0 !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        if (ms1 == ms2 || ts1 == 0 || ts2 == 0)
                            MessageBox.Show("Hai phân số đã được quy đồng hoặc tồn tại phân số = 0 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            int bcnn = BCNN.BCNN_For(Math.Abs(ms1), Math.Abs(ms2));
                            int tsp1 = bcnn / ms1;
                            int tsp2 = bcnn / ms2;

                            if (ms1 != ms2)
                            {
                                string[] rowValuesTS = new string[] { "", ts1.ToString(), "", (ts1 * tsp1).ToString(), "", ts2.ToString(), "", (ts2 * tsp2).ToString() };
                                string[] bracket = new string[] { "", "--------", "=", "--------", "và", "--------", "=", "--------" };
                                string[] rowValuesMS = new string[] { "", ms1.ToString(), "", (ms1 * tsp1).ToString(), "", ms2.ToString(), "", (ms2 * tsp2).ToString() };

                                // Thêm dòng mới vào DataGridView tại vị trí 0 (lên đầu)
                                dgvHistory.Rows.Insert(0, "Quy đồng");
                                dgvHistory.Rows.Insert(1, rowValuesTS);
                                dgvHistory.Rows.Insert(2, bracket);
                                dgvHistory.Rows.Insert(3, rowValuesMS);
                                dgvHistory.Rows.Insert(4, "");
                            }
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Không phải là số !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            panel.Visible = false;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            Home_Load(sender, e);
            panel.Visible = false;
            // Lấy giá trị 2 phân số nhập vào
            string sts1 = txtTS1.Text.ToString();
            string sms1 = txtMS1.Text.ToString();
            string sts2 = txtTS2.Text.ToString();
            string sms2 = txtMS2.Text.ToString();

            if (sts1 == "" || sts2 == "" || sms1 == "" || sms2 == "")
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    int ts1 = int.Parse(sts1);
                    int ms1 = int.Parse(sms1);
                    int ts2 = int.Parse(sts2);
                    int ms2 = int.Parse(sms2);

                    // Gán trả giá trị ban đầu của 2 phân số
                    int its1 = ts1;
                    int ims1 = ms1;

                    int its2 = ts2;
                    int ims2 = ms2;
                Compare:

                    if (ms1 < 0)
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
                        MessageBox.Show("Mẫu số phải khác 0 !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        string point = "";
                        if ((ts1 == ts2 && ms1 == ms2) || (ts1 == 0 && ts2 == 0))
                        {
                            point = "=";
                            MessageBox.Show("Hai phân số bằng nhau !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (ts1 == ts2)
                        {
                            if (ts1 > 0)
                            {
                                if (ms1 > ms2)
                                {
                                    point = "<";
                                    MessageBox.Show("Phân số 1 < Phân số 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    point = ">";
                                    MessageBox.Show("Phân số 1 > Phân số 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                if (ms1 > ms2)
                                {
                                    point = ">";
                                    MessageBox.Show("Phân số 1 > Phân số 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    point = "<";
                                    MessageBox.Show("Phân số 1 < Phân số 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else if (ms1 == ms2)
                        {
                            if (ts1 > ts2)
                            {
                                point = ">";
                                MessageBox.Show("Phân số 1 > Phân số 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                point = "<";
                                MessageBox.Show("Phân số 1 < Phân số 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            int bcnn = BCNN.BCNN_For(Math.Abs(ms1), Math.Abs(ms2));
                            int tsp1 = bcnn / ms1;
                            int tsp2 = bcnn / ms2;

                            // Quy đồng để so sánh
                            ts1 = ts1 * tsp1;
                            ms1 = ms1 * tsp1;

                            ts2 = ts2 * tsp2;
                            ms2 = ms2 * tsp2;
                            goto Compare; // Nhảy nhãn lên trên
                        }

                        string[] rowValuesTS = new string[] { "", "", "", "", "", its1.ToString(), "", its2.ToString() };
                        string[] bracket = new string[] { "", "", "", "", "", "--------", point, "--------" };
                        string[] rowValuesMS = new string[] { "", "", "", "", "", ims1.ToString(), "", ims2.ToString() };

                        // Thêm dòng mới vào DataGridView tại vị trí 0 (lên đầu)
                        dgvHistory.Rows.Insert(0, "So sánh");
                        dgvHistory.Rows.Insert(1, rowValuesTS);
                        dgvHistory.Rows.Insert(2, bracket);
                        dgvHistory.Rows.Insert(3, rowValuesMS);
                        dgvHistory.Rows.Insert(4, "");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Không phải là số !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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
            label2.Visible = false;
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
            panel2.Visible = true;
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
                try
                {
                    int ts1 = int.Parse(sts1);
                    int ms1 = int.Parse(sms1);
                    int ts2 = int.Parse(sts2);
                    int ms2 = int.Parse(sms2);

                    if (number == 4 && ts2 == 0)
                    {
                        panel.Visible = false;
                        MessageBox.Show("Không thể chia cho 0 !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (ms1 < 0)
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
                                        c.Text = tskq.ToString();
                                        d.Text = mskq.ToString();
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
                                        c.Text = (ts1 * tsp1).ToString() + " + " + (ts2 * tsp2).ToString();
                                        d.Text = mskq.ToString();
                                        g.Text = tskq.ToString();
                                        h.Text = mskq.ToString();
                                        panel1.Visible = true;
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
                                        c.Text = tskq.ToString();
                                        d.Text = mskq.ToString();
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
                                        c.Text = (ts1 * tsp1).ToString() + " - " + (ts2 * tsp2).ToString();
                                        d.Text = mskq.ToString();
                                        g.Text = tskq.ToString();
                                        h.Text = mskq.ToString();
                                        panel1.Visible = true;
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
                                    c.Text = tskq.ToString();
                                    d.Text = mskq.ToString();
                                    break;
                                default: // Phép chia
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
                                    c.Text = tskq.ToString();
                                    d.Text = mskq.ToString();
                                    break;
                            }
                            string[] rowHeader = new string[] { cal };
                            string[] rowValuesTS = new string[] { "", "", "", ts1.ToString(), "", ts2.ToString(), "", tskq.ToString() };
                            string[] bracket = new string[] { "", "", "", "--------", point, "--------", "=", "--------" };
                            string[] rowValuesMS = new string[] { "", "", "", ms1.ToString(), "", ms2.ToString(), "", mskq.ToString() };
                            string[] rowValuesNone = new string[] { "" };
                            panel.Visible = true;
                            int ucln = UCLN.UCLN_Sub(Math.Abs(tskq), Math.Abs(mskq));

                            if (ucln > 1 && (tskq % mskq) != 0)
                            {
                                int tsrg = tskq / ucln;
                                int msrg = mskq / ucln;

                                g.Text = tsrg.ToString();
                                h.Text = msrg.ToString();
                                panel1.Visible = true;

                                rowValuesTS = new string[] { "", "", "", ts1.ToString(), "", ts2.ToString(), "", tsrg.ToString() };
                                rowValuesMS = new string[] { "", "", "", ms1.ToString(), "", ms2.ToString(), "", msrg.ToString() };
                            }
                            if (tskq % mskq == 0)
                            {
                                if (ms1 == ms2 || number > 2)
                                {
                                    label2.Visible = true;
                                    g.Text = (tskq / mskq).ToString();
                                }
                                else
                                {
                                    up.Visible = true;
                                    j.Text = (tskq / mskq).ToString();
                                }
                                rowValuesTS = new string[] { "", "", "", ts1.ToString(), "", ts2.ToString(), "" };
                                bracket = new string[] { "", "", "", "--------", point, "--------", "=", (tskq / mskq).ToString() };
                                rowValuesMS = new string[] { "", "", "", ms1.ToString(), "", ms2.ToString(), "" };
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
                catch (FormatException)
                {
                    panel.Visible = false;
                    MessageBox.Show("Không phải là số !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private string Bracket(int number)
        {
            if (number < 0)
            {
                return "(" + number + ")";
            }
            else
                return number.ToString();
        }

        private void btnTG1_Click(object sender, EventArgs e)
        {
            Home_Load(sender, e);
            ToiGian(1);
        }

        private void btnTG2_Click(object sender, EventArgs e)
        {
            Home_Load(sender, e);
            ToiGian(2);
        }

        private void ToiGian(int number)
        {
            panel.Visible = true;
            string sts = "";
            string sms = "";
            if (number == 1)
            {
                // Lấy giá trị nhập vào
                sts = txtTS1.Text.ToString();
                sms = txtMS1.Text.ToString();
            }
            else
            {
                // Lấy giá trị nhập vào
                sts = txtTS2.Text.ToString();
                sms = txtMS2.Text.ToString();
            }

            if (sts == "" || sms == "")
            {
                MessageBox.Show("Vui lòng nhập phân số 1 !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int ts = int.Parse(sts);
                    int ms = int.Parse(sms);
                    int ucln = UCLN.UCLN_Sub(Math.Abs(ts), Math.Abs(ms));

                    a.Text = "UCLN = " + ucln.ToString();
                    panel2.Visible = false;

                    if (ms == 0)
                        MessageBox.Show("Mẫu số phải khác 0 !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (ucln == 1 && (ts % ms) != 0)
                    {
                        panel.Visible = false;
                        panel1.Visible = false;
                        MessageBox.Show("Phân số đã tối giản !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int tsrg = ts / ucln;
                        int msrg = ms / ucln;

                        panel1.Visible = true;
                        c.Text = Bracket(ts) + " : " + ucln;
                        d.Text = Bracket(ms) + " : " + ucln;
                        g.Text = tsrg.ToString();
                        h.Text = msrg.ToString();

                        if (msrg < 0)
                        {
                            tsrg = -tsrg;
                            msrg = -msrg;
                        }

                        string[] rowValuesTS = new string[] { "", "", "", "", "", ts.ToString(), "", tsrg.ToString() };
                        string[] bracket = new string[] { "", "", "", "", "", "--------", "=", "--------" };
                        string[] rowValuesMS = new string[] { "", "", "", "", "", ms.ToString(), "", msrg.ToString() };

                        if (tsrg % msrg == 0)
                        {
                            up.Visible = true;
                            j.Text = (tsrg / msrg).ToString();
                            rowValuesTS = new string[] { "", "", "", "", "", ts.ToString(), "", "" };
                            bracket = new string[] { "", "", "", "", "", "--------", "=", (tsrg / msrg).ToString() };
                            rowValuesMS = new string[] { "", "", "", "", "", ms.ToString(), "", "" };
                        }

                        // Thêm dòng mới vào DataGridView tại vị trí 0 (lên đầu)
                        dgvHistory.Rows.Insert(0, "Tối giản PS" + number);
                        dgvHistory.Rows.Insert(1, rowValuesTS);
                        dgvHistory.Rows.Insert(2, bracket);
                        dgvHistory.Rows.Insert(3, rowValuesMS);
                        dgvHistory.Rows.Insert(4, "");

                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Không phải là số !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnRG1_Click(object sender, EventArgs e)
        {
            Home_Load(sender, e);
            RutGon(1);
            panel.Visible = false;
        }

        private void btnRG2_Click(object sender, EventArgs e)
        {
            Home_Load(sender, e);
            RutGon(2);
            panel.Visible = false;
        }

        private void RutGon(int number)
        {
            panel.Visible = false;

            string sts = "";
            string sms = "";
            if (number == 1)
            {
                // Lấy giá trị nhập vào
                sts = txtTS1.Text.ToString();
                sms = txtMS1.Text.ToString();
            }
            else
            {
                // Lấy giá trị nhập vào
                sts = txtTS2.Text.ToString();
                sms = txtMS2.Text.ToString();
            }

            if (sts == "" || sms == "")
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    int ts = int.Parse(sts);
                    int ms = int.Parse(sms);

                    if (ms < 0)
                    {
                        ts = -ts;
                        ms = -ms;
                    }

                    if (ms == 0)
                        MessageBox.Show("Mẫu số phải khác 0 !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        int ucln = UCLN.UCLN_Sub(Math.Abs(ts), Math.Abs(ms));
                        if (ucln == 1)
                            MessageBox.Show("Phân số đã tối giản không thể rút gọn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            KQRutGon.a = sts;
                            KQRutGon.b = sms;
                            KQRutGon.fnumber = number;
                            KQRutGon form2 = new KQRutGon();
                            form2.RGClick();
                            form2.ShowDialog();
                        }
                    }
                }
                catch (FormatException)
                {
                    panel.Visible = false;
                    MessageBox.Show("Không phải là số !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void SetFraction(int number, string ts, string ms)
        {
            if (number == 1)
            {
                txtTS1.Text = ts;
                txtMS1.Text = ms;
            }
            else
            {
                txtTS2.Text = ts;
                txtMS2.Text = ms;
            }
        }

        private void txtMS1_TextChanged(object sender, EventArgs e)
        {
            string sms1 = txtMS1.Text.ToString();
            try
            {
                int ms1 = int.Parse(sms1);
                if (sms1 == "")
                {
                    errorProvider1.SetError(txtMS1, "Hãy nhập mẫu số phân số 1");
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ms1 == 0)
                {
                    errorProvider1.SetError(txtMS1, "Mẫu số phải khác 0");
                    MessageBox.Show("Mẫu số phải khác 0", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    errorProvider1.SetError(txtMS1, "");
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtMS1, "Không phải là số!");
                MessageBox.Show("Không phải là số!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void txtMS2_TextChanged(object sender, EventArgs e)
        {
            string sms2 = txtMS2.Text.ToString();
            try
            {
                int ms2 = int.Parse(sms2);
                if (sms2 == "")
                {
                    errorProvider1.SetError(txtMS2, "Hãy nhập mẫu số phân số 2");
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ms2 == 0)
                {
                    errorProvider1.SetError(txtMS2, "Mẫu số phải khác 0");
                    MessageBox.Show("Mẫu số phải khác 0", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    errorProvider1.SetError(txtMS2, "");
                }
            }
            catch(Exception ex)
            {
                errorProvider1.SetError(txtMS2, "Không phải là số!");
                MessageBox.Show("Không phải là số!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void txtTS1_TextChanged(object sender, EventArgs e)
        {
            string sts1 = txtTS1.Text.ToString();
            try
            {
                int ts1 = int.Parse(sts1);
                if (sts1 == "")
                {
                    errorProvider1.SetError(txtTS1, "Hãy nhập tử số phân số 1");
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    errorProvider1.SetError(txtTS1, "");
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtTS1, "Không phải là số!");
                MessageBox.Show("Không phải là số!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void txtTS2_TextChanged(object sender, EventArgs e)
        {
            string sts2 = txtTS2.Text.ToString();
            try
            {
                int ts1 = int.Parse(sts2);
                if (sts2 == "")
                {
                    errorProvider1.SetError(txtTS2, "Hãy nhập tử số phân số 2");
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    errorProvider1.SetError(txtTS2, "");
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtTS2, "Không phải là số!");
                MessageBox.Show("Không phải là số!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
