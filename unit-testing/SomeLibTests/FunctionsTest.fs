[<NUnit.Framework.TestFixture>]
module SomeLibTests


open System
open System.Collections.Generic
open Allure.Commons
open NUnit.Allure.Attributes
open NUnit.Allure.Core
open NUnit.Framework

open type NUnit.Framework.Assert

open Allure.Xunit.Attributes
open Xunit
open SomeLib


// NUnit
let factorialTestData () : IEnumerable<TestCaseData> =
    [ new TestCaseData(0, 1)
      new TestCaseData(1, 1)
      new TestCaseData(2, 2)
      new TestCaseData(3, 6)
      new TestCaseData(4, 24) ]

// xUnit
let factorialXunitTestData () : IEnumerable<(obj)[]> =
    [ [| 0; 1 |]
      [| 1; 1 |]
      [| 2; 2 |]
      [| 3; 6 |]
      [| 4; 24 |] ]


[<AllureEpic("Unit testing in F#")>]
[<AllureFeature([| "Parameterized tests" |])>]
[<AllureStory([| "NUnit, xUnit" |])>]
[<AllureSuite("NUnit, xUnit")>]
[<AllureTag([| "NUnit"; "xUnit" |])>]
[<AllureSeverity(SeverityLevel.normal)>]
[<AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")>]
[<AllureId(123)>]
[<AllureName("test0001 NUnit?")>]

// NUnit
[<Test>]
[<TestCaseSource("factorialTestData")>]

// xUnit
[<AllureXunitTheory>]
[<MemberData(nameof (factorialXunitTestData))>]


let factorialTest (number: int, expectedResult: int) =
    let actualResult = FuncLib.factorial number
    AreEqual(expectedResult, actualResult, $"Expected = {expectedResult}, actual = {actualResult}")
