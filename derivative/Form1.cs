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
           /* chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.ChartAreas[0].AxisX.Maximum = 4;
            chart1.ChartAreas[0].AxisX.Minimum = -1;*/
           
            float d = 0.01f;
            float h = 0.001f;
            float y;
            for (float x = c.x[0]; x <= c.x[4]; x += d)
            {

                y = (cubicSpline.Interpolate(x + h) - cubicSpline.Interpolate(x - h)) / (2 * h); 
                this.chart1.Series[2].Points.AddXY(x, y);
            }
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
           /* chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Interval = 2;
            chart1.ChartAreas[0].AxisX.Maximum = 4;
            chart1.ChartAreas[0].AxisX.Minimum = -1;
            chart1.ChartAreas[0].AxisY.Maximum = 28;
            chart1.ChartAreas[0].AxisY.Minimum = -40;*/
            float d = 0.001f;
            float h = 0.8f;
            float y;
            for (float x = c.x[0]; x <= c.x[4]; x += d)
            {
               y = (cubicSpline.Interpolate(x + h) - 2 * cubicSpline.Interpolate(x) + cubicSpline.Interpolate(x - h)) / (h * h);
                this.chart1.Series[1].Points.AddXY(x, y);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
           /* chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.ChartAreas[0].AxisX.Maximum = 4;
            chart1.ChartAreas[0].AxisX.Minimum = -1;*/
           

            float d = 0.0001f;
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
            chart1.Series[4].Points.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.ChartAreas[0].AxisX.Maximum = 4;
            chart1.ChartAreas[0].AxisX.Minimum = -1;
          //  chart1.ChartAreas[0].AxisY.Maximum = 15;
         //   chart1.ChartAreas[0].AxisY.Minimum = -10;*/
            for (int i = 0; i < 5; i++) this.chart1.Series[3].Points.AddXY(c.x_ret(i), c.y_ret(i));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.ChartAreas[0].AxisX.Maximum = 7;
            chart1.ChartAreas[0].AxisX.Minimum = 2;*/
            float a1= float.Parse(textBox11.Text);
            float b1 = float.Parse(textBox12.Text);
            float c1= float.Parse(textBox13.Text);
            float d1= float.Parse(textBox14.Text);
            float a2 = float.Parse(textBox15.Text);
            float b2 = float.Parse(textBox16.Text);
            float c2 = float.Parse(textBox17.Text);
            float d2 = float.Parse(textBox18.Text);
            float a3 = float.Parse(textBox19.Text);
            float b3 = float.Parse(textBox20.Text);
            float c3 = float.Parse(textBox21.Text);
            float d3 = float.Parse(textBox22.Text);
            float a4 = float.Parse(textBox23.Text);
            float b4 = float.Parse(textBox24.Text);
            float c4 = float.Parse(textBox25.Text);
            float d4 = float.Parse(textBox26.Text);

            float d = 0.001f;
            float y=0;
            for (float x = c.x[0]; x <= c.x[4]; x += d)
            {
                if ((x > c.x_ret(0)) && (x < c.x_ret(1))) y = d1 * (float)Math.Pow(x - 5, 3) + c1 * (float)Math.Pow(x - 5, 2) + b1 * (float)Math.Pow(x - 5, 1) + a1;
                if ((x > c.x_ret(1)) && (x < c.x_ret(2))) y = d2 * (float)Math.Pow(x - 7, 3) + c2 * (float)Math.Pow(x - 7, 2) + b2 * (float)Math.Pow(x - 7, 1) + a2;
                if ((x > c.x_ret(2)) && (x < c.x_ret(3))) y = d3 * (float)Math.Pow(x - 9, 3) + c3 * (float)Math.Pow(x - 9, 2) + b3 * (float)Math.Pow(x - 9, 1) + a3;
                if ((x > c.x_ret(3)) && (x < c.x_ret(4))) y = d4 * (float)Math.Pow(x - 11, 3) + c4 * (float)Math.Pow(x - 11, 2) + b4 * (float)Math.Pow(x - 11, 1) + a4;
                this.chart1.Series[4].Points.AddXY(x, y);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

