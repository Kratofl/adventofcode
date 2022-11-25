using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._8
{
    public static class Day8
    {
        private static readonly List<string> Input = File.ReadAllLines(@"8\input.csv").ToList();

        public static string Part1()
        {
            var bootCodes = GetInputToList();
            var position = new List<int>();

            int acc = 0;
            for (int i = 0; i < bootCodes.Count; i++)
            {
                if (position.Contains(i))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n.....loop detected.....");
                    Console.ForegroundColor = ConsoleColor.White;
                    return $"Accumulator value is: {acc}";
                }
                if (bootCodes[i].StartsWith("acc"))
                {
                    string[] value = bootCodes[i].Split(' ');
                    acc += int.Parse(value[1]);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"[{i:000}] Found: acc {value[1]}, acc now: {acc}");
                }
                else if (bootCodes[i].StartsWith("jmp"))
                {
                    string[] value = bootCodes[i].Split(' ');
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"[{i:000}] Found: jmp {value[1]}, jump to {i + int.Parse(value[1])}");
                    i += int.Parse(value[1]) - 1;
                }
                else
                {
                    string[] value = bootCodes[i].Split(' ');
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[{i:000}] Found: nop {value[1]}, no action");
                }
                position.Add(i);
            }
            return "Hä?????";
        }
        public static string Part2()
        {
            var bootCodes = GetInputToList();
            var position = new List<int>();

            int acc = 0;
            for (int i = 0; i < bootCodes.Count; i++)
            {
                if (bootCodes[i].StartsWith("nop"))
                {
                    acc = RunBootCodeWithChangedParameter(i, "jmp", bootCodes);
                }
                else if (bootCodes[i].StartsWith("jmp"))
                {
                    acc = RunBootCodeWithChangedParameter(i, "nop", bootCodes);
                }
                position.Add(i);
                if (acc != 0)
                {
                    return $"Accumulator value is: {acc}";
                }
            }
            return $"Accumulator value is: {acc}";
        }
        private static int RunBootCodeWithChangedParameter(int switchInstructionLine, string newInstruction, List<string> bootCodes)
        {
            int acc = 0;
            List<int> line = new List<int>();
            for (int i = 0; i < Input.Count; i++)
            {
                if (i == Input.Count - 1)
                {
                    return acc;
                }
                else if(line.Count > Input.Count)
                {
                    return 0;
                }
                line.Add(i);

                string instruction = "";
                if (bootCodes[i].StartsWith("jmp")) instruction = "jmp";
                else if(bootCodes[i].StartsWith("acc")) instruction = "acc";
                else if (bootCodes[i].StartsWith("nop")) instruction = "nop";

                if (i == switchInstructionLine)
                {
                    instruction = newInstruction;
                }

                string[] value = bootCodes[i].Split(' ');
                if (instruction == "jmp")
                {
                    i += int.Parse(value[1]) - 1;
                }
                else if (instruction == "acc")
                {
                    acc += int.Parse(value[1]);
                }
            }
            return 0;
        }
        private static List<string> GetInputToList()
        {
            var list = new List<string>();
            foreach (var item in Input) list.Add(item);
            return list;
        }

    }
}
