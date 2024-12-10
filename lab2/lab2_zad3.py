def analiza_danych(dane):
    liczby = list(filter(lambda x: isinstance(x, (int, float)), dane))
    napisy = list(filter(lambda x: isinstance(x, str), dane))
    krotki = list(filter(lambda x: isinstance(x, tuple), dane))

    max_liczba = max(liczby, default=None)

    najdluzszy_napis = max(napisy, key=len, default=None)

    najwieksza_krotka = max(krotki, key=len, default=None)

    return max_liczba, najdluzszy_napis, najwieksza_krotka


dane = [42, "Hello", 103.14, ("apple", "banana"), "Python", (1, 2, 3, 4), 100]

max_liczba, najdluzszy_napis, najwieksza_krotka = analiza_danych(dane)

print(f"Największa liczba: {max_liczba}")
print(f"Najdłuższy napis: {najdluzszy_napis}")
print(f"Krotka o największej liczbie elementów: {najwieksza_krotka}")
