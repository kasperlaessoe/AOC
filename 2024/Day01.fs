module Day01

open Utils

let solve() =
    let lines = readLines "Input/01.txt"
    
    let parseLists (lines: string[]) =
        lines
        |> Array.map (fun line -> 
            let parts = line.Split([|' '; '\t'|], System.StringSplitOptions.RemoveEmptyEntries)
            (parseInt parts[0], parseInt parts[1]))
        |> Array.unzip
    
    let (leftList, rightList) = parseLists lines
    
    let part1() =
        let sortedLeft = Array.sort leftList
        let sortedRight = Array.sort rightList
        
        let totalDistance = 
            Array.zip sortedLeft sortedRight
            |> Array.map (fun (left, right) -> abs (left - right))
            |> Array.sum
        
        printfn "Day 1 - Part 1: Total distance = %d" totalDistance
        totalDistance

    let part2() =
        let rightCounts = 
            rightList
            |> Array.groupBy id
            |> Array.map (fun (num, occurrences) -> (num, Array.length occurrences))
            |> Map.ofArray
        
        let similarityScore =
            leftList
            |> Array.map (fun num -> 
                let count = Map.tryFind num rightCounts |> Option.defaultValue 0
                num * count)
            |> Array.sum
        
        printfn "Day 1 - Part 2: Similarity score = %d" similarityScore
        similarityScore

    printfn "=== Day 1 ==="
    let result1 = time part1
    let result2 = time part2
    (result1, result2)
