//Node Sınıfı: Her bir düğüm bir veriye ve bir sonraki düğüme işaret eder
//veri yapısı tanımladık
public class Node //Düğüm tanımlama
{
    public int data; //verimiz
    public Node Next; //Node türünde sonraki pointerı

    public Node(int _data) // gönderilen değeri node a dönüştürür
    {
        data = _data;
        Next = null;
    }
}

//Linkedlist sınıfı

public class BagliList
{
    private Node head;
    private Node tail;

    public BagliList()
    {
        head = null;
        tail = null;
    }
    //başa eleman ekleme 
    public void BasaEkle(int value)
    {
        Node newNode = new Node(value);//noda dönüştür
        newNode.Next = head;
        head = newNode;
        Console.WriteLine($"{value} başa eklendi.");
    }
    //sona eleman ekleme 
    public void sonaEkle(int value)
    {
        Node newNode = new Node(value);
        if (head == null) // içinde başka eleman yoksa
        {
            head = newNode;
            tail = newNode;
            Console.WriteLine($"{value} sona eklendi");
            return;
        }
        Node current = head;
        while (current.Next != null) // boş değilse devam et
        {
            current = current.Next;
        }
        current.Next = newNode;
        tail = newNode;
        Console.WriteLine($"{value} sona eklendi.");
    }

    //Eleman arama

    public void ara(int value)
    {
        Node current = head;
        while (current != head)
        {
            if (current.data == value)
            {
                Console.WriteLine($"{value} listede bulunuyor.");
                return;
            }
            current = current.Next;
        }
        Console.WriteLine($"{value} listede bulunmuyor.");
    }
