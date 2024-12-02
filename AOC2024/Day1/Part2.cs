using System;
using System.Collections.Generic;
using System.IO;

namespace AOC2024.Day1
{
    class Part2
    {
        public static void Run()
        {
            var leftList = new List<int>();
            var rightList = new List<int>();
            var input = File.ReadAllLines("Day1/input.txt");

            foreach (var line in input)
            {
                var numbers = line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries);
                if (numbers.Length != 2) continue;
                leftList.Add(int.Parse(numbers[0]));
                rightList.Add(int.Parse(numbers[1]));
            }

            var rightCount = new Dictionary<int, int>();
            foreach (var number in rightList.Where(number => !rightCount.TryAdd(number, 1)))
            {
                rightCount[number]++;
            }

            var similarityScore = leftList.Where(number => rightCount.ContainsKey(number)).Sum(number => number * rightCount[number]);

            Console.WriteLine($"Similarity Score: {similarityScore}");
        }
    }
}