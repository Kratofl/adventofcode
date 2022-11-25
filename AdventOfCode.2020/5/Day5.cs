using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode._5
{
    public static class Day5
    {
        private static readonly List<string> Input = File.ReadAllLines(@"5\input.csv").ToList();

        public static string Part1()
        {
            int highestSeatId = 0;
            foreach (var item in Input)
            {
                int seatpos = GetSeatId(item);

                if (seatpos > highestSeatId)
                {
                    highestSeatId = seatpos;
                }
            }
            return $"Highest SeatId: {highestSeatId}";
        }
        public static string Part2()
        {
            int myseatid = GetMySeatId();
            return $"My SeatId: {myseatid}";
        }

        private static int GetSeatId(string seatcode)
        {
            Regex rgx = new Regex(@"^([B-F]{7})([L-R]{3})$");

            string groupValue = rgx.Match(seatcode).Groups[1].Value;
            double seatrow = GetSeatValues(groupValue, groupValue.Length, 127, 'F');
            groupValue = rgx.Match(seatcode).Groups[2].Value;
            double seatcolumn = GetSeatValues(groupValue, groupValue.Length, 7, 'L');

            return Convert.ToInt32(seatrow * 8 + seatcolumn);
        }
        private static double GetSeatValues(string seatcode, int length, int upperValue, char seatcodeIndex)
        {
            double lower = 0;
            double upper = upperValue;

            for (int i = 0; i < length; i++)
            {
                if (seatcode[i] == seatcodeIndex)
                {
                    upper = Math.Floor((upper + lower) / 2);
                }
                else
                {
                    lower = Math.Ceiling((lower + upper) / 2);
                }
            }

            return (upper + lower) / 2;
        }
        private static int GetMySeatId()
        {
            SortedList<int, int> sortedList = new SortedList<int, int>();
            int myseat = 0;
            foreach (var item in Input)
            {
                int seatpos = GetSeatId(item);
                sortedList.Add(seatpos, 0);
            }
            for (int i = 55; i < 953; i++)
            {
                if (!sortedList.ContainsKey(i))
                {
                    myseat = i;
                }
            }

            return myseat;
        }
    }
}
