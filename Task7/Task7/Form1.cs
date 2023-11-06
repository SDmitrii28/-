using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
namespace Task7
{
    public partial class Form1 : Form
    {
        private BinarySearchTree binaryTree; // Экземпляр бинарного дерева
        private List<string> wordList; // Список слов из файла
        public Form1()
        {
            InitializeComponent();
            binaryTree = new BinarySearchTree(); // Инициализация бинарного дерева
            wordList = new List<string>();

            LoadWordsFromFile("input.txt"); // Загрузка слов из файла
            BuildBinaryTree(); // Построение бинарного дерева
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VisualizeTree(); // Визуализация дерева
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            string searchWord = textBox1.Text;
            bool foundInTree = binaryTree.Search(searchWord); // Поиск в дереве
            bool foundInList = wordList.Contains(searchWord); // Поиск в списке

            if (foundInTree)
            {
                MessageBox.Show($"Слово \"{searchWord}\" найдено в дереве.");
            }
            else
            {
                MessageBox.Show($"Слово \"{searchWord}\" не найдено в дереве.");
            }

            if (foundInList)
            {
                MessageBox.Show($"Слово \"{searchWord}\" найдено в списке.");
            }
            else
            {
                MessageBox.Show($"Слово \"{searchWord}\" не найдено в списке.");
            }
        }
        // Метод для загрузки слов из файла
        private void LoadWordsFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                wordList = File.ReadAllText(fileName).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            else
            {
                MessageBox.Show("Файл не найден.");
            }
        }

        // Метод для построения бинарного дерева из списка слов
        private void BuildBinaryTree()
        {
            foreach (var word in wordList)
            {
                binaryTree.Insert(word); // Вставка каждого слова в дерево
            }
        }

        // Метод для визуализации дерева
        private void VisualizeTree()
        {
            treeView1.Nodes.Clear(); // Очистка TreeView
            VisualizeTreeRec(binaryTree.Root, null); // Рекурсивное построение дерева в TreeView
        }
        //TreeNode - родительского узла node - корневой узел
        private void VisualizeTreeRec(Node node, TreeNode parentNode)
        {
            if (node == null) return;

            TreeNode treeNode = new TreeNode(node.Value);

            if (parentNode == null)
            {
                treeView1.Nodes.Add(treeNode); // Добавление корневого узла
            }
            else
            {
                //treeView1.Nodes.Add(treeNode.Value);
                parentNode.Nodes.Add(treeNode); // Добавление узла к родительскому узлу
            }

            VisualizeTreeRec(node.Left, treeNode); // Рекурсивное построение левого поддерева
            VisualizeTreeRec(node.Right, treeNode); // Рекурсивное построение правого поддерева
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sortedList = binaryTree.InOrderTraversal(); // Получение отсортированного списка
            textBox2.Text = string.Join(" ", sortedList); // Отображение в текстовом поле
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sortedList = binaryTree.ReverseInOrderTraversal(); // Получение отсортированного списка
            textBox2.Text = string.Join(" ", sortedList); // Отображение в текстовом поле
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}