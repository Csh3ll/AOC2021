using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Utils;

namespace Day04
{
    public class Day04 : Solver
    {
        public override string PartOne()
        {
            string input = ReadInputText<string>();
            // first completed board
            return CompletedBoards(input).First().point.ToString();
        }

        public override string PartTwo()
        {
            string input = ReadInputText<string>();
            // last completed board
            return CompletedBoards(input).Last().point.ToString();
        }

        IEnumerable<Board> CompletedBoards(string input)
        {
            var lines = input.Split(Environment.NewLine);

            var bingoNumbers = lines[0].Split(",")
                .Select(int.Parse);

            var bingoBoards = lines.Skip(2).Chunk(6)
                .Select(x => new Board(x))
                .ToHashSet();

            var completedBoards = new List<Board>();
            foreach (var number in bingoNumbers)
            {
                foreach (var bingoBoard in bingoBoards.ToArray())
                {
                    bingoBoard.AddNumber(number);
                    if (bingoBoard.point > 0)
                    {
                        completedBoards.Add(bingoBoard);
                        bingoBoards.Remove(bingoBoard);
                    }
                }
            }
            return completedBoards;
        }
    }

    record Cell(int number, bool @checked = false);

    class Board
    {
        public int point { get; set; }
        private List<Cell> cells;

        IEnumerable<Cell> Rows(int row)
            => Enumerable.Range(0, 5)
                .Select(col => cells[row * 5 + col]);

        IEnumerable<Cell> Columns(int col)
            => Enumerable.Range(0, 5)
                .Select(row => cells[row * 5 + col]);

        public Board(string[] lines)
        {
            cells = string.Join(" ", lines)
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(word => new Cell(int.Parse(word))).ToList();
        }

        public void AddNumber(int number)
        {
            var list = cells;
            var cell = list.FindIndex(c => c.number == number);

            if (cell >= 0)
            {
                list[cell] = list[cell] with { @checked = true };

                for (var i = 0; i < 5; i++)
                {
                    if (Rows(i).All(cell => cell.@checked) || Columns(i).All(cell => cell.@checked))
                    {
                        var uncheckedNumbers = list.Where(cell => !cell.@checked)
                            .Select(cell => cell.number);

                        point = number * uncheckedNumbers.Sum();
                    }
                }
            }
        }
    }
}
