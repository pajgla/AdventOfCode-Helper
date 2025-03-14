/*
 * Advent of Code 2024 - Day 11 Solution
 * 
 * Problem Description:
 * This puzzle involves processing a sequence of stone numbers according to specific rules:
 * - If a stone number is 0, it creates a new stone with number 1
 * - If a stone number has an even number of digits, it splits into two new stones
 *   (first half digits and second half digits)
 * - If a stone number has an odd number of digits, it is multiplied by 2024
 * 
 * Solution Approach:
 * - Use two dictionaries to track stones: one for current state (currentStone) and one for next state (m_NextStones)
 * - Each iteration ("blink"):
 *   1. Process each stone in m_CurrentStones map according to rules
 *   2. Store resulting stones in m_NextStones map
 *   3. Merge m_NextStones back into m_CurrentStones
 *   4. Clear m_NextStones map for next iteration
 * - Track stone counts using dictionary values to handle multiple identical stones efficiently
 * 
 * The solution runs for a specified number of "blinks" and calculates the total number
 * of stones at the end of the process.
 */

namespace AoCHelper;

[Solver(2024, 11)]
public class PlutonianPebblesSolver : BaseSolver<PlutonianPebblesSolution>
{
}

public class PlutonianPebblesSolution : BaseSolution
{
    Dictionary<long, long> m_CurrentStones = new();
    Dictionary<long, long> m_NextStones = new();
    
    //Config
    int m_BlinkCount = 0;

    public override void Initialize(ESolutionPart part)
    {
        if (part == ESolutionPart.PartOne)
        {
            m_BlinkCount = 25;
        }
        else
        {
            m_BlinkCount = 75;
        }
    }

    public override string Solve(string input)
    {
        //Process puzzle input
        string[] inputArray = input.Split(' ');
        for (int i = 0; i < inputArray.Length; i++)
        {
            AddToMap(m_CurrentStones, long.Parse(inputArray[i]), 1);
        }


        for (int blink = 1; blink <= m_BlinkCount; blink++)
        {
            DebugPrint("New Blink!");

            foreach (KeyValuePair<long, long> pair in m_CurrentStones)
            {
                long stoneNumber = pair.Key;
                long stoneCount = pair.Value;
                if (stoneCount > 0)
                {
                    DebugPrint($"Stone: {stoneNumber}, Count: {stoneCount}, ");
                }
                ProcessStone(pair);
            }

            //Transfer from next to current stones
            foreach (KeyValuePair<long, long> pair in m_NextStones)
            {
                long stoneNumber = pair.Key;
                long stoneCount = pair.Value;
                
                AddToMap(m_CurrentStones, stoneNumber, stoneCount);
            }
            
            m_NextStones.Clear();

            DebugPrint("\n");
        }

        return $"Total stones: {m_CurrentStones.Sum(x => x.Value)}";
    }

    void ProcessStone(KeyValuePair<long, long> kvp)
    {
        long stoneNumber = kvp.Key;
        long stoneCount = kvp.Value;

        if (kvp.Key == 0)
        {
            AddToMap(m_NextStones, 1, stoneCount);
        }
        else if (GetNumberOfDigits(stoneNumber) % 2 == 0)
        {
            SplitStone(stoneNumber);
        }
        else
        {
            AddToMap(m_NextStones, stoneNumber * 2024, stoneCount);
        }

        //We processed the number, so we can set its count to 0
        m_CurrentStones[stoneNumber] = 0;
    }

    int GetNumberOfDigits(long number)
    {
        return number.ToString().Length;
    }

    void SplitStone(long stoneNumber)
    {
        long stoneCount = m_CurrentStones[stoneNumber];
        string stoneNumberString = stoneNumber.ToString();
        int length = stoneNumberString.Length;
        int halfLength = length / 2;
        string firstHalf = stoneNumberString.Substring(0, length - halfLength);
        string secondHalf = stoneNumberString.Substring(halfLength);
        AddToMap(m_NextStones, long.Parse(firstHalf), stoneCount);
        AddToMap(m_NextStones, long.Parse(secondHalf), stoneCount);
    }

    void AddToMap(Dictionary<long, long> map, long stoneNumber, long stoneCount)
    {
        if (!map.TryAdd(stoneNumber, stoneCount))
        {
            map[stoneNumber] += stoneCount;
        }
    }
}