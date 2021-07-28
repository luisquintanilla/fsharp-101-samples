(*VALUE TYPES*)

// String value
"New Yok"

// Boolean value
true

// Integer value
13

// Tuple
(1.0, 3.0)

// List value
["Learn F#";"Build app";"Profit!"]

// Lambda expression / Anonymous function value
fun input -> input / 3

(*VALUE BINDING*)
let cityName = "New Yok"

let fSharpIsAwesome = true

let luckyNumber = 13

let coordinates = (1.0, 3.0)

let toDoList = ["Learn F#";"Build app";"Profit!"]

let divideByThree input = input / 3

(* EXPLICIT TYPE ANNOTATIONS*)
let (luckyNumberString:string) = "13"

(* UPDATING VALUES *)

cityName <- "New York" // Throws error

let correctCityName = "New York"

(* MUTABLE VALUES *)
let mutable mutableCityName = "New Yok"

mutableCityName <- "New York"