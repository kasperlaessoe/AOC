module Day01Tests

open NUnit.Framework
open Day01

[<TestFixture>]
type Day01TestFixture() =
    
    // Sample data from Day 1 problem description
    let leftList = [3; 4; 2; 1; 3; 3]
    let rightList = [4; 3; 5; 3; 9; 3]
    
    [<Test>]
    member this.TestPart1() =
        // Sort both lists
        let sortedLeft = List.sort leftList
        let sortedRight = List.sort rightList
        
        // Calculate total distance
        let totalDistance = 
            List.zip sortedLeft sortedRight
            |> List.map (fun (left, right) -> abs (left - right))
            |> List.sum
        
        Assert.That(totalDistance, Is.EqualTo(11), "Part 1 should return 11 for sample data")

    [<Test>]
    member this.TestPart2() =
        // Count occurrences in right list
        let rightCounts = 
            rightList
            |> List.groupBy id
            |> List.map (fun (num, occurrences) -> (num, List.length occurrences))
            |> Map.ofList
        
        // Calculate similarity score
        let similarityScore =
            leftList
            |> List.map (fun num -> 
                let count = Map.tryFind num rightCounts |> Option.defaultValue 0
                num * count)
            |> List.sum
        
        Assert.That(similarityScore, Is.EqualTo(31), "Part 2 should return 31 for sample data")
