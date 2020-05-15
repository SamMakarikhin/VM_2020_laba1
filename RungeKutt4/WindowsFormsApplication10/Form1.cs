using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication10
{
    public partial class Form1 : Form
    {
        double tl;
        double tr;
        double a;
        double eps;
        double h;
        int Nmax;
        double x0;
        double y0;
        List<DataCalc> values;
        Equation exp;
        double[] Ust;
        double[] coefs;

        public Form1()
        {
            InitializeComponent();
            dataGridView2.Columns.Add("№", "№");
            dataGridView2.Columns[0].Width = 60;
            dataGridView2.Columns.Add("t( i )", "t( i )");
            dataGridView2.Columns.Add("x( i )", "x( i )");
            dataGridView2.Columns.Add("y( i )", "y( i )");
            for (int i = 1; i < 4; i++)
            {
                dataGridView2.Columns[i].Width = 150;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != 8) && (e.KeyChar != 45) && (e.KeyChar != 44))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != 8) && (e.KeyChar != 45) && (e.KeyChar != 44))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != 8) && (e.KeyChar != 45) && (e.KeyChar != 44))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != 8) && (e.KeyChar != 45) && (e.KeyChar != 44))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != 8) && (e.KeyChar != 44) && (e.KeyChar != 45))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != 8) && (e.KeyChar != 44) && (e.KeyChar != 45))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != 8) && (e.KeyChar != 44))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ((textBox1.Text.Length == 0) || (textBox2.Text.Length == 0) || (textBox10.Text.Length == 0))
            {
            }
            else
            {
                tl = Convert.ToDouble(textBox1.Text);
                tr = Convert.ToDouble(textBox2.Text);
                h = Convert.ToDouble(textBox10.Text);
                Nmax = (int)Math.Round((tr - tl) / h);
                coefs = new double[2];
                exp = new Equation();
                if ((textBox5.Text.Length != 0) && (textBox6.Text.Length != 0))
                {
                    dataGridView2.Rows.Clear();
                    chart3.Series[0].Points.Clear();
                    chart4.Series[0].Points.Clear();
                    chart5.Series[0].Points.Clear();
                    x0 = Convert.ToDouble(textBox5.Text);
                    y0 = Convert.ToDouble(textBox6.Text);
                    Ust = new double[2];
                    Ust[0] = x0;
                    Ust[1] = y0;
                    a = Convert.ToDouble(textBox7.Text);
                    eps = Convert.ToDouble(textBox8.Text);
                    if (tl >= tr)
                    {
                        MessageBox.Show("Введены некорректные значения", "Предупреждение");
                    }
                    else
                    {
                        coefs[0] = a;
                        coefs[1] = eps;
                        Experiment();
                    }
                }
            }
        }

        private void Experiment()
        {
            values = exp.RungeMethod(tl, tr, Ust, h, coefs, Nmax);
            FillMainTable(values);
            DrawMainGraph(values);
        }

        private void FillMainTable(List<DataCalc> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = i;
                dataGridView2.Rows[i].Cells[1].Value = l[i].GetArg().ToString("0.##############");
                dataGridView2.Rows[i].Cells[2].Value = l[i].GetVal()[0].ToString("0.##############");
                dataGridView2.Rows[i].Cells[3].Value = l[i].GetVal()[1].ToString("0.##############");
            }
        }

        private void DrawMainGraph(List<DataCalc> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                chart3.Series[0].Points.AddXY(l[i].GetArg(), l[i].GetVal()[0]);
                chart4.Series[0].Points.AddXY(l[i].GetArg(), l[i].GetVal()[1]);
                chart5.Series[0].Points.AddXY(l[i].GetVal()[0], l[i].GetVal()[1]);
            }
        }
    }
}
