using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2021.Day4
{
    public class Day4Tasks
    {
        public string[] Lines { get; set; } = File.ReadAllLines("Day4/Input.csv");

        public int Task1()
        {
            var nubmersToDraw = new List<int>();
            var playfields = new List<List<string[]>>();
            List<string[]> winnerPlayfieldArray = null;
            var lastNumberDrawn = 0;
            var winnerSum = 0;

            // SORT NUMBERS TO DRAW AND THE PLAYFIELDS
            var playfieldArray = new List<string[]>();
            for (int i = 0; i < Lines.Length; i++)
            {
                var currentLine = Lines[i];
                if (i == 0) { nubmersToDraw = currentLine.Split(',').Select(int.Parse).ToList(); continue; }

                if (currentLine != "")
                {
                    var numbersInCurrentLine = currentLine.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    playfieldArray.Add(numbersInCurrentLine);
                }
                else
                {
                    if (i != 1)
                    {
                        playfields.Add(playfieldArray);
                        playfieldArray = new List<string[]>();
                    }
                }
            }

            for (int i = 0; i < nubmersToDraw.Count; i++)
            {
                lastNumberDrawn = nubmersToDraw[i];
                if (lastNumberDrawn == 24)
                { }
                for (int i2 = 0; i2 < playfields.Count; i2++)
                {
                    var currentPlayfield = playfields[i2];
                    for (int i3 = 0; i3 < currentPlayfield.Count; i3++)
                    {
                        var currentRow = currentPlayfield[i3];
                        for (int i4 = 0; i4 < currentRow.Length; i4++)
                        {
                            var number = currentRow[i4];
                            if (int.TryParse(number, out _) && int.Parse(number) == lastNumberDrawn) { playfields[i2][i3][i4] = "X"; }
                        }
                        var xInRow = currentRow.Where(x => x == "X").Count();
                        if (xInRow == 5)
                        {
                            winnerPlayfieldArray = currentPlayfield;
                            break;
                        }
                    }
                    if (winnerPlayfieldArray != null) break;
                }
                if (winnerPlayfieldArray != null) break;
            }

            if (winnerPlayfieldArray != null)
            {
                for (int i = 0; i < winnerPlayfieldArray.Count; i++)
                {
                    var currentRow = winnerPlayfieldArray[i];
                    //var test = currentRow.Where(x => x.GetType() == typeof(int)).Select(x => int.Parse(x));
                    for (int i2 = 0; i2 < currentRow.Length; i2++)
                    {
                        var number = currentRow[i2];
                        if (int.TryParse(number, out _)) { winnerSum += int.Parse(number); }
                    }
                }
            }

            return winnerSum * lastNumberDrawn;
        }

        public int Task2()
        {
            var nubmersToDraw = new List<int>();
            var playfields = new List<List<string[]>>();
            List<string[]> winnerPlayfieldArray = null;
            var lastNumberDrawn = 0;
            var winnerSum = 0;
            var playfieldsWonCount = 0;
            var playfieldsWon = new List<List<string[]>>();

            // SORT NUMBERS TO DRAW AND THE PLAYFIELDS
            var playfieldArray = new List<string[]>();
            for (int i = 0; i < Lines.Length; i++)
            {
                var currentLine = Lines[i];
                if (i == 0) { nubmersToDraw = currentLine.Split(',').Select(int.Parse).ToList(); continue; }

                if (currentLine != "")
                {
                    var numbersInCurrentLine = currentLine.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    playfieldArray.Add(numbersInCurrentLine);
                }
                else
                {
                    if (i != 1)
                    {
                        playfields.Add(playfieldArray);
                        playfieldArray = new List<string[]>();
                    }
                }
            }

            for (int i = 0; i < nubmersToDraw.Count; i++)
            {
                lastNumberDrawn = nubmersToDraw[i];
                if (lastNumberDrawn == 24)
                { }
                for (int i2 = 0; i2 < playfields.Count; i2++)
                {
                    var currentPlayfield = playfields[i2];
                    for (int i3 = 0; i3 < currentPlayfield.Count; i3++)
                    {
                        var currentRow = currentPlayfield[i3];
                        for (int i4 = 0; i4 < currentRow.Length; i4++)
                        {
                            var number = currentRow[i4];
                            if (int.TryParse(number, out _) && int.Parse(number) == lastNumberDrawn) { playfields[i2][i3][i4] = "X"; }
                        }
                        if (PlayfieldWon(currentPlayfield) && !playfieldsWon.Contains(currentPlayfield))
                        {
                            playfieldsWonCount += 1;
                            if (playfieldsWonCount == playfields.Count)
                            {
                                winnerPlayfieldArray = currentPlayfield;
                                break;
                            }
                            playfieldsWon.Add(currentPlayfield);
                        }
                        //var xInRow = currentRow.Where(x => x == "X").Count();
                        //if (xInRow == 5 && !playfieldsWon.Contains(currentPlayfield))
                        //{
                        //    playfieldsWonCount += 1;
                        //    if (playfieldsWonCount == playfields.Count)
                        //    {
                        //        winnerPlayfieldArray = currentPlayfield;
                        //        break;
                        //    }
                        //    playfieldsWon.Add(currentPlayfield);
                        //}
                    }
                    if (winnerPlayfieldArray != null) break;
                }
                if (winnerPlayfieldArray != null) break;
            }

            if (winnerPlayfieldArray != null)
            {
                for (int i = 0; i < winnerPlayfieldArray.Count; i++)
                {
                    var currentRow = winnerPlayfieldArray[i];
                    //var test = currentRow.Where(x => x.GetType() == typeof(int)).Select(x => int.Parse(x));
                    for (int i2 = 0; i2 < currentRow.Length; i2++)
                    {
                        var number = currentRow[i2];
                        if (int.TryParse(number, out _))
                        {
                            winnerSum += int.Parse(number);
                        }
                    }
                }
            }

            return winnerSum * lastNumberDrawn;
        }

        private bool PlayfieldWon(List<string[]> playfield)
        {
            if (playfield[0][0] == "X" && playfield[0][1] == "X" && playfield[0][2] == "X" && playfield[0][3] == "X" && playfield[0][4] == "X" ||
                playfield[1][0] == "X" && playfield[1][1] == "X" && playfield[1][2] == "X" && playfield[1][3] == "X" && playfield[1][4] == "X" ||
                playfield[2][0] == "X" && playfield[2][1] == "X" && playfield[2][2] == "X" && playfield[2][3] == "X" && playfield[2][4] == "X" ||
                playfield[3][0] == "X" && playfield[3][1] == "X" && playfield[3][2] == "X" && playfield[3][3] == "X" && playfield[3][4] == "X" ||
                playfield[4][0] == "X" && playfield[4][1] == "X" && playfield[4][2] == "X" && playfield[4][3] == "X" && playfield[4][4] == "X" ||
                playfield[0][0] == "X" && playfield[1][0] == "X" && playfield[2][0] == "X" && playfield[3][0] == "X" && playfield[4][0] == "X" ||
                playfield[0][1] == "X" && playfield[1][1] == "X" && playfield[2][1] == "X" && playfield[3][1] == "X" && playfield[4][1] == "X" ||
                playfield[0][2] == "X" && playfield[1][2] == "X" && playfield[2][2] == "X" && playfield[3][2] == "X" && playfield[4][2] == "X" ||
                playfield[0][3] == "X" && playfield[1][3] == "X" && playfield[2][3] == "X" && playfield[3][3] == "X" && playfield[4][3] == "X" ||
                playfield[0][4] == "X" && playfield[1][4] == "X" && playfield[2][4] == "X" && playfield[3][4] == "X" && playfield[4][4] == "X")
            {
                return true;
            }
            return false;
        }
    }
}
