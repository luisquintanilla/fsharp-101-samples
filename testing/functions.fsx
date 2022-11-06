module Functions =
    let factorial (n:int) =
        n * (n - 1)

    let result =  factorial 3
    let strResult = string result
    sprintf "%s" strResult