/* ----------------------------- This is an example solution class --------------------------
 *
 * Advent of Code 2024 - Day 11 Solution
 * 
 * Problem Description:
 * This puzzle involves processing a sequence of stone numbers according to specific rules:
 * - If a stone number is 0, it creates a new stone with number 1
 * - If a stone number has an even number of digits, it splits into two new stones
 *   (first half digits and second half digits)
 * - If a stone number has an odd number of digits, it is multiplied by 2024
 * 
 * The solution runs for a specified number of "blinks" and calculates the total number
 * of stones at the end of the process.
 */

namespace AoCHelper;

[Solver(1999, 7)]
public class SolutionExampleSolver : BaseSolver<SolutionExample>
{
    //No need to have anything here
}

public class SolutionExample : BaseSolution
{
    //You can define members here
    private bool m_ExampleBool = false;
    private Dictionary<int, bool> m_ExampleMap = new();
    
    //You can also define config members (in PlutonianPebbles example, we have different amount of blinks in first and second exercise part)
    private int m_Blinks = 25;

    //Initialize your solution based on the exercise part
    public override void Initialize(ESolutionPart part)
    {
        if (part == ESolutionPart.PartOne)
        {
            m_Blinks = 25;
        }
        else
        {
            m_Blinks = 75;
        }
    }

    //Write your solution here and return the output as string
    public override string Solve(string input)
    {
        //Process puzzle input
        string[] inputArray = input.Split(' ');
        for (int i = 0; i < inputArray.Length; i++)
        {
            m_ExampleMap[int.Parse(inputArray[i])] = true;
        }

        DebugPrint("You can also write debug prints if you need them!");
        return $"{m_ExampleMap[0]}";
    }
}