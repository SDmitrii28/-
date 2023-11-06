using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form2 : Form
    {
        private int i = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var series = new System.Windows.Forms.DataVisualization.Charting.Series
            //{
            //    Color = Color.FromArgb(new Random().Next(256), new Random().Next(256), new Random().Next(256)),
            //    //System.Drawing.Color.Blue,
            //    IsVisibleInLegend = true,
            //    IsXValueIndexed = false,
            //    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline,
            //    MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle, // Стиль маркера
            //    MarkerSize = 5, // Размер маркера
            //    MarkerColor = Color.Blue
            //};

            //chart1.Series.Add(series);
            //chart2.Series.Add(series);
            string inputText = textBox1.Text.ToString();
            string[] words = inputText.Split(new char[] { ' ', '.', ',', '!', '?', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            wordCounts.Clear();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int count = 0;
            foreach (string word in words)
            {
                count++;
                // Преобразуем слово в нижний регистр для учета регистра
                string lowercaseWord = word.ToLower();

                if (wordCounts.ContainsKey(lowercaseWord))
                {
                    // Увеличиваем счетчик для существующего слова
                    wordCounts[lowercaseWord]++;
                }
                else
                {
                    // Добавляем новое слово в словарь
                    wordCounts[lowercaseWord] = 1;
                }
            }
            stopwatch.Stop();
            label3.Text = stopwatch.Elapsed.ToString();
            string str="";
            foreach (var pair in wordCounts)
            {
                str+= $"Слово '{pair.Key}' встречается {pair.Value} раз.\n";
            }
            label1.Text = str;
            chart1.Series[i].Points.AddXY(words.Length, count);
            chart2.Series[i].Points.AddXY(words.Length, stopwatch.Elapsed.TotalMilliseconds);
            //i++;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
