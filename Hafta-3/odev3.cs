using System;

// Node Tanımı (Düğüm)
public class OgrenciNode
{
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public int Numara { get; set; }
    public OgrenciNode Next { get; set; }

    // Yapıcı Metot
    public OgrenciNode(string ad, string soyad, int numara)
    {
        this.Ad = ad;
        this.Soyad = soyad;
        this.Numara = numara;
        this.Next = null;
    }

    public override string ToString()
    {
        return $"Ad: {Ad}, Soyad: {Soyad}, Numara: {Numara}";
    }
}

// Linked List Yönetim Sınıfı
public class OgrenciLinkedList
{
    public OgrenciNode Head { get; private set; }

    public OgrenciLinkedList()
    {
        Head = null;
    }

    // Arama Metodu (Gizli yardımcı metot)
    private OgrenciNode Ara(int numara)
    {
        OgrenciNode current = Head;
        while (current != null)
        {
            if (current.Numara == numara)
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    // ==========================================================
    // Ekleme İşlemleri
    // ==========================================================

    // Başa Ekleme
    public void BasaEkle(string ad, string soyad, int numara)
    {
        var yeniNode = new OgrenciNode(ad, soyad, numara);
        yeniNode.Next = Head;
        Head = yeniNode;
        Console.WriteLine($"[Ekle] Başa: {numara}");
    }

    // Sona Ekleme
    public void SonaEkle(string ad, string soyad, int numara)
    {
        var yeniNode = new OgrenciNode(ad, soyad, numara);

        if (Head == null)
        {
            Head = yeniNode;
            Console.WriteLine($"[Ekle] Sona: {numara}");
            return;
        }

        OgrenciNode current = Head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = yeniNode;
        Console.WriteLine($"[Ekle] Sona: {numara}");
    }

    // Değerden Sonrasına Ekleme
    public void SonrasinaEkle(int mevcutNumara, string ad, string soyad, int numara)
    {
        OgrenciNode mevcutNode = Ara(mevcutNumara);
        if (mevcutNode == null)
        {
            Console.WriteLine($"[Hata] Ekleme: {mevcutNumara} bulunamadı.");
            return;
        }

        var yeniNode = new OgrenciNode(ad, soyad, numara);
        yeniNode.Next = mevcutNode.Next;
        mevcutNode.Next = yeniNode;
        Console.WriteLine($"[Ekle] {mevcutNumara}'dan sonraya: {numara}");
    }

    // Değerden Öncesine Ekleme
    public void OncesineEkle(int mevcutNumara, string ad, string soyad, int numara)
    {
        if (Head == null) return;
        var yeniNode = new OgrenciNode(ad, soyad, numara);

        if (Head.Numara == mevcutNumara)
        {
            yeniNode.Next = Head;
            Head = yeniNode;
            Console.WriteLine($"[Ekle] {mevcutNumara}'dan önceye (Başa): {numara}");
            return;
        }

        OgrenciNode current = Head;
        while (current.Next != null && current.Next.Numara != mevcutNumara)
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            yeniNode.Next = current.Next;
            current.Next = yeniNode;
            Console.WriteLine($"[Ekle] {mevcutNumara}'dan önceye: {numara}");
        }
        else
        {
            Console.WriteLine($"[Hata] Ekleme: {mevcutNumara} bulunamadı.");
        }
    }

    // ==========================================================
    // Silme İşlemleri
    // ==========================================================

    // Baştan Silme
    public void BastanSil()
    {
        if (Head == null) { Console.WriteLine("[Hata] Silme: Liste boş."); return; }
        int silinenNumara = Head.Numara;
        Head = Head.Next;
        Console.WriteLine($"[Sil] Baştan: {silinenNumara}");
    }

    // Sondan Silme
    public void SondanSil()
    {
        if (Head == null) { Console.WriteLine("[Hata] Silme: Liste boş."); return; }
        if (Head.Next == null) { BastanSil(); return; }

        OgrenciNode current = Head;
        while (current.Next.Next != null)
        {
            current = current.Next;
        }

        int silinenNumara = current.Next.Numara;
        current.Next = null;
        Console.WriteLine($"[Sil] Sondan: {silinenNumara}");
    }

    // İstenen Değeri Silme
    public void DegerSil(int numara)
    {
        if (Head == null) { Console.WriteLine("[Hata] Silme: Liste boş."); return; }

        if (Head.Numara == numara)
        {
            BastanSil();
            return;
        }

        OgrenciNode current = Head;
        while (current.Next != null && current.Next.Numara != numara)
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
            Console.WriteLine($"[Sil] Değer: {numara}");
        }
        else
        {
            Console.WriteLine($"[Hata] Silme: {numara} bulunamadı.");
        }
    }

