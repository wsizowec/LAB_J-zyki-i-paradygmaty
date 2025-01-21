//Zadanie 3. Generowanie permutacji listy:

let rec permutacje lst =
    match lst with
    | [] -> [[]]
    | x :: xs ->
        [for perm in permutacje xs do
            for i in 0 .. List.length perm do
                yield List.insertAt i x perm]

[<EntryPoint>]
let main argv =
    let lista = [1; 2; 3]
    let permutacjeLista = permutacje lista

   
    printfn "Permutacje listy %A:" lista
    permutacjeLista |> List.iter (fun perm -> printfn "%A" perm)

    0 