using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2021.Day3
{
    public class Day3Tasks
    {
        public string[] Lines { get; set; } = File.ReadAllLines("Day3/Input.csv");

        public int Task1()
        {
            var gammaRate = "";
            var epsilonRate = "";
            var maxIterations = Lines[0].Length;
            for (int iteration = 0; iteration < maxIterations; iteration++)
            {
                var times0ShowedUp = 0;
                var times1ShowedUp = 0;

                for (int i2 = 0; i2 < Lines.Length; i2++)
                {
                    var currentLine = Lines[i2];
                    if (currentLine[iteration] == '1')
                    {
                        times1ShowedUp += 1;
                    }
                    else
                    {
                        times0ShowedUp += 1;
                    }
                }

                if (times0ShowedUp > times1ShowedUp)
                {
                    gammaRate += "0";
                    epsilonRate += "1";
                }
                else
                {
                    gammaRate += "1";
                    epsilonRate += "0";
                }
            }
            return Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);
        }

        public int Task2()
        {
            var oxygenGeneratorRating = "";
            var co2ScrubberRacting = "";
            var maxIterations = Lines[0].Length;

            for (int changeValue = 0; changeValue < 2; changeValue++)
            {
                var selectedLines = Lines.ToList();
                for (int iteration = 0; iteration < maxIterations; iteration++)
                {
                    var times0ShowedUp = 0;
                    var times1ShowedUp = 0;
                    var linesContains1 = new List<string>();
                    var linesContains0 = new List<string>();

                    if (selectedLines.Count == 1)
                    {
                        break;
                    }

                    for (int i = 0; i < selectedLines.Count; i++)
                    {
                        var currentLine = selectedLines[i];
                        if (currentLine[iteration] == '1')
                        {
                            times1ShowedUp += 1;
                            linesContains1.Add(currentLine);
                        }
                        else
                        {
                            times0ShowedUp += 1;
                            linesContains0.Add(currentLine);
                        }
                    }

                    if (changeValue == 0)
                    {
                        if (times0ShowedUp > times1ShowedUp)
                        {
                            selectedLines = linesContains0;
                        }
                        else if (times0ShowedUp < times1ShowedUp)
                        {
                            selectedLines = linesContains1;
                        }
                        else
                        {
                            selectedLines = linesContains1;
                        }
                    }
                    else
                    {
                        if (times0ShowedUp > times1ShowedUp)
                        {
                            selectedLines = linesContains1;
                        }
                        else if (times0ShowedUp < times1ShowedUp)
                        {
                            selectedLines = linesContains0;
                        }
                        else
                        {
                            selectedLines = linesContains0;
                        }
                    }
                }
                if (changeValue == 0)
                {
                    oxygenGeneratorRating = selectedLines[0];
                }
                else
                {
                    co2ScrubberRacting = selectedLines[0];
                }
            }
            return Convert.ToInt32(oxygenGeneratorRating, 2) * Convert.ToInt32(co2ScrubberRacting, 2);
        }
    }
}
