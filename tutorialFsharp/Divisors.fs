module tutorialFsharp.Divisors

let getDivisors number =
    [1..number] |> List.filter (fun x -> number % x = 0)