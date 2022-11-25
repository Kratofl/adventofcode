using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._9
{
    public static class Day9
    {
        private static readonly List<string> Input = File.ReadAllLines(@"9\input.csv").ToList();

        public static string Part1()
        {
            string str = "0123456789";
            str.Length();
            while (true)
            {

            }
            List<string> numbers = GetInputToList();
            for (int i = 0; i < 5; i++)
            {
                for (int i2 = 0; i2 < 5; i2++)
                {
                    int n1 = int.Parse(numbers[i]);
                    int n2 = int.Parse(numbers[i2]);
                    int nend = int.Parse(numbers[5]);
                    if (n1 != n2)
                    {
                        if (n1 + n2 == nend)
                        {
                            Console.WriteLine($"{n1} + {n2} + {nend}");
                        }
                    }
                }
            }
            return $"";
        }
        public static string Part2()
        {
            return $"";
        }

        private static List<string> GetInputToList()
        {
            var list = new List<string>();

            foreach (var item in Input)
            {
                list.Add(item);
            }
            return list;
        }

        private static int Length(this string value)
        {
            return value.Length;
        }
    }
}

