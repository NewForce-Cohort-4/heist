using System;
using System.Collections.Generic;

namespace heist
{

    // Ok Jordan, what the HECK is going on here??
    public class HelperMethods
    {
        // These are static methods, which means we don't have to instantiate the HelperMethods class to use them


        public static string Ask(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }




        // Ttry to convert a string to an integer. There are situations where we'd consider the user's input invalid: either they enter a string that can't be converted to an integer (example: "abc") or they enter a negative number. Either way, we want to re-prompt them for valid input.
        public static int ConvertToValidInt(string stringToConvert)
        {
            int num;
            bool canConvert = Int32.TryParse(stringToConvert, out num);
            bool isValid = num > 0;

            // As long as it's invalid, keep prompting them
            if (!canConvert || !isValid)
            {
                Console.WriteLine("Pleae enter a valid positive number");
                string tryAgain = Console.ReadLine();
                ConvertToValidInt(tryAgain);
            }

            return num;
        }

        // This method will do the same thing as the one above, but for doubles
        // Courage factors have to be between 0 and 2. If we get a number outside that range, we gotta re-promt em.
        public static double ConvertToValidDouble(string stringToConvert)
        {
            double num;
            bool canCovnert = Double.TryParse(stringToConvert, out num);
            bool isValid = num >= 0 && num <= 2.0;
            if (!canCovnert || !isValid)
            {
                Console.WriteLine("Pleae enter a valid decimal between 0 and 2");
                string tryAgain = Console.ReadLine();
                ConvertToValidDouble(tryAgain);
            }
            return num;
        }

        public static void Space()
        {
            Console.WriteLine();
        }

    }
}