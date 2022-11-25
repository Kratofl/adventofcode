using AdventOfCode._1;
using AdventOfCode._2;
using AdventOfCode._3;
using AdventOfCode._4;
using AdventOfCode._5;
using AdventOfCode._6;
using AdventOfCode._7;
using AdventOfCode._8;
using AdventOfCode._9;
using System;

namespace AdventOfCode
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("           Advent of Code 2020");
            Console.WriteLine("");
            Console.WriteLine(@"            *    *  ()   *   *");
            Console.WriteLine(@"         *        * /\         *");
            Console.WriteLine(@"               *   /i\\    *  *");
            Console.WriteLine(@"             *     o/\\  *      *");
            Console.WriteLine(@"          *       ///\i\    *");
            Console.WriteLine(@"              *   /*/o\\  *    *");
            Console.WriteLine(@"            *    /i//\*\      *");
            Console.WriteLine(@"                 /o/*\\i\   *");
            Console.WriteLine(@"           *    //i//o\\\\     *");
            Console.WriteLine(@"             * /*////\\\\i\*");
            Console.WriteLine(@"          *    //o//i\\*\\\   *");
            Console.WriteLine(@"            * /i///*/\\\\\o\   *");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"     /\  /\    ___  _ __  _ __ __    __");
            Console.WriteLine(@"    /  \/  \  / _ \| '__|| '__|\ \  / /");
            Console.WriteLine(@"   / /\  /\ \|  __/| |   | |    \ \/ /");
            Console.WriteLine(@"   \ \ \/ / / \___/|_|   |_|     \  /");
            Console.WriteLine(@"                                 / /");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(@"   __  __                       ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("/_/");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"     _");
            Console.WriteLine(@"   \ \/ /        /\  /\    __ _  ____  | |");
            Console.WriteLine(@"    \  /   __   /  \/  \  / _` |/ ___\ |_|");
            Console.WriteLine(@"    /  \  |__| / /\  /\ \| (_| |\___ \  _");
            Console.WriteLine(@"   /_/\_\      \ \ \/ / / \__,_|\____/ |_|");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Launching...");

            while (true)
            {
                string day;
                string part;
                try
                {
                    if (args[0] == "")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Please select a day (1-25)");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("> ");
                        day = Console.ReadLine();
                    }
                    else
                    {
                        day = args[0];
                        Console.WriteLine($"Day: {day}");
                    }
                    if (args[1] == "")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Please select a part from day {day} (1-2)");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("> ");
                        part = Console.ReadLine();
                    }
                    else
                    {
                        part = args[1];
                        Console.WriteLine($"Part: {part}");
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Please select a day (1-25)");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("> ");
                    day = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Please select a part from day {day} (1-2)");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("> ");
                    part = Console.ReadLine();
                }

                Start(day, part);
            }
        }
        private static void Start(string day, string part)
        {
            Console.ForegroundColor = ConsoleColor.White;

            switch (day)
            {
                case "1":
                    if (part == "1") Console.WriteLine(Day1.Part1()); else Console.WriteLine(Day1.Part2());
                    break;
                case "2":
                    if (part == "1") Console.WriteLine(Day2.Part1()); else Console.WriteLine(Day2.Part2());
                    break;
                case "3":
                    if (part == "1") Console.WriteLine(Day3.Part1()); else Console.WriteLine(Day3.Part2());
                    break;
                case "4":
                    if (part == "1") Console.WriteLine(Day4.Part1()); else Console.WriteLine(Day4.Part2());
                    break;
                case "5":
                    if (part == "1") Console.WriteLine(Day5.Part1()); else Console.WriteLine(Day5.Part2());
                    break;
                case "6":
                    if (part == "1") Console.WriteLine(Day6.Part1()); else Console.WriteLine(Day6.Part2());
                    break;
                case "7":
                    if (part == "1") Console.WriteLine(Day7.Part1()); else Console.WriteLine(Day7.Part2());
                    break;
                case "8":
                    if (part == "1") Console.WriteLine(Day8.Part1()); else Console.WriteLine(Day8.Part2());
                    break;
                case "9":
                    if (part == "1") Console.WriteLine(Day9.Part1()); else Console.WriteLine(Day9.Part2());
                    break;
                case "10":
                    Console.WriteLine("The day {0} does not exist yet", day);
                    break;
                case "11":
                    Console.WriteLine("The day {0} does not exist yet", day);
                    break;
                case "12":
                    Console.WriteLine("The day {0} does not exist yet", day);
                    break;
                case "13":
                    Console.WriteLine("The day {0} does not exist yet", day);
                    break;
                case "14":
                    Console.WriteLine("The day {0} does not exist yet", day);
                    break;
                case "15":
                    Console.WriteLine("The day {0} does not exist yet", day);
                    break;
                case "16":
                    Console.WriteLine("The day {0} does not exist yet", day);
                    break;
                case "17":
                    Console.WriteLine("The day {0} does not exist yet", day);
                    break;
                case "18":
                    Console.WriteLine("The day {0} does not exist yet", day);
                    break;
                case "19":
                    Console.WriteLine("The day {0} does not exist yet", day);
                    break;
                case "20":
                    Console.WriteLine("The day {0} does not exist yet", day);
                    break;
                case "21":
                    Console.WriteLine("The day {0} does not exist yet", day);
                    break;
                case "22":
                    Console.WriteLine("The day {0} does not exist yet", day);
                    break;
                case "23":
                    Console.WriteLine("The day {0} does not exist yet", day);
                    break;
                case "24":
                    Console.WriteLine("The day {0} does not exist yet", day);
                    break;
                case "25":
                    Console.WriteLine("The day {0} does not exist yet", day);
                    break;
                default:
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("Press a key to restart");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
