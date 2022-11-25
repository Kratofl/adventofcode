using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode._3
{
    static class Day3
    {
        public static string Part1()
        {
            long tressHit = GetHittedTrees(3, 1);
            return $"Trees hit: {tressHit}";
        }
        public static string Part2()
        {
            long _1 = GetHittedTrees(1, 1);
            long _2 = GetHittedTrees(3, 1);
            long _3 = GetHittedTrees(5, 1);
            long _4 = GetHittedTrees(7, 1);
            long _5 = GetHittedTrees(1, 2);

            long output = _1 * _2 * _3 * _4 * _5;

            return $"Trees hit: {output}";
        }

        private static long GetHittedTrees(int right, int down)
        {
            int tressHit = 0;
            int passed = 0;
            int row = 0;
            int skipper = down;
            int currentLine = 0;
            using (StreamReader sr = new StreamReader(@"3\input.csv"))
            {
                String line;
                int position = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (currentLine % skipper != 0)
                    {
                        currentLine++;
                        continue;
                    }
                    currentLine++;
                    if (position >= line.Length) position -= line.Length;

                    string line1 = line.Substring(0, position);
                    string line2 = line.Substring(position, line.Length - position - 1);
                    if (line[position] == '#')
                    {
                        position = PositionJump(line, position, right);
                        tressHit += 1;
                        ConsoleOutput(currentLine, position, line1, line2, "X", "HIT", ConsoleColor.Red);
                    }
                    else
                    {
                        position = PositionJump(line, position, right);
                        passed += 1;
                        ConsoleOutput(currentLine, position, line1, line2, "X", "PASSED", ConsoleColor.Green);

                    }

                    if (row != 323)
                    {
                        row += 1;
                    }
                }
                if (down % 2 == 0)
                {
                    skipper += 1;
                }
            }
            return tressHit;
        }
        private static void ConsoleOutput(int row, int position, string line1, string line2, string marker, string type, ConsoleColor color)
        {
            Console.Write($"[{row:000}]");
            if (type == "HIT") Console.Write($" {type}       {position:00}  {line1}"); else Console.Write($" {type}    {position:00}  {line1}");
            Console.ForegroundColor = color;
            Console.Write(marker);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{line2}");
        }
        private static int PositionJump(string line, int position, int positionhopp)
        {
            if (position < line.Length) { position += positionhopp; } else position = line.Length - position;
            return position;
        }
    }
}
