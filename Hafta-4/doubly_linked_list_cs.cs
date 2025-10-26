using System;
using System.Collections.Generic;

public class Node
{
    public int Veri;
    public Node Onceki;
    public Node Sonraki;

    public Node(int veri)
    {
        Veri = veri;
        Onceki = null;
        Sonraki = null;
    }
}

public class IkiYonluBagliListe
{
    private Node Bas;
    private Node Son;

    public IkiYonluBagliListe()
    {
        Bas = null;
        Son = null;
    }

    public void BasaEkle(int veri)
    {
        Node yeniNode = new Node(veri);
        
        if (Bas == null)
        {
            Bas = yeniNode;
            Son = yeniNode;
        }
        else
        {
            yeniNode.Sonraki = Bas;
            Bas.Onceki = yeniNode;
            Bas = yeniNode;
        }
    }

    public void SonaEkle(int veri)
    {
        Node yeniNode = new Node(veri);
        
        if (Son == null)
        {
            Bas = yeniNode;
            Son = yeniNode;
        }
        else
        {
            Son.Sonraki = yeniNode;
            yeniNode.Onceki = Son;
            Son = yeniNode;
        }
    }

    public void SonrasindaEkle(int aramVeri, int yeniVeri)
    {
        Node gecici = Ara(aramVeri);
        
        if (gecici == null)
        {
            Console.WriteLine("Veri bulunamadı!");
            return;
        }

        Node yeniNode = new Node(yeniVeri);
        yeniNode.Onceki = gecici;
        yeniNode.Sonraki = gecici.Sonraki;

        if (gecici.Sonraki != null)
            gecici.Sonraki.Onceki = yeniNode;
        else
            Son = yeniNode;

        gecici.Sonraki = yeniNode;
    }

    public void OncesindaEkle(int aramVeri, int yeniVeri)
    {
        Node gecici = Ara(aramVeri);
        
        if (gecici == null)
        {
            Console.WriteLine("Veri bulunamadı!");
            return;
        }

        Node yeniNode = new Node(yeniVeri);
        yeniNode.Sonraki = gecici;
        yeniNode.Onceki = gecici.Onceki;

        if (gecici.Onceki != null)
            gecici.Onceki.Sonraki = yeniNode;
        else
            Bas = yeniNode;

        gecici.Onceki = yeniNode;
    }

    public void BastenSil()
    {
        if (Bas == null)
        {
            Console.WriteLine("Liste boş!");
            return;
        }

        if (Bas == Son)
        {
            Bas = null;
            Son = null;
        }
        else
        {
            Bas = Bas.Sonraki;
            Bas.Onceki = null;
        }
    }

    public void SondanSil()
    {
        if (Son == null)
        {
            Console.WriteLine("Liste boş!");
            return;
        }

        if (Bas == Son)
        {
            Bas = null;
            Son = null;
        }
        else
        {
            Son = Son.Onceki;
            Son.Sonraki = null;
        }
    }

    public void AradanSil(int veri)
    {
        Node gecici = Ara(veri);
        
        if (gecici == null)
        {
            Console.WriteLine("Veri bulunamadı!");
            return;
        }

        if (gecici.Onceki != null)
            gecici.Onceki.Sonraki = gecici.Sonraki;
        else
            Bas = gecici.Sonraki;

        if (gecici.Sonraki != null)
            gecici.Sonraki.Onceki = gecici.Onceki;
        else
            Son = gecici.Onceki;
    }

    public Node Ara(int veri)
    {
        Node gecici = Bas;
        
        while (gecici != null)
        {
            if (gecici.Veri == veri)
                return gecici;
            gecici = gecici.Sonraki;
        }
        
        return null;
    }

    public void Listele()
    {
        if (Bas == null)
        {
            Console.WriteLine("Liste boş!");
            return;
        }

        Console.Write("Liste: ");
        Node gecici = Bas;
        
        while (gecici != null)
        {
            Console.Write(gecici.Veri + " ");
            gecici = gecici.Sonraki;
        }
        
        Console.WriteLine();
    }

    public void TumunuSil()
    {
        Bas = null;
        Son = null;
    }

    public int[] DiziyeAtma()
    {
        if (Bas == null)
            return new int[0];

        List<int> dizi = new List<int>();
        Node gecici = Bas;
        
        while (gecici != null)
        {
            dizi.Add(gecici.Veri);
            gecici = gecici.Sonraki;
        }
        
        return dizi.ToArray();
    }
}

class Program
{
    static void Main()
    {
        IkiYonluBagliListe liste = new IkiYonluBagliListe();

        liste.BasaEkle(5);
        liste.BasaEkle(3);
        liste.BasaEkle(1);
        liste.SonaEkle(7);
        liste.SonaEkle(9);
        
        liste.Listele();

        liste.SonrasindaEkle(5, 6);
        liste.Listele();

        liste.OncesindaEkle(5, 4);
        liste.Listele();

        liste.BastenSil();
        liste.Listele();

        liste.SondanSil();
        liste.Listele();

        liste.AradanSil(5);
        liste.Listele();

        Node bulunan = liste.Ara(7);
        if (bulunan != null)
            Console.WriteLine("7 bulundu!");

        int[] dizi = liste.DiziyeAtma();
        Console.Write("Dizi: ");
        foreach (int i in dizi)
            Console.Write(i + " ");
        Console.WriteLine();

        liste.TumunuSil();
        liste.Listele();
    }
}