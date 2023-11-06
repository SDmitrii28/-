using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Тестирование стека
            Console.WriteLine("Тестирование стека:");
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.PrintStack();
            Console.WriteLine("Вершина стека: " + stack.Peek()); // Выводит 3
            int poppedItem = stack.Pop();
            Console.WriteLine("Извлеченный элемент: " + poppedItem); // Выводит 3
            Console.WriteLine("Размер стека: " + stack.Count); // Выводит 2
            stack.PrintStack();

            // Тестирование очереди
            Console.WriteLine("\nТестирование очереди:");
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Первый");
            queue.Enqueue("Второй");
            queue.Enqueue("Третий");
            queue.PrintQueue();
            Console.WriteLine("Первый элемент в очереди: " + queue.Peek()); // Выводит "Первый"
            string dequeuedItem = queue.Dequeue();
            Console.WriteLine("Извлеченный элемент: " + dequeuedItem); // Выводит "Первый"
            Console.WriteLine("Размер очереди: " + queue.Count); // Выводит 2
            queue.PrintQueue();

            // Тестирование двусвязного списка
            Console.WriteLine("\nТестирование двусвязного списка:");
            DoublyLinkedList<string> linkedList = new DoublyLinkedList<string>();
            linkedList.Add("Stack");
            linkedList.Add("Queue");
            linkedList.Add("List");
            linkedList.PrintList();
            Console.WriteLine("Содержит ли список 'List'? " + linkedList.Contains("List")); // Выводит True
            bool removed = linkedList.Remove("Stack");
            Console.WriteLine("Удален ли 'Stack'? " + removed); // Выводит True
            linkedList.PrintList();
            linkedList.Insert(1, "Stack + Queue + List");
            Console.WriteLine("Размер списка: " + linkedList.Count); // Выводит 2
            linkedList.PrintList();
            Console.ReadKey();


            MeasureMemoryUsage(() =>
            {
                // Тестирование памяти при добавлении незначительных объектов в стек
                Stack<int> smallObjectsStack = new Stack<int>();
                for (int i = 0; i < 1000; i++)
                {
                    smallObjectsStack.Push(i);
                }
            }, "Добавление незначительных объектов в стек");

            MeasureMemoryUsage(() =>
            {
                // Тестирование памяти при добавлении объекта с массивом из 100,000 целых чисел в стек
                Stack<int[]> largeObjectStack = new Stack<int[]>();
                for (int i = 0; i < 1; i++)
                {
                    largeObjectStack.Push(new int[100000]);
                }

                // Принудительный вызов сборщика мусора
                GC.Collect();
            }, "Добавление объектов с массивом из 100,000 целых чисел в стек");


            Console.ReadLine();
        }

        static void MeasureMemoryUsage(Action action, string operation)
        {
            GC.Collect(); // Запускаем сборку мусора, чтобы очистить предыдущие объекты

            long startMemory = Process.GetCurrentProcess().PrivateMemorySize64;//GC.GetTotalMemory(true);

            action();

            long endMemory = Process.GetCurrentProcess().PrivateMemorySize64; //GC.GetTotalMemory(true);

            long memoryUsed = endMemory - startMemory; 
            Console.WriteLine($"{operation}: Использовано памяти: {memoryUsed /1024} KB");
        }
    }
}
