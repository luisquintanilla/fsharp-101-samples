[<Allure.Xunit.Attributes.AllureEpic("Unit testing in F#")>]
[<Allure.Xunit.Attributes.AllureFeature([| "Single tests" |])>]
[<Allure.Xunit.Attributes.AllureStory([| "xUnit" |])>]
[<Allure.Xunit.Attributes.AllureSuite("xUnit")>]
[<Allure.Xunit.Attributes.AllureTag([| "xUnit" |])>]
[<Allure.Xunit.Attributes.AllureSeverity(Allure.Commons.SeverityLevel.normal)>]
module SingleTests

open System.Collections.Generic
open Allure.Commons


open Allure.Xunit.Attributes
open Xunit

open type Xunit.Assert
open SimpleLib

[<AllureXunit>]
[<AllureDescription("a very simple xUnit test")>]
let squareTest =
    let n = 3
    Equal(n * n, FuncLib.square n)
