using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode._4
{
    static class Day4
    {
        private static readonly List<string> Input = File.ReadAllLines(@"4\input.csv").ToList();

        //public static string Part1()
        //{
        //    int validPassports = 0;
        //    int validpoints = 0;
        //    List<string> lines = GetPassportsFromInput();
        //    for (int i = 0; i < lines.Count; i++)
        //    {
        //        string[] values = lines[i].Split(' ');
        //        string[] sdf = values[i].Split(':');
        //        switch (sdf[0])
        //        {
        //            case "byr":
        //                if (GetPassportValidByRange(sdf[1], 1920, 2002)) { validpoints += 1; }
        //                break;
        //            case "iyr":
        //                if (GetPassportValidByRange(sdf[1], 2010, 2020)) { validpoints += 1; }
        //                break;
        //            case "eyr":
        //                if (GetPassportValidByRange(sdf[1], 2020, 2030)) { validpoints += 1; }
        //                break;
        //            case "hgt":
        //                if (GetPassportValid_hgt(sdf[1])) { validpoints += 1; }
        //                break;
        //            case "hcl":
        //                if (GetPassportValidByRegex(sdf[1], "^#[A-Fa-f0-9]{6}|#[A-Fa-f0-9]{3}$")) { validpoints += 1; }
        //                break;
        //            case "ecl":
        //                if (GetPassportValidByRegex(sdf[1], "^(amb|blu|brn|gry|grn|hzl|oth)$")) { validpoints += 1; }
        //                break;
        //            case "pid":
        //                if (GetPassportValidByRegex(sdf[1], "^[0-9]{9}$")) { validpoints += 1; }
        //                break;
        //        }
        //    }
        //    Console.ForegroundColor = ConsoleColor.White;
        //    return $"Valid passports: {validpassports}";
        //}
        //public static string Part2()
        //{
        //    int validpassports = 0;
        //    using (StreamReader sr = new StreamReader(@"4\input.csv"))
        //    {
        //        int birthyear = 0;
        //        int issueyear = 0;
        //        int expirationyear = 0;
        //        string height = "MISSING";
        //        string haircolor = "MISSING";
        //        string eyecolor = "MISSING";
        //        string passportid = "MISSING";

        //        String line;
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            if (line != "")
        //            {
        //                string[] linecontent = line.Split(' ');
        //                for (int i = 0; i < linecontent.Length; i++)
        //                {
        //                    try
        //                    {
        //                        if (linecontent[i].StartsWith("byr")) { string[] byr = linecontent[i].Split(':'); birthyear = int.Parse(byr[1]); }
        //                        if (linecontent[i].StartsWith("iyr")) { string[] iyr = linecontent[i].Split(':'); issueyear = int.Parse(iyr[1]); }
        //                        if (linecontent[i].StartsWith("eyr")) { string[] eyr = linecontent[i].Split(':'); expirationyear = int.Parse(eyr[1]); }
        //                        if (linecontent[i].StartsWith("hgt")) { string[] hgt = linecontent[i].Split(':'); height = hgt[1]; }
        //                        if (linecontent[i].StartsWith("hcl")) { string[] hcl = linecontent[i].Split(':'); haircolor = hcl[1]; }
        //                        if (linecontent[i].StartsWith("ecl")) { string[] ecl = linecontent[i].Split(':'); eyecolor = ecl[1]; }
        //                        if (linecontent[i].StartsWith("pid")) { string[] pid = linecontent[i].Split(':'); passportid = pid[1]; }
        //                    }
        //                    catch (FormatException)
        //                    {
        //                        Console.ForegroundColor = ConsoleColor.Yellow;
        //                        Console.WriteLine($"[FORMAT]  byr:{birthyear} iyr:{issueyear} eyr:{expirationyear} hgt:{height} hcl:{haircolor} ecl:{eyecolor} pid:{passportid} valid:{validpassports}");
        //                        Console.ForegroundColor = ConsoleColor.White;
        //                        Console.WriteLine($"Reset");
        //                        birthyear = 0;
        //                        issueyear = 0;
        //                        expirationyear = 0;
        //                        height = "MISSING";
        //                        haircolor = "MISSING";
        //                        eyecolor = "MISSING";
        //                        passportid = "MISSING";
        //                        break;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                //if (CheckPassport(birthyear, issueyear, expirationyear, height, haircolor, eyecolor, passportid))
        //                //{
        //                //    validpassports++;
        //                //    Console.ForegroundColor = ConsoleColor.Green;
        //                //    Console.WriteLine($"[VALID]   byr:{birthyear} iyr:{issueyear} eyr:{expirationyear} hgt:{height} hcl:{haircolor} ecl:{eyecolor} pid:{passportid} valid:{validpassports}");
        //                //}
        //                //else
        //                //{
        //                //    Console.ForegroundColor = ConsoleColor.Red;
        //                //    Console.WriteLine($"[INVALID] byr:{birthyear} iyr:{issueyear} eyr:{expirationyear} hgt:{height} hcl:{haircolor} ecl:{eyecolor} pid:{passportid} valid:{validpassports}");
        //                //}
        //                birthyear = 0;
        //                issueyear = 0;
        //                expirationyear = 0;
        //                height = "MISSING";
        //                haircolor = "MISSING";
        //                eyecolor = "MISSING";
        //                passportid = "MISSING";
        //                Console.ForegroundColor = ConsoleColor.White;
        //                Console.WriteLine($"Reset");
        //            }
        //        }
        //    }
        //    Console.ForegroundColor = ConsoleColor.White;
        //    return $"Valid passports: {validpassports}";
        //}
        public static string Part1()
        {
            int validPassports = 0;
            var passports = GetPassportsFromInput();
            var ppFields = GetPassportValidationFields();

            foreach (var pp in passports)
            {
                if (ppFields.All(pp.Contains))
                    validPassports++;
            }

            return String.Format("Part 1 valid passports: {0}", validPassports.ToString());
        }
        public static string Part2()
        {
            int validPassports = 0;
            var passports = GetPassportsFromInput();
            var ppValidationFields = GetPassportValidationFields();

            foreach (var pp in passports)
            {
                if (ppValidationFields.All(pp.Contains) && ValidatePassportFields(pp))
                    validPassports++;
            }

            return String.Format("Part 2 valid passports: {0}", validPassports.ToString());
        }

        private static bool ValidatePassportFields(string pp)
        {
            var fields = pp.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var field in fields)
            {
                var keyValue = field.Split(':');
                var valid = true;

                switch (keyValue[0])
                {
                    case "byr":
                        valid = GetPassportValidByRange(keyValue[1], 1920, 2002);
                        break;
                    case "iyr":
                        valid = GetPassportValidByRange(keyValue[1], 2010, 2020);
                        break;
                    case "eyr":
                        valid = GetPassportValidByRange(keyValue[1], 2020, 2030);
                        break;
                    case "hgt":
                        valid = GetPassportValid_hgt(keyValue[1]);
                        break;
                    case "hcl":
                        valid = GetPassportValidByRegex(keyValue[1], @"^#[0-9a-f]{6}$");
                        break;
                    case "ecl":
                        valid = GetPassportValidByRegex(keyValue[1], @"^(amb|blu|brn|gry|grn|hzl|oth)$");
                        break;
                    case "pid":
                        valid = GetPassportValidByRegex(keyValue[1], @"^[0-9]{9}$");
                        break;
                    default:
                        break;
                }
                if (valid)
                    Console.WriteLine(String.Format("Checking: {0} key: {1} value {2}", valid.ToString(), keyValue[0], keyValue[1]));

                if (!valid)
                    return false;
            }

            return true;
        }
        private static List<string> GetPassportValidationFields()
        {
            var ppFields = new List<string>();
            ppFields.Add("byr");
            ppFields.Add("iyr");
            ppFields.Add("eyr");
            ppFields.Add("hgt");
            ppFields.Add("hcl");
            ppFields.Add("ecl");
            ppFields.Add("pid");
            return ppFields;
        }
        private static List<string> GetPassportsFromInput()
        {
            var passports = new List<string>();
            var passportString = "";

            foreach (var item in Input)
            {
                if (item == String.Empty)
                {
                    passports.Add(passportString);
                    passportString = "";
                }
                else
                {
                    passportString += " " + item;
                }
            }
            return passports;
        }
        private static bool GetPassportValidByRegex(string value, string regex)
        {
            Regex rgx = new Regex(@regex);
            if (!rgx.IsMatch(value))
            {
                return false;
            }
            return true;
        }
        private static bool GetPassportValidByRange(string value, int min, int max)
        {
            int valueAsInt;
            if (!int.TryParse(value, out valueAsInt))
                return false;

            return valueAsInt >= min && valueAsInt <= max;
        }
        private static bool GetPassportValid_hgt(string value)
        {
            var regexResult = Regex.Match(value, @"^(\d+)(cm|in)$");
            if (!regexResult.Success)
                return false;
            var number = int.Parse(regexResult.Groups[1].Value);
            var unit = regexResult.Groups[2].Value;

            if ((unit != "cm" && number! >= 150 && number! <= 193) || (unit != "in" && number! >= 59 && number! <= 76))
            {
                return false;
            }
            return true;
        }

    }
}
