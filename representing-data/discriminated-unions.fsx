type StringGitHubProject =
    { ProjectName: string
      Stars: int
      State: string }

let fakeProject =
    { ProjectName = "Amazing Project"
      Stars = 0
      State = "asdfwerq" //No enforcement
    }

(**DEFINE DISCRIMINATED UNION*)
type ProjectState =
    | Archived
    | Active of {| Maintainer: string |}

type GitHubProject =
    { ProjectName: string
      Stars: int
      State: ProjectState }

(**USE DISCRIMINATED UNION*)
let (anotherFakeProject: GitHubProject) =
    { ProjectName = "Other amazing project"
      Stars = 0
      State = "asdfasdf" }

let corefxlab =
    { ProjectName = "corefxlab"
      Stars = 1500
      State = Archived }

let fsharp =
    { ProjectName = "dotnet/fsharp"
      Stars = 2800
      State = Active {| Maintainer = "F# Team" |} }
