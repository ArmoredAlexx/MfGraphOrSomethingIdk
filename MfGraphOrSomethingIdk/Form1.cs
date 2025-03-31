using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MfGraphOrSomethingIdk
{
    public partial class Form1 : Form
    {
		private Color spiralColor = Color.Gray;
		private double a = 1.0;
		private double b = 0.2;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
		private void Form1_Load(object sender, EventArgs e)
		{
			chart1.Series.Clear();
			chart1.ChartAreas[0].Area3DStyle.Enable3D = false;

            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
			chart1.ChartAreas[0].AxisX.Interval = 30;
			chart1.ChartAreas[0].AxisX.Minimum = 0;
			chart1.ChartAreas[0].AxisX.Maximum = 360;
			chart1.ChartAreas[0].AxisX.Crossing = 0;

			chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
			chart1.ChartAreas[0].AxisY.Minimum = 0;
			chart1.ChartAreas[0].AxisY.Maximum = 10;

			Series spiralSeries = new Series("Logarithmic Spiral");
			spiralSeries.ChartType = SeriesChartType.Polar;
            spiralSeries.Color = spiralColor;
            spiralSeries.BorderWidth = 2;
            chart1.Series.Add(spiralSeries);

            GenerateLogarithmicSpiral(spiralSeries);
		}

		private void GenerateLogarithmicSpiral(Series series)
		{
			series.Points.Clear();

			for (double theta = 0; theta <= 10 * Math.PI; theta += 0.1)
			{
				double r = a * Math.Exp(b * theta); // Logarithmic spiral equation

				double thetaDegrees = theta * (180 / Math.PI);

				series.Points.AddXY(thetaDegrees, r);
			}
		}
			
		private void chart1_Click(object sender, EventArgs e)
		{
            // Optional
			GenerateLogarithmicSpiral(chart1.Series["Logarithmic Spiral"]);
		}

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				Color color = colorDialog1.Color;
				spiralColor = color;
                Form1_Load(sender, e);
            }

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
			a = (double)numericUpDown2.Value;
            Form1_Load(sender, e);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            b = (double)numericUpDown1.Value;
            Form1_Load(sender, e);
        }
    }
}
