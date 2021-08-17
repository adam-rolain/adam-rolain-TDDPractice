using System;

namespace DiamondKata
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Type a letter to see a diamond: ");
            string choice = Console.ReadLine().ToUpper();
            char[] choiceChar = choice.ToCharArray();
            Console.WriteLine($"\n{Diamond.CreateGrid(choiceChar[0])}");
        }
    }

    public class Diamond
    {
        private static string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string DisplayDiamond()
        {
            string allGrids = "";

            foreach (char _letter in Diamond.Alphabet)
            {
                string fullGrid = CreateGrid(_letter);

                allGrids += $"\n\n{fullGrid}";
            }

            return allGrids;
        }
        
        public static string CreateGrid(char _letter)
        {
            // SETTING GLOBAL VARIABLES FOR METHOD
            int gridWidth = GetDiamondWidth(_letter);
            string fullGrid = "";

            // SETTING TEMPORARY VARIABLES FOR FIRST HALF OF LADDER
            string currentLetter = Alphabet[0].ToString();
            int currentLetterIndex = 0;
            int outsideDots = (gridWidth / 2);

            // GENERATING FIRST HALF OF LADDER AND ADDING IT TO FULLGRID
            while (currentLetterIndex < Alphabet.IndexOf(_letter))
            {
                if (currentLetterIndex == 0)
                {
                    string _blankLine = GenerateBlankLine(gridWidth);
                    _blankLine = _blankLine.Substring(0, _blankLine.Length - 1);
                    _blankLine = _blankLine.Insert(_blankLine.Length - outsideDots, currentLetter);
                    fullGrid += $"{_blankLine}\n";
                }
                else
                {
                    string _blankLine = GenerateBlankLine(gridWidth);
                    _blankLine = _blankLine.Substring(0, _blankLine.Length - 2);
                    _blankLine = _blankLine.Insert(outsideDots, currentLetter);
                    _blankLine = _blankLine.Insert(_blankLine.Length - outsideDots, currentLetter);
                    fullGrid += $"{_blankLine}\n";
                }

                outsideDots--;
                currentLetterIndex++;
                currentLetter = Alphabet[currentLetterIndex].ToString();
            }

            // SETTING TEMPORARY VARIABLES FOR SECOND HALF OF LADDER
            currentLetter = _letter.ToString();
            currentLetterIndex = Alphabet.IndexOf(_letter);
            outsideDots = 0;

            // GENERATING SECOND HALF OF LADDER AND ADDING IT TO FULLGRID
            currentLetterIndex = Alphabet.IndexOf(_letter);
            outsideDots = 0;
            while (currentLetterIndex >= 0)
            {
                if (currentLetterIndex == 0)
                {
                    string _blankLine = GenerateBlankLine(gridWidth);
                    _blankLine = _blankLine.Substring(0, _blankLine.Length - 1);
                    _blankLine = _blankLine.Insert(_blankLine.Length - outsideDots, currentLetter);
                    fullGrid += $"{_blankLine}\n";
                    break;
                }
                else
                {
                    string _blankLine = GenerateBlankLine(gridWidth);
                    _blankLine = _blankLine.Substring(0, _blankLine.Length - 2);
                    _blankLine = _blankLine.Insert(outsideDots, currentLetter);
                    _blankLine = _blankLine.Insert(_blankLine.Length - outsideDots, currentLetter);
                    fullGrid += $"{_blankLine}\n";

                    outsideDots++;
                    currentLetterIndex--;
                    currentLetter = Alphabet[currentLetterIndex].ToString();
                }
            }
            return fullGrid;
        }
        
        public static string GenerateBlankLine(int _DiamondWidth)
        {
            string oneLine = "";

            for (int i = 0; i < _DiamondWidth; i++)
            {
                oneLine += ".";
            }

            return oneLine;
        }
        
        public static int GetDiamondWidth(char _letter)
        {
            return Alphabet.IndexOf(_letter) * 2 + 1;
        } 
    }
}
