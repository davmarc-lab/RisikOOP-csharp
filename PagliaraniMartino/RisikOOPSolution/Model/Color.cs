namespace RisikOOPSolution.Model;

public class Color
{
    public static string Purple = "Purple";
    public static string Blue = "Blue";
    public static string Red = "Red";
    public string Name { get; set; }

    public Color(string name)
    {
        Name = name;
    }
}