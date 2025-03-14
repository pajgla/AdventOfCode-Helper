using AoCHelper;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Advent of Code Helper! To run a solution, write year and day in one line, like this: 2024 11");
        Console.WriteLine("----------------------------");
        string? consoleInput = Console.ReadLine();

        if (consoleInput is null)
        {
            Console.WriteLine("Invalid input. Terminating the program.");
            return;
        }

        string[] splitInput = consoleInput.Split(' ');
        int splitInputLength = splitInput.Length;
        if (splitInputLength < 2 || splitInputLength > 3)
        {
            Console.WriteLine("Invalid input count. Provide input as {year} {day} {p:optional}. Terminating the program.");
            return;
        }

        int year;
        int day;
        try
        {
            year = int.Parse(splitInput[0]);
            day = int.Parse(splitInput[1]);
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input. Terminating the program.");
            return;
        }
        
        string? thirdArgument = splitInputLength == 3 ? splitInput[2].ToLower() : null;
        bool enableDebugPrint = false;
        if (thirdArgument is not null)
        {
            enableDebugPrint = thirdArgument is "p" or "1" or "printdebug";
        }
         
        SolutionRunner.RunSolution(year, day, enableDebugPrint);
        
        //Keep the console open
        Console.WriteLine();
    }


}
