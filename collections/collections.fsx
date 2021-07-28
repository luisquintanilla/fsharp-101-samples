(** CREATE COLLECTIONS **)

// List

// Built-in creation functions
List.init<int> 10 (fun i -> i)
List.init<int> 10 (fun i -> i * 2)

// Inline initialization
[ 1; 2; 3; 4; 5; 6; 7; 8; 9; 10 ]
[ 1 .. 10 ]

// Array
Array.init<int> 10 (id)
Array2D.init<int> 3 3 (fun x _ -> x)
Array3D.init<int> 3 3 3 (fun _ _ z -> z)

[| 1; 2; 3; 4; 5; 6; 7; 8; 9; 10 |]
[| 1 .. 10 |]

// Sequence
Seq.init<int> 10 (fun i -> i)
Seq.initInfinite<int> (fun i -> i)

seq {
    1
    2
    3
    4
    5
    6
    7
    8
    9
    10
}

seq { 1 .. 10 }

(**ACCESS ELEMENTS**)
open System

type Transaction =
    { Date: DateTime
      CustomerId: string
      Amount: double }

let transactions =
    [ { Date = new DateTime(2021, 1, 1)
        CustomerId = "1"
        Amount = 23.80 }
      { Date = new DateTime(2021, 2, 1)
        CustomerId = "1"
        Amount = 120.00 }
      { Date = new DateTime(2021, 1, 5)
        CustomerId = "2"
        Amount = 46.09 }
      { Date = new DateTime(2021, 3, 15)
        CustomerId = "3"
        Amount = 15.12 }
      { Date = new DateTime(2021, 2, 15)
        CustomerId = "2"
        Amount = 3.09 } ]

// Get first element
transactions.Head

// Get rest of elements
transactions.Tail

// Access by index
// This is just for demo purposes. 
// Access by index is more efficient on arrays.
transactions.[0] // similar to head
transactions.[1..] // similar to tail

// Built in collection operations
transactions
|> List.find (fun transaction -> transaction.CustomerId = "1")

transactions
|> List.find (fun transaction -> transaction.CustomerId = "4") // Throws error

// Handle missing data using Option type
transactions
|> List.tryFind (fun x -> x.CustomerId = "4")

transactions
|> List.tryFind (fun x -> x.CustomerId = "1")

// Append & Prepend
let todoList = [ "Learn F#"; "Create app"; "Profit!" ]

[ "Repeat" ] |> List.append todoList // Append
todoList |> List.append [ "Make coffee" ] // Prepend

(** CONVERT COLLECTIONS **)
let transactionArray = transactions |> Array.ofList
let transactionSeq = transactions |> Seq.ofList

(**OPERATIONS**)
transactions
|> List.map
    (fun transaction ->
        let taxRate = 0.03

        {| PreTax = transaction.Amount
           Tax = transaction.Amount * taxRate
           Total = transaction.Amount * (1.0 + taxRate) |}) // Calculate tax

transactions
|> List.iter (fun transaction -> printfn $"{transaction.CustomerId}")

// Total Transactions
transactions
|> List.sumBy (fun transaction -> transaction.Amount)

// Average amount
transactions
|> List.averageBy (fun transaction -> transaction.Amount)

// Filter
transactions
|> List.filter (fun transaction -> transaction.Date > DateTime(2021, 1, 31))

// Sort
transactions
|> List.sortBy (fun transaction -> transaction.Date)

transactions
|> List.sortByDescending (fun transaction -> transaction.Date)

// Pipelines
transactions
|> List.filter(fun transaction -> transaction.Date > DateTime(2021, 1, 31))
|> List.sortByDescending (fun transaction  -> transaction.Date)
