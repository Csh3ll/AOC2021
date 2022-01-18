using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using static System.StringSplitOptions;

namespace Day08
{
    public class Day08 : Solver
    {
        public override string PartOne()
        {
            var lines = ReadInputArray<string>();

            int count = 0;
            var outputNumbers = new List<string>();
            foreach (var line in lines)
            {
                var secondPart = line.Split(" | ")[1].Split(" ");
                foreach (var number in secondPart)
                {
                    switch (number.Length)
                    {
                        case 2:
                        case 3:
                        case 4:
                        case 7: count++;
                            break;
                    }
                }
            }

            return count.ToString();
        }

        public override string PartTwo()
        {
            var lines = ReadInputArray<string>();

            int count = 0;
            foreach (var line in lines)
            {
                var part = line.Split("|", RemoveEmptyEntries | TrimEntries);
                var firstPart = part[0].Split(" ", RemoveEmptyEntries | TrimEntries)
                    .Select(x => x.OrderBy(v => v).ToHashSet()).ToList();
                var secondPart = part[1].Split(" ", RemoveEmptyEntries | TrimEntries)
                    .Select(x => x.OrderBy(v => v).ToHashSet()).ToList();

                var one = firstPart.First(x => x.Count == 2);
                var four = firstPart.First(x => x.Count == 4);
                var seven = firstPart.First(x => x.Count == 3);
                var eight = firstPart.First(x => x.Count == 7);
                var nine = firstPart.First(x => x.Count == 6 && four.All(x.Contains));
                var zero = firstPart.First(x => x.Count == 6 && !four.All(x.Contains) && one.All(x.Contains));
                var six = firstPart.First(x => x.Count == 6 && !four.All(x.Contains) && !one.All(x.Contains));
                var three = firstPart.First(x => x.Count == 5 && one.All(x.Contains));
                var five = firstPart.First(x => x.Count == 5 && !one.All(x.Contains) && x.All(six.Contains));
                var two = firstPart.First(x => x.Count == 5 && !one.All(x.Contains) && !x.All(six.Contains));

                var number = string.Empty;
                foreach (var entry in secondPart)
                {
                    if (entry.SequenceEqual(zero)) number += "0";
                    if (entry.SequenceEqual(one)) number += "1";
                    if (entry.SequenceEqual(two)) number += "2";
                    if (entry.SequenceEqual(three)) number += "3";
                    if (entry.SequenceEqual(four)) number += "4";
                    if (entry.SequenceEqual(five)) number += "5";
                    if (entry.SequenceEqual(six)) number += "6";
                    if (entry.SequenceEqual(seven)) number += "7";
                    if (entry.SequenceEqual(eight)) number += "8";
                    if (entry.SequenceEqual(nine)) number += "9";
                }
                count += int.Parse(number);
            }
            return count.ToString();
        }
    }
}
