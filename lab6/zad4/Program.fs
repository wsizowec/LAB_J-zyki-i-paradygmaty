//Zadanie 4: Zmiana formatu tekstu

open System

let formatText (text: string) =
    let parts = text.Split(';') |> Array.map (fun s -> s.Trim())
    if parts.Length = 3 then
        let firstName = parts.[0]
        let lastName = parts.[1]
        let age = parts.[2]
        printfn "%s, %s (%s lat)" lastName firstName age
    else
        printfn "Niepoprawny format danych."

printfn "Wprowadź tekst w formacie 'imię; nazwisko; wiek':"
let userInput = Console.ReadLine()
formatText userInput
