(** INTERFACES **)
#r "nuget:FSharp.Data"

open FSharp.Data
open System.IO

type IHtmlParser =
    abstract member ParseHtml : string -> HtmlDocument

type WebParser () =
    interface IHtmlParser with
        member this.ParseHtml url = HtmlDocument.Load(url)

    member this.ParseHtml url = (this :> IHtmlParser).ParseHtml(url)

type FileParser () =
    interface IHtmlParser with
        member this.ParseHtml filePath = 
            filePath
            |> File.ReadAllText
            |> fun fileContents -> HtmlDocument.Parse(fileContents)

    member this.ParseHtml filePath = (this :> IHtmlParser).ParseHtml(filePath)

// Create parsers
let classWebParser = WebParser() :> IHtmlParser
let classFileParser = FileParser() :> IHtmlParser

//Function to handle parsing of HTML
let parseHtml (parser:IHtmlParser) (source:string) = parser.ParseHtml(source)

// Use web parser
parseHtml classWebParser "https://github.com/dotnet/fsharp"

// Use file parser
Path.Join(__SOURCE_DIRECTORY__, "fsharp-github-repo.html") 
|> parseHtml classFileParser

(** OBJECT EXPRESSIONS **)

// Implement IHtmlParser to parse HTML contents from URL
let webParser =
    { new IHtmlParser with
        member this.ParseHtml url = HtmlDocument.Load(url) }

// Implement IHtmlPraser to parse HTML contents from local file
let fileParser =
    { new IHtmlParser with
        member this.ParseHtml filePath =
            filePath
            |> File.ReadAllText
            |> fun fileContents -> HtmlDocument.Parse(fileContents) }

// Parse with webParser
parseHtml webParser "https://github.com/dotnet/fsharp" 

// Read local file contents and parse with fileParser
Path.Join(__SOURCE_DIRECTORY__, "fsharp-github-repo.html") 
|> parseHtml fileParser
