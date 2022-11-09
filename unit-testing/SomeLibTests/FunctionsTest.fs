module SomeLibTests


open System.Collections.Generic
open NUnit.Framework
open SomeLib



[<Test>]
[<TestCaseSource("factorialTestData")>]

let factorialTest (number: int, expectedResult: int) =
    let actualResult = FuncLib.factorial number
    Assert.AreEqual(expectedResult, actualResult, $"Expected = {expectedResult}, actual = {actualResult}")

let factorialTestData () : IEnumerable<TestCaseData> =
    [ new TestCaseData(0, 1)
      new TestCaseData(1, 1)
      new TestCaseData(2, 2)
      new TestCaseData(3, 6)
      new TestCaseData(4, 24) ]
