from typing import ValuesView

def podzialPaczki(wagi, max_waga):
    for waga in wagi:
        if waga > max_waga:
            raise ValuesView(f"Blad: paczka o wadze {waga} przekracza maksymalna wage kursu ({max_waga} kg).")
    wagi_sorted = sorted(wagi, reverse=True)
    kursy = []

    for waga in wagi_sorted:
        dodano = False
        for kurs in kursy:
            if sum(kurs) + waga <= max_waga:
                kurs.append(waga)
                dodano = True
                break

        if not dodano:
            kursy.append([waga])
    return len(kursy), kursy

wagi = [20, 5, 8, 15, 10, 10, 7]
max_waga = 25

liczba_kursow, kursy = podzialPaczki(wagi, max_waga)
for i, kurs in enumerate(kursy, 1):
    print(f"Kurs {i}: {kurs} - suma wagi: {sum(kurs)} kg")
