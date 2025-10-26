# Hafta 3 — Linked List (Bağlı Liste)

Bu hafta C# ile öğrenci bilgilerini tutan bir **Linked List (Bağlı Liste)** yapısı uyguladık.

---

## 📋 Ödev Açıklaması

Bir Linked List örneği yapılması istendi. Aşağıdaki fonksiyonların olduğu bir öğrenci (ad, soyad, numara) Linked List kodu:

### Gereksinimler
- ✅ **Node tanımlama** ve yapıcı metot
- ✅ **Ekleme işlemleri:**
  - Başa ekleme
  - Sona ekleme
  - İstenen değerden sonrasına ekleme
  - İstenen değerden öncesine ekleme
- ✅ **Silme işlemleri:**
  - Baştan silme
  - Sondan silme
  - İstenen değeri silme
  - İstenen değerin öncesini silme
  - İstenen değerin sonrasını silme
- ✅ **Arama** (private helper metot olarak)
- ✅ **Listeleme**
- ✅ **Kullanıcıdan değer alarak ekleme**

---

## 📁 Dosya Yapısı

- `odev3.cs` — Tam Linked List implementasyonu (C#)

---

## 🚀 Nasıl Çalıştırılır

### Gereksinimler
- .NET SDK (6.0 veya üzeri) veya Visual Studio

### Derleme ve Çalıştırma

```powershell
# Proje köküne git
cd "c:\Users\Casper\Documents\GitHub\mustafa-kemal-cingil\Hafta-3"

# Derleme
csc odev3.cs

# Çalıştırma
.\odev3.exe
```

**Not:** Eğer `csc` komutu çalışmıyorsa, Visual Studio'da veya Visual Studio Code'da C# extension ile çalıştırabilirsiniz.

---

## 🔍 Kod Yapısı

### 1. OgrenciNode Sınıfı (Node)
```csharp
public class OgrenciNode
{
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public int Numara { get; set; }
    public OgrenciNode Next { get; set; }
    
    // Yapıcı metot
    public OgrenciNode(string ad, string soyad, int numara)
}
```

### 2. OgrenciLinkedList Sınıfı (Linked List Yönetimi)

**Ekleme Metotları:**
- `BasaEkle(ad, soyad, numara)` - Liste başına ekler
- `SonaEkle(ad, soyad, numara)` - Liste sonuna ekler
- `SonrasinaEkle(mevcutNumara, ad, soyad, numara)` - Belirtilen numaradan sonraya ekler
- `OncesineEkle(mevcutNumara, ad, soyad, numara)` - Belirtilen numaradan önceye ekler

**Silme Metotları:**
- `BastanSil()` - Baştaki elemanı siler
- `SondanSil()` - Sondaki elemanı siler
- `DegerSil(numara)` - Belirtilen numarayı siler
- `OncesiniSil(numara)` - Belirtilen numaranın öncesini siler
- `SonrasiniSil(numara)` - Belirtilen numaranın sonrasını siler

**Diğer Metotlar:**
- `Ara(numara)` - Private helper metot, numara arar
- `Listele()` - Tüm listeyi ekrana yazdırır
- `KullanicidanDegerAlarakEkle()` - Kullanıcıdan ad, soyad, numara alıp listeye ekler

---

## 💡 Örnek Kullanım

```csharp
OgrenciLinkedList list = new OgrenciLinkedList();

// Ekleme
list.BasaEkle("Ayşe", "Yılmaz", 101);
list.SonaEkle("Burak", "Kaya", 102);
list.SonrasinaEkle(101, "Ece", "Fidan", 105);
list.OncesineEkle(104, "Furkan", "Gül", 106);

// Listeleme
list.Listele();

// Silme
list.BastanSil();
list.SondanSil();
list.DegerSil(105);
list.OncesiniSil(106);
list.SonrasiniSil(101);

// Kullanıcıdan değer alma
list.KullanicidanDegerAlarakEkle();
```

---

## 📊 Örnek Çıktı

```
--- İşlemler Başlıyor ---
[Ekle] Başa: 101
[Ekle] Sona: 102
[Ekle] Başa: 103
[Ekle] Sona: 104
[Ekle] 101'dan sonraya: 105
[Ekle] 104'dan önceye: 106

--- Öğrenci Listesi ---
Ad: Cem, Soyad: Demir, Numara: 103
Ad: Ayşe, Soyad: Yılmaz, Numara: 101
Ad: Ece, Soyad: Fidan, Numara: 105
Ad: Burak, Soyad: Kaya, Numara: 102
Ad: Furkan, Soyad: Gül, Numara: 106
Ad: Deniz, Soyad: Eren, Numara: 104
--------------------------

[Sil] Baştan: 103
[Sil] Sondan: 104
[Sil] Değer: 105
[Sil] 106'dan öncesi: 102
[Sil] 101'dan sonrası: 106

--- Öğrenci Listesi ---
Ad: Ayşe, Soyad: Yılmaz, Numara: 101
--------------------------

--- Yeni Öğrenci Ekleme ---
Ad: Mehmet
Soyad: Öztürk
Numara (Sayı): 107
[Ekle] Sona: 107
Ekleme tamamlandı.

--- Öğrenci Listesi ---
Ad: Ayşe, Soyad: Yılmaz, Numara: 101
Ad: Mehmet, Soyad: Öztürk, Numara: 107
--------------------------

--- İşlemler Bitti ---
```

---

## 🎯 Öğrenilen Kavramlar

- **Linked List yapısı** ve düğüm (node) kavramı
- **Head pointer** kullanımı
- **Traversal** (liste gezinme) teknikleri
- **Edge case** kontrolü (boş liste, tek eleman, vb.)
- **C# property** ve constructor kullanımı
- Kullanıcı girişi doğrulama (`TryParse`)

---

## 💡 İpuçları

- Linked List, dinamik veri yapısıdır - boyut önceden belli değildir
- Ekleme/silme işlemleri dizilere göre daha esnektir
- Ancak rastgele erişim (indexing) yoktur, O(n) zaman alır
- Her node bir sonrakini gösterir (singly linked list)
- Silme/ekleme öncesinde null kontrolü yapmak önemlidir

---

## 🔗 Zaman Karmaşıklığı

| İşlem | Zaman Karmaşıklığı |
|-------|-------------------|
| Başa ekleme | O(1) |
| Sona ekleme | O(n) |
| Arama | O(n) |
| Baştan silme | O(1) |
| Sondan silme | O(n) |
| İstenen değeri silme | O(n) |

**Not:** Doubly Linked List kullanılsaydı bence bazı işlemler daha hızlı olurdu.