// Zadanie 5. Implementacja algorytmu QuickSort

printfn "============================="
printfn "Część 1 (wersja rekurencyjna)"

let rec quickSort (arr: 'a list) : 'a list =
    match arr with
    | [] -> []  
    | pivot :: rest ->
        let smaller = List.filter (fun x -> x <= pivot) rest
        let larger = List.filter (fun x -> x > pivot) rest
        quickSort smaller @ [pivot] @ quickSort larger

let arr1 = [5; 3; 8; 4; 2; 7; 1; 6]
let sortedArr1 = quickSort arr1
printfn "Sorted Array (Rekurencyjnie): %A" sortedArr1


printfn "============================="
printfn "Część 2 (wersja iteracyjna)"

let quickSortIter (arr: int array) : int array =
    let stack = System.Collections.Generic.Stack<(int * int)>()  
    stack.Push((0, arr.Length - 1)) 

    let mutable arr' = Array.copy arr

    let partition (arr: int array) left right =
        let pivot = arr.[right] 
        let mutable i = left - 1

        for j in left .. right - 1 do
            if arr.[j] <= pivot then
                i <- i + 1
                let temp = arr.[i]
                arr.[i] <- arr.[j]
                arr.[j] <- temp

        let temp = arr.[i + 1]
        arr.[i + 1] <- arr.[right]
        arr.[right] <- temp

        i + 1 

    while stack.Count > 0 do
        let left, right = stack.Pop()

        if left < right then
            let pivotIndex = partition arr' left right
            stack.Push((left, pivotIndex - 1))
            stack.Push((pivotIndex + 1, right))

    arr' 

let arr2 = [|5; 3; 8; 4; 2; 7; 1; 6|]
let sortedArr2 = quickSortIter arr2
printfn "Sorted Array (Iteracyjnie): %A" sortedArr2
