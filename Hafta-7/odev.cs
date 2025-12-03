using System;
using System.Collections.Generic;

class Node
{
    public int Value;
    public Node Left;
    public Node Right;

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

class BinarySearchTree
{
    public Node Root;

    public void Insert(int value)
    {
        Root = InsertRec(Root, value);
    }

    private Node InsertRec(Node root, int value)
    {
        if (root == null)
            return new Node(value);

        if (value < root.Value)
            root.Left = InsertRec(root.Left, value);
        else
            root.Right = InsertRec(root.Right, value);

        return root;
    }

    // PREORDER (Root - Left - Right)
    public void Preorder(Node node)
    {
        if (node == null) return;
        Console.Write(node.Value + " ");
        Preorder(node.Left);
        Preorder(node.Right);
    }

    // INORDER (Left - Root - Right)
    public void Inorder(Node node)
    {
        if (node == null) return;
        Inorder(node.Left);
        Console.Write(node.Value + " ");
        Inorder(node.Right);
    }

    // POSTORDER (Left - Right - Root)
    public void Postorder(Node node)
    {
        if (node == null) return;
        Postorder(node.Left);
        Postorder(node.Right);
        Console.Write(node.Value + " ");
    }

    // LEVEL ORDER (BFS)
    public void LevelOrder()
    {
        if (Root == null) return;

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            Console.Write(current.Value + " ");

            if (current.Left != null)
                queue.Enqueue(current.Left);
            if (current.Right != null)
                queue.Enqueue(current.Right);
        }
    }
}

class Program
{
    static void Main()
    {
        BinarySearchTree bst = new BinarySearchTree();

        Console.WriteLine("Kaç adet sayı gireceksiniz?");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Sayıları giriniz:");
        for (int i = 0; i < n; i++)
        {
            int val = int.Parse(Console.ReadLine());
            bst.Insert(val);
        }

        Console.Write("\nPreorder: ");
        bst.Preorder(bst.Root);

        Console.Write("\nInorder: ");
        bst.Inorder(bst.Root);

        Console.Write("\nPostorder: ");
        bst.Postorder(bst.Root);

        Console.Write("\nLevel-order: ");
        bst.LevelOrder();

        Console.WriteLine();
    }
}
