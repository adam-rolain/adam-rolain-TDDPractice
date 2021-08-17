using System;

namespace PasswordVerifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class PasswordVerifier
    {
        // STATIC METHODS
        public static bool Verify(string _password)
        {
            // Counting how many conditions are passing
            int passedConditions = 0;
            if (IsLargerThanEight(_password))
            {
                passedConditions++;
            }
            if (!String.IsNullOrEmpty(_password))
            {
                passedConditions++;
            }
            if (HasAnUpperCase(_password))
            {
                passedConditions++;
            }
            if (HasALowerCase(_password))
            {
                passedConditions++;
            }
            else
            {
                return false;
            }
            if (HasANumber(_password))
            {
                passedConditions++;
            }

            // Based off of passedConditions, return true or false
            if (passedConditions >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsLargerThanEight(string _password)
        {
            if (_password.Length >= 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool HasAnUpperCase(string _password)
        {
            bool upperCaseFound = false;
            for (int i = 0; i < _password.Length; i++)
            {
                if (char.IsUpper(_password, i))
                {
                    upperCaseFound = true;
                    break;
                }
            }
            return upperCaseFound;
        }
        public static bool HasALowerCase(string _password)
        {
            bool lowerCaseFound = false;
            for (int i = 0; i < _password.Length; i++)
            {
                if (char.IsLower(_password, i))
                {
                    lowerCaseFound = true;
                    break;
                }
            }
            return lowerCaseFound;
        }
        public static bool HasANumber(string _password)
        {
            bool numberFound = false;
            int _number = 0;
            for (int i = 0; i < _password.Length; i++)
            {
                if (int.TryParse(_password[i].ToString(), out _number))
                {
                    numberFound = true;
                    break;
                }
            }
            return numberFound;
        }
    }
}
