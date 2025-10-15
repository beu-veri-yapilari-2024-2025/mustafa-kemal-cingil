# 📘 Hafta 2 — Bağlı Liste (Linked List) Uygulaması

Bu hafta **bağlı liste veri yapısı (Linked List)** temellerini işledik.
Projemiz, **düğüm (Node)** ve **bağlı liste (BagliList)** sınıflarından oluşmaktadır.
Bu yapı, dinamik veri ekleme, silme ve arama işlemlerini göstermek için hazırlanmıştır.

---

## 📁 Dosya Yapısı

```
Hafta-2/
│
├── Program.cs          # Ana çalışma dosyası (örnek kullanım)
```

---

## 🚀 Hızlı Başlangıç

### 1. Projeyi Çalıştırma

Terminal veya Visual Studio üzerinden:

```bash
dotnet run
```

ya da manuel olarak:

```bash
csc Program.cs Node.cs BagliList.cs
Program.exe
```

---

## 🧩 Sınıf Yapıları

### 🔹 Node Sınıfı

Her bir **Node (düğüm)**, bir veri (`data`) ve bir sonraki düğüme işaretçi (`Next`) içerir.

```csharp
public class Node
{
    public int data;
    public Node Next;

    public Node(int _data)
    {
        data = _data;
        Next = null;
    }
}
```

🧠 **Amaç:**
Liste içinde tek bir elemanı ve bağlantısını temsil eder.

---

### 🔹 Bağlı Liste Sınıfı (`BagliList`)

Bağlı listenin baş (`head`) ve son (`tail`) referanslarını tutar.
Eleman ekleme ve arama fonksiyonları içerir.

```csharp
public class BagliList
{
    private Node head;
    private Node tail;

    public BagliList()
    {
        head = null;
        tail = null;
    }
}
```

#### ✳️ Başa Eleman Ekleme

```csharp
public void BasaEkle(int value)
{
    Node newNode = new Node(value);
    newNode.Next = head;
    head = newNode;
    Console.WriteLine($"{value} başa eklendi.");
}
```

#### ✳️ Sona Eleman Ekleme

```csharp
public void sonaEkle(int value)
{
    Node newNode = new Node(value);
    if (head == null)
    {
        head = newNode;
        tail = newNode;
        Console.WriteLine($"{value} sona eklendi");
        return;
    }

    Node current = head;
    while (current.Next != null)
        current = current.Next;

    current.Next = newNode;
    tail = newNode;
    Console.WriteLine($"{value} sona eklendi.");
}
```

#### ✳️ Eleman Arama

```csharp
public void ara(int value)
{
    Node current = head;
    while (current != null)
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
```

---

## 🧪 Örnek Kullanım (`Program.cs`)

```csharp
class Program
{
    static void Main(string[] args)
    {
        BagliList liste = new BagliList();

        liste.BasaEkle(10);
        liste.sonaEkle(20);
        liste.sonaEkle(30);

        liste.ara(20);
        liste.ara(50);
    }
}
```

📤 **Konsol Çıktısı:**

```
10 başa eklendi.
20 sona eklendi.
30 sona eklendi.
20 listede bulunuyor.
50 listede bulunmuyor.
```

---

## ⚙️ Teknik Bilgiler

| İşlem        | Açıklama           | Zaman Karmaşıklığı |
| ------------ | ------------------ | ------------------ |
| `BasaEkle()` | Başa eleman ekleme | O(1)               |
| `sonaEkle()` | Sona eleman ekleme | O(n)               |
| `ara()`      | Eleman arama       | O(n)               |

---

## 💡 Notlar

* Şu an liste **tek yönlü (singly linked list)** olarak tasarlanmıştır.
* İleri seviye adımlar için:

  * **Silme (remove)** işlemi eklenebilir.
  * **Çift yönlü bağlı liste (doubly linked list)** versiyonu oluşturulabilir.
  * **Generic tip desteği (List<T>)** eklenebilir.

---
