import sys
import os
import random

# test dosyası ile aynı klasördeki module'ü import etmek için
sys.path.insert(0, os.path.dirname(__file__))
from binary_search import binary_search


def trace_binary_search(arr, target):
    lo = 0
    hi = len(arr) - 1
    step = 1
    print("\n--- Binary Search İzleme Başladı ---")
    print("Not: lo = aramanın sol sınırı (indeks), hi = aramanın sağ sınırı (indeks), mid = (lo+hi)//2 (orta indeks)")
    print("Karar mantığı: arr[mid] ile hedef karşılaştırılır. arr[mid] < hedef → sağ yarıya; arr[mid] > hedef → sol yarıya; eşitse bulundu.")

    while lo <= hi:
        mid = (lo + hi) // 2
        # gösterimi daha açıklayıcı yapıyom
        segment = arr[lo:hi+1]
        print(f"\nAdım {step}: Arama aralığı indeks [{lo}..{hi}] — elemanlar: {segment}")
        print(f"  Orta indeks: mid = {mid}, arr[mid] = {arr[mid]}")

        if arr[mid] == target:
            print(f"  Karar: arr[mid] == target ({arr[mid]} == {target}) → Bulundu (index {mid})")
            print("--- İzleme Bitti ---\n")
            return mid
        elif arr[mid] < target:
            print(f"  Karar: arr[mid] < target ({arr[mid]} < {target})")
            new_lo = mid + 1
            print(f"  => Aramayı sağ yarıya kaydırıyoruz. Yeni arama aralığı indeks [{new_lo}..{hi}]")
            lo = new_lo
        else:
            print(f"  Karar: arr[mid] > target ({arr[mid]} > {target})")
            new_hi = mid - 1
            print(f"  => Aramayı sol yarıya kaydırıyoruz. Yeni arama aralığı indeks [{lo}..{new_hi}]")
            hi = new_hi

        step += 1

    print("\nArama bitti: lo > hi oldu; aranan değer bu dizide yok.")
    print("Fonksiyon -1 döndü: bu, 'aranan değer dizide mevcut değil' anlamına gelir.")
    print("--- İzleme Bitti ---\n")
    return -1


def single_verbose_run():
    # rastgele dizi seçiyom ama tek olacak
    arr = sorted(random.randint(0, 50) for _ in range(10))
    # Eğer kullanıcı argument verilmişse onu kullanmaya çalışıyom
    if len(sys.argv) > 1:
        try:
            target = int(sys.argv[1])
        except ValueError:
            print("Argüman sayı olmalı; aranan değeri diziden seçeceğim.")
            target = random.choice(arr)
    else:
        # Varsayılan: aranan değeri diziden seç, böylece -1 alınmaz (keyf yaptım)
        target = random.choice(arr)

    # Eğer kullanıcı target verdi ve dizide yoksa, değeri diziye ekleyip sıralı hale getir
    if target not in arr:
        print(f"Not: Verilen aranan değer ({target}) dizide yok. Değeri diziye ekliyorum ve sıralıyorum.")
        arr.append(target)
        arr.sort()

    print("Dizi:", arr)
    print("Aranan:", target)

    res = trace_binary_search(arr, target)

    # Sonuç değerlendirmesi
    if res == -1:
        if target in arr:
            print("Sonuç: Başarısız — fonksiyon dizideki değeri bulamadı (beklenmiyor)")
        else:
            print("Sonuç: Başarılı — aranan değer dizide değil, -1 beklenen sonuç")
    else:
        print(f"Sonuç: Başarılı — aranan değer bulundu (index: {res})")


if __name__ == '__main__':
    single_verbose_run()
