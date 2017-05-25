using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_de_Prestamos
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        double prestamo;
        short meses, taza;
        float interes, amortizacion, saldo, totalInteres;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Calcular(float p, short m, float t)
        {
            

            dataGridView1.Rows.Clear();

            saldo = (float)p;
            t /= 100f;

            if (radioButton2.Checked)
            {
                m *= 12;
            }

            float cuota = (float)(p * ((t * Math.Pow(1 + t,m))/(Math.Pow(1 + t,m) - 1))) * m;

            label4.Text = "$RD " + Math.Round(cuota, 2).ToString();

            cuota /= m;

            totalInteres = 0;

            /* for (int i = 1; i < m + 1; i++)
             {
                 interes = saldo * t;
                 totalInteres += interes;
                 Math.Round(interes, 2);
                 amortizacion = (float)cuota - interes;
                 Math.Round(amortizacion, 2);
                 saldo -= amortizacion;
                 Math.Round(saldo, 2);

                 dataGridView1.Rows.Add(i, cuota.ToString("0.00"), interes.ToString("0.00"), amortizacion.ToString("0.00"), saldo.ToString("0.00"));
             }

             label5.Text = "$RD " + totalInteres.ToString("0.00");*/

            fillTable(saldo, t, m, cuota);
        }

        private void fillTable(float saldo, float taza, short mes,float cuota)
        {
            for(int i = 1; i < mes + 1; i++)
            {
                this.interes = saldo * taza;
                this.totalInteres += this.interes;
                this.amortizacion = (float)cuota - this.interes;
                Math.Round(this.amortizacion, 2);
                saldo -= this.amortizacion;
                dataGridView1.Rows.Add(i, cuota.ToString("0.00"), this.interes.ToString("0.00"), this.amortizacion.ToString("0.00"), saldo.ToString("0.00"));
            }

            label5.Text = "$RD " + this.totalInteres.ToString("0.00");
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "") {
                prestamo = Convert.ToDouble(textBox1.Text);
                meses = (short)numericUpDown2.Value;
                taza = (short)numericUpDown1.Value;
                Calcular((float)prestamo, meses, taza);
            }else
            {
                MessageBox.Show("Ingrese Monto Prestamo");
            }

            if(numericUpDown1.Value == 0 || numericUpDown2.Value == 0)
            {
                MessageBox.Show("La cantidad de meses y/ La taza debe de ser mayor que 0");
            }
            
        }
    }
}
