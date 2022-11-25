using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2021.Day2
{
    public class Day2Tasks
    {
        public string[] Lines { get; set; } = File.ReadAllLines("Day2/Input.csv");

        private int positionX;
        private int depth;
        private int aim;

        public int Task1()
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                var currentLine = Lines[i].Split(' ');
                var command = currentLine[0];
                var value = int.Parse(currentLine[1]);

                if (command == "forward") positionX += value;
                else if (command == "up") depth -= value;
                else if (command == "down") depth += value;
            }
            return positionX * depth;
        }

        public int Task2()
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                var currentLine = Lines[i].Split(' ');
                var command = currentLine[0];
                var value = int.Parse(currentLine[1]);

                if (command == "forward") { positionX += value; depth += aim*value; }
                else if (command == "up") { aim -= value; }
                else if (command == "down") { aim += value; }
            }
            return positionX * depth;
        }
    }
}
