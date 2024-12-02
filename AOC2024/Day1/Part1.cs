namespace AOC2024.Day1
{
    class Part1
    {
        static void Run()
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
            
            leftList.Sort();
            rightList.Sort();

            var totalDistance = 0;
            
            for (var i = 0; i < leftList.Count; i++)
            {
                Console.WriteLine($"{leftList[i]} {rightList[i]}");
                
                var rowDistance = Math.Abs(leftList[i] - rightList[i]);
                
                totalDistance += rowDistance;
            }
            Console.WriteLine($"Total Distance: {totalDistance}");
        }
    }
}