using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AOC2024.Day3
{
    public class Part2
    {
        public static void Run()
        {
            var input = File.ReadAllText("Day3/input.txt");
            
            var mulRegex = new Regex(@"mul\((\d+),(\d+)\)");
            var doRegex = new Regex(@"do\(\)");
            var dontRegex = new Regex(@"don't\(\)");

            var instructions = new SortedList<int, (string type, int x, int y)>();
            
            foreach (Match match in mulRegex.Matches(input))
            {
                instructions.Add(match.Index, ("mul", int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value)));
            }
            
            foreach (Match match in doRegex.Matches(input))
            {
                instructions.Add(match.Index, ("do", 0, 0));
            }
            
            foreach (Match match in dontRegex.Matches(input))
            {
                instructions.Add(match.Index, ("don't", 0, 0));
            }

            bool mulEnabled = true;
            long sum = 0;

            foreach (var kvp in instructions)
            {
                var instruction = kvp.Value;
                switch (instruction.type)
                {
                    case "do":
                        mulEnabled = true;
                        break;
                    case "don't":
                        mulEnabled = false;
                        break;
                    case "mul":
                        if (mulEnabled)
                        {
                            sum += (long)instruction.x * instruction.y;
                        }
                        break;
                }
            }

            Console.WriteLine($"Sum of enabled multiplications: {sum}");
        }
    }
}
