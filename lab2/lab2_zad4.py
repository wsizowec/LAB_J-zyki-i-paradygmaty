import numpy as np
from functools import reduce

def operacja_macierzy(macierze, operacja):
    """
    Funkcja łącząca macierze za pomocą operacji.
    
    :param macierze: lista macierzy numpy.
    :param operacja: funkcja operacji (np. np.add dla sumy, np.dot dla iloczynu).
    :return: wynik operacji na wszystkich macierzach.
    """
    return reduce(operacja, macierze)

# Przykładowe macierze
macierz1 = np.array([[1, 2], [3, 4]])
macierz2 = np.array([[5, 6], [7, 8]])
macierz3 = np.array([[9, 10], [11, 12]])

macierze = [macierz1, macierz2, macierz3]

# suma macierzy
wynik_suma = operacja_macierzy(macierze, np.add)
print("Wynik sumy macierzy:")
print(wynik_suma)

# iloczyn macierzy
wynik_iloczyn = operacja_macierzy(macierze, np.dot)
print("\nWynik iloczynu macierzy:")
print(wynik_iloczyn)
