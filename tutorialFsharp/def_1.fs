module tutorialFsharp.def_1

// vars
let a = 5
let fl = 0.3
let stt = "str"

// lists
let twoFive = [2..5]
let againTwoFive = [2;3;4;5]
let oneToFive = 1 :: twoFive  // 1;2;3;4;5
let zeroFive = [0;1] @ twoFive // 0;1;2;3;4;5

// funcs
let funcName argName = argName + 1
let anotherFuncName firstArg secondArg thirdArg = firstArg + secondArg + thirdArg
let evens someSeq =
    let isEven arg = arg % 2 = 0
    Seq.filter isEven someSeq
    
let sumSquares n =
    Seq.sum (Seq.map (fun x -> x * x ) [1..n])
    
let sumSquaresPiped n =
    [1..n] |> Seq.map(fun x -> x * x) |> Seq.sum

// pattern matching
let actionChooser x =
    match x with
    | 1 -> printfn "First action used"
    | 2 -> printfn "Second action used"
    | _ -> printfn "Undefined action"
     
// Types
let tuple = 1,2

type Person = {Name:string; Surname:string}
let someP = {Name="Just"; Surname="Read"}

type Temperature =
    | DegreesC of float
    | DegreesF of float
let temp = DegreesC 100.0
let tempPrinter (x:Temperature) =
    match x with
    | DegreesC x -> printfn "%f degrees of Celsius" x
    | DegreesF x -> printfn "%f degrees of Fahrenheit" x
    
