using System;

class HanoiKuleleri
{
    static int moveCount = 0;

    static void Main()
    {
        int diskSayisi = 3;
        
        Console.WriteLine("=== HANOİ KÜLELERİ ÇÖZÜMÜ ===\n");
        Console.WriteLine($"Disk Sayısı: {diskSayisi}");
        Console.WriteLine($"Toplam Hareket: {Math.Pow(2, diskSayisi) - 1}\n");
        
        HanoiCoz(diskSayisi, 'A', 'C', 'B');
        
        Console.WriteLine($"\nToplam {moveCount} hareket tamamlandı.");
    }

    static void HanoiCoz(int n, char kaynak, char hedef, char gecici)
    {
        if (n == 1)
        {
            moveCount++;
            Console.WriteLine($"{moveCount}. Disk {n}: {kaynak} → {hedef}");
            return;
        }

        HanoiCoz(n - 1, kaynak, gecici, hedef);

        moveCount++;
        Console.WriteLine($"{moveCount}. Disk {n}: {kaynak} → {hedef}");

        HanoiCoz(n - 1, gecici, hedef, kaynak);
    }
}