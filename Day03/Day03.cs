using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Day03
{
    public class Day03 : Solver
    {
        private static List<List<int>> _bits;
        private static int _length;

        public override string PartOne()
        {
            {
                IEnumerable<string> input = ReadInputArray<string>();
                _bits = input
                    .Select(input => input.Select(CharToInt).ToList())
                    .ToList();
            }

            _length = _bits.First().Count;

            int gamma = 0;
            int epsilon = 0;
            int doubler = 1;

            for (int i = _length - 1; i >= 0; i--)
            {
                int sum = IndexSum(_bits, i);

                if (sum > 0)
                    gamma += doubler;
                else
                    epsilon += doubler;

                doubler *= 2;
            }

            return (gamma * epsilon).ToString();
        }

        public override string PartTwo()
        {
            int oxy = FromBits(Filter(1, -1));
            int co2 = FromBits(Filter(-1, 1));

            return (oxy * co2).ToString();
        }

        static int CharToInt(char bit)
            => bit switch
            {
                '0' => -1,
                '1' => 1,
                _ => throw new ArgumentException(message: "Invalid value")
            };

        List<int> Filter(int positive, int negative)
        {
            var bitList = _bits;

            for (int i = 0; i < _length; i++)
            {
                int sum = IndexSum(bitList, i);

                if (sum >= 0)
                    bitList = bitList.Where(bits => bits[i] == positive).ToList();
                else
                    bitList = bitList.Where(bits => bits[i] == negative).ToList();

                if (bitList.Count == 1)
                    break;
            }

            return bitList.First();
        }

        static int IndexSum(List<List<int>> bits, int i)
            => bits.Select(bits => bits[i]).Sum();

        static int FromBits(List<int> bits)
        {
            int res = 0;
            int doubling = 1;

            for (int i = bits.Count - 1; i >= 0; i--)
            {
                if (bits[i] == 1)
                    res += doubling;

                doubling *= 2;
            }
            return res;
        }
    }
}
