[<Allure.Xunit.Attributes.AllureEpic("Unit testing in F#")>]
[<Allure.Xunit.Attributes.AllureFeature([| "Parameterized tests" |])>]
[<Allure.Xunit.Attributes.AllureStory([| "Unquote" |])>]
[<Allure.Xunit.Attributes.AllureSuite("Unquote")>]
[<Allure.Xunit.Attributes.AllureTag([| "Unquote" |])>]
[<Allure.Xunit.Attributes.AllureSeverity(Allure.Commons.SeverityLevel.normal)>]
module SimpleLibUnquoteTests



open System.Collections.Generic
open Allure.Commons



open Allure.Xunit.Attributes
open Swensen.Unquote
open Xunit

open type Xunit.Assert
open SimpleLib

[<AllureXunit>]
let squareTest =
    let n = 3
    test <@ n * n = FuncLib.square n @>



let factorialXunitTestData () : IEnumerable<(obj)[]> =
    [ [| 0; 1 |]
      [| 1; 1 |]
      [| 2; 2 |]
      [| 3; 6 |]
      [| 4; 24 |] ]






[<AllureXunitTheory>]
[<MemberData(nameof (factorialXunitTestData))>]
let factorialTest (number: int, expectedResult: int) =
    let actualResult = FuncLib.factorial number
    test <@ expectedResult = actualResult @>
