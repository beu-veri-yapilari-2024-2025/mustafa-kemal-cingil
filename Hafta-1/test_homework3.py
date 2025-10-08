"""Test homework3.py - Matris çarpımı"""

import sys
import os
import random

sys.path.insert(0, os.path.dirname(__file__))
from homework3 import matrix_multiply, print_matrix


def test_homework3():
    print("=== Homework 3: Matris Çarpımı ===\n")
    
    # Test 1: 2x3 ve 3x2 matris çarpımı
    print("Test 1: 2x3 matris × 3x2 matris = 2x2 matris\n")
    
    A = [[random.randint(1, 5) for _ in range(3)] for _ in range(2)]
    B = [[random.randint(1, 5) for _ in range(2)] for _ in range(3)]
    
    print_matrix(A, "Matris A (2x3)")
    print_matrix(B, "Matris B (3x2)")
    
    try:
        C = matrix_multiply(A, B)
        print_matrix(C, "Sonuç C = A × B (2x2)")
        print("Durum: ✓ Başarılı\n")
    except Exception as e:
        print(f"Durum: ✗ Hata: {e}\n")
    
    print("\nTest 2: Basit kontrol edilebilir örnek\n")
    
    A2 = [[1, 2], [3, 4]]
    B2 = [[5, 6], [7, 8]]
    expected = [[19, 22], [43, 50]]
    
    print_matrix(A2, "Matris A (2x2)")
    print_matrix(B2, "Matris B (2x2)")
    
    try:
        C2 = matrix_multiply(A2, B2)
        print_matrix(C2, "Sonuç C = A × B (2x2)")
        print_matrix(expected, "Beklenen Sonuç")
        
        if C2 == expected:
            print("\nDurum: ✓ Başarılı — sonuç beklenen ile eşleşiyor\n")
        else:
            print("\nDurum: ✗ Başarısız — sonuç beklenen ile eşleşmiyor\n")
    except Exception as e:
        print(f"Durum: ✗ Hata: {e}\n")
    
    # Test 3: Uyumsuz boyutlar
    print("\nTest 3: Uyumsuz boyutlar (hata bekleniyor)\n")
    
    A3 = [[1, 2], [3, 4]]
    B3 = [[1, 2, 3]]
    
    print_matrix(A3, "Matris A (2x2)")
    print_matrix(B3, "Matris B (1x3)")
    
    try:
        C3 = matrix_multiply(A3, B3)
        print("Durum: ✗ Başarısız — hata fırlatılmalıydı\n")
    except ValueError as e:
        print(f"Durum: ✓ Başarılı — beklenen hata alındı: {e}\n")


if __name__ == '__main__':
    test_homework3()
