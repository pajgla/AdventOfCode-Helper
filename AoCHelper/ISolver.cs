namespace AoCHelper;

using System.Diagnostics;

public interface ISolver
{
    public string SolvePart1(string input, bool enableDebug = false);

    public string SolvePart2(string input, bool enableDebug = false);
    public void ResetSolution();
}

public class BaseSolver<T> : ISolver where T : BaseSolution, new()
{
    public T m_Solution = new();
    
    public string SolvePart1(string input, bool enableDebug = false)
    {
        return Solve_Internal(ESolutionPart.PartOne, input, enableDebug);
    }

    public string SolvePart2(string input, bool enableDebug = false)
    {
        return Solve_Internal(ESolutionPart.PartTwo, input, enableDebug);
    }

    public void ResetSolution()
    {
        m_Solution = new();
    }

    private string Solve_Internal(ESolutionPart part, string input, bool enableDebug = false)
    {
        m_Solution.Initialize(part);
        m_Solution.m_EnableDebugOutput = enableDebug;
        
        Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
        string output = m_Solution.Solve(input);
        watch.Stop();
        
        Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds} ms ({watch.ElapsedMilliseconds / 1000f} seconds)");
        return output;
    }
}