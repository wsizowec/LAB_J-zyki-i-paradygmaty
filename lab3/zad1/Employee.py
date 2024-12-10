class Employee:
    def __init__(self, name, age, salary):
        self.name = name
        self.age = age
        self.salary = salary

    def info(self):
        return f"Pracownik: \t{self.name} \t{self.age} lat(a) \t{self.salary} zł"

    def newZarobki(self, newZarobki):
        self.salary = newZarobki

#tworzenie obiektu
# pracownik1 = Employee("Ivan", 22, 4500)
# print(pracownik1.info())
