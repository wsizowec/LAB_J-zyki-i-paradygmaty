from abc import ABC, abstractmethod

class Zwierze(ABC):
    @abstractmethod
    def dzwiek(self):
        pass

class Lew(Zwierze):
    def dzwiek(self):
        return f"Lew wydaje głos"

lew = Lew()
print(lew.dzwiek())