namespace AoCHelper;

public enum ESolutionPart
{
    PartOne,
    PartTwo
}

public abstract class BaseSolution
{
    public abstract void Initialize(ESolutionPart part);
    public abstract void Reset();
    public abstract string Solve(string input);
    
    protected void DebugPrint(string message)
    {
        if (m_EnableDebugOutput)
        {
            Console.WriteLine(message);
        }
    }

    public bool m_EnableDebugOutput = false;
}