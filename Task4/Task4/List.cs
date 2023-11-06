using System;
using System.Collections.Generic;
//Двусвязный список состоит из узлов (элементов), которые имеют ссылки как на следующий элемент (Next)
//и на предыдущий элемент (Previous), что позволяет обходить список в прямом и в обратном направлении.
// Класс для элемента двусвязного списка
public class ListNode<T>
{
    public T Data { get; set; } //Переменная, в которой хранятся данные элемента списка
    public ListNode<T> Next { get; set; }//Ссылка на следующий элемент в списке
    public ListNode<T> Previous { get; set; }//Ссылка на предыдущий элемент в списке

    public ListNode(T data)
    {
        Data = data;
        Next = null;
        Previous = null;
    }
}

// Класс для двусвязного списка
public class DoublyLinkedList<T>
{
    private ListNode<T> head;//Ссылка на первый элемент списка
    private ListNode<T> tail;//Ссылка на последний элемент списка
    private int count;//Количество элементов в списке.

    public int Count
    {
        get { return count; }
    }

    public bool IsEmpty
    {
        get { return count == 0; }
    }

    // Метод для добавления элемента в конец списка
    public void Add(T data)
    {
        ListNode<T> newNode = new ListNode<T>(data);
        if (tail == null)
        {
            head = tail = newNode;
        }
        else
        {
            // Устанавливаем ссылку "tail.Next" на новый узел, чтобы связать текущий последний элемент с новым узлом
            tail.Next = newNode;
            // Устанавливаем ссылку "newNode.Previous" на текущий последний элемент
            newNode.Previous = tail;
            // Затем обновляем "tail" на новый узел, который становится последним элементом списка
            tail = newNode;
        }
        count++;
    }
    public void Insert(int index, T data)
    {
        if (index < 0 || index > count)
        {
            throw new ArgumentOutOfRangeException("index", "Индекс находится вне допустимого диапазона.");
        }

        ListNode<T> newNode = new ListNode<T>(data);

        if (index == 0)
        {
            // Вставка в начало списка
            newNode.Next = head;
            head = newNode;
            if (tail == null)
            {
                tail = newNode;
            }
        }
        else if (index == count)
        {
            // Вставка в конец списка
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }
        else
        {
            // Если индекс находится в середине списка
            ListNode<T> current = head;
            // Проходим до элемента, куда нужно вставить новый элемент
            for (int i = 0; i < index - 1; i++)
            {
               current = current.Next;
            }

            // Устанавливаем связи для вставки нового элемента в середину
            newNode.Next = current.Next; // Следующий элемент нового узла становится следующим после current
            current.Next = newNode; // Следующим после current становится новый узел (newNode)
            newNode.Previous = current; // Предыдущим для нового узла становится current
            newNode.Next.Previous = newNode; // Предыдущим для следующего элемента после newNode становится newNode
        }
        count++;
    }
    // Метод для удаления элемента из списка
    public bool Remove(T data)
    {
        ListNode<T> current = head; // Начинаем с головы списка

        while (current != null) // Перебираем элементы списка
        {
            // Сравниваем значение текущего элемента с переданным значением data
            if (EqualityComparer<T>.Default.Equals(current.Data, data))
            {
                if (current.Previous != null)
                {
                    // Если текущий элемент имеет предыдущий элемент, устанавливаем ссылку предыдущего элемента на следующий элемент,
                    // пропуская текущий элемент и удаляя его из списка
                    current.Previous.Next = current.Next;
                }
                else
                {
                    // Если текущий элемент - голова списка, обновляем голову на следующий элемент
                    head = current.Next;
                }

                if (current.Next != null)
                {
                    // Если текущий элемент имеет следующий элемент, устанавливаем ссылку следующего элемента на предыдущий элемент,
                    // пропуская текущий элемент и удаляя его из списка
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    // Если текущий элемент - хвост списка, обновляем хвост на предыдущий элемент
                    tail = current.Previous;
                }

                count--; // Уменьшаем счетчик элементов списка
                return true; // Возвращаем true, если элемент был успешно удален
            }

            current = current.Next; // Переходим к следующему элементу в списке
        }

        // Если не найдено совпадений, возвращаем false, и ничего не удаляем
        return false;
    }

    // Метод для поиска элемента в списке
    public bool Contains(T data)
    {
        ListNode<T> current = head;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, data))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }
    //Метод для вывода двусвязного списка
    public void PrintList()
    {
        if (IsEmpty)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        ListNode<T> current = head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }
}