using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode._7
{
    public static class Day7
    {
        private static readonly List<string> Input = File.ReadAllLines(@"7\input.csv").ToList();

        public static string Part1()
        {
            return $"So many bags can contain at least one shiny gold bag: {GetBags()}";
        }
        public static string Part2()
        {
            return $"";
        }

        private static int GetBags()
        {
            Regex nobagsfilter = new Regex(@"^[a-z]* [a-z]* bags contain no other bags.$");
            int bags = 0;
            List<string> bagsWithShinyGoldBags = new List<string>();
            int run = 0;
            foreach (var item in GetInputToList())
            {
                if (!nobagsfilter.IsMatch(item))
                {
                    bags += GetBagsWithShinyGoldBags(item, ref bagsWithShinyGoldBags);
                }
            }
            for (int i = 0; i < 1; i++)
            {
                foreach (var item in GetInputToList())
                {
                    if (!nobagsfilter.IsMatch(item))
                    {
                        int[] bagsShinyGold = GetBagsContainShinyInTree(item, ref bagsWithShinyGoldBags);
                        bags += bagsShinyGold[0];
                        run = bagsShinyGold[1];
                        if (run != 0)
                        {
                            i = 0;
                        }
                    }
                }

            }

            return bags;
        }
        private static int GetBagsWithShinyGoldBags(string bag, ref List<string> bagsWithShinyGoldBags)
        {
            string[] bags = bag.Split(" bags contain ");
            string mainbagColor = bags[0];

            if (bags[1].Contains("shiny gold bag"))
            {
                bagsWithShinyGoldBags.Add(mainbagColor);
            }

            return bagsWithShinyGoldBags.Count;
        }
        private static int[] GetBagsContainShinyInTree(string bag, ref List<string> bagTree)
        {
            Regex bagColorFilter = new Regex(@"([0-9]) ([a-z]* [a-z]*)");
            string[] bags = bag.Split(" bags contain ");
            string mainBag = bags[0];
            string[] bagsInMainBag = bags[1].Trim().Split(',');
            int goldBagTree = 0;
            int run = 0;

            foreach (var item in bagsInMainBag)
            {
                var amountContainbag = bagColorFilter.Match(item).Groups[1].Value;
                var colorContainbag = bagColorFilter.Match(item).Groups[2].Value;

                if (bagTree.Contains(colorContainbag))
                {
                    if (int.Parse(amountContainbag) >= 1)
                    {
                        goldBagTree += 1;
                        bagTree.Remove(colorContainbag);
                        bagTree.Add(mainBag);
                        run += 1;
                    }
                }
            }
            return new int[] { goldBagTree, run };
        }

        private static List<string> GetInputToList()
        {
            var list = new List<string>();

            foreach (var item in Input)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
