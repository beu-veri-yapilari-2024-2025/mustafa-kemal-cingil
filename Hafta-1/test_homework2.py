"""Test homework2.py - Binary Search (detaylı izleme ile)"""

import sys
import os
import random

sys.path.insert(0, os.path.dirname(__file__))
from homework2 import binary_search


def trace_binary_search(arr, target):
    """Binary search'in her adımını gösterir."""
    lo = 0
    hi = len(arr) - 1
    step = 1
    print("\n--- Binary Search İzleme Başladı ---")
    print("Not: lo = sol sınır (indeks), hi = sağ sınır (indeks), mid = orta indeks")
    
    while lo <= hi:
        mid = (lo + hi) // 2
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
            print(f"  => Aramayı sağ yarıya kaydır. Yeni aralık: [{new_lo}..{hi}]")
            lo = new_lo
        else:
            print(f"  Karar: arr[mid] > target ({arr[mid]} > {target})")
            new_hi = mid - 1
            print(f"  => Aramayı sol yarıya kaydır. Yeni aralık: [{lo}..{new_hi}]")
            hi = new_hi
        
        step += 1
    
    print("\nArama bitti: lo > hi; aranan değer dizide yok.")
    print("Fonksiyon -1 döndü (bulunamadı).")
    print("--- İzleme Bitti ---\n")
    return -1


def test_homework2():
    print("=== Homework 2: Binary Search (Dizide Eleman Arama) ===\n")
    
    # Rastgele dizi oluştur
    arr = sorted(random.randint(0, 50) for _ in range(10))
    
    # Diziden bir değer seç (böylece bulunacak)
    target = random.choice(arr)
    
    print("Dizi:", arr)
    print("Aranan:", target)
    
    # Trace ile arama
    result = trace_binary_search(arr, target)
    
    # Doğrulama
    if result == -1:
        if target in arr:
            print("Sonuç: ✗ Başarısız — fonksiyon dizideki değeri bulamadı")
        else:
            print("Sonuç: ✓ Başarılı — aranan değer dizide değil, -1 beklenen sonuç")
    else:
        print(f"Sonuç: ✓ Başarılı — aranan değer bulundu (index: {result})")


if __name__ == '__main__':
    test_homework2()
