module Day02

open Utils

// Check if a report is safe according to the rules
let isSafe levels =
    let rec checkSequence prev direction remainingLevels =
        match remainingLevels with
        | [] -> true
        | current :: rest ->
            let diff = current - prev
            let absDiff = abs diff
            
            // Check if difference is within valid range (1-3)
            if absDiff < 1 || absDiff > 3 then
                false
            else
                // Determine direction (1 for increasing, -1 for decreasing)
                let currentDirection = if diff > 0 then 1 else -1
                
                // Check if direction is consistent
                match direction with
                | None -> checkSequence current (Some currentDirection) rest
                | Some dir when dir = currentDirection -> checkSequence current direction rest
                | _ -> false
    
    match levels with
    | [] | [_] -> true
    | first :: rest -> checkSequence first None rest

// Check if a report can be made safe by removing one level
let canBeMadeSafe levels =
    if isSafe levels then
        true
    else
        // Try removing each level one at a time
        levels
        |> List.mapi (fun i _ -> 
            levels 
            |> List.mapi (fun j x -> if i = j then None else Some x)
            |> List.choose id)
        |> List.exists isSafe

let solve() =
    let lines = readLines "Input/02.txt"
    
    // Parse each line into a list of integers
    let reports = 
        lines 
        |> Array.map (fun line -> 
            line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries)
            |> Array.map parseInt
            |> Array.toList)
        |> Array.toList
    
    let part1() =
        let safeCount = reports |> List.filter isSafe |> List.length
        printfn "Day 2 - Part 1: Safe reports = %d" safeCount
        safeCount

    let part2() =
        let safeWithDampenerCount = reports |> List.filter canBeMadeSafe |> List.length
        printfn "Day 2 - Part 2: Safe reports with Problem Dampener = %d" safeWithDampenerCount
        safeWithDampenerCount

    printfn "=== Day 2 ==="
    let result1 = time part1
    let result2 = time part2
    (result1, result2)
