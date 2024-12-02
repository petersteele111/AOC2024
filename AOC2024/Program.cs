namespace AOC2024
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please specify the day and part to run (e.g., 1 1):");
            var input = Console.ReadLine();
            var parts = input.Split(' ');

            if (parts.Length == 2 && int.TryParse(parts[0], out int day) && int.TryParse(parts[1], out int part))
            {
                var type = Type.GetType($"AOC2024.Day{day}.Part{part}");
                if (type != null)
                {
                    var method = type.GetMethod("Run", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
                    method?.Invoke(null, null);
                }
                else
                {
                    Console.WriteLine("Invalid day or part specified.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input format.");
            }
        }
    }
}