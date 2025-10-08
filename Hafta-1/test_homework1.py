"""Test homework1.py - Dizideki sayıların toplamı"""

import sys
import os
import random

sys.path.insert(0, os.path.dirname(__file__))
from homework1 import array_sum


def test_homework1():
    print("=== Homework 1: Dizideki Sayıların Toplamı ===\n")
    
    # Test 1: Basit pozitif sayılar
    arr1 = [random.randint(1, 10) for _ in range(5)]
    expected1 = sum(arr1)
    result1 = array_sum(arr1)
    print(f"Test 1:")
    print(f"  Dizi: {arr1}")
    print(f"  Beklenen toplam: {expected1}")
    print(f"  Hesaplanan toplam: {result1}")
    print(f"  Durum: {'✓ Başarılı' if result1 == expected1 else '✗ Başarısız'}\n")
    
    # Test 2: Negatif sayılarla
    arr2 = [-5, 10, -3, 8, 2]
    expected2 = sum(arr2)
    result2 = array_sum(arr2)
    print(f"Test 2:")
    print(f"  Dizi: {arr2}")
    print(f"  Beklenen toplam: {expected2}")
    print(f"  Hesaplanan toplam: {result2}")
    print(f"  Durum: {'✓ Başarılı' if result2 == expected2 else '✗ Başarısız'}\n")
    
    # Test 3: Boş dizi
    arr3 = []
    expected3 = 0
    result3 = array_sum(arr3)
    print(f"Test 3:")
    print(f"  Dizi: {arr3}")
    print(f"  Beklenen toplam: {expected3}")
    print(f"  Hesaplanan toplam: {result3}")
    print(f"  Durum: {'✓ Başarılı' if result3 == expected3 else '✗ Başarısız'}\n")
    
    # Test 4: Tek eleman
    arr4 = [42]
    expected4 = 42
    result4 = array_sum(arr4)
    print(f"Test 4:")
    print(f"  Dizi: {arr4}")
    print(f"  Beklenen toplam: {expected4}")
    print(f"  Hesaplanan toplam: {result4}")
    print(f"  Durum: {'✓ Başarılı' if result4 == expected4 else '✗ Başarısız'}\n")


if __name__ == '__main__':
    test_homework1()
