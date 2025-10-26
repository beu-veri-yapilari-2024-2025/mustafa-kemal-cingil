# Hafta 4 — İki Yönlü Bağlı Liste (Doubly Linked List)

Bu hafta C# ile **İki Yönlü Bağlı Liste (Doubly Linked List)** yapısını uyguladık.

---

## 📋 Ödev Açıklaması

Önceki hafta tek yönlü bağlı listeyi öğrendik, bu hafta **her düğümün hem sonraki hem de önceki düğümü gösterebildiği** iki yönlü bağlı liste yapısını implement ettik.

### Gereksinimler
- ✅ **Node tanımlama** (Veri, Onceki, Sonraki)
- ✅ **Ekleme işlemleri:**
  - Başa ekleme
  - Sona ekleme
  - Değerden sonrasına ekleme
  - Değerden öncesine ekleme
- ✅ **Silme işlemleri:**
  - Baştan silme
  - Sondan silme
  - Belirtilen değeri silme
  - Değerden sonrasını silme
  - Değerden öncesini silme
- ✅ **Arama** (belirtilen değeri bulma)
- ✅ **İleri ve geriye doğru listeleme**
- ✅ **Listeleme**

---

## 📁 Dosya Yapısı

- `doubly_linked_list_cs.cs` — Tam İki Yönlü Bağlı Liste implementasyonu (C#)

---

## 🚀 Nasıl Çalıştırılır

### Gereksinimler
- .NET SDK (6.0 veya üzeri) veya Visual Studio

### Derleme ve Çalıştırma

```powershell
# Proje köküne git
cd "c:\Users\Casper\Documents\GitHub\mustafa-kemal-cingil\Hafta-4"

# Derleme
csc doubly_linked_list_cs.cs

# Çalıştırma
.\doubly_linked_list_cs.exe
```

---

## 🔍 Kod Yapısı

### 1. Node Sınıfı

```csharp
public class Node
{
    public int Veri;
    public Node Onceki;      // Önceki düğüme işaret
    public Node Sonraki;     // Sonraki düğüme işaret

    public Node(int veri)
    {
        Veri = veri;
        Onceki = null;
        Sonraki = null;
    }
}
```

### 2. IkiYonluBagliListe Sınıfı

**Yapı:**
- `Bas` — Listenin başını gösterir
- `Son` — Listenin sonunu gösterir

**Ekleme Metotları:**
- `BasaEkle(veri)` — Başa ekler, önceki ve sonraki pointerları ayarlar
- `SonaEkle(veri)` — Sona ekler
- `SonrasindaEkle(aramVeri, yeniVeri)` — Belirtilen veriden sonraya ekler
- `OncesindaEkle(aramVeri, yeniVeri)` — Belirtilen veriden öncesine ekler

**Silme Metotları:**
- `BastanSil()` — Baştan siler
- `SondanSil()` — Sondan siler
- `DegerSil(veri)` — Belirtilen değeri siler
- `SonrasiniSil(veri)` — Belirtilen değerden sonrasını siler
- `OncesiniSil(veri)` — Belirtilen değerden öncesini siler

**Diğer Metotlar:**
- `Ara(veri)` — Belirtilen değeri arar
- `IleriListele()` — Baştan sona doğru listeleme
- `GeriListele()` — Sondan başa doğru listeleme

---

## 💡 Örnek Kullanım

```csharp
IkiYonluBagliListe liste = new IkiYonluBagliListe();

// Ekleme
liste.BasaEkle(10);
liste.SonaEkle(20);
liste.BasaEkle(5);
liste.SonrasindaEkle(10, 15);

// İleri listeleme
liste.IleriListele();     // 5 -> 10 -> 15 -> 20

// Geri listeleme
liste.GeriListele();      // 20 -> 15 -> 10 -> 5

// Silme
liste.DegerSil(15);
liste.IleriListele();     // 5 -> 10 -> 20
```

---

## 🎯 Tek Yönlü vs İki Yönlü Farklar

| Özellik | Tek Yönlü | İki Yönlü |
|---------|-----------|----------|
| İleri gezinti | ✅ O(n) | ✅ O(n) |
| Geri gezinti | ❌ Mümkün değil | ✅ O(n) |
| Geriye silme | ❌ Mümkün değil | ✅ Mümkün |
| Alan kullanımı | 1 pointer | 2 pointer |
| Karmaşıklık | Daha basit | Daha karmaşık |

---

## 📊 Zaman Karmaşıklığı

| İşlem | Zaman |
|-------|--------|
| Başa ekleme | O(1) |
| Sona ekleme | O(1) |
| Arama | O(n) |
| Baştan silme | O(1) |
| Sondan silme | O(1) |
| Değer silme | O(n) |
| İleri/Geri listeleme | O(n) |

---

## 🔗 Öğrenilen Kavramlar

- **İki yönlü pointer** yapısı (Onceki, Sonraki)
- **Başı (Bas) ve sonu (Son)** işaretçileri yönetmek
- **Çift yönlü traversal** (ileriye ve geriye doğru)
- **Pointer manipülasyonu** ekleme/silme sırasında
- **Null pointer** kontrolleri

---

## 💾 Avantajlar ve Dezavantajlar

### ✅ Avantajlar
- Listenin her iki yönünden de erişim sağlıyor
- Belirli bir düğümden geriye doğru erişim yapabilir
- Daha esnek silme/ekleme işlemleri

### ❌ Dezavantajlar
- Daha fazla bellek kullanır (iki pointer)
- Ekleme/silme işlemleri daha karmaşık
- Pointer yönetimi dikkat gerektirir