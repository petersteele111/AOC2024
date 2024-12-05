using System.Text.RegularExpressions;

namespace AOC2024.Day3;

public class Part1
{
    public static void Run()
    {
        var input = File.ReadAllText("Day3/input.txt");
        var sum = 0;
        
        var regex = new Regex(@"mul\((\d+),(\d+)\)");
        var matches = regex.Matches(input);

        foreach (Match match in matches)
        {
            var x = int.Parse(match.Groups[1].Value);
            var y = int.Parse(match.Groups[2].Value);
            var result = x * y;
            sum += result;
        }

        Console.WriteLine($"Sum of all valid multiplications: {sum}");
    }
}