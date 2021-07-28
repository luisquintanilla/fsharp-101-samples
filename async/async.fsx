#r "nuget:FSharp.Data"

open FSharp.Data

let getHtml (source: string) =
    async {
        let! html = HtmlDocument.AsyncLoad(source)
        return html
    }

"https://docs.microsoft.com/dotnet/fsharp"
|> getHtml
|> Async.RunSynchronously

// Run multiple async in parallel
let documents =
    [ "https://docs.microsoft.com/dotnet/fsharp"
      "https://docs.microsoft.com/dotnet/fsharp/tutorials/asynchronous-and-concurrent-programming/async"
      "https://docs.microsoft.com/dotnet/fsharp/language-reference/asynchronous-workflows" ]

documents
|> List.map getHtml
|> Async.Parallel
|> Async.RunSynchronously

// Run in order
documents
|> List.map getHtml
|> Async.Sequential
|> Async.RunSynchronously

(*TASK INTEROP*)
open System.Net.Http

let getHtmlTask (source: string) =
    async {
        use client = new HttpClient()
        let! html = client.GetStringAsync(source) |> Async.AwaitTask
        let parsedHtml = HtmlDocument.Parse html
        return parsedHtml
    }

"https://docs.microsoft.com/dotnet/fsharp"
|> getHtmlTask
|> Async.RunSynchronously

// Merged https://github.com/dotnet/fsharp/pull/6811
// task {

// }