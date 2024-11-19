from functools import reduce

def plecak_proceduralnie(pojemnosc, przedmioty):
    n = len(przedmioty)
    dp = [[0] * (pojemnosc + 1) for _ in range(n + 1)]

    for i in range(1, n + 1):
        waga, wartosc = przedmioty[i - 1]
        for c in range(pojemnosc + 1):
            if waga <= c:
                dp[i][c] = max(dp[i - 1][c], dp[i - 1][c - waga] + wartosc)
            else:
                dp[i][c] = dp[i - 1][c]

    wynik = []
    c = pojemnosc
    for i in range(n, 0, -1):
        if dp[i][c] != dp[i - 1][c]:
            wynik.append(przedmioty[i - 1])
            c -= przedmioty[i - 1][0]

    return dp[n][pojemnosc], wynik

def plecak_funkcyjnie(pojemnosc, przedmioty):
    def knapsack(n, c, memo):
        if n == 0 or c == 0:
            return 0, []
        if (n, c) in memo:
            return memo[(n, c)]

        waga, wartosc = przedmioty[n - 1]

        if waga > c:
            wynik = knapsack(n - 1, c, memo)
        else:
            bez_przedmiotu = knapsack(n - 1, c, memo)
            z_przedmiotem = knapsack(n - 1, c - waga, memo)
            z_przedmiotem = (z_przedmiotem[0] + wartosc, z_przedmiotem[1] + [przedmioty[n - 1]])

            wynik = max(bez_przedmiotu, z_przedmiotem, key=lambda x: x[0])

        memo[(n, c)] = wynik
        return wynik

    wartosc, wybrane_przedmioty = knapsack(len(przedmioty), pojemnosc, {})
    return wartosc, wybrane_przedmioty


przedmioty = [(2, 3), (3, 4), (4, 5), (5, 8)]  
pojemnosc = 8

wartosc_proc, wybrane_proc = plecak_proceduralnie(pojemnosc, przedmioty)
print("Proceduralne podejście:")
print("Maksymalna wartość:", wartosc_proc)
print("Wybrane przedmioty:", wybrane_proc)

wartosc_funk, wybrane_funk = plecak_funkcyjnie(pojemnosc, przedmioty)
print("\nFunkcyjne podejście:")
print("Maksymalna wartość:", wartosc_funk)
print("Wybrane przedmioty:", wybrane_funk)
