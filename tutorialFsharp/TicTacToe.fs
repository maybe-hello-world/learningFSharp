module tutorialFsharp.TicTacToe
open System

// game field
type Field =
    {width: int} with
    member this.FieldSize = this.width * this.width
    member this.winningCoords () =
        let horizontalCoords =
            [1..this.FieldSize] |> List.splitInto this.width
        let verticalCoords =
            [1..this.width] |> List.map (fun x -> [for i in 1..this.width -> x + (i-1) * this.width])
        let diagonalCoords =
            [1..this.width] |> List.map (fun item -> item + (item - 1) * this.width)
        let rdiagonalCoords =
            [1..this.width] |> List.rev |> List.map (fun item -> item + (this.width - item) * this.width)
        
        [diagonalCoords; rdiagonalCoords] @ horizontalCoords @ verticalCoords |> List.map (fun x -> Set x)   


// check if the game is ended
let ifGameEnded player1Coords player2Coords (gameField: Field) =
    let ifWinner coords =
        gameField.winningCoords() |> Seq.exists (fun x -> x.IsSubsetOf(coords))
    
    match Set.union player1Coords player2Coords with
    | _ when ifWinner player1Coords -> 1         // first player wins
    | _ when ifWinner player2Coords -> 2         // second player wins
    | x when x.Count = gameField.FieldSize -> 0  // draw
    | _ -> -1                                    // go on
    
// cool print the field
let printField (player1: Set<int>) (player2: Set<int>) playerTurn (gameField: Field) =
    let p1, p2 =
        match playerTurn with
        | true -> player1, player2
        | false -> player2, player1
    let setSymbol coord =
        match coord with
        | x when p1.Contains x -> "X"
        | x when p2.Contains x -> "O"
        | _ -> coord.ToString()
        
    let coolPrint str =
        str |> Seq.splitInto gameField.width |> Seq.iter (fun substr -> printfn "%A" substr)
        
    [1..gameField.FieldSize] |> Seq.map setSymbol |> coolPrint
    


// read turns from console and check if it possible
let rec readTurn (playerTurns: Set<int>) (oppositePlayerTurns: Set<int>) (gameField: Field)=
    
    // reader from console
    let rec readIntFromConsole() =
        let input = Console.ReadLine()
        match input with
        | null -> failwith "Ctrl+Z pressed"    // handling Ctrl+Z in terminal
        | _ ->
            match Int32.TryParse input with
            | (false, _) -> printfn "Not a number"; readIntFromConsole()
            | (true, number) ->
                match number with
                | x when x < 1 || x > gameField.FieldSize -> printfn "wrong place"; readIntFromConsole()
                | _ -> number
    
    // check if turn have already been done
    match readIntFromConsole() with
    | x when playerTurns.Contains x ->
        printfn "You've already taken this turn";
        readTurn playerTurns oppositePlayerTurns gameField
    | x when oppositePlayerTurns.Contains x ->
        printfn "Opposite player have already taken this turn";
        readTurn playerTurns oppositePlayerTurns gameField
    | x -> x
    
    
let rec takeTurn player1 player2 playerTurn field =
    printField player1 player2 playerTurn field
    match ifGameEnded player1 player2 field with
    | 1 -> "Opposite player wins"
    | 2 -> "Current player wins"
    | 0 -> "Draw"
    | _ -> 
        let playerName =
            match playerTurn with
            | true -> "one"
            | false -> "two"
        printfn "Your turn, player %s" playerName
        let step = readTurn player1 player2 field
        takeTurn player2 (Set.union player1 (Set [step])) (not playerTurn) field
    
let gameStarter fieldSize =
    printfn "%s" (takeTurn (Set []) (Set []) true {Field.width=fieldSize})
    