//Zadanie 1. Liczba słów i znaków

open System

let countWordsAndChars (text: string) =
    let words = text.Split([|' '|], StringSplitOptions.RemoveEmptyEntries)
    let numWords = words.Length
    let numChars = text.Replace(" ", "").Length
    printfn "Liczba słów: %d" numWords
    printfn "Liczba znaków (bez spacji): %d" numChars

printfn "Wprowadź tekst:"
let userInput = Console.ReadLine()
countWordsAndChars userInput
