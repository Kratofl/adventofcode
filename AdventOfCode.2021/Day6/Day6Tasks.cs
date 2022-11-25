using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2021.Day6
{
    public class Day6Tasks
    {
        public string[] Lines { get; set; } = File.ReadAllLines("Day6/Input.csv");

        public int Task1()
        {
            return CalcualteFishInDays(80, false);
        }

        public int Task2()
        {
            return CalcualteFishInDays(256, true);
        }

        private int CalcualteFishInDays(int days, bool multipleArrays)
        {
            var fishTimers = Lines[0].Split(',').Select(x => int.Parse(x)).ToArray();
            var fishTimerDaysList = new List<int[]>();
            fishTimerDaysList.Add(fishTimers);

            for (int day = 0; day < days; day++)
            {
                var fishesAddedNextDay = new List<int>();
                if (!multipleArrays)
                {
                    for (int i = 0; i < fishTimers.Length; i++)
                    {
                        if (fishTimers[i] == 0)
                        {
                            fishTimers[i] = 6;
                            fishesAddedNextDay.Add(8);
                        }
                        else
                        {
                            fishTimers[i] -= 1;
                        }
                    }
                    fishTimers = fishTimers.Concat(fishesAddedNextDay).ToArray();
                }
                else
                {
                    for (int i = 0; i < fishTimerDaysList.Count; i++)
                    {
                        for (int i2 = 0; i2 < fishTimerDaysList[i].Length; i2++)
                        {
                            if (fishTimers[i] == 0)
                            {
                                fishTimers[i] = 6;
                                fishesAddedNextDay.Add(8);
                            }
                            else
                            {
                                fishTimers[i] -= 1;
                            }
                        }
                    }
                }
                //Array.Resize(ref fishTimers, fishTimers.Length + fishesAddedNextDay.Count);
                //fishesAddedNextDay.CopyTo(fishTimers, fishTimers.Length - fishesAddedNextDay.Count);
                //Array.Copy(fishesAddedNextDay.ToArray(), fishTimers, fishesAddedNextDay.Count);
            }

            return fishTimers.Length;
        }
    }
}
