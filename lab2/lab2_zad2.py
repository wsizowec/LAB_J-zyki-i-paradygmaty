import numpy as np

def validate_addition(matrix1, matrix2):
    if matrix1.shape != matrix2.shape:
        raise ValueError("Macierze muszą mieć takie same wymiary do dodawania.")
    return True

def validate_multiplication(matrix1, matrix2):
    if matrix1.shape[1] != matrix2.shape[0]:
        raise ValueError("Liczba kolumn pierwszej macierzy musi być równa liczbie wierszy drugiej macierzy.")
    return True

def wykonaj_operacje(operacja, matrix1, matrix2=None):
    if operacja == 'dodaj':
        if matrix2 is None:
            raise ValueError("Do dodawania potrzeba dwóch macierzy.")
        validate_addition(matrix1, matrix2)
        return matrix1 + matrix2
    
    elif operacja == 'mnoz':
        if matrix2 is None:
            raise ValueError("Do mnożenia potrzeba dwóch macierzy.")
        validate_multiplication(matrix1, matrix2)
        return np.dot(matrix1, matrix2)
    
    elif operacja == 'transponuj':
        return np.transpose(matrix1)
    
    else:
        raise ValueError(f"Nieznana operacja: {operacja}")

macierz1 = np.array([[1, 2], [3, 4], [5, 6]])
macierz2 = np.array([[7, 8], [9, 10]])

try:
    wynik_dodawania = wykonaj_operacje('dodaj', macierz1, macierz2)
    print("Wynik dodawania:", wynik_dodawania)
except ValueError as e:
    print(e)

try:
    wynik_mnozenia = wykonaj_operacje('mnoz', macierz1, macierz2)
    print("Wynik mnożenia:", wynik_mnozenia)
except ValueError as e:
    print(e)

transponowana_macierz = wykonaj_operacje('transponuj', macierz1)
print("Transponowana macierz:\n", transponowana_macierz)
