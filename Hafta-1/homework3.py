"""Homework 3: Matris Çarpımı
"""

from typing import List


def matrix_multiply(A: List[List[float]], B: List[List[float]]) -> List[List[float]]:
    # Boyut kontrolü
    if len(A) == 0 or len(B) == 0:
        raise ValueError("Matrisler boş olamaz")
    
    m = len(A)          # A'nın satır sayısı
    n = len(A[0])       # A'nın sütun sayısı
    n_b = len(B)        # B'nin satır sayısı
    p = len(B[0])       # B'nin sütun sayısı
    
    if n != n_b:
        raise ValueError(f"Matris boyutları uyumsuz: A({m}x{n}) ve B({n_b}x{p})")
    
    # Sonuç matrisi (m x p)
    result = [[0 for _ in range(p)] for _ in range(m)]
    
    # Çarpma işlemi
    for i in range(m):
        for j in range(p):
            for k in range(n):
                result[i][j] += A[i][k] * B[k][j]
    
    return result


def print_matrix(matrix: List[List[float]], name: str = "Matris"):
    """Matrisi güzel formatta yazdırır."""
    print(f"\n{name}:")
    for row in matrix:
        print("  ", row)


if __name__ == "__main__":
    # Basit demo
    import random
    
    # 2x3 matris
    A = [[random.randint(1, 5) for _ in range(3)] for _ in range(2)]
    
    # 3x2 matris
    B = [[random.randint(1, 5) for _ in range(2)] for _ in range(3)]
    
    print_matrix(A, "Matris A (2x3)")
    print_matrix(B, "Matris B (3x2)")
    
    # Çarpım
    C = matrix_multiply(A, B)
    print_matrix(C, "Sonuç C = A × B (2x2)")
