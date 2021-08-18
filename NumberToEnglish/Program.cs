using System;
using System.Collections.Generic;

namespace NumberToEnglish
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Converter
    {
        // STATIC METHODS
        public static string ConvertToEnglish(decimal _number)
        {
            if (_number > 0 && _number < 1000000000)
            {
                string englishConversion = "";
                string numberAsString = _number.ToString();
                int numberOfDigits = numberAsString.Length;
                int decimalPlace = numberOfDigits;

                for (int i = 0; i < numberOfDigits; i++)
                {
                    int currentDigit = int.Parse(numberAsString[i].ToString());
                    string currentFiller = GetFiller(decimalPlace);

                    // If it is in the tens place, then it will print out the next two digits in the proper formatting
                    if (
                        (decimalPlace == 8 || decimalPlace == 5 || decimalPlace == 2)
                        && currentDigit != 0
                        )
                    {
                        string numberPairAsString = numberAsString.Substring(i, 2);
                        int numberPair = int.Parse(numberPairAsString);
                        englishConversion += $" {Write10Through99(numberPair)}";

                        // Skipping over next number because it is already displayed using the Write10Through99() method. Need to update currentFiller to account for this change.
                        currentFiller = GetFiller(decimalPlace - 1);
                        i++;
                        decimalPlace--;
                    }
                    // If not then, it will just print out the digit
                    else
                    {
                        if (currentDigit != 0)
                        {
                            string englishDigit = WriteDigit(currentDigit);
                            englishConversion += $" {englishDigit}";
                        }
                    }      

                    // Add in "hundred", "thousand", or "million
                    if (currentFiller != null)
                    {
                        englishConversion += $" {currentFiller}";
                    }
                    
                    decimalPlace--;
                }

                // Trim space from front and capitalize first letter of return string
                englishConversion = englishConversion.TrimStart();
                englishConversion = Capitalize(englishConversion);

                return englishConversion;
            }
            else if (_number < 0)
            {
                return "Our program is not able to write any numbers less than 0";
            }
            else if (_number == 0)
            {
                return "Zero";
            }
            else
            {
                return "Our program is not able to write passed 999,999,999.99";
            }
        }

        public static string GetFiller(int position)
        {
            if (position > 9 || position < 3)
            {
                return null;
            }
            else if (position % 3 == 0)
            {
                return "hundred";
            }
            else if (position == 7)
            {
                return "million";
            }
            else if (position == 4)
            {
                return "thousand";
            }
            else
            {
                return null;
            }
        }
        
        public static string WriteDigit(int digit)
        {
            if (digit == 1)
            {
                return "one";
            }
            else if (digit == 2)
            {
                return "two";
            }
            else if (digit == 3)
            {
                return "three";
            }
            else if (digit == 4)
            {
                return "four";
            }
            else if (digit == 5)
            {
                return "five";
            }
            else if (digit == 6)
            {
                return "six";
            }
            else if (digit == 7)
            {
                return "seven";
            }
            else if (digit == 8)
            {
                return "eight";
            }
            else if (digit == 9)
            {
                return "nine";
            }
            else
            {
                return "";
            }
        }

        public static string Write10Through99(int number)
        {
            if (number < 100 && number > 9)
            {
                if (number > 19)
                {
                    if (WriteTens(number) == null)
                    {
                        string firstPart = number.ToString()[0].ToString();
                        firstPart += "0";
                        firstPart = WriteTens(int.Parse(firstPart));

                        string secondPart = number.ToString()[1].ToString();
                        secondPart = WriteDigit(int.Parse(secondPart));

                        return $"{firstPart}-{secondPart}";
                    }
                    else
                    {
                        return WriteTens(number);
                    }
                }
                else
                {
                    if (number > 15 || number == 14)
                    {
                        int secondDigit = int.Parse(number.ToString()[1].ToString());
                        return $"{WriteDigit(secondDigit)}teen";
                    }
                    else
                    {
                        if (number == 15)
                        {
                            return "fifteen";
                        }
                        else if (number == 13)
                        {
                            return "thirteen";
                        }
                        else if (number == 12)
                        {
                            return "twelve";
                        }
                        else if (number == 11)
                        {
                            return "eleven";
                        }
                        else
                        {
                            return "ten";
                        }
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public static string WriteTens(int number)
        {
            if (number.ToString()[1] == '0' && number > 19 && number < 100)
            {
                if (number == 20)
                {
                    return "twenty";
                }
                else if (number == 30)
                {
                    return "thirty";
                }
                else if (number == 40)
                {
                    return "forty";
                }
                else if (number == 50)
                {
                    return "fifty";
                }
                else if (number == 80)
                {
                    return "eighty";
                }
                else
                {
                    return $"{WriteDigit(int.Parse(number.ToString()[0].ToString()))}ty";
                }
            }
            else
            {
                return null;
            }
        }

        public static string Capitalize(string word)
        {
            if (String.IsNullOrEmpty(word))
            {
                return "";
            }
            else
            {
                string lowerCase = word.ToLower();
                char firstLetter = lowerCase[0];
                string upperCaseFirstLetter = firstLetter.ToString().ToUpper();
                string capitalized = upperCaseFirstLetter + lowerCase.Substring(1);

                return capitalized;
            }    
        }
    }
}
