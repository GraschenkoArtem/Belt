using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace belt
{
    public partial class Form1 : Form
    {
        Random chislo = new Random();
        int i = 0, j = 0,k;
        decimal delta, N = 1, n1 = 1, D1, Dmin_delta, v, F, sigma0, A, W, D1_delta, C0 = 1, C1, C2, C3, sigma_f_0, sigma_f, b;
        decimal[,] param = new decimal[5, 17];
        string[] param_w = new string[17] { "N", "n1", "Dmin/delta", "Delta", "D1", "v", "F", "sigma0", "C0", "C1", "C2", "C3", "A", "w", "sigma_f", "sigma_f_0", "b"};

    DataTable tabel1;

        void param_ch()
        {
            string q = listBox1.Text;
            for(int j = 0;j<17; j++)
            {
                if (param_w[j] == q)
                    k = j;
            }
        }

        void less()
        {
            param_ch();
            decimal number = Convert.ToDecimal(textBox1.Text);
            int n = i;
            for(int q =0; q < 5; q++)
                dataGridView1.Rows[q].DefaultCellStyle.BackColor = Color.White;
            for(int q =0; q < n; q++)
            {
                if (param[q,k]<number)
                    dataGridView1.Rows[q].DefaultCellStyle.BackColor = Color.Red;
            }     
        }

        void more()
        {
            param_ch();
            decimal number = Convert.ToDecimal(textBox1.Text);
            int n = i;
            for (int q = 0; q < 5; q++)
                dataGridView1.Rows[q].DefaultCellStyle.BackColor = Color.White;
            for (int q = 0; q < n; q++)
            {
                if (param[q, k] > number)
                    dataGridView1.Rows[q].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        void equal()
        {
            param_ch();
            decimal number = Convert.ToDecimal(textBox1.Text);
            int n = i;
            for (int q = 0; q < 5; q++)
                dataGridView1.Rows[q].DefaultCellStyle.BackColor = Color.White;
            for (int q = 0; q < n; q++)
            {
                if (param[q, k] == number)
                    dataGridView1.Rows[q].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        void less_or_equal()
        {
            param_ch();
            decimal number = Convert.ToDecimal(textBox1.Text);
            int n = i;
            for (int q = 0; q < 5; q++)
                dataGridView1.Rows[q].DefaultCellStyle.BackColor = Color.White;
            for (int q = 0; q < n; q++)
            {
                if (param[q, k] <= number)
                    dataGridView1.Rows[q].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        void more_or_equal()
        {
            param_ch();
            decimal number = Convert.ToDecimal(textBox1.Text);
            int n = i;
            for (int q = 0; q < 5; q++)
                dataGridView1.Rows[q].DefaultCellStyle.BackColor = Color.White;
            for (int q = 0; q < n; q++)
            {
                if (param[q, k] >= number)
                    dataGridView1.Rows[q].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        void All_Round()
        {
            for(int j = 0; j <= 16; j++)
                param[i, j] = Convert.ToDecimal(Math.Round(Convert.ToDouble(param[i,j]), 2));
        }

        void Final_count()
        {
            Delta();
            F_();
            Sigma0();
            C_0();
            C_1();
            C_2();
            C_3();
            A_W();
            sigma_f = sigma_f_0 * C0 * C1 * C2 * C3;
            b = F / (delta * sigma_f);
        }

        void C_0()
        {
            if (radioButton1.Checked)
            {
                if (radioButton7.Checked)
                    C0 = 1.0m;
                if (radioButton8.Checked)
                    C0 = 0.9m;
                if (radioButton9.Checked)
                    C0 = 0.8m;
            }
            else
                C0 = 1;

        }
        
        void InitTabel()
        {
            tabel1 = new DataTable();
            DataColumn x = tabel1.Columns.Add("№", typeof(string));
            DataColumn x1 = tabel1.Columns.Add("N", typeof(string));
            DataColumn x2 = tabel1.Columns.Add("n1", typeof(string));
            DataColumn x3 = tabel1.Columns.Add("Dmin/delta", typeof(string));
            DataColumn x4 = tabel1.Columns.Add("Delta", typeof(string));
            DataColumn x5 = tabel1.Columns.Add("D1", typeof(string));
            DataColumn x6 = tabel1.Columns.Add("v", typeof(string));
            DataColumn x7 = tabel1.Columns.Add("F", typeof(string));
            DataColumn x8 = tabel1.Columns.Add("sigma0", typeof(string));
            DataColumn x9 = tabel1.Columns.Add("C0", typeof(string));
            DataColumn x10 = tabel1.Columns.Add("C1", typeof(string));
            DataColumn x11 = tabel1.Columns.Add("C2", typeof(string));
            DataColumn x12 = tabel1.Columns.Add("C3", typeof(string));
            DataColumn x13 = tabel1.Columns.Add("A", typeof(string));
            DataColumn x14 = tabel1.Columns.Add("W", typeof(string));
            DataColumn x15 = tabel1.Columns.Add("sigma_f", typeof(string));
            DataColumn x16 = tabel1.Columns.Add("sigma_f_0", typeof(string));
            DataColumn x17 = tabel1.Columns.Add("b", typeof(string));
            DataRow y = tabel1.NewRow();
            DataRow y0 = tabel1.NewRow();
            DataRow y1 = tabel1.NewRow();
            DataRow y2 = tabel1.NewRow();
            DataRow y3 = tabel1.NewRow();
            tabel1.Rows.Add(y);
            tabel1.Rows.Add(y0);
            tabel1.Rows.Add(y1);
            tabel1.Rows.Add(y2);
            tabel1.Rows.Add(y3);
            tabel1.Rows[0][0] = 1;
            tabel1.Rows[1][0] = 2;
            tabel1.Rows[2][0] = 3;
            tabel1.Rows[3][0] = 4;
            tabel1.Rows[4][0] = 5;
            dataGridView1.DataSource = tabel1;
        }

        void param_fill()
        {
            param[i, 0] = N;
            param[i, 1] = n1;
            param[i, 2] = Dmin_delta;
            param[i, 3] = delta;
            param[i, 4] = D1;
            param[i, 5] = v;
            param[i, 6] = F;
            param[i, 7] = sigma0;
            param[i, 8] = C0;
            param[i, 9] = C1;
            param[i, 10] = C2;
            param[i, 11] = C3;
            param[i, 12] = A;
            param[i, 13] = W;
            param[i, 14] = sigma_f;
            param[i, 15] = sigma_f_0;
            param[i, 16] = b;
            All_Round();
        }

        void A_W()
        {
            if (sigma0 == 1.6m)
            {
                A = 2.3m;
                W = 9.0m;
            }
            if (sigma0 == 1.8m)
            {
                A = 2.5m;
                W = 10.0m;
            }
            if (sigma0 == 2.0m)
            {
                A = 2.7m;
                W = 11.0m;
            }
            if (sigma0 == 2.4m)
            {
                A = 3.05m;
                W = 13.5m;
            }
            if (sigma0 == 4)
            {
                A = 5.75m;
                W = 176m;
            }
            if (sigma0 == 5)
            {
                A = 7.0m;
                W = 220.0m;
            }
            if (sigma0 == 7.5m)
            {
                A = 9.6m;
                W = 330.0m;
            }
            if (sigma0 == 10)
            {
                A = 11.6m;
                W = 440.0m;
            }
            sigma_f_0 = A - ((delta / D1) * W);
        }

        void Sigma0()
        {
            D1_delta = D1 / delta;
            if (radioButton1.Checked)
            {
                if (radioButton3.Checked)
                    sigma0 = 1.6m;
                if (radioButton4.Checked)
                    sigma0 = 1.8m;
                if (radioButton5.Checked)
                    sigma0 = 2.0m;
                if (radioButton6.Checked)
                    sigma0 = 2.4m;
            }
            else
            {
                if (D1_delta <= 80)
                    sigma0 = Convert.ToDecimal(chislo.Next(4, 5));
                if (D1_delta > 80)
                    sigma0 = 7.5m;
                if (D1_delta > 100)
                    sigma0 = 10;
            }
        }

        void C_1()
        {
            if (trackBar1.Value >= 110)
                C1 = 0.79m;
            if (trackBar1.Value >= 120)
                C1 = 0.82m;
            if (trackBar1.Value >= 130)
                C1 = 0.85m;
            if (trackBar1.Value >= 140)
                C1 = 0.88m;
            if (trackBar1.Value >= 150)
                C1 = 0.91m;
            if (trackBar1.Value >= 160)
                C1 = 0.94m;
            if (trackBar1.Value >= 170)
                C1 = 0.97m;
            if (trackBar1.Value == 180)
                C1 = 1.0m;
        }

        void C_2()
        {
            if(radioButton1.Checked)
            {
                if (v <= 5)
                    C2 = 1.03m;
                if (v <= 10)
                    C2 = 1.00m;
                if (v <= 15)
                    C2 = 0.95m;
                if (v <= 20)
                    C2 = 0.88m;
                if (v <= 25)
                    C2 = 0.79m;
                if (v <= 30 || v > 30)
                    C2 = 0.68m;
            }
            else
            {
                if (v <= 5)
                    C2 = 1.01m;
                if (v <= 10)
                    C2 = 1.00m;
                if (v <= 15)
                    C2 = 0.99m;
                if (v <= 20)
                    C2 = 0.97m;
                if (v <= 25)
                    C2 = 0.95m;
                if (v <= 30)
                    C2 = 0.92m;
                if (v <= 35)
                    C2 = 0.89m;
                if (v <= 40)
                    C2 = 0.85m;
                if (v <= 50)
                    C2 = 0.76m;
                if (v <= 70 || v > 70)
                    C2 = 0.52m;
            }
        }

        void C_3()
        {
            if(radioButton10.Checked)
                C3 = 1.0m;
            if (radioButton11.Checked)
                C3 = 0.9m;
            if (radioButton12.Checked)
                C3 = 0.9m;
            if (radioButton13.Checked)
                C3 = 0.8m;
            if (radioButton14.Checked)
                C3 = 0.8m;
            if (radioButton15.Checked)
                C3 = 0.7m;
            if (radioButton16.Checked)
                C3 = 0.7m;
            if (radioButton17.Checked)
                C3 = 0.5m;
        }

        void Delta()
        {
            if (radioButton1.Checked)
                Dmin_delta = 40;
            else
                Dmin_delta = Convert.ToDecimal(chislo.Next(100, 150));
            N = Convert.ToDecimal(Moshnost_znachenie.Text);
            n1 = Convert.ToDecimal(Shkiv_znachenie.Text);
            D1  = N * 1000;
            D1 = D1 / n1;
            D1 = Convert.ToDecimal(Math.Pow(Convert.ToDouble(D1),1.0/3));
            D1 = 120 * D1;
            delta = D1 / Dmin_delta;
        }

        void F_()
        {
            v = 3.14m * D1 * n1 / (60000);
            F = N / v;
            F = F * 1000;
        }

        void dobav()
        {
            for (j = 1; j <= 16; j++)
            {
                tabel1.Rows[i][j] = param[i,j-1];
            }
            tabel1.Rows[i][17] = param[i, 16];
        }

        void sint()
        {
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitTabel();
            listBox1.DataSource = param_w;
        }

        private void moshnost_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Moshnost_znachenie_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        
        private void Shkiv_Click(object sender, EventArgs e)
        {

        }

        private void Shkiv_znachenie_TextChanged(object sender, EventArgs e)
        {

        }

        private void Material_remnua_Enter(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Угол обхвата = " + trackBar1.Value;
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
   
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            Final_count();            
            if (i <= 4)
            {
                param_fill();
                All_Round();
                dobav();
                if (i == 4)
                    button1.Enabled = false;
                i++;
            }
            button2.Enabled = true;
            button5.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("save_1.txt");
            int n = i;
            for (int q = 0; q < n; q++)
            {
                sw.WriteLine("Расчет №" + (q + 1));
                for (j = 0; j <= 16; j++)
                    sw.WriteLine(param_w[j] + " = " + param[q, j]);
                sw.WriteLine();
            }
            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton18.Checked)
                less();
            if (radioButton19.Checked)
                more();
            if (radioButton20.Checked)
                equal();
            if (radioButton21.Checked)
                less_or_equal();
            if (radioButton22.Checked)
                more_or_equal();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            for (int q = 0; q < 5; q++)
                dataGridView1.Rows[q].DefaultCellStyle.BackColor = Color.White;
            radioButton18.Checked = false;
            radioButton19.Checked = false;
            radioButton20.Checked = false;
            radioButton21.Checked = false;
            radioButton22.Checked = false;
            textBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int q = 0; q < 5; q++)
                dataGridView1.Rows[q].DefaultCellStyle.BackColor = Color.White;
            i--;
            for (j = 1; j <= 16; j++)
            {
                tabel1.Rows[i][j] = " ";
            }
            tabel1.Rows[i][17] = " ";
            button1.Enabled = true;
            if(i==0)
                button5.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("save_2.txt");
            int n = i;
            for (int q = 0; q < n; q++)
            {
                if (dataGridView1.Rows[q].DefaultCellStyle.BackColor == Color.Red)
                {
                    sw.WriteLine("Расчет №" + (q + 1));
                    for (j = 0; j <= 16; j++)
                        sw.WriteLine(param_w[j] + " = " + param[q, j]);
                    sw.WriteLine();
                }
            }
            sw.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            trackBar1.Visible = false;
            label1.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            trackBar1.Visible = true;
            label1.Visible = true;
            groupBox3.Visible = true;
            sint();
            groupBox2.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            trackBar1.Visible = true;
            label1.Visible = true;
        }
               
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            trackBar1.Visible = true;
            label1.Visible = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            trackBar1.Visible = true;
            label1.Visible = true;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            trackBar1.Visible = true;
            label1.Visible = true;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
        
        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
