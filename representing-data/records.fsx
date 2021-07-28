(**DEFINE RECORD**)
type GitHubProject = { ProjectName: string; Stars: int }

(**CREATE RECORD**)
let fsharp =
    { ProjectName = "dotnet/fsharp"
      Stars = 2800 }

(**ACCESS RECORD DATA**)
printfn $"{fsharp.ProjectName} has {fsharp.Stars} stars"

(**UPDATE RECORD DATA**)
let updatedFSharp = { fsharp with Stars = 2801 }

printfn $"{updatedFSharp.ProjectName} now has {updatedFSharp.Stars} stars"

(**RECORD MEMBERS**)
type GitHubProjectWithMember =
    { ProjectName: string
      Stars: int }
    member this.GetUrl () =
        $"https://github.com/{this.ProjectName}"

    member _.GetCodeOwner () = "dotnet"

let fsharpProj =
    { ProjectName = "dotnet/fsharp"
      Stars = 2800 }

fsharpProj.GetUrl()
fsharpProj.GetCodeOwner()
