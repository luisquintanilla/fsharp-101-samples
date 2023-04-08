[<NUnit.Framework.TestFixture>]
[<NUnit.Allure.Core.AllureNUnit>]

[<NUnit.Allure.Attributes.AllureEpic("Unit testing in F#")>]
[<NUnit.Allure.Attributes.AllureFeature([| "Parameterized tests" |])>]
[<NUnit.Allure.Attributes.AllureStory([| "NUnit" |])>]
[<NUnit.Allure.Attributes.AllureSuite("NUnit")>]
[<NUnit.Allure.Attributes.AllureTag([| "NUnit" |])>]

// this one does not work)
// module SimpleLibNUnitTests2
module NUnit.Samples.SimpleLibNUnitTests

open System
open System.Collections
open NUnit.Allure.Attributes
open NUnit.Allure.Core
open NUnit.Framework
open NUnit.Framework.Constraints
open Shouldly

open type NUnit.Framework.Assert
open SimpleLib


let factorialTestData () = //: IEnumerable<TestCaseData> =
    [ new TestCaseData(0, 1)
      new TestCaseData(1, 1)
      new TestCaseData(2, 2)
      new TestCaseData(3, 6)
      new TestCaseData(4, 24) ]






[<Test>]
[<AllureName("one more NUnit test")>]
let oneMoreTest () = Assert.AreEqual(1, 1)


// variations
// [<TestCaseSource(typeof< testClass001>, "factorialTestData" )>]
// [<TestCaseSource("factorialTestData")>]
// [<TestCaseSource(typeof< testData>, "factorialTestData" )>]
// [<TestCaseSource(typeof<testData>, nameof testData.factorialTestData)>]
[<TestCaseSource(nameof factorialTestData)>]
// [<TestCaseSource(typeof SimpleLibNUnitTests, nameof factorialTestData )>]
[<Description("NUnit parameterized test")>]
let factorialTest (number: int, expectedResult: int) =
    let actualResult = FuncLib.factorial number
    AreEqual(expectedResult, actualResult, $"Expected = {expectedResult}, actual = {actualResult}")
    actualResult.ShouldBe(expectedResult)
