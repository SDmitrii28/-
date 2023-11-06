using System;
//Очередь работает по принципу "первым пришел, первым ушел",
//что означает, что элементы извлекаются в порядке их добавления.
// Класс для элемента очереди
public class QueueNode<T>
{
    public T Data { get; set; }//Переменная, в которой хранятся данные элемента очереди
    public QueueNode<T> Next { get; set; }//Ссылка на следующий элемент в очереди

    public QueueNode(T data)
    {
        Data = data;
        Next = null;
    }
}

// Класс для очереди
public class Queue<T>
{
    private QueueNode<T> front;//Ссылка на первый элемент в очереди (начало очереди)
    private QueueNode<T> rear;//Ссылка на последний элемент в очереди (конец очереди)
    private int count;//Количество элементов в очереди

    public int Count
    {
        get { return count; }
    }

    public bool IsEmpty
    {
        get { return count == 0; }
    }

    // Метод для добавления элемента в конец очереди
    public void Enqueue(T data)
    {
        QueueNode<T> newNode = new QueueNode<T>(data);
        if (rear == null)
        {
            front = rear = newNode;
        }
        else
        {
            rear.Next = newNode;
            rear = newNode;
        }
        count++;
    }

    // Метод для удаления элемента из начала очереди и его возврата
    public T Dequeue()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Очередь пуста");
        }

        T data = front.Data;
        front = front.Next;
        if (front == null)
        {
            rear = null;
        }
        count--;
        return data;
    }

    // Метод для просмотра элемента в начале очереди без удаления
    public T Peek()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Очередь пуста");
        }

        return front.Data;
    }
    //Метод для вывода очереди
    public void PrintQueue()
    {
        if (IsEmpty)
        {
            Console.WriteLine("Очередь пуста");
            return;
        }

        QueueNode<T> current = front;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }
}