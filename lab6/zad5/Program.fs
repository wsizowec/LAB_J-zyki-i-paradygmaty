//Zadanie 5: Znajdowanie najdłuższego słowa

open System

let findLongestWords (text: string) =
    let words = text.Split([|' '|], StringSplitOptions.RemoveEmptyEntries)
    let maxLength = words |> Array.maxBy String.length |> String.length
    let longestWords = words |> Array.filter (fun word -> word.Length = maxLength)

    printfn "Najdłuższe słowa: %A" longestWords
    printfn "Długość najdłuższych słów: %d" maxLength

printfn "Wprowadź tekst:"
let userInput = Console.ReadLine()
findLongestWords userInput
