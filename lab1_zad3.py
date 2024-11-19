from functools import reduce

def optymalizacja_zadan_proceduralnie(zadania):
    zadania.sort(key=lambda x: x[1])  
    czas = 0
    suma_oczekiwania = 0
    kolejnosc = []
    for czas_trwania, nagroda in zadania:
        czas += czas_trwania
        suma_oczekiwania += czas
        kolejnosc.append((czas_trwania, nagroda))
    return kolejnosc, suma_oczekiwania

def optymalizacja_zadan_funkcyjnie(zadania):
    zadania_posortowane = sorted(zadania, key=lambda x: x[1])
    czas = 0

    def zaktualizuj(czas_sumy, zadanie):
        czas, suma_oczekiwania = czas_sumy
        czas += zadanie[0]
        suma_oczekiwania += czas
        return czas, suma_oczekiwania

    _, suma_oczekiwania = reduce(zaktualizuj, zadania_posortowane, (0, 0))
    return zadania_posortowane, suma_oczekiwania


zadania = [(3, 50), (1, 20), (2, 40), (4, 70)]  # (czas wykonania, nagroda)

kolejnosc_proc, czas_proc = optymalizacja_zadan_proceduralnie(zadania)
print("Optymalna kolejnosc zadan (proceduralnie):", kolejnosc_proc)
print("Calkowity czas oczekiwania (proceduralnie):", czas_proc)

kolejnosc_funk, czas_funk = optymalizacja_zadan_funkcyjnie(zadania)
print("Optymalna kolejnosc zadan (funkcyjnie):", kolejnosc_funk)
print("Calkowity czas oczekiwania (funkcyjnie):", czas_funk)
