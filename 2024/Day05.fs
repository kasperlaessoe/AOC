module Day05

open Utils

let solve() =
    let lines = readLines "Input/05.txt"
    
    // Find the empty line that separates rules from updates
    let emptyLineIndex = lines |> Array.findIndex (fun line -> line.Trim() = "")
    
    // Parse rules (X|Y format)
    let rules = 
        lines.[0..emptyLineIndex-1]
        |> Array.map (fun line ->
            let parts = line.Split('|')
            (parseInt parts.[0], parseInt parts.[1]))
        |> Array.toList
    
    // Parse updates (comma-separated numbers)
    let updates = 
        lines.[emptyLineIndex+1..]
        |> Array.map (fun line ->
            line.Split(',')
            |> Array.map parseInt
            |> Array.toList)
        |> Array.toList
    
    // Check if an update follows all applicable rules
    let isValidUpdate update =
        let pagePositions = 
            update 
            |> List.mapi (fun i page -> (page, i))
            |> Map.ofList
        
        rules
        |> List.forall (fun (before, after) ->
            match Map.tryFind before pagePositions, Map.tryFind after pagePositions with
            | Some beforePos, Some afterPos -> beforePos < afterPos
            | _ -> true // Rule doesn't apply if either page is missing
        )
    
    // Get the middle page number from a list
    let getMiddlePage pages =
        let len = List.length pages
        pages.[len / 2]
    
    let part1() =
        let validUpdates = updates |> List.filter isValidUpdate
        let middleSum = validUpdates |> List.map getMiddlePage |> List.sum
        printfn "Day 5 - Part 1: Sum of middle pages = %d" middleSum
        middleSum

    // Fix an incorrectly ordered update using the rules
    let fixUpdate update =
        let relevantRules = 
            rules 
            |> List.filter (fun (before, after) ->
                List.contains before update && List.contains after update)
        
        // Use topological sort based on the rules
        let rec sortPages remaining =
            match remaining with
            | [] -> []
            | _ ->
                // Find a page that has no dependencies (no other remaining page should come before it)
                let nextPage = 
                    remaining 
                    |> List.find (fun page ->
                        relevantRules
                        |> List.forall (fun (before, after) ->
                            if after = page then not (List.contains before remaining)
                            else true))
                
                nextPage :: sortPages (List.filter ((<>) nextPage) remaining)
        
        sortPages update

    let part2() =
        let invalidUpdates = updates |> List.filter (not << isValidUpdate)
        let fixedUpdates = invalidUpdates |> List.map fixUpdate
        let middleSum = fixedUpdates |> List.map getMiddlePage |> List.sum
        printfn "Day 5 - Part 2: Sum of middle pages after fixing = %d" middleSum
        middleSum

    printfn "=== Day 5 ==="
    let result1 = time part1
    let result2 = time part2
    (result1, result2)
