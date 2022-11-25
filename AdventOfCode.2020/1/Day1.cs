using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode._1
{
    static class Day1
    {

        public static string Part1()
        {
            List<int> expense = GetExpenseReport();

            foreach (var i in expense)
            {
                foreach (var i2 in expense)
                {
                    if (i + i2 == 2020)
                    {
                        int output = i * i2;
                        return output.ToString();
                    }
                }
            }
            return "0";

        }
        public static string Part2()
        {
            List<int> expense = GetExpenseReport();

            foreach (var i in expense)
            {
                foreach (var i2 in expense)
                {
                    foreach (var i3 in expense)
                    {
                        if (i + i2 + i3 == 2020)
                        {
                            int output = i * i2 * i3;
                            return output.ToString();
                        }
                    }
                }
            }
            return "0";
        }
        private static List<int> GetExpenseReport()
        {
            List<int> expense = new List<int>();
            using (StreamReader sr = new StreamReader(@"1\input.csv"))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    expense.Add(int.Parse(line));
                }
            }
            return expense;
        }


    }
}
