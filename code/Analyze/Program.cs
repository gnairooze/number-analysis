// See https://aka.ms/new-console-template for more information

namespace Analyze
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            var resutls = AnalyzeNumber(string.Empty, out string message, out bool isExit);

            if (isExit)
            {
                return;
            }
        }

        public static List<int>? AnalyzeNumber(string? input, out string message, out bool isExit)
        {
            message = string.Empty;
            isExit = false;

            Console.WriteLine("Write x to exit.");
            Console.WriteLine("Enter a number greater than 0 to analyze:");
            input = Console.ReadLine();

            if (input == "x")
            {
                isExit = true;
                Console.WriteLine("exit analysis.");
                return null; 
            }
            
            bool parseSucceeded = int.TryParse(input, out int number);

            if (!parseSucceeded)
            {
                Console.WriteLine("Invalid number");

                return AnalyzeNumber(input, out message, out isExit);
            }

            var results = NumberAnalysis.Business.Manager.AnalyzeNumber(number, out message);

            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);

                return AnalyzeNumber(input, out message, out isExit);
            }

            if (results == null)
            {
                Console.WriteLine("no analysis for this number");
                return AnalyzeNumber(input, out message, out isExit);
            }

            Console.WriteLine("resuts:");
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------");

            return AnalyzeNumber(input, out message, out isExit);
        }
    }
}

