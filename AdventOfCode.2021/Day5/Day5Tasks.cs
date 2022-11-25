using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2021.Day5
{
    public class Day5Tasks
    {
        readonly Dictionary<(int X, int Y), int> _board = new();
        public string[] Lines { get; set; } = File.ReadAllLines("Day5/Input.csv");

        private int overlapPoints = 0;
        private Dictionary<(int X, int Y), int> rangeLines = new();

        // BASED: https://github.com/MaxtorCoder/AdventOfCode-2021/blob/master/AdventOfCode/Days/Day5.cs
        public int Task1()
        {
            var maxNumber = 0;
            for (int i = 0; i < Lines.Length; i++)
            {
                var currentLine = Lines[i];
                var coordinates = currentLine.Split(new string[] { ",", " -> " }, StringSplitOptions.RemoveEmptyEntries);

                var x1 = int.Parse(coordinates[0]);
                var x2 = int.Parse(coordinates[2]);
                var y1 = int.Parse(coordinates[1]);
                var y2 = int.Parse(coordinates[3]);

                // MY IDEA, BUT IT WAS TOO HIGH
                //if (x1 == x2)
                //{
                //    LineDoesOverlap(x1, y1);
                //    LineDoesOverlap(x2, y2);

                //    var higherCoordinate = y1 > y2 ? y1 : y2;
                //    var lowerCoordinate = y2 > y1 ? y1 : y2;

                //    for (int i2 = lowerCoordinate; i2 <= higherCoordinate; i2++)
                //    {
                //        LineDoesOverlap(x1, i2);
                //    }
                //}
                //if (y1 == y2)
                //{
                //    var higherCoordinate = x1 > x2 ? x1 : x2;
                //    var lowerCoordinate = x2 > x1 ? x1 : x2;

                //    for (int i2 = lowerCoordinate; i2 <= higherCoordinate; i2++)
                //    {
                //        LineDoesOverlap(i2, y1);
                //    }
                //}

                MarkCoords(x1, x2, y1, y2);


                if (maxNumber < x1)
                    maxNumber = x1;
                else if (maxNumber < x2)
                    maxNumber = x2;

                if (maxNumber < y1)
                    maxNumber = y1;
                else if (maxNumber < y2)
                    maxNumber = y2;
            }

            for (var x = 0; x <= maxNumber; ++x)
            {
                for (var y = 0; y <= maxNumber; ++y)
                {
                    if (_board.ContainsKey((y, x)))
                    {
                        if (_board[(y, x)] >= 2)
                            ++overlapPoints;
                    }
                }
            }

            return overlapPoints;
        }

        // MY IDEA, IDK IF THIS IS RIGHT
        private void LineDoesOverlap(int x, int y)
        {
            if (!rangeLines.ContainsKey((y, x)))
            {
                rangeLines.Add((y, x), 0);
            }
            else
            {
                overlapPoints += 1;
            }
        }

        // BOTH COPIED FROM DUDE ABOVE
        private void MarkCoords(int x1, int x2, int y1, int y2)
        {
            // Ignore diagonal coords
            if ((x1 == x2 && y1 != y2) || (x1 != x2 && y1 == y2))
            {
                var xCount = Math.Abs(x1 - x2);
                var yCount = Math.Abs(y1 - y2);

                for (var i = 0; i <= xCount; ++i)
                {
                    if (x1 > x2)
                        MarkCoordsInBoard(x1 - i, y1);
                    else if (x1 < x2)
                        MarkCoordsInBoard(x1 + i, y1);
                }
                for (var i = 0; i <= yCount; ++i)
                {
                    if (y1 > y2)
                        MarkCoordsInBoard(x1, y1 - i);
                    else if (y1 < y2)
                        MarkCoordsInBoard(x1, y1 + i);
                }
            }
        }
        private void MarkCoordsInBoard(int x, int y)
        {
            if (!_board.ContainsKey((x, y)))
                _board.Add((x, y), 0);
            _board[(x, y)]++;
        }

        // COPIED: https://github.com/filipbiernat/AdventOfCode2021/blob/master/Day5/Day5B.cs
        public void Task2()
        {
            // You come across a field of hydrothermal vents on the ocean floor! 
            // They tend to form in lines; the submarine helpfully produces a list of nearby lines of vents for you to review. 
            string[] input = File.ReadAllLines(@"Day5\Input.csv");
            IEnumerable<Point> hydrothermalVentsPoints = input
                .Select(line => line
                    .Split(new string[] { "->", "," }, StringSplitOptions.TrimEntries)
                    .Select(int.Parse)
                    .ToList())
                .SelectMany(elem => GetPointsInBetween(new Point(elem[0], elem[1]), new Point(elem[2], elem[3])));

            // To avoid the most dangerous areas, you need to determine the number of points where at least two lines overlap. 
            int output = hydrothermalVentsPoints
                .GroupBy(elem => elem)
                .Where(group => group.Count() >= 2)
                .Select(elem => elem.Key)
                .ToList()
                .Count;

            // Consider all of the lines. At how many points do at least two lines overlap?
            Console.WriteLine("Solution: {0}.", output);
        }

        private static List<Point> GetPointsInBetween(Point pointA, Point pointB)
        {
            Size delta = new(Math.Sign(pointB.X - pointA.X), Math.Sign(pointB.Y - pointA.Y));
            List<Point> pointsInBetween = new() { pointA };
            while (pointsInBetween.Last() != pointB)
            {
                pointsInBetween.Add(pointsInBetween.Last() + delta);
            }
            return pointsInBetween;
        }
    }
}
