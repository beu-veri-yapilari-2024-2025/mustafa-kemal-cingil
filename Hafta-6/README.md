# Hafta 6 — Hanoi Kuleleri (Towers of Hanoi)

Bu hafta C# ile **Hanoi Kuleleri problemi**nin **özyinelemeli (recursive) çözümünü** uyguladık.

---

## 📋 Ödev Açıklaması

**Hanoi Kuleleri**, klasik bilgisayar bilimi problemidir:

### Problem
- **3 kule (A, B, C)** ve **N disk** vardır
- Başlangıçta tüm diskler **Kule A'da** dizilir (büyükten küçüğe)
- Tüm diskleri **Kule C'ye** taşımak gerekir
- Kurallar:
  - ✅ Bir defada sadece 1 disk taşınabilir
  - ✅ Hiçbir zaman büyük disk küçük diskin üzerine gelmez
  - ✅ Orta kule (B) yardımcı kule olarak kullanılabilir

### Çözüm
Özyinelemeli algoritma kullanarak optimal çözümü bulduk.

---

## 📁 Dosya Yapısı

- `hanoi_towers.cs` — Özyinelemeli Hanoi çözümü (C#)
- `Hanoi_Kuleleri_Raporu_Duzgun.pdf` — Ayrıntılı raporumuz

---

## 🚀 Nasıl Çalıştırılır

```powershell
# Proje köküne git
cd "c:\Users\Casper\Documents\GitHub\mustafa-kemal-cingil\Hafta-6"

# Derleme
csc hanoi_towers.cs

# Çalıştırma
.\hanoi_towers.exe
```

---

## 🔍 Algoritma Açıklaması

### Özyinelemeli Çözüm

N disk'i A'dan C'ye taşımak için:

1. **N-1 disk'i A'dan B'ye taşı** (C'yi yardımcı olarak kullan)
2. **En büyük disk (N)'i A'dan C'ye taşı**
3. **N-1 disk'i B'den C'ye taşı** (A'yı yardımcı olarak kullan)

```
HanoiCoz(n, kaynak, hedef, gecici):
    if n == 1:
        kaynak'dan hedef'e taşı
    else:
        HanoiCoz(n-1, kaynak, gecici, hedef)
        kaynak'dan hedef'e taşı
        HanoiCoz(n-1, gecici, hedef, kaynak)
```

---

## 📊 Örnek Çözüm (3 Disk)

```
Başlangıç:
Kule A: [3, 2, 1]
Kule B: []
Kule C: []

Adımlar:
1. Disk 1: A → C
2. Disk 2: A → B
3. Disk 1: C → B
4. Disk 3: A → C
5. Disk 1: B → A
6. Disk 2: B → C
7. Disk 1: A → C

Son Durum:
Kule A: []
Kule B: []
Kule C: [3, 2, 1]
```

---

## 💡 Kod Yapısı

```csharp
class HanoiKuleleri
{
    static int moveCount = 0;

    static void Main()
    {
        int diskSayisi = 3;
        Console.WriteLine($"Disk Sayısı: {diskSayisi}");
        Console.WriteLine($"Toplam Hareket: {Math.Pow(2, diskSayisi) - 1}");
        
        HanoiCoz(diskSayisi, 'A', 'C', 'B');
        Console.WriteLine($"Toplam {moveCount} hareket tamamlandı.");
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
```

---

## 📈 Hareket Sayısı

| Disk Sayısı | Hareket Sayısı | Formül |
|---|---|---|
| 1 | 1 | $2^1 - 1 = 1$ |
| 2 | 3 | $2^2 - 1 = 3$ |
| 3 | 7 | $2^3 - 1 = 7$ |
| 4 | 15 | $2^4 - 1 = 15$ |
| 5 | 31 | $2^5 - 1 = 31$ |
| 10 | 1023 | $2^{10} - 1 = 1023$ |
| 64 | $2^{64} - 1 ≈ 1.8 × 10^{19}$ | **Efsaneye göre dünyanın sonu** |

---

## 🎯 Zaman Karmaşıklığı

$$T(n) = 2 \times T(n-1) + 1$$

$$T(n) = O(2^n)$$

- **Hareket Sayısı**: O($2^n$)
- **Recursion Derinliği**: O(n)
- **Stack Alanı**: O(n)

---

## 💡 Efsane

Hindistanlı bir tapınakta 3 altın kule ve 64 altın disk olduğu söylenir. Rahipler, diskleri taşırken her gün 1 hareket yapabilirler. Tüm diskler Kule C'ye taşındığında **dünyanın sonu gelecektir**.

Gerçek: 64 disk'i taşımak $2^{64} - 1 ≈ 18.4$ quintillion hareket gereklidir.
Günde 1 hareket: **~585 milyar yıl** alır! 🌍

---

## 🔗 Öğrenilen Kavramlar

- **Özyineleme (Recursion)** — Kompleks problemleri basit alt problemlere ayırma
- **Temel Durum (Base Case)** — Recursion'ı durdurma koşulu
- **İndirgemeli Durum (Recursive Case)** — Problemi küçültme
- **Call Stack** — Recursion çağrı yığını
- **Divide and Conquer** — "Böl ve yönet" stratejisi
- **Exponential Growth** — Üstel büyüme

---

## ⚠️ Dikkat Edilecekler

1. **Base Case** olmadan infinite recursion olur ❌
2. **Stack Overflow** riski — N çok büyük olursa çöker
3. **Exponential karmaşıklık** — N=30 bile 10 milyon hareket
4. Bu problem **optimal çözümdür** — daha iyi bir yol yoktur

---

## 💾 Variasyonlar

- **4 Kule** (Frame-Stewart Algoritması) — Daha hızlı çözüm
- **İkinci kare** — Diskleri farklı sıraya taşımak
- **Paralel İşlem** — Birden fazla disk aynı anda

---

## 📚 İlgili Konular

- Tower of Hanoi Grafik Gösterim
- Interactive Hanoi Solver (Web)
- 3D Visualizasyon
- Bağlı Listeleri de ekleyerek sanal kuleyi simüle etme