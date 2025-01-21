//Zadanie 2. Wyszukiwanie elementu w drzewie binarnym

open System

type BinaryTree<'T> =
    | Empty
    | Node of 'T * BinaryTree<'T> * BinaryTree<'T>

let rec szukajRek (x: 'T) (drzewo: BinaryTree<'T>) : bool =
    match drzewo with
    | Empty -> false
    | Node (v, lewy, prawy) ->
        if v = x then true
        elif x < v then szukajRek x lewy
        else szukajRek x prawy

let szukajIter (x: 'T) (drzewo: BinaryTree<'T>) : bool =
    let rec loop (st: BinaryTree<'T> list) =
        match st with
        | [] -> false
        | Empty :: tail -> loop tail
        | Node (v, lewy, prawy) :: tail ->
            if v = x then true
            elif x < v then loop (lewy :: tail)
            else loop (prawy :: tail)
    
    loop [drzewo]

[<EntryPoint>]
let main argv =
    let drzewo =
        Node (10,
              Node (5, Node (3, Empty, Empty), Node (7, Empty, Empty)),
              Node (15, Node (12, Empty, Empty), Node (17, Empty, Empty)))

    let wynikRekurencyjny = szukajRek 7 drzewo
    printfn "Czy 7 znajduje się w drzewie (rekurencyjnie)? %b" wynikRekurencyjny

    let wynikIteracyjny = szukajIter 7 drzewo
    printfn "Czy 7 znajduje się w drzewie (iteracyjnie)? %b" wynikIteracyjny

    let wynikRekurencyjnyBrak = szukajRek 20 drzewo
    printfn "Czy 20 znajduje się w drzewie (rekurencyjnie)? %b" wynikRekurencyjnyBrak

    let wynikIteracyjnyBrak = szukajIter 20 drzewo
    printfn "Czy 20 znajduje się w drzewie (iteracyjnie)? %b" wynikIteracyjnyBrak

    0 
