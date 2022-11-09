namespace SomeLib

module FuncLib =


    let rec factorial (n: int) =
        if n = 0 then 1
        elif n = 1 then 1
        else n * factorial (n - 1)
