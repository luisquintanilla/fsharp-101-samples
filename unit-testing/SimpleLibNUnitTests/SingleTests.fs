[<NUnit.Framework.TestFixture>]
[<NUnit.Allure.Core.AllureNUnit>]

[<NUnit.Allure.Attributes.AllureEpic("Unit testing in F#")>]
[<NUnit.Allure.Attributes.AllureFeature([| "Single tests" |])>]
[<NUnit.Allure.Attributes.AllureStory([| "NUnit" |])>]
[<NUnit.Allure.Attributes.AllureSuite("NUnit")>]
[<NUnit.Allure.Attributes.AllureTag([| "NUnit" |])>]

module NUnit.Samples.SingleTests

open System
open System.Collections
open NUnit.Allure.Attributes
open NUnit.Allure.Core
open NUnit.Framework
open NUnit.Framework.Constraints

open type NUnit.Framework.Assert
open SimpleLib

[<Test>]
[<AllureName("a simple NUnit test")>]
let someTest () =
    let n = 3
    AreEqual(n * n, FuncLib.square n)
