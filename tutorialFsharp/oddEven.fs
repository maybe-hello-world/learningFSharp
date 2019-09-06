module tutorialFsharp.oddEven
open System

// read a number from console and say if it's odd or even
let printOddOrEven number =
    match number with
    | x when x % 2 = 0 -> printfn "Even"
    | _ -> printfn "Odd"

let rec readIntFromConsole() =
    let input = Console.ReadLine()
    match input with
    | null -> failwith "Ctrl+Z pressed"    // handling Ctrl+Z in terminal
    | _ ->
        match Int32.TryParse input with
        | (false, _) -> readIntFromConsole()
        | (true, number) -> number
        
let oddOrEven () =
    readIntFromConsole () |> printOddOrEven
            
        
       
