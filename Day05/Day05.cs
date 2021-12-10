using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Day05
{
    record Vector(int x, int y);
    public class Day05 : Solver
    {
        public override string PartOne()
        {
            var input = ReadInputArray<string>();
            return CountOverlaps(ParseInput(input, true)).ToString();
        }
        public override string PartTwo()
        {
            var input = ReadInputArray<string>();
            return CountOverlaps(ParseInput(input, false)).ToString();
        }

        IEnumerable<IEnumerable<Vector>> ParseInput(string[] input, bool skipDiagonals)
            => from line in input

            let coordinates = (
                    from data in line.Split(", ->".ToArray(), StringSplitOptions.RemoveEmptyEntries)
                    select int.Parse(data)
                ).ToArray()

            // line properties:
            let start = new Vector(coordinates[0], coordinates[1])
            let end = new Vector(coordinates[2], coordinates[3])
            let diff = new Vector(end.x - start.x, end.y - start.y)
            let len = 1 + Math.Max(Math.Abs(diff.x), Math.Abs(diff.y))
            let direction = new Vector(Math.Sign(diff.x), Math.Sign(diff.y))

            // points:
            let points =
                from i in Enumerable.Range(0, len)
                select new Vector(start.x + i * direction.x, start.y + i * direction.y)

            // skip diagonals
            where !skipDiagonals || direction.x == 0 || direction.y == 0

            select points;

        private int CountOverlaps(IEnumerable<IEnumerable<Vector>> lines)
        {
            var diagram = new Dictionary<Vector, int>();
            foreach (var pt in lines.SelectMany(pt => pt)) 
                diagram[pt] = diagram.GetValueOrDefault(pt, 0) + 1;

            int count = 0;
            foreach (var x in diagram)
            {
                if (x.Value > 1)
                    count++;
            }

            return count;
        }
    }
}
