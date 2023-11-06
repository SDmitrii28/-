using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Task5
{

    public partial class Form1 : Form
    {
        private Chart chart;
        private Series weldingSeries;
        private Series paintingSeries;
        private Series assemblySeries;
        private ListBox listBoxLog;
        private Queue<string> weldingQueue;
        private Queue<string> paintingQueue;
        private Queue<string> assemblyQueue;
        private System.Threading.Timer simulationTimer;

        public Form1()
        {
            InitializeComponent();
            InitializeChart();
            //InitializeComponents();

            weldingQueue = new Queue<string>();
            paintingQueue = new Queue<string>();
            assemblyQueue = new Queue<string>();
        }

        private void InitializeChart()
        {
            chart1.Titles.Add("Время выполнения этапов сборки");
            chart1.ChartAreas[0].AxisX.Title = "Количество автомобилей";
            chart1.ChartAreas[0].AxisY.Title = "Время";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            listBox1.Items.Clear();

            for (int i = 0; i < 100; i++)
            {
                weldingQueue.Enqueue($"Автомобиль {i + 1}");
            }
            simulationTimer = new System.Threading.Timer(UpdateSimulation, null, 0, 100);
        }

        private void UpdateSimulation(object state)
        {
            double weldingTime = 0.0;
            double paintingTime = 0.0;
            double assemblyTime = 0.0;
            if (weldingQueue.Count > 0)
            {
                string car = weldingQueue.Dequeue();
                LogEvent($"Начало сварки для {car}");
                //Thread.Sleep(1000);

                weldingTime = SimulateWelding();
                //listBox1.Items.Add($"количество автомобилей на сварку {weldingQueue.Count}");
                //LogEvent($"Сварка завершена для {car}");
                paintingQueue.Enqueue(car); // Добавляем в очередь для покраски
            }

            if (paintingQueue.Count > 0)
            {
                string car = paintingQueue.Dequeue();
                LogEvent($"Начало покраски для {car}");
                //Thread.Sleep(1000);

                paintingTime = SimulatePainting();
                //listBox1.Items.Add("количество автомобилей на покраску" + paintingQueue.Count.ToString());
                //LogEvent($"Покраска завершена для {car}");
                assemblyQueue.Enqueue(car); // Добавляем в очередь для сборки
            }

            if (assemblyQueue.Count > 0)
            {
                string car = assemblyQueue.Dequeue();
                LogEvent($"Начало сборки для {car}");
                //Thread.Sleep(1000);

                assemblyTime = SimulateAssembly();
                //listBox1.Items.Add("количество автомобилей на сборку" + assemblyQueue.Count.ToString());
                LogEvent($"{car} готов");

                UpdateChart(weldingTime, paintingTime, assemblyTime);
            }
        }
        private double SimulatePainting()
        {
            Random random = new Random();
            int paintingTimeMilliseconds = random.Next(400, 900); // случайное время покраски от 0.3 до 0.9 секунд

            Thread.Sleep(paintingTimeMilliseconds);

            return paintingTimeMilliseconds / 1000.0; // Возвращаем время покраски в секундах
        }

        private double SimulateWelding()
        {
            Random random = new Random();
            int weldingTimeMilliseconds = random.Next(500, 1500); // случайное время сварки от 0.2 до 0.6 секунд

            Thread.Sleep(weldingTimeMilliseconds);

            return weldingTimeMilliseconds / 1000.0; // Возвращаем время сварки в секундах
        }
        private double SimulateAssembly()
        {
            Random random = new Random();
            int assemblyTimeMilliseconds = random.Next(200, 1000); // случайное время сборки от 0.5 до 1.5 секунд

            Thread.Sleep(assemblyTimeMilliseconds);

            return assemblyTimeMilliseconds / 1000.0; // Возвращаем время сборки в секундах
        }
        private void UpdateChart(double weldingTime, double paintingTime, double assemblyTime)
        {

            if (chart1.InvokeRequired)
            {
                chart1.Invoke(new Action(() =>
                {
                    //listBox1.Items.Add("количество автомобилей на сборку" + assemblyQueue.Count.ToString());
                    //listBox1.Items.Add("количество автомобилей на покраску" + paintingQueue.Count.ToString());
                    //listBox1.Items.Add("количество автомобилей на сварку" + weldingQueue.Count.ToString());
                    chart1.Series[0].Points.AddXY(chart1.Series[0].Points.Count + 1, weldingTime);
                    chart1.Series[1].Points.AddXY(chart1.Series[1].Points.Count + 1, weldingTime + paintingTime);
                    chart1.Series[2].Points.AddXY(chart1.Series[2].Points.Count + 1, weldingTime + paintingTime + assemblyTime);
                }));
            }
            else
            {
                chart1.Series[0].Points.AddXY(chart1.Series[0].Points.Count + 1, weldingTime);
                chart1.Series[1].Points.AddXY(chart1.Series[1].Points.Count + 1, weldingTime + paintingTime);
                chart1.Series[2].Points.AddXY(chart1.Series[2].Points.Count + 1, weldingTime + paintingTime + assemblyTime);
            }
            //if (chart1.InvokeRequired)
            //{
            //    chart1.Invoke(new Action(() =>
            //    {
            //        chart1.Series[0].Points.AddXY(weldingQueue.Count, weldingTime);
            //        chart1.Series[1].Points.AddXY(paintingQueue.Count, weldingTime + paintingTime);
            //        chart1.Series[2].Points.AddXY(assemblyQueue.Count, weldingTime + paintingTime + assemblyTime);
            //    }));
            //}
            //else
            //{
            //    chart1.Series[0].Points.AddXY(weldingQueue.Count, weldingTime);
            //    chart1.Series[1].Points.AddXY(paintingQueue.Count, weldingTime + paintingTime);
            //    chart1.Series[2].Points.AddXY(assemblyQueue.Count, weldingTime + paintingTime + assemblyTime);
            //}
        }

        private void LogEvent(string message)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new Action(() => {
                    listBox1.Items.Add($"{DateTime.Now:HH:mm:ss}: {message}");
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }));
            }
            else
            {
                listBox1.Items.Add($"{DateTime.Now:HH:mm:ss}: {message}");
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }
    }
}