"""Homework 1: Dizideki Sayıların Toplamını Bulma
"""

from typing import List, Union


def array_sum(arr: List[Union[int, float]]) -> Union[int, float]:
    total = 0
    for num in arr:
        total += num
    return total


if __name__ == "__main__":
    # Basit demo
    import random
    
    sample = [random.randint(1, 20) for _ in range(8)]
    print("Dizi:", sample)
    print("Toplam:", array_sum(sample))
    print()
    
    # Negatif sayılarla örnek
    sample2 = [-5, 10, -3, 8, 2]
    print("Dizi:", sample2)
    print("Toplam:", array_sum(sample2))
