using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using Utils;

namespace Day06
{
    public class Day06 : Solver
    {
        private readonly long[] _input;

        public Day06()
        {
            var input = ReadInputText<string>()
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            _input = Enumerable.Range(0, 9)
                .Select(i => Convert.ToInt64(input.Count(x => x == i)))
                .ToArray();
        }

        public override string PartOne() => CountLanternFish(80).ToString();

        public override string PartTwo() => CountLanternFish(256).ToString();

        private long CountLanternFish(int days)
        {
            var rate = _input.ToArray();
            var day = 0;

            while (day < days)
            {
                var prevRate = 0L;

                for (int i = rate.Length - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        rate[6] += rate[i];
                        rate[8] = rate[i];
                    }

                    (rate[i], prevRate) = 
                    (prevRate, rate[i]);
                }
                day++;
            }

            return rate.Sum();
        }
    }
}
