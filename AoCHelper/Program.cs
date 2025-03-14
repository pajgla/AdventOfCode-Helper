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
        if (splitInput.Length != 2)
        {
            Console.WriteLine("Invalid input. Terminating the program.");
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

        SolutionRunner.RunSolution(year, day);
        
        //Keep the console open
        Console.WriteLine();
    }


}
