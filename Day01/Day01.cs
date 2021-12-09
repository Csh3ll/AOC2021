using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Day01
{
    public class Day01 : Solver
    {
        public override string PartOne()
        {
            var depths = ReadInputArray<string>().Select(int.Parse).ToArray();
            int counter = 0;
            for (int i = 1; i < depths.Length; i++)
            {
                if (depths[i] > depths[i - 1])
                    counter++;
            }

            return counter.ToString();
        }
        public override string PartTwo()
        {
            var depths = ReadInputArray<string>().Select(int.Parse).ToArray();

            int counter = 0;
            for (var i = 3; i < depths.Length; i++)
            {
                var prevSet = depths.Skip(i - 3).Take(3);
                var currSet = depths.Skip(i - 2).Take(3);

                if (prevSet.Sum() < currSet.Sum())
                    counter++;
            }

            return counter.ToString();
        }
    }
}
