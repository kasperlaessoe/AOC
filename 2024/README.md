# Advent of Code 2024 - F# Solutions

This project contains F# solutions for Advent of Code 2024.

## Running the Solutions

To run all solutions:
```bash
dotnet run
```

To run a specific day:
```bash
dotnet run 1    # Run Day 1
```

## Project Structure

- `Program.fs` - Main entry point
- `Utils.fs` - Common utility functions
- `Day01.fs` - Day 1 solution (template)
- `Input/` - Input files (gitignored)

## Adding New Days

1. Create a new `Day##.fs` file
2. Add it to the `AOC2024.fsproj` file in the `<ItemGroup>`
3. Add the day to the pattern matching in `Program.fs`

## Input Files

Place your input files in the `Input/` directory with names like `day01.txt`, `day02.txt`, etc.
