//Zadanie 3: Usuwanie duplikatów
open System

let removeDuplicates (words: string list) =
    words |> List.distinct

printfn "Wprowadź słowa oddzielone spacjami:"
let userInput = Console.ReadLine()
let wordsList = userInput.Split(' ') |> List.ofArray
let uniqueWords = removeDuplicates wordsList

let result = String.Join(" ", uniqueWords)
printfn "Unikalne słowa: %s" result
