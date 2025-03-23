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
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
		private void Form1_Load(object sender, EventArgs e)
		{
			// Set up the chart as a polar chart
			chart1.Series.Clear();
			chart1.ChartAreas[0].Area3DStyle.Enable3D = false;

			// Configure the angle axis (AxisX)
			chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = true; // Show angle labels
			chart1.ChartAreas[0].AxisX.Interval = 30; // Set angle interval to 30 degrees
			chart1.ChartAreas[0].AxisX.Minimum = 0; // Start angle at 0 degrees
			chart1.ChartAreas[0].AxisX.Maximum = 360; // End angle at 360 degrees
			chart1.ChartAreas[0].AxisX.Crossing = 0; // Ensure 0 degrees is at the rightmost point

			// Configure the radial axis (AxisY)
			chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = true; // Show radial labels
			chart1.ChartAreas[0].AxisY.Minimum = 0; // Start radius at 0
			chart1.ChartAreas[0].AxisY.Maximum = 10; // Set maximum radius (adjust as needed)

			// Add a series for the logarithmic spiral
			Series spiralSeries = new Series("Logarithmic Spiral");
			spiralSeries.ChartType = SeriesChartType.Polar;
			chart1.Series.Add(spiralSeries);

			// Generate the logarithmic spiral data points
			GenerateLogarithmicSpiral(spiralSeries);
		}

		private void GenerateLogarithmicSpiral(Series series)
		{
			// Constants for the logarithmic spiral
			double a = 1.0; // Controls the starting radius
			double b = 0.2; // Controls the tightness of the spiral

			// Clear any existing data points
			series.Points.Clear();

			// Generate points for the logarithmic spiral
			for (double theta = 0; theta <= 10 * Math.PI; theta += 0.1)
			{
				double r = a * Math.Exp(b * theta); // Logarithmic spiral equation

				// Convert theta from radians to degrees (if needed)
				double thetaDegrees = theta * (180 / Math.PI);

				series.Points.AddXY(thetaDegrees, r);
			}
		}

		private void chart1_Click(object sender, EventArgs e)
		{
			// Optional: Regenerate the spiral on click if needed
			GenerateLogarithmicSpiral(chart1.Series["Logarithmic Spiral"]);
		}
	}
}
