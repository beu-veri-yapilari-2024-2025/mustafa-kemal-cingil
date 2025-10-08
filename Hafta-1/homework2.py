"""Homework 2: Dizideki Elemanın Aranması (Binary Search)
"""

from typing import List


def binary_search(arr: List[int], target: int) -> int:
    lo, hi = 0, len(arr) - 1
    while lo <= hi:
        mid = (lo + hi) // 2
        if arr[mid] == target:
            return mid
        if arr[mid] < target:
            lo = mid + 1
        else:
            hi = mid - 1
    return -1


if __name__ == "__main__":
    # Basit demo
    import random
    
    sample = sorted(random.randint(0, 30) for _ in range(10))
    target = random.choice(sample)  # Diziden bir değer seç
    
    print("Dizi:", sample)
    print("Aranan:", target)
    print("Sonuç index:", binary_search(sample, target))
