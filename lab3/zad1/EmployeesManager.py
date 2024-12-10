from zad1.Employee import Employee


class EmployeesManager(Employee):
    def __init__(self):
        self.employees = []

    def add_employee(self, employee):
        """Dodaje nowego pracownika do listy."""
        self.employees.append(employee)

    def show_employees(self):
        """Wyświetla listę wszystkich pracowników."""
        if not self.employees:
            print("Brak wyników")
        for employee in self.employees:
            print(employee.info())

    def remove_employees_by_age_range(self, min_age, max_age):
        """Usuwa pracowników w podanym przedziale wiekowym."""
        self.employees = [emp for emp in self.employees if not (min_age <= emp.age <= max_age)]

    def find_employee_by_name(self, name):
        foundEmployee = [emp for emp in self.employees if emp.name.lower() == name.lower()]
        if foundEmployee:
                for employee in foundEmployee:
                    print(employee.info())
        else:
            print(f"Nie znaleziono pracownika o imieniu i nazwisku {name}.")


    def update_salary_by_name(self, name, newZarobki):
        """Aktualizuje wynagrodzenie pracownika według jego imienia i nazwiska."""
        for emp in self.employees:
            if emp.name == name:
                emp.salary = newZarobki
                print(f"Wynagrodzenie pracownika {name} zostało zaktualizowane do {newZarobki} zł.")
        return "Pracownik o takim imieniu i nazwisku nie istnieje."