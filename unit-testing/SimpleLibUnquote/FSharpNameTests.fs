// https://github.com/SwensenSoftware/unquote/blob/master/test/UnquoteTests/FSharpNameTests.fs

[<AutoOpen>] //making auto open allows us not to have to fully qualify module properties



[<Allure.Xunit.Attributes.AllureEpic("Unit testing in F#")>]
[<Allure.Xunit.Attributes.AllureFeature([| "FSharpNameTests" |])>]
[<Allure.Xunit.Attributes.AllureStory([| "Unquote" |])>]
[<Allure.Xunit.Attributes.AllureSuite("Unquote")>]
[<Allure.Xunit.Attributes.AllureTag([| "Unquote" |])>]
[<Allure.Xunit.Attributes.AllureSeverity(Allure.Commons.SeverityLevel.normal)>]
module FSharpNameTests

open Allure.Xunit.Attributes
open Xunit
open Swensen.Unquote

[<AllureXunit>]
let ``simple`` () = typeof<float>.FSharpName =! "float"

[<AllureXunit>]
let ``type with alias and generic args`` () =
    typeof<list<float>>.FSharpName =! "list<float>"

[<AllureXunit>]
let ``no alias with generic args`` () =
    typeof<System.Collections.Generic.LinkedList<string>>.FSharpName
    =! "LinkedList<string>"

[<AllureXunit>]
let ``no alias with no generic args`` () =
    typeof<System.Collections.BitArray>.FSharpName
    =! "BitArray"

[<AllureXunit>]
let ``tuple`` () =
    typeof<int * int>.FSharpName =! "int * int"

[<AllureXunit>]
let ``nested tuples`` () =
    typeof<int * (float * (string * int))>.FSharpName
    =! "int * (float * (string * int))"

[<AllureXunit>]
let ``generic tuple arg`` () =
    typeof<list<int * int>>.FSharpName
    =! "list<int * int>"

[<AllureXunit>]
let ``dynamic type test with complex type: nested and tuple precedence`` () =
    typeof<int * list<float * (int * (string * float) * int)>>.FSharpName
    =! "int * list<float * (int * (string * float) * int)>"

[<AllureXunit>]
let ``single dimimensional array of type alias`` () = typeof<int[]>.FSharpName =! "int[]"

[<AllureXunit>]
let ``multi dimimensional array of type alias`` () = typeof<int[,,]>.FSharpName =! "int[,,]"

[<AllureXunit>]
let ``jagged array of type alias`` () =
    typeof<int[,,][][]>.FSharpName =! "int[,,][][]"

[<AllureXunit>]
let ``array of no type alias`` () =
    typeof<System.Text.RegularExpressions.Regex[]>.FSharpName
    =! "Regex[]"

[<AllureXunit>]
let ``array of generic type`` () =
    typeof<list<int>[]>.FSharpName =! "list<int>[]"

[<AllureXunit>]
let ``tuple array is parenthisized`` () =
    typeof<(int * int)[]>.FSharpName
    =! "(int * int)[]"

[<AllureXunit>]
let ``fsharp funcs`` () =
    typeof<int -> int * int -> float>.FSharpName
    =! "int -> int * int -> float"

    typeof<int -> int * int -> float[]>.FSharpName
    =! "int -> int * int -> float[]"

    typeof<list<int -> int * int -> float[]>>.FSharpName
    =! "list<int -> int * int -> float[]>"

    typeof<Map<int, int -> int * int -> float[]>>.FSharpName
    =! "Map<int, int -> int * int -> float[]>"

    typeof<(int -> int -> int)[][][]>.FSharpName
    =! "(int -> int -> int)[][][]"

    typeof<(int -> int) -> int>.FSharpName
    =! "(int -> int) -> int"

[<AllureXunit>] //issue 32
let ``generic type definition: function`` () =
    typedefof<int -> (int * int)>.FSharpName
    =! "'T -> 'TResult"

[<AllureXunit>] //issue 32
let ``generic type definition: tuple`` () =
    typedefof<int * int>.FSharpName =! "'T1 * 'T2"

[<AllureXunit>] //issue 32
let ``generic type definition: list`` () =
    typedefof<list<_>>.FSharpName =! "list<'T>"

[<AllureXunit>] //issue 32
let ``generic type definition: seq of nested list, no such thing as "partially open" generic types`` () =
    typedefof<seq<list<_>>>.FSharpName =! "seq<'T>"

[<AllureXunit>] //issue 32
let ``generic type definition: 1d array, arrays are not generic`` () = typedefof<_[]>.FSharpName =! "obj[]" //sorry, arrays just aren't generic

module Module =
    type Hello(x: int) =
        let x = x

[<AllureXunit>] //issue #10
let ``types in modules`` () =
    typeof<Module.Hello>.FSharpName =! "Hello"
