namespace AoCHelper.Core;

[Solver(2024, 1)]
public class HistorianHysteriaSolver : BaseSolver<HistorianHysteria>
{

}

public class HistorianHysteria : BaseSolution
{
    private int[] m_LeftList;
    private int[] m_RightList;

    private ESolutionPart m_SolutionPart = ESolutionPart.PartOne;
    
    public override void Initialize(ESolutionPart part)
    {
        m_SolutionPart = part;
    }

    public override string Solve(string input)
    {
        if (m_SolutionPart == ESolutionPart.PartOne)
        {
            return SolvePartOne(input);
        }
        else
        {
            return SolvePartTwo(input);
        }
    }

    private string SolvePartOne(string input)
    {
        SplitInput(input);
        
        Array.Sort(m_LeftList);
        Array.Sort(m_RightList);
        
        int totalDifference = 0;
        for (int i = 0; i < m_LeftList.Length; i++)
        {
            totalDifference += Math.Abs(m_RightList[i] - m_LeftList[i]);
        }
        
        return $"Total difference = {totalDifference}";
    }

    private string SolvePartTwo(string input)
    {
        SplitInput(input);

        Dictionary<int, int> rightNumbersMap = new Dictionary<int, int>();
        
        foreach (int rightNumber in m_RightList)
        {
            if (!rightNumbersMap.ContainsKey(rightNumber))
            {
                rightNumbersMap.Add(rightNumber, 1);
            }
            else
            {
                rightNumbersMap[rightNumber]++;
            }
        }

        int similarityScore = 0;
        foreach (int leftNumber in m_LeftList)
        {
            if (rightNumbersMap.ContainsKey(leftNumber))
            {
                similarityScore += leftNumber * rightNumbersMap[leftNumber];
            }
        }
        
        return $"Similarity score = {similarityScore}";
    }

    private void SplitInput(string input)
    {
        string[] splitInput = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        int totalLines = splitInput.Length;
        m_LeftList = new int[totalLines];
        m_RightList = new int[totalLines];
        
        int currentLineCount = 0;
        foreach (string s in splitInput)
        {
            string[] spltRow = s.Split("   ", StringSplitOptions.RemoveEmptyEntries);
            m_LeftList[currentLineCount] = int.Parse(spltRow[0]);
            m_RightList[currentLineCount] = int.Parse(spltRow[1]);
            currentLineCount++;
        }
    }
}