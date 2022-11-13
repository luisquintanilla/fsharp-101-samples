[<Allure.Xunit.Attributes.AllureEpic("Unit testing in F#")>]
[<Allure.Xunit.Attributes.AllureFeature([| "Parameterized tests" |])>]
[<Allure.Xunit.Attributes.AllureStory([| "xUnit" |])>]
[<Allure.Xunit.Attributes.AllureSuite("xUnit")>]
[<Allure.Xunit.Attributes.AllureTag([| "xUnit" |])>]
[<Allure.Xunit.Attributes.AllureSeverity(Allure.Commons.SeverityLevel.normal)>]
module SimpleLibxUnitTests



open System.Collections.Generic
open Allure.Commons


open Allure.Xunit.Attributes
open Xunit

open type Xunit.Assert
open SimpleLib





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
    Equal(expectedResult, actualResult)
