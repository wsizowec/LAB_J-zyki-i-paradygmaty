class Pojazd:
    def __init__(self, make):
        self.make = make
    def opis(self):
        return f"Pojazd marki: {self.make}"


class Car(Pojazd):
 # Konstruktor - definiowanie atrybutów
    def __init__(self, make, model, year):
        super().__init__(make)
        self.model = model # Model samochodu
        self.year = year # Rok produkcji

    def opis(self):
        return f"Samochod {self.make} {self.model} {self.year}"

#tworzenie obiektu
samochod1 = Car("Toyota", "Corolla", "2020")
print(samochod1.opis())