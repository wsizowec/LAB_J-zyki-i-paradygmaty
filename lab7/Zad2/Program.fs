open System
open System.Collections.Generic

type BankAccount(accountNumber: string, initialBalance: decimal) =
    let mutable balance = initialBalance

    member this.AccountNumber = accountNumber
    member this.Balance = balance

    member this.Deposit(amount: decimal) =
        if amount <= 0m then
            printfn "Kwota musi być większa niż zero!"
        else
            balance <- balance + amount
            printfn "Wpłata %.2f na konto %s. Aktualne saldo: %.2f" amount this.AccountNumber balance

    member this.Withdraw(amount: decimal) =
        if amount <= 0m then
            printfn "Kwota musi być większa niż zero!"
        elif amount > balance then
            printfn "Brak wystarczających środków na koncie!"
        else
            balance <- balance - amount
            printfn "Wypłata %.2f z konta %s. Aktualne saldo: %.2f" amount this.AccountNumber balance

type Bank() =
    let mutable accounts = Dictionary<string, BankAccount>()

    member this.CreateAccount(accountNumber: string, initialBalance: decimal) =
        if accounts.ContainsKey(accountNumber) then
            printfn "Konto o numerze %s już istnieje!" accountNumber
        else
            let newAccount = BankAccount(accountNumber, initialBalance)
            accounts.Add(accountNumber, newAccount)
            printfn "Konto %s zostało pomyślnie utworzone z początkowym saldem %.2f." accountNumber initialBalance

    member this.GetAccount(accountNumber: string) =
        if accounts.ContainsKey(accountNumber) then
            let account = accounts.[accountNumber]
            printfn "Numer konta: %s, Saldo: %.2f" account.AccountNumber account.Balance
            Some(account) 
        else
            printfn "Konto o numerze %s nie istnieje!" accountNumber
            None  

    member this.UpdateAccount(accountNumber: string, newBalance: decimal) =
        match this.GetAccount(accountNumber) with
        | Some(account) -> account.Deposit(newBalance - account.Balance)  
        | None -> printfn "Nie udało się zaktualizować konta o numerze %s." accountNumber

    member this.DeleteAccount(accountNumber: string) =
        if accounts.ContainsKey(accountNumber) then
            accounts.Remove(accountNumber) |> ignore
            printfn "Konto o numerze %s zostało usunięte." accountNumber
        else
            printfn "Konto o numerze %s nie istnieje!" accountNumber

let readDecimalInput prompt =
    let rec loop () =
        printf "%s" prompt
        match Decimal.TryParse(Console.ReadLine()) with
        | (true, value) -> value
        | (false, _) ->
            printfn "Błędny wpis, proszę wprowadzić liczbę!"
            loop ()  
    loop()

[<EntryPoint>]
let main argv =
    let bank = Bank()

    let rec showMenu () =
        printfn "\nMenu:"
        printfn "1. Utwórz konto"
        printfn "2. Zobacz konto"
        printfn "3. Wpłać na konto"
        printfn "4. Wypłać z konta"
        printfn "5. Zaktualizuj saldo"
        printfn "6. Usuń konto"
        printfn "7. Wyjście"

        printf "Wybierz opcję (1-7): "
        match Console.ReadLine() with
        | "1" -> 
            printf "Podaj numer konta: "
            let accountNumber = Console.ReadLine()
            let initialBalance = readDecimalInput "Podaj początkowe saldo: "
            bank.CreateAccount(accountNumber, initialBalance)
            showMenu()  
        | "2" -> 
            printf "Podaj numer konta: "
            let accountNumber = Console.ReadLine()
            bank.GetAccount(accountNumber)
            showMenu()
        | "3" -> 
            printf "Podaj numer konta, na które chcesz wpłacić: "
            let accountNumber = Console.ReadLine()
            match bank.GetAccount(accountNumber) with
            | Some(account) -> 
                let depositAmount = readDecimalInput "Podaj kwotę wpłaty: "
                account.Deposit(depositAmount)
            | None -> printfn "Nie udało się znaleźć konta!"
            showMenu()
        | "4" -> 
            printf "Podaj numer konta, z którego chcesz wypłacić: "
            let accountNumber = Console.ReadLine()
            match bank.GetAccount(accountNumber) with
            | Some(account) -> 
                let withdrawAmount = readDecimalInput "Podaj kwotę wypłaty: "
                account.Withdraw(withdrawAmount)
            | None -> printfn "Nie udało się znaleźć konta!"
            showMenu()
        | "5" -> 
            printf "Podaj numer konta, którego saldo chcesz zaktualizować: "
            let accountNumber = Console.ReadLine()
            let newBalance = readDecimalInput "Podaj nowe saldo: "
            bank.UpdateAccount(accountNumber, newBalance)
            showMenu()
        | "6" -> 
            printf "Podaj numer konta, które chcesz usunąć: "
            let accountNumber = Console.ReadLine()
            bank.DeleteAccount(accountNumber)
            showMenu()
        | "7" -> 
            printfn "Wychodzenie z programu..."
        | _ -> 
            printfn "Błędny wybór, spróbuj ponownie."
            showMenu()

    showMenu()


    0 
