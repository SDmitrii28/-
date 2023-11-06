using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

// Определение класса для представления узла бинарного дерева
public class Node
{
    public string Value { get; set; } // Значение узла
    public Node Left { get; set; } // Левый потомок
    public Node Right { get; set; } // Правый потомок

    public Node(string value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

// Определение класса для бинарного дерева поиска
public class BinarySearchTree
{
    public Node Root { get; set; } // Корневой узел дерева

    // Метод для вставки нового значения в дерево
    public void Insert(string value)
    {
        Root = InsertRec(Root, value);
    }

    private Node InsertRec(Node root, string value)
    {
        // Рекурсивный метод для вставки значения в бинарное дерево

        if (root == null)
        {
            // Если текущий узел равен null, создаем новый узел с переданным значением
            root = new Node(value);
            return root;
        }

        if (string.Compare(value, root.Value, StringComparison.Ordinal) < 0)
        {
            // Если value меньше значения в текущем узле, вставляем его в левое поддерево
            root.Left = InsertRec(root.Left, value);
        }
        else if (string.Compare(value, root.Value, StringComparison.Ordinal) >= 0)
        {
            // Если value больше или равно значению в текущем узле, вставляем его в правое поддерево
            root.Right = InsertRec(root.Right, value);
        }

        return root;
    }

    // Метод для поиска значения в дереве
    public bool Search(string value)
    {
        return SearchRec(Root, value);
    }

    private bool SearchRec(Node root, string value)
    {
        if (root == null)
        {
            return false;
        }

        if (value == root.Value)
        {
            return true; // Значение найдено
        }

        if (string.Compare(value, root.Value, StringComparison.Ordinal) < 0)
        {
            return SearchRec(root.Left, value); // Рекурсивный поиск в левом поддереве
        }

        return SearchRec(root.Right, value); // Рекурсивный поиск в правом поддереве
    }
    // Метод для выполнения прямого обхода бинарного дерева.
    // Возвращает отсортированный список слов по возрастанию.
    public List<string> InOrderTraversal()
    {
        List<string> result = new List<string>();
        InOrderTraversalRec(Root, result);
        return result;
    }

    private void InOrderTraversalRec(Node root, List<string> result)
    {
        // Рекурсивный прямой обход бинарного дерева.

        if (root != null)
        {
            InOrderTraversalRec(root.Left, result); // Рекурсивно обходим левое поддерево
            result.Add(root.Value); // Добавляем значение текущего узла в список
            InOrderTraversalRec(root.Right, result); // Рекурсивно обходим правое поддерево
        }
    }

    // Метод для выполнения обратного обхода бинарного дерева.
    // Возвращает отсортированный список слов по убыванию.
    public List<string> ReverseInOrderTraversal()
    {
        List<string> result = new List<string>();
        ReverseInOrderTraversalRec(Root, result);
        return result;
    }

    private void ReverseInOrderTraversalRec(Node root, List<string> result)
    {
        // Рекурсивный обратный обход бинарного дерева.

        if (root != null)
        {
            ReverseInOrderTraversalRec(root.Right, result); // Рекурсивно обходим правое поддерево
            result.Add(root.Value); // Добавляем значение текущего узла в список
            ReverseInOrderTraversalRec(root.Left, result); // Рекурсивно обходим левое поддерево
        }
    }
}