 //Zadanie 1
    let rec fibRek n =
        if n <= 0 then 0
        elif n = 1 then 1
        else fibRek (n - 1) + fibRek (n - 2)

    let rec fibRekTail n a b =
        if n = 0 then a
        elif n = 1 then b
        else fibRekTail (n - 1) b (a + b)

    [<EntryPoint>]
    let main argv = 
        let wynik3 = fibRekTail 10 0 1
        printf "Fib: %d\n" wynik3
        0