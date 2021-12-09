using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Utils
{
    public abstract class Solver
    {
        private readonly string inputPath = "../../../input.txt";

        public T[] ReadInputArray<T>()
        {
            return File.ReadAllLines(inputPath).Select(l => (T)Convert.ChangeType(l, typeof(T))).ToArray();
        }
        public T ReadInputText<T>()
        {
            return (T)Convert.ChangeType(File.ReadAllText(inputPath), typeof(T));
        }
        public abstract string PartOne();
        public abstract string PartTwo();

        public void GetPuzzleResult()
        {
            PrintBanner();

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" *  ");
                Console.ResetColor();

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                var resultPart1 = PartOne();
                stopWatch.Stop();
                TimeSpan ts1 = stopWatch.Elapsed;

                PrintResults("Part One", resultPart1);
                Console.WriteLine($"Time: {ts1.TotalSeconds} sec");
                SaveOutput(resultPart1, "part1");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - -");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("* * ");
                Console.ResetColor();
                stopWatch.Start();
                var resultPart2 = PartTwo();
                stopWatch.Stop();
                TimeSpan ts2 = stopWatch.Elapsed;
                PrintResults("Part Two", resultPart2);
                Console.WriteLine($"Time: {ts2.TotalSeconds} sec");
                SaveOutput(resultPart2, "part2");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        private void SaveOutput(string result, string part)
        {
            File.WriteAllText($"../../../Output/output_{part}.txt", result);
        }


        private void PrintResults(string part, string result)
        {
            Console.WriteLine(part);
            Console.Write("Result: ");
            Console.ForegroundColor = result == "Not Solved." ? ConsoleColor.DarkGray : ConsoleColor.Yellow;
            Console.WriteLine(result.ToString());
            Console.ResetColor();
        }

        private void PrintBanner()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@" _                        _    __         ");
            Console.WriteLine(@"|_| _|    _ __ _|_    _ _|_   /   _  _| _ ");
            Console.WriteLine(@"| |(_|\_/(/_| | |_   (_) |    \__(_)(_|(/_   2021");
            Console.WriteLine(@"");
            Console.ResetColor();
        }
    }
}
