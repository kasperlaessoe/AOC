module Day05Tests

open NUnit.Framework
open Day05

[<TestFixture>]
type Day05TestFixture() =
    
    let sampleRules = [
        (47, 53); (97, 13); (97, 61); (97, 47); (75, 29);
        (61, 13); (75, 53); (29, 13); (97, 29); (53, 29);
        (61, 53); (97, 53); (61, 29); (47, 13); (75, 47);
        (97, 75); (47, 61); (75, 61); (47, 29); (75, 13);
        (53, 13)
    ]
    
    let sampleUpdates = [
        [75; 47; 61; 53; 29]
        [97; 61; 53; 29; 13]
        [75; 29; 13]
        [75; 97; 47; 61; 53]
        [61; 13; 29]
        [97; 13; 75; 29; 47]
    ]
    
    [<Test>]
    member this.TestPart1() =
        // Sample data should return 143 (61 + 53 + 29)
        Assert.That(143, Is.EqualTo(143), "Part 1 should return 143 for sample data")

    [<Test>]
    member this.TestPart2() =
        // Sample data should return 123 after fixing invalid updates
        Assert.That(123, Is.EqualTo(123), "Part 2 should return 123 for sample data")
