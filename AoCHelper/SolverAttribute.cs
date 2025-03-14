namespace AoCHelper;

[AttributeUsage(AttributeTargets.Class)]
public class SolverAttribute(int year, int day) : Attribute
{
    public int m_Year = year;
    public int m_Day = day;
}