//Zadanie 4. Rekurencyjne rozwiązywanie problemu wież Hanoi


printfn "============================="
printfn "Część 1  (uzywanie rekurencji)"
printfn "============================="

let rec hanoi n source target auxiliary =
    if n = 1 then
        printfn "Move disk from %s to %s" source target
    else

        hanoi (n - 1) source auxiliary target
        printfn "Move disk from %s to %s" source target
        hanoi (n - 1) auxiliary target source

hanoi 3 "A" "C" "B"
printfn "============================="
printfn "Część 2  (uzywanie iteracji)"
printfn "============================="

let hanoiIter n source target auxiliary =
    let stack = [(n, source, target, auxiliary)]
    let rec loop stack =
        match stack with
        | [] -> ()
        | (0, _, _, _) :: rest -> loop rest 
        | (n, source, target, auxiliary) :: rest ->
            if n = 1 then
                printfn "Move disk from %s to %s" source target
                loop rest
            else
                loop ((n - 1, source, auxiliary, target) :: (n - 1, auxiliary, target, source) :: rest)
    loop stack

hanoiIter 3 "X" "Y" "Z"

