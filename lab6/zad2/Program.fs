//Zadanie 2. Sprawdzenie palindromu

open System

let isPalindrome (text: string) =
    let cleanedText = text.Replace(" ", "").ToLower()
    let reversedText = new string(cleanedText.ToCharArray() |> Array.rev)
    if cleanedText = reversedText then
        printfn "To jest palindrom."
    else
        printfn "To nie jest palindrom."

printfn "Wprowadź tekst:"
let userInput = Console.ReadLine()
isPalindrome userInput