    // İstenen Değerden Öncesini Silme
    public void OncesiniSil(int numara)
    {
        if (Head == null || Head.Next == null) { Console.WriteLine("[Hata] Silme: Öncesi silinemez."); return; }
        
        if (Head.Next.Numara == numara) // Silinecek olan Head ise
        {
            BastanSil();
            return;
        }

        OgrenciNode current = Head;
        // current.Next (silinecek node) ve current.Next.Next (aranan numara)
        while (current.Next.Next != null && current.Next.Next.Numara != numara)
        {
            current = current.Next;
        }

        if (current.Next.Next != null)
        {
            int silinenNumara = current.Next.Numara;
            current.Next = current.Next.Next;
            Console.WriteLine($"[Sil] {numara}'dan öncesi: {silinenNumara}");
        }
        else
        {
            Console.WriteLine($"[Hata] Silme: {numara}'nın öncesi bulunamadı.");
        }
    }

    // İstenen Değerden Sonrasını Silme
    public void SonrasiniSil(int numara)
    {
        OgrenciNode mevcutNode = Ara(numara);
        if (mevcutNode == null || mevcutNode.Next == null)
        {
            Console.WriteLine($"[Hata] Silme: {numara} bulunamadı veya sonrasında eleman yok.");
            return;
        }

        int silinenNumara = mevcutNode.Next.Numara;
        mevcutNode.Next = mevcutNode.Next.Next;
        Console.WriteLine($"[Sil] {numara}'dan sonrası: {silinenNumara}");
    }

    // ==========================================================
    // Listeleme & Kullanıcıdan Değer Alma
    // ==========================================================

    // Listeleme
    public void Listele()
    {
        if (Head == null)
        {
            Console.WriteLine("Liste Boş.");
            return;
        }

        Console.WriteLine("\n--- Öğrenci Listesi ---");
        OgrenciNode current = Head;
        while (current != null)
        {
            Console.WriteLine(current.ToString());
            current = current.Next;
        }
        Console.WriteLine("--------------------------\n");
    }

    // Kullanıcıdan Değer Alarak Ekleme (Sona)
    public void KullanicidanDegerAlarakEkle()
    {
        Console.WriteLine("\n--- Yeni Öğrenci Ekleme ---");
        
        Console.Write("Ad: ");
        string ad = Console.ReadLine();

        Console.Write("Soyad: ");
        string soyad = Console.ReadLine();

        int numara = 0;
        bool gecerliNumara = false;
        while (!gecerliNumara)
        {
            Console.Write("Numara (Sayı): ");
            if (int.TryParse(Console.ReadLine(), out numara))
            {
                gecerliNumara = true;
            }
            else
            {
                Console.WriteLine("Geçersiz numara. Tekrar deneyin.");
            }
        }
        
        SonaEkle(ad, soyad, numara);
        Console.WriteLine("Ekleme tamamlandı.");
    }
}


// Program Sınıfı (Kullanım Örneği)
public class Program
{
    public static void Main(string[] args)
    {
        OgrenciLinkedList list = new OgrenciLinkedList();
        
        Console.WriteLine("--- İşlemler Başlıyor ---");

        list.BasaEkle("Ayşe", "Yılmaz", 101);
        list.SonaEkle("Burak", "Kaya", 102);
        list.BasaEkle("Cem", "Demir", 103);
        list.SonaEkle("Deniz", "Eren", 104);
        // Liste: 103 (Cem) -> 101 (Ayşe) -> 102 (Burak) -> 104 (Deniz)

        list.SonrasinaEkle(101, "Ece", "Fidan", 105);
        list.OncesineEkle(104, "Furkan", "Gül", 106);
        // Liste: 103 -> 101 -> 105 -> 102 -> 106 -> 104

        list.Listele();

        // Silme İşlemleri
        list.BastanSil(); // 103 silinir
        list.SondanSil(); // 104 silinir
        list.DegerSil(105); // 105 silinir
        // Liste: 101 -> 102 -> 106

        list.OncesiniSil(106); // 102 silinir
        list.SonrasiniSil(101); // 106 silinir
        // Liste: 101

        list.Listele();

        // Kullanıcıdan Değer Alarak Ekleme
        list.KullanicidanDegerAlarakEkle();
        
        list.Listele();
        Console.WriteLine("--- İşlemler Bitti ---");
    }
}
