using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Day02
{
    public class Day02 : Solver
    {
        public override string PartOne()
        {
            string[] commands = ReadInputArray<string>();
            int horizontal = 0;
            int vertical = 0;

            foreach (string line in commands)
            {
                var instruction = line.Split();
                var direction = int.Parse(instruction[1]);

                switch (instruction[0])
                {
                    case "forward":
                        horizontal += direction;
                        break;
                    case "down":
                        vertical += direction;
                        break;
                    default:
                        vertical -= direction;
                        break;
                }
            }

            return (horizontal * vertical).ToString();
        }
        public override string PartTwo()
        {
            string[] commands = ReadInputArray<string>();
            int horizontal = 0;
            int vertical = 0;
            int aim = 0;

            foreach (string line in commands)
            {
                var instruction = line.Split();
                var direction = int.Parse(instruction[1]);

                switch (instruction[0])
                {
                    case "forward":
                        horizontal += direction;
                        vertical += aim * direction;
                        break;
                    case "down":
                        aim += direction;
                        break;
                    default:
                        aim -= direction;
                        break;
                }
            }

            return (horizontal * vertical).ToString();
        }
    }
}
