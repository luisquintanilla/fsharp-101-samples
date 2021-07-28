(** CLASSES **)
type Repo(name: string, stars: int) =
    
    // Private properties
    let baseUrl = "https://github.com"
    
    // Private method
    let incrementStarsBy stars n = stars + n

    // Additional Constructors
    new() = Repo("", 0)

    // Instance properties
    member this.Name = name //read-only (immutable)
    member val Stars = stars with get, set //mutable

    // Static Methods
    static member PrintHelp() = "Class that contains repo information"

    // Methods
    member _.GetBaseUrl() = $"{baseUrl}"
    member this.GetRepoUrl() = $"{baseUrl}/{this.Name}"
    member this.IncrementStarsBy(n) = this.Stars <- incrementStarsBy this.Stars n //takes parameters

// Static members
Repo.PrintHelp()

// Create instance
let fsharpRepo = Repo("dotnet/fsharp", 2800)
let blankRepo = Repo()

(** ACCESS MEMBERS / PROPERTIES **)
fsharpRepo.Name
fsharpRepo.GetRepoUrl()
fsharpRepo.Stars <- 3000
fsharpRepo.IncrementStarsBy 2
fsharpRepo.Stars
