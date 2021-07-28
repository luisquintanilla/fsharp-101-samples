(** CREATE TUPLES**)

let point1 = (1.0, 2.0)

let gitHubStars = ("dotnet/fsharp", 2800)

(**GET DATA**)
fst gitHubStars // Get first item
snd gitHubStars // Get second item

let projectName, stars = gitHubStars

printfn $"{projectName}: {stars}"

let projectName, _ = gitHubStars // Stars is ignored
