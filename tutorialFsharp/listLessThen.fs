module tutorialFsharp.listLessThen

// return list with elements less then given number
let listLessThen list number =
    list |> List.filter (fun x -> x < number)