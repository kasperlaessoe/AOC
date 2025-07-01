open System
open System.Reflection

let getAvailableDays() =
    let assembly = Assembly.GetExecutingAssembly()
    assembly.GetTypes()
    |> Array.filter (fun t -> 
        t.Name.StartsWith("Day") && 
        t.Name.Length = 5 && // Day01, Day02, etc.
        t.GetMethod("solve") <> null)
    |> Array.map (fun t -> 
        let dayNum = t.Name.Substring(3) |> int
        (dayNum, t))
    |> Array.sortBy fst

let runDay dayNumber =
    let availableDays = getAvailableDays()
    match availableDays |> Array.tryFind (fun (num, _) -> num = dayNumber) with
    | Some (_, dayType) ->
        let solveMethod = dayType.GetMethod("solve")
        solveMethod.Invoke(null, [||]) |> ignore
        true
    | None ->
        printfn "Day %d not found or not implemented yet" dayNumber
        printfn "Available days: %s" 
            (availableDays |> Array.map (fun (num, _) -> string num) |> String.concat ", ")
        false

let runAllDays() =
    let availableDays = getAvailableDays()
    if Array.isEmpty availableDays then
        printfn "No day solutions found"
    else
        availableDays |> Array.iter (fun (dayNum, _) -> 
            printfn ""
            runDay dayNum |> ignore)

[<EntryPoint>]
let main args =
    printfn "Advent of Code 2024 - F# Solutions"
    printfn "=================================="
    
    match args with
    | [||] ->
        // Run all days if no arguments provided
        runAllDays()
        
    | [| dayArg |] ->
        // Run specific day
        match Int32.TryParse(dayArg) with
        | (true, dayNum) when dayNum > 0 && dayNum <= 25 ->
            runDay dayNum |> ignore
        | _ ->
            printfn "Invalid day: %s" dayArg
            printfn "Please provide a day number between 1 and 25"
            
    | _ ->
        printfn "Usage: dotnet run [day_number]"
        printfn "Example: dotnet run 1"
    
    0
    