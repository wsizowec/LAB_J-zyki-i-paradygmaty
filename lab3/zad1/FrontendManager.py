# frontend_manager.py
from tkinter.font import names

from EmployeesManager import EmployeesManager
from Employee import Employee

class FrontendManager(EmployeesManager):
    def __init__(self):
        self.manager = EmployeesManager()

    def mainMenu(self):
        print("\n Menu Zarządzania")
        print("1. Dodaj nowego pracownika")
        print("2. Wyświetl wszystkich pracownikow")
        print("3. Usuń pracowników w przediale wiekowym")
        print("4. Znajdz pracownika po Imię i Nazwisku")
        print("5. Zaktualizuj zarobki pracownika")
        print("6. Exit")

    def getEmployeeDetails(self):
        name = input("Wprowadż Imię i Nawisko pracownika: ")
        age = int(input("Wprowadż wiek pracownika: "))
        salary = int(input("Wprowadż zarobki pracownika: "))
        return Employee(name, age, salary)

    def start(self):
        while True:
            self.mainMenu()
            choice = input("Wybierż opcję:")

            if choice == '1':
                employee = self.getEmployeeDetails()
                self.manager.add_employee(employee)
            elif choice == '2':
                self.manager.show_employees()
            elif choice == '3':
                min_age = int(input("Wprowadż minimalny Wiek: "))
                max_age = int(input("Wprowadż maxsymalny Wiek: "))
                self.manager.remove_employees_by_age_range(min_age, max_age)
            elif choice == '4':
                name = input("Podaj nazwisko pracownika: ")
                self.manager.find_employee_by_name(name)
            elif choice == '5':
                name = input("Podaj imie i nazwisko pracownika, którego zarobki chcesz zmienić: ")
                newZarobki = int(input("Podaj nowe zarobki pracownika: "))
                self.manager.update_salary_by_name(name, newZarobki)
            elif choice == '6':
                print('Sukces wylogowania z systemu.')
                break
            else:
                print("Wybrałeś nie poprawną opcję, skorzystaj z menu.")