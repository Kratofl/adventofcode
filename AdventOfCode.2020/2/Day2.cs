using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode._2
{
    static class Day2
    {
        public static string Part1()
        {
            int correctPasswords = 0;

            using (StreamReader sr = new StreamReader(@"2\input.csv"))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    int length = 0;
                    int minAmount;
                    int maxAmount;
                    char letter;
                    string password;

                    string[] linec = line.Split(':');
                    password = linec[1].Trim();

                    string[] pwPloicy = linec[0].Split(' ');
                    letter = char.Parse(pwPloicy[1]);

                    string[] pwSymbolLength = pwPloicy[0].Split('-');
                    minAmount = int.Parse(pwSymbolLength[0]);
                    maxAmount = int.Parse(pwSymbolLength[1]);

                    for (int i = 0; i < password.Length; i++)
                    {
                        if (password[i] == letter)
                        {
                            length ++;
                        }
                    }
                    if (length >= minAmount && length <= maxAmount)
                    {
                        correctPasswords ++;
                    }
                }
            }
            return correctPasswords.ToString();
        }
        public static string Part2()
        {
            int correctPasswords = 0;

            using (StreamReader sr = new StreamReader(@"2\input.csv"))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    int posOne;
                    int posTwo;
                    char letter;
                    char[] password;

                    string[] linec = line.Split(':');
                    password = linec[1].Trim().ToCharArray();

                    string[] pwPloicy = linec[0].Split(' ');
                    letter = char.Parse(pwPloicy[1]);

                    string[] pwSymbolPosition = pwPloicy[0].Split('-');
                    posOne = int.Parse(pwSymbolPosition[0]) - 1;
                    posTwo = int.Parse(pwSymbolPosition[1]) - 1;

                    if (password[posOne] == letter && password[posTwo] != letter || password[posOne] != letter && password[posTwo] == letter)
                    {
                        correctPasswords++;
                    }
                }
            }
            return correctPasswords.ToString();
        }
    }
}
