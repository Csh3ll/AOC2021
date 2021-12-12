using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Day07
{
    public class Day07 : Solver
    {
        private record CrabRate(int Position, int Count);
        private readonly Dictionary<int, int> _input;

        public Day07()
        {
            _input = ReadInputText<string>()
                .Split(",")
                .Select(int.Parse)
                .GroupBy(x => x)
                .Select(x => new CrabRate(x.Key, x.Count(y => y == x.Key)))
                .ToDictionary(x => x.Position, x => x.Count);
        }

        public override string PartOne()
        {
            var minFuel = int.MaxValue;

            foreach (var pos in _input)
            {
                var fuel = 0;
                foreach (var comp in _input)
                    fuel += comp.Value * Math.Abs(comp.Key - pos.Key);

                if (fuel < minFuel)
                    minFuel = fuel;
            }
            return minFuel.ToString();
        }

        public override string PartTwo()
        {
            var positionRange = Enumerable.Range(1, _input.Count).ToArray();
            var minFuel = long.MaxValue;

            foreach (var i in positionRange)
            {
                var fuel = 0;
                foreach (var comp in _input)
                {
                    var diff = Math.Abs(i - comp.Key);
                    fuel += diff * (diff + 1) / 2 * comp.Value;
                }

                if (fuel < minFuel)
                    minFuel = fuel;
            }
            return minFuel.ToString();
        }
    }
}
