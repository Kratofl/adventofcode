using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode._6
{
    public static class Day6
    {
        private static readonly List<string> Input = File.ReadAllLines(@"6\input.csv").ToList();

        public static string Part1()
        {
            return $"Question answered with \"yes\": {GetAllAnswers()}";
        }
        public static string Part2()
        {
            return $"Same Questions answered with \"yes\": {GetSameAnswers()}";
        }

        private static List<string> GetAnswersFromInput()
        {
            var answers = new List<string>();
            var answersString = "";

            foreach (var item in Input)
            {
                if (item == String.Empty)
                {
                    answers.Add(answersString);
                    answersString = "";
                }
                else
                {
                    answersString += " " + item;
                }
            }
            return answers;
        }
        private static int GetAllAnswers()
        {
            var answers = GetAnswersFromInput();
            int counted = 0;
            foreach (var ans in answers)
            {
                counted += CountGroupAnswers(ans).Count();
            }
            return counted;
        }
        private static int GetSameAnswers()
        {
            int sum = 0;
            foreach (string ans in GetAnswersFromInput())
            {
                List<char> answersList = new List<char>();
                var temp = ans.Split(" ").Select(x => x.Distinct().ToList()).Where(x => x.Count > 0).ToList();
                for (int i = 0; i < temp.Count; i++)
                {
                    var a = temp[i];
                    if (i == 0)
                    {
                        answersList.AddRange(a);
                    }
                    else
                    {
                        answersList = new List<char>(answersList.Intersect(a).ToList());
                    }
                }

                sum += answersList.Count;
            }

            return sum;
        }
        private static List<char> CountGroupAnswers(string ans)
        {
            var answers = ans.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var counted = new List<char>();

            for (int i = 0; i < answers.Length; i++)
            {
                char[] letters = answers[i].ToCharArray();
                for (int il = 0; il < letters.Length; il++)
                {
                    if (!counted.Contains(letters[il]))
                    {
                        counted.Add(letters[il]);
                    }
                }
            }
            return counted;
        }
    }
}
