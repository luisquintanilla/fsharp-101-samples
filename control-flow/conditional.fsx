// Conditional expressions
open System.IO

let processFile (fileName:string) = 
    let fileExtension = Path.GetExtension(fileName)

    if fileExtension = ".fs" then
        printfn "This is a source file"
    elif fileExtension = ".fsx" then
        printfn "This is a script"
    elif fileExtension = ".fsproj" then
        printfn "This is a build configuration file"
    else printfn "Can't process file"

processFile "hello.fsx"
processFile "app.fs"
processFile "README.md"

// Exception Handling
let divide x y = 
    try
        Some(x / y)
    with 
        | :? System.DivideByZeroException -> printfn "Can't divide by zero"; None
        | ex -> printfn "Some other exception occurred";None

divide 10 2 // Some
divide 1 0 //None
