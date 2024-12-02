namespace AOC2024.Day2
{
    public class Part1
    {
        public static void Run()
        {
            var input = File.ReadAllLines("Day2/input.txt");
            var safeReportsCount = 0;

            foreach (var line in input)
            {
                var levels = line.Split(' ').Select(int.Parse).ToList();

                if (IsSafeReport(levels))
                {
                    safeReportsCount++;
                }
            }
            Console.WriteLine($"Number of safe reports: {safeReportsCount}");
        }

        private static bool IsSafeReport(List<int> levels)
        {
            for (var i = 1; i < levels.Count; i++)
            {
                var diff = levels[i] - levels[i - 1];

                if (diff is 0 or < -3 or > 3)
                {
                    return false;
                }
            }

            var isIncreasing = true;
            var isDecreasing = true;

            for (var i = 1; i < levels.Count; i++)
            {
                if (levels[i] < levels[i - 1])
                {
                    isIncreasing = false;
                }
                if (levels[i] > levels[i - 1])
                {
                    isDecreasing = false;
                }
            }
            return isIncreasing || isDecreasing;
        }
    }
}