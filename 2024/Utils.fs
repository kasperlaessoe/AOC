module Utils

open System.IO

/// Read all lines from a file
let readLines (filename: string) =
    File.ReadAllLines(filename)

/// Read all text from a file
let readText (filename: string) =
    File.ReadAllText(filename)

/// Split a string by a separator
let split (separator: string) (text: string) =
    text.Split(separator, System.StringSplitOptions.RemoveEmptyEntries)

/// Parse a string to an integer
let parseInt (s: string) =
    System.Int32.Parse(s)

/// Parse a string to a long
let parseLong (s: string) =
    System.Int64.Parse(s)

/// Timer function to measure execution time
let time func =
    let stopwatch = System.Diagnostics.Stopwatch.StartNew()
    let result = func()
    stopwatch.Stop()
    printfn "Execution time: %d ms" stopwatch.ElapsedMilliseconds
    result
