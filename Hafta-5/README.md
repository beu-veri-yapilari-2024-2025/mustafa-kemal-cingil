# Hafta 5 — İnfix, Prefix, Postfix Dönüşümleri

Bu hafta C# ile **matematiksel ifadelerin farklı notasyonlarına dönüştürülmesini** öğrendik.

---

## 📋 Ödev Açıklaması

Matematiksel ifadeler üç farklı şekilde yazılabilir:
- **Infix** (işlem ortada): `3 + 4 * 2` (Normal yazdığımız şekil)
- **Prefix** (işlem başında): `+ 3 * 4 2` (Polish Notation)
- **Postfix** (işlem sonunda): `3 4 2 * +` (Reverse Polish Notation)

Bu hafta bu üç notasyon arasında **dönüşüm yapan** bir sistem uyguladık.

### Gereksinimler
- ✅ **Infix → Postfix** dönüşümü
- ✅ **Infix → Prefix** dönüşümü
- ✅ **Postfix → Infix** dönüşümü
- ✅ **Operatör önceliği** (precedence) yönetimi
- ✅ **Parantez** desteği
- ✅ **Sağ ilişkilendirme** (right associativity) işlemi

---

## 📁 Dosya Yapısı

- `infix_prefix_postfix.cs` — Dönüşüm algoritmaları (C#)

---

## 🚀 Nasıl Çalıştırılır

```powershell
# Proje köküne git
cd "c:\Users\Casper\Documents\GitHub\mustafa-kemal-cingil\Hafta-5"

# Derleme
csc infix_prefix_postfix.cs

# Çalıştırma
.\infix_prefix_postfix.exe
```

---

## 🔍 Algoritma Açıklaması

### 1. Operatör Önceliği (Precedence)

```
^ (Üs alma)        → Öncelik: 3 (Sağ ilişkili)
* / (Çarp/Böl)     → Öncelik: 2 (Sol ilişkili)
+ - (Topla/Çıkar)  → Öncelik: 1 (Sol ilişkili)
```

### 2. Infix → Postfix (Shunting Yard Algoritması)

**Adımlar:**
1. Operand'ı (sayı/harf) çıktıya yaz
2. `(` görürsen Stack'e koy
3. `)` görürsen Stack'in `(` bulana kadar elemanlarını çıktıya yaz
4. Operator görürsen:
   - Stack'in tepesindeki operatorun önceliği daha yüksek/eşitse onları çıktıya yaz
   - Sonra bu operatörü Stack'e koy
5. Sonunda Stack'i boşalt

**Örnek:**
```
Infix:   3 + 4 * 2
         
Step 1:  Çıktı: 3
Step 2:  Stack: +
Step 3:  Çıktı: 3 4
Step 4:  Stack: + *
Step 5:  Çıktı: 3 4 2
Step 6:  Çıktı: 3 4 2 * +

Postfix: 3 4 2 * +
```

### 3. Infix → Prefix

**Yöntem:**
1. Infix ifadeyi ters çevir
2. `(` ve `)` yerini değiştir
3. Infix → Postfix uygula
4. Sonucu ters çevir

### 4. Postfix → Infix

**Adımlar:**
1. Postfix'i soldan sağa oku
2. Operand'ları Stack'e koy
3. Operator görürse:
   - Stack'ten 2 operand çıkar
   - `(operand1 operator operand2)` yap
   - Bunu Stack'e koy
4. Sonunda Stack'te tek eleman kalır

---

## 💡 Kod Yapısı

```csharp
class InfixPrefixPostfixConverter
{
    // Operatör önceliğini belirtir
    static int GetPrecedence(char op)
    
    // Operatörün sağ ilişkili olup olmadığını kontrol eder
    static bool IsRightAssociative(char op)
    
    // Infix → Postfix (Shunting Yard)
    static string InfixToPostfix(string infix)
    
    // Infix → Prefix
    static string InfixToPrefix(string infix)
    
    // Postfix → Infix
    static string PostfixToInfix(string postfix)
}
```

---

## 📊 Örnek Dönüşümler

### Örnek 1: Basit İfade
```
Infix:    a + b
Postfix:  a b +
Prefix:   + a b
```

### Örnek 2: Operatör Önceliği
```
Infix:    a + b * c
Postfix:  a b c * +
Prefix:   + a * b c
```

### Örnek 3: Parantez İle
```
Infix:    (a + b) * c
Postfix:  a b + c *
Prefix:   * + a b c
```

### Örnek 4: Üs Alma (Sağ İlişkili)
```
Infix:    a ^ b ^ c
Postfix:  a b c ^ ^
Prefix:   ^ a ^ b c

NOT: a ^ b ^ c = a ^ (b ^ c) şeklinde hesaplanır!
```

---

## 🎯 Kullanım Alanları

1. **Derleyiciler** — İfadeleri parse ederken
2. **Hesap Makineleri** — Postfix daha hızlı hesaplanır
3. **SQL Sorguları** — Koşulların değerlendirilmesi
4. **Matematiksel Motorlar** — WolframAlpha gibi
5. **Data Structures** — Stack temelli ifade değerlendirmesi

---

## 📋 Zaman Karmaşıklığı

| İşlem | Zaman | Alan |
|-------|-------|------|
| Infix → Postfix | O(n) | O(n) |
| Infix → Prefix | O(n) | O(n) |
| Postfix → Infix | O(n) | O(n) |
| Stack işlemleri | O(1) | O(n) |

---

## 🔗 Öğrenilen Kavramlar

- **Stack** veri yapısının kullanımı
- **Operatör önceliği** (precedence) ve **ilişkilendirme** (associativity)
- **Shunting Yard Algoritması** (Dijkstra)
- **Recursive descent parsing**
- **Polish Notation** (Prefix) ve **Reverse Polish Notation** (Postfix)
- **İfade değerlendirmesi** (Expression Evaluation)

---

## 💡 İpuçları

- **Stack** kullanmadan bu dönüşümleri yapamayız
- Postfix notasyonu **bilgisayarlar tarafından** daha hızlı hesaplanır
- Infix notasyonu **insanlar tarafından** daha kolay anlaşılır
- Operatör önceliğini yanlış almak sonucu tamamen değiştirir!
- Sağ/sol ilişkilendirme üs alma gibi işlemlerde önemlidir