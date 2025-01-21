type Book(title: string, author: string, pages: int) =
    member this.Title = title
    member this.Author = author
    member this.Pages = pages
    member this.GetInfo() =
        sprintf "Tytuł: %s, Autor: %s, Liczba stron: %d" this.Title this.Author this.Pages

type User(name: string) =
    member this.Name = name
    member val BorrowedBooks = [] with get, set
    
    member this.BorrowBook(book: Book) =
        this.BorrowedBooks <- book :: this.BorrowedBooks
        printfn "%s wypożyczył książkę: %s" this.Name book.Title
        
    member this.ReturnBook(book: Book) =
        if List.contains book this.BorrowedBooks then
            this.BorrowedBooks <- List.filter ((<>) book) this.BorrowedBooks
            printfn "%s zwrócił książkę: %s" this.Name book.Title
        else
            printfn "%s nie wypożyczył książki: %s" this.Name book.Title

type Library() =
    member val Books = [] with get, set
    member val BorrowedBooks = [] with get, set
    
    member this.AddBook(book: Book) =
        this.Books <- book :: this.Books
        printfn "Dodano książkę: %s" book.Title
        
    member this.RemoveBook(book: Book) =
        this.Books <- List.filter ((<>) book) this.Books
        printfn "Usunięto książkę: %s" book.Title
        
    member this.ListBooks() =
        if this.Books.Length > 0 then
            this.Books |> List.iteri (fun i b -> printfn "%d. %s" (i + 1) (b.GetInfo()))
        else
            printfn "Brak książek w bibliotece"

[<EntryPoint>]
let main argv =
    let book1 = Book("Kobzar", "Taras Szewczenko", 320)    // "Kobzar" to jedno z najbardziej znanych dzieł Tarasa Szewczenki.
    let book2 = Book("Lisova Pisnya", "Lesja Ukrajinka", 180)    // "Lisova Pisnya" (w polskim tłumaczeniu "Pieśń Leśna") to znane dzieło Lesi Ukraińki.
    let book3 = Book("Nakrytyj Dvor", "Iwan Franko", 270)    // "Nakrytyj Dvor" (w polskim tłumaczeniu "Zakryty Dwór") autorstwa Iwana Franko.
    let book4 = Book("Sofija", "Ołeksandr Dovżenko", 250)    // "Sofija" to jedno z dzieł Ołeksandra Dovżenki.
    let book5 = Book("Tini zabutych predkiv", "Maksym Rylskyj", 300)    // "Tini zabutych predkiv" (w polskim tłumaczeniu "Cienie zapomnianych przodków") to dzieło Maksym Rylskyj.

    let library = Library()
    library.AddBook(book1)
    library.AddBook(book2)
    library.AddBook(book3)
    library.AddBook(book4)
    library.AddBook(book5)

    printfn "=================="
    printfn "Podaj swoje imię:"
    let userName = System.Console.ReadLine()
    let user = User(userName)

    let rec menu() =
        printfn "\n--- MENU ---"
        printfn "1. Wypożycz książkę"
        printfn "2. Zwróć książkę"
        printfn "3. Lista książek w bibliotece"
        printfn "4. Wyjście"
        printfn "Wybierz opcję:"

        let option = System.Console.ReadLine() |> int
        
        match option with
        | 1 ->
            printfn "=================="
            printfn "Dostępne książki w bibliotece:"
            library.ListBooks()

            printfn "=================="
            printfn "Wybierz książkę do wypożyczenia (1-5):"
            let bookChoice = System.Console.ReadLine() |> int

            let selectedBook = library.Books |> List.tryItem (bookChoice - 1)
            
            match selectedBook with
            | Some book ->
                user.BorrowBook(book)
                library.BorrowedBooks <- (user, book) :: library.BorrowedBooks
            | None -> printfn "Nie ma książki o tym numerze."
            
            menu()

        | 2 ->
            printfn "Wypożyczone książki:"
            if user.BorrowedBooks.Length > 0 then
                user.BorrowedBooks |> List.iteri (fun i b -> printfn "%d. %s" (i + 1) (b.GetInfo()))
            else
                printfn "Nie wypożyczyłeś żadnej książki."

            printfn "Wybierz książkę do zwrócenia (1-5):"
            let returnChoice = System.Console.ReadLine() |> int

            let bookToReturn = user.BorrowedBooks |> List.tryItem (returnChoice - 1)

            match bookToReturn with
            | Some book ->
                user.ReturnBook(book)
                library.BorrowedBooks <- List.filter (fun (u, b) -> u <> user || b <> book) library.BorrowedBooks
            | None -> printfn "Nie masz książki o tym numerze."

            menu()

        | 3 ->
            library.ListBooks()
            menu()

        | 4 ->
            printfn "Dziękujemy za skorzystanie z biblioteki!"
            0

        | _ -> 
            printfn "Nieprawidłowa opcja!"
            menu()

    menu()
