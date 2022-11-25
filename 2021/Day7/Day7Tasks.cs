using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2021.Day7
{
    public class Day7Tasks
    {
        public string[] Lines { get; set; } = File.ReadAllLines("Day7/Input.csv");

        public int Task1()
        {
            var minFuelCosts = int.MaxValue;
            var positions = Lines[0].Split(',').Select(int.Parse).ToArray();

            for (int i = 0; i < positions.Length; i++)
            {
                var targetCrab = positions[i];
                var currentFuelCosts = 0;
                for (int i2 = 0; i2 < positions.Length; i2++)
                {
                    var currentCrab = positions[i2];
                    if (targetCrab != currentCrab)
                    {
                        var fuelCost = targetCrab > currentCrab ? targetCrab - currentCrab : currentCrab - targetCrab;
                        currentFuelCosts += fuelCost;
                    }
                }

                if (minFuelCosts > currentFuelCosts)
                {
                    minFuelCosts = currentFuelCosts;
                }
            }

            return minFuelCosts;
        }

        public int Task2()
        {
            //var averagePosition = 0;
            var minFuelCosts = int.MaxValue;
            var positions = Lines[0].Split(',').Select(int.Parse).ToArray();

            for (int i = 0; i < positions.Max(); i++)
            {
                var targetPosition = i;
                var currentFuelCosts = 0;
                for (int i2 = 0; i2 < positions.Length; i2++)
                {
                    var currentCrab = positions[i2];
                    if (targetPosition != currentCrab)
                    {
                        var fuelCost = targetPosition > currentCrab ? targetPosition - currentCrab : currentCrab - targetPosition;
                        for (int i3 = 0; i3 < fuelCost; i3++)
                        {
                            currentFuelCosts += 1 + i3;
                        }
                    }
                }

                if (minFuelCosts > currentFuelCosts)
                {
                    minFuelCosts = currentFuelCosts;
                }
                //averagePosition += positions[i];
            }
            //averagePosition = (int)Math.Round((decimal)(averagePosition / positions.Length), 0);

            return minFuelCosts;
        }
    }
}
