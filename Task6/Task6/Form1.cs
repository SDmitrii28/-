using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task6
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

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            // Создаем инвертированный индекс
            InvertedIndex invertedIndex = new InvertedIndex();

            // Прочитываем и индексируем документы
            string[] documents = Directory.GetFiles("Files");
            foreach (string document in documents)
            {
                string text = File.ReadAllText(document);
                string[] terms = text.Split(new char[] { ' ', '.', ',', '\n', '\r', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string term in terms)
                {
                    invertedIndex.AddTerm(term, document);
                }
            }

            // Сортируем индекс по лексемам
            var sortedIndex = invertedIndex.index.OrderBy(entry => entry.Key);//сортируем по терминам

            // Выполняем поиск по алгоритму «грубой силы»
            string searchTerm = textBox1.Text.ToString();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var simpleSearchResult = invertedIndex.SimpleSearch(searchTerm);
            sw.Stop();
            label2.Text = $"Результат поиска по алгоритму 'грубой силы' для '{searchTerm}':";
            foreach (var result in simpleSearchResult)
            {
                listBox1.Items.Add(result);
            }
            label4.Text = $"Время выполнения запроса 'грубой силы': {sw.ElapsedMilliseconds} мс";

            // Выполняем поиск с использованием инвертированных индексов
            //string searchTerm2 = "апельсин";
            sw.Restart();
            // Вывод инвертированного индекса в консоль
            foreach (var entry in invertedIndex.index.OrderBy(entry => entry.Key))
            {
                listBox3.Items.Add($"Лексема: {entry.Key}");
                listBox3.Items.Add("Документы:");

                foreach (var document in entry.Value)
                {
                    listBox3.Items.Add(document);
                }
            }

            Console.ReadLine(); // Ожидаем ввод пользователя перед закрытием консоли
            if (sortedIndex.Any(entry => entry.Key == searchTerm))
            {
                var indexSearchResult = sortedIndex.First(entry => entry.Key == searchTerm).Value;
                label3.Text = $"Результат поиска с использованием инвертированных индексов для '{searchTerm}':";
                foreach (var result in indexSearchResult)
                {
                    listBox2.Items.Add(result);
                }
            }
            else
            {
                listBox2.Items.Add($"Термин '{searchTerm}' не найден в индексе.");
            }
            sw.Stop();
            label5.Text = $"Время выполнения запроса с использованием инвертированных индексов: {sw.ElapsedMilliseconds} мс";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
