using System;
//Стек работает по принципу "последний пришел, первым ушел",
//что означает, что элементы извлекаются в обратном порядке их добавления.
// Класс для элемента стека
public class StackNode<T>
{
    public T Data { get; set; }//Переменная, в которой хранятся данные элемента стека
    public StackNode<T> Next { get; set; }//Ссылка на следующий элемент стека

    public StackNode(T data)
    {
        Data = data;
        Next = null;
    }
}

// Класс для стека
public class Stack<T>
{
    private StackNode<T> top;//Ссылка на верхний элемент стека (вершина стека)
    private int count;//Количество элементов в стеке

    public int Count
    {
        get { return count; }
    }

    public bool IsEmpty
    {
        get { return count == 0; }
    }

    // Метод для добавления элемента на вершину стека
    public void Push(T data)
    {
        StackNode<T> newNode = new StackNode<T>(data);
        if (top == null)
        {
            top = newNode;
        }
        else
        {
            newNode.Next = top;
            top = newNode;
        }
        count++;
    }

    // Метод для удаления элемента с вершины стека и его возврата
    public T Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Стек пуст");
        }

        T data = top.Data;
        top = top.Next;
        count--;
        return data;
    }

    // Метод для просмотра элемента на вершине стека без удаления
    public T Peek()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Стек пуст");
        }

        return top.Data;
    }
    //Метод для вывода стека
    public void PrintStack()
    {
        if (IsEmpty)
        {
            Console.WriteLine("Стек пуст");
            return;
        }

        StackNode<T> current = top;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }
}