# Hafta 1 — Temel Algoritmalar

Bu hafta 3 temel algoritma uygulaması yaptık:
1. **Dizideki sayıların toplamını bulma**
2. **Dizideki elemanın aranması (Binary Search)**
3. **Matris çarpımı**

---

## 📁 Dosya Yapısı

### Homework Dosyaları
- `homework1.py` — Dizideki sayıların toplamı
- `homework2.py` — Binary search (iteratif)
- `homework3.py` — Matris çarpımı

### Test Dosyaları
- `test_homework1.py` — Homework 1 testleri
- `test_homework2.py` — Homework 2 testleri (detaylı izleme ile)
- `test_homework3.py` — Homework 3 testleri

---

## 🚀 Hızlı Başlangıç

Terminal (PowerShell) içinde proje köküne gidin:

## 🚀 Hızlı Başlangıç

Terminal (PowerShell) içinde proje köküne gidin:

```powershell
cd "c:\Users\Casper\Documents\GitHub\mustafa-kemal-cingil"
```

### Tüm testleri çalıştırma

```powershell
# Homework 1 testi
python "Hafta-1\test_homework1.py"

# Homework 2 testi
python "Hafta-1\test_homework2.py"

# Homework 3 testi
python "Hafta-1\test_homework3.py"
```

### Demo çalıştırma

Her homework dosyası doğrudan çalıştırılabilir:

```powershell
python "Hafta-1\homework1.py"
python "Hafta-1\homework2.py"
python "Hafta-1\homework3.py"
```

---

## 📝 Homework Açıklamaları

### Homework 1: Dizideki Sayıların Toplamı

**Fonksiyon:** `array_sum(arr) -> int/float`

Bir dizideki tüm sayıların toplamını hesaplar.

**Örnek kullanım:**
```python
from homework1 import array_sum

numbers = [1, 2, 3, 4, 5]
total = array_sum(numbers)
print(total)  # 15
```

**Zaman karmaşıklığı:** O(n) — dizinin her elemanını bir kez gezer.

---

### Homework 2: Binary Search (Dizide Eleman Arama)

**Fonksiyon:** `binary_search(arr, target) -> int`

Sıralı bir dizide verilen değeri iteratif binary search ile arar.
- Bulursa: elemanın index'ini döner (0-tabanlı)
- Bulamazsa: `-1` döner

**Örnek kullanım:**
```python
from homework2 import binary_search

sorted_array = [1, 3, 5, 7, 9, 11]
index = binary_search(sorted_array, 7)
print(index)  # 3
```

**Önemli:**
- Dizi **mutlaka sıralı** olmalıdır (artan sırada)
- Indexler 0'dan başlar

**Zaman karmaşıklığı:** O(log n) — her adımda arama alanı yarıya iner.

---

### Homework 3: Matris Çarpımı

**Fonksiyon:** `matrix_multiply(A, B) -> List[List[float]]`

İki matrisi standart matris çarpımı kurallarına göre çarpar.

**Örnek kullanım:**
```python
from homework3 import matrix_multiply

A = [[1, 2], [3, 4]]
B = [[5, 6], [7, 8]]
C = matrix_multiply(A, B)
# C = [[19, 22], [43, 50]]
```

**Kurallar:**
- A matrisi `m × n` boyutunda ise
- B matrisi `n × p` boyutunda olmalıdır
- Sonuç `m × p` boyutunda bir matris olur
- A'nın sütun sayısı ile B'nin satır sayısı eşit olmalıdır

**Zaman karmaşıklığı:** O(m × n × p)

---
