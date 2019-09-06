open System

open tutorialFsharp.listLessThen
open tutorialFsharp.def_1
open tutorialFsharp.Divisors
open tutorialFsharp.ListOverlap
open tutorialFsharp.TicTacToe


let oddEvenStarter () = tutorialFsharp.oddEven.oddOrEven()
let listLessThenStarter () = listLessThen [1..100] 24 |> printfn "%A"
let divisorsStarter () = getDivisors 100 |> printfn "%A"
let listOverlapStarter () = listOverlap [1..30] [1;24;27;665] |> printfn "%A"
let ticTacToeStarter () = gameStarter 3



[<EntryPoint>]
let main argv =
    ticTacToeStarter ()
    0 // return an integer exit code
    
    


