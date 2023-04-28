using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace derivative
{
    public partial class Form1 : Form
    {
        Data c = new Data();
        CubicSpline cubicSpline = new CubicSpline();
        public Form1()
        {
            InitializeComponent();
        }
   private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                float a = float.Parse(textBox1.Text);
                c.x_enter(0, a);
                a = float.Parse(textBox2.Text);
                c.y_enter(0, a);
                a = float.Parse(textBox3.Text);
                c.x_enter(1, a);
                a = float.Parse(textBox4.Text);
                c.y_enter(1, a);
                a = float.Parse(textBox5.Text);
                c.x_enter(2, a);
                a = float.Parse(textBox6.Text);
                c.y_enter(2, a);
                a = float.Parse(textBox7.Text);
                c.x_enter(3, a);
                a = float.Parse(textBox8.Text);
                c.y_enter(3, a);
                a = float.Parse(textBox9.Text);
                c.x_enter(4, a);
                a = float.Parse(textBox10.Text);
                c.y_enter(4, a);
                cubicSpline.BuildSpline(c.x, c.y, 4);
            }
            catch (System.FormatException)
            {
                MessageBox.Show(
       "Wrong data",
       "Error",
       MessageBoxButtons.OK,
       MessageBoxIcon.Information,
       MessageBoxDefaultButton.Button1,
       MessageBoxOptions.DefaultDesktopOnly);
            }

        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            float d = 0.01f;
            float h = 0.1f;
            float y;
            for (float x = c.x[0]; x <= c.x[4]; x += d)
            {

                y = (cubicSpline.Interpolate(x + h) - cubicSpline.Interpolate(x - h)) / (2 * h); ;
                this.chart1.Series[2].Points.AddXY(x, y);
            }
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
          
            float d = 0.01f;
            float h = 0.1f;
            float y;
            for (float x = c.x[0]; x <= c.x[4]; x += d)
            {
               y = (cubicSpline.Interpolate(x + h) - 2 * cubicSpline.Interpolate(x) + cubicSpline.Interpolate(x - h)) / (h * h);
                this.chart1.Series[1].Points.AddXY(x, y);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
           
            float d = 0.01f;
            float y;
            for (float x = c.x[0]; x <=c.x[4]; x += d)
            {
                y = cubicSpline.Interpolate(x);
                this.chart1.Series[0].Points.AddXY(x, y);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++) this.chart1.Series[3].Points.AddXY(c.x_ret(i), c.y_ret(i));
        }
    
    }
}
