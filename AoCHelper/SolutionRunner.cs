namespace AoCHelper;

using System.Reflection;



public static class SolutionRunner
{
    public static void RunSolution(int year, int day)
    {
        ISolver? solver = FindSolver(year, day);
        if (solver is null)
        {
            return;
        }

        string? input = FindInput(year, day);
        if (input is null)
        {
            return;
        }
        
        SolveBothParts(solver, input);
    }

    private static string? FindInput(int year, int day)
    {
        string inputPath = Path.Combine("Solutions", $"{year}", $"{day}", "Input.txt");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file is missing for this solution. Please create a new .txt file in the" +
                              " corresponding advent of code solution directory and name it 'Input.txt'.");
            return null;
        }
        
        return File.ReadAllText(inputPath);
    }
    
    private static ISolver? FindSolver(int year, int day)
    {
        var solverType = Assembly.GetExecutingAssembly().GetTypes()
            .FirstOrDefault(t => t.GetCustomAttribute<SolverAttribute>()?.m_Year == year
                                 && t.GetCustomAttribute<SolverAttribute>()?.m_Day == day);

        if (solverType is null || Activator.CreateInstance(solverType) is not ISolver solver)
        {
            Console.WriteLine($"Could not find a solver for year {year} day {day}");
            return null;
        }
        
        return solver;
    }
    
    private static void SolveBothParts(ISolver solver, string input)
    {
        SolvePart(ESolutionPart.PartOne, solver, input);
        SolvePart(ESolutionPart.PartTwo, solver, input);
    }

    private static void SolvePart(ESolutionPart part, ISolver solver, string input)
    {
        int partNumber = part == ESolutionPart.PartOne ? 1 : 2;
    
        Console.WriteLine("----------------------------");
        Console.WriteLine($"Executing part {partNumber}...");
        string output = partNumber == 1 ? solver.SolvePart1(input) : solver.SolvePart2(input);
        Console.WriteLine($"Output: {output}");
    }
}
