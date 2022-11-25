using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2021.Day1
{
    public class Day1Tasks
    {
        public string[] Lines { get; set; } = File.ReadAllLines("Day1/Input.csv");

        public int Task1()
        {
            int previousMaxMeasurement = int.Parse(Lines[0]);
            var timesLargerThenBefore = 0;

            for (int i = 1; i < Lines.Length; i++)
            {
                var currentLine = int.Parse(Lines[i]);
                if (currentLine > previousMaxMeasurement)
                {
                    timesLargerThenBefore += 1;
                }
                previousMaxMeasurement = currentLine;
            }
            return timesLargerThenBefore;
        }

        public int Task2()
        {
            int previousMaxMeasurement = 0;
            var timesLargerThenBefore = 0;

            for (int i = 0; i < Lines.Length; i++)
            {
                var currentLine = int.Parse(Lines[i]);
                var sum = 0;

                if ((i + 1) < Lines.Length)
                {
                    sum = currentLine + int.Parse(Lines[i + 1]);
                }
                if ((i + 2) < Lines.Length)
                {
                    sum += int.Parse(Lines[i + 2]);
                }

                if (i != 0)
                {
                    if (sum > previousMaxMeasurement)
                    {
                        timesLargerThenBefore += 1;
                    }
                }
                previousMaxMeasurement = sum;
            }
            return timesLargerThenBefore;
        }
    }
}
