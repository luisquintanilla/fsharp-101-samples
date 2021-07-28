(** LAMBDA EXPRESSIONS **)
fun () -> printfn "Hello World"
fun x -> x + 1
fun x y -> x + y

(** DEFINING NAMED FUNCTIONS **)
let addOne x = x + 1 // let addOne = fun x -> x + 1

(** CALLING FUNCTIONS **)
addOne 3

(** TYPE ANNOTATIONS **)
// https://github.com/dotnet/fsharp
// Protocol: http or https
// Base Url: github.com
// Path: dotnet/fsharp

let buildUrlNoAnnotations protocol baseUrl path = $"{protocol}://{baseUrl}/{path}"

buildUrlNoAnnotations 1 "github.com" (1.0,4.0)

let buildUrl (protocol: string) (baseUrl: string) (path: string) : string = 
    $"{protocol}://{baseUrl}/{path}"

buildUrl 1 "github.com" (1.0,4.0) // Throws error

buildUrl "http" "github.com" "dotnet/fsharp" // Works

(** OPTION TYPES **)
#r "nuget:FSharp.Data"

open FSharp.Data
open System.IO

let getHtml (htmlFile: string) : HtmlDocument option =
    try
        let html = HtmlDocument.Load(htmlFile)
        Some(html)
    with
    | ex ->
        printfn $"Error: {ex}"
        None

HtmlDocument.Load "doesnotexist"

getHtml "doesnotexist"

let htmlPath = Path.Join(__SOURCE_DIRECTORY__,"fsharp-github-repo.html")

getHtml htmlPath

(** PIPELINES **)

let getLinks (html: HtmlDocument option) =
    // Pattern match over option type to get 'a' html tags in document
    match html with
    | Some (x) -> x.Descendants [ "a" ]
    | None -> Seq.empty

// Call getHtml and getLinks
getLinks (getHtml htmlPath)

// Use pipe operator |> to call getHtml and getLinks
htmlPath |> getHtml |> getLinks

(** COMPOSITION **)

// Use composition operator >> to 
// combine getHtml and getLinks into one function
let getLinksFromHtml = getHtml >> getLinks

// Call getLinksFromHtml
getLinksFromHtml htmlPath

// Use pipe operator and lambda expression for additional processing
htmlPath
|> getLinksFromHtml 
|> fun links -> printfn $"{links}"
