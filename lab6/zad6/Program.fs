//Zadanie 6. Wyszukiwanie i zamiana

open System

let searchAndReplace (text: string) (oldWord: string) (newWord: string) =
    if text.Contains(oldWord) then
        let modifiedText = text.Replace(oldWord, newWord)
        printfn "Zmodyfikowany tekst:\n%s" modifiedText
    else
        printfn "Nie znaleziono słowa '%s' w tekście." oldWord

printfn "Wprowadź tekst:"
let userInput = Console.ReadLine()

printfn "Wprowadź słowo do wyszukania:"
let wordToSearch = Console.ReadLine()

printfn "Wprowadź nowe słowo:"
let wordToReplace = Console.ReadLine()

searchAndReplace userInput wordToSearch wordToReplace
