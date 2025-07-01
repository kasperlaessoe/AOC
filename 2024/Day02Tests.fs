module Day02Tests

open NUnit.Framework
open Day02

[<TestFixture>]
type Day02TestFixture() =
    
    let sampleData = [
        [7; 6; 4; 2; 1]
        [1; 2; 7; 8; 9]
        [9; 7; 6; 2; 1]
        [1; 3; 2; 4; 5]
        [8; 6; 4; 4; 1]
        [1; 3; 6; 7; 9]
    ]
    
    [<Test>]
    member this.TestPart1() =
        let safeCount = sampleData |> List.filter Day02.isSafe |> List.length
        Assert.That(safeCount, Is.EqualTo(2), "Part 1 should return 2 for sample data")
    
    [<Test>]
    member this.TestPart2() =
        let safeWithDampenerCount = sampleData |> List.filter Day02.canBeMadeSafe |> List.length
        Assert.That(safeWithDampenerCount, Is.EqualTo(4), "Part 2 should return 4 for sample data")
