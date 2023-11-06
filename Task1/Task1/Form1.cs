using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Task1
{
    public partial class Form1 : Form
    {
        private int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void PrintMatrix(Matrix matrix, Label label)
        {
            string matrixString = "";
            for (int i = 0; i < matrix._matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix._matrix.GetLength(1); j++)
                {
                    matrixString +=matrix._matrix[i, j] + " ";
                }
                matrixString += "\n";
            }

            label.Text = matrixString;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //chart1.Series.Clear();
            //var series = new System.Windows.Forms.DataVisualization.Charting.Series
            //{
            //    Color = Color.FromArgb(new Random().Next(256), new Random().Next(256), new Random().Next(256)),
            //    //System.Drawing.Color.Blue,
            //    IsVisibleInLegend = true,
            //    IsXValueIndexed = false,
            //    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline,
            //    MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle, // Стиль маркера
            //    MarkerSize = 20, // Размер маркера
            //    MarkerColor = Color.Blue
            //};
            //chart1.Series.Add(series);
            //chart2.Series.Add(series);
            if (textBox1.Text != null)
            {
                int n = Convert.ToInt32(textBox1.Text);
                Matrix matr1 = new Matrix(n, n);
                matr1.setRandomMatrix();
                //PrintMatrix(matr1, label2);
                Matrix matr2 = new Matrix(n, n);
                matr2.setRandomMatrix();
                //PrintMatrix(matr2, label3);
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                //PrintMatrix(matr1.MultiMatrix(matr2), label4);
                matr1.MultiMatrix(matr2);
                stopwatch.Stop();
                label6.Text = stopwatch.Elapsed.ToString();
                chart1.Series[i].Points.AddXY(n, matr1.count);
                chart2.Series[i].Points.AddXY(n, stopwatch.Elapsed.TotalMilliseconds);
                //series.Points.AddXY(n*n, stopwatch.Elapsed.TotalMilliseconds);
                //i++;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
