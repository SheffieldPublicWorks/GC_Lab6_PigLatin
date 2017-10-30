using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC_Deliverable6_Lab6_PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("/*********************************/");
            Console.WriteLine("/* Welcome to Pig-Latinizer v1.0 */");
            Console.WriteLine("/*********************************/");

            //Get user input
            Console.WriteLine("Step right up! Give me an ordway, any ordway. ");
            
            bool continueStatus = true;
            while (continueStatus)
            {
                Console.Write("Enter your word now: ");
                string userEntry = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(userEntry))
                {
                    Console.WriteLine("That all you got? Give me something! Even a one-letter word will do");
                    continueStatus = GetContinueStatus();
                }
                else
                {
                    ZiggyPiggy(userEntry);
                    continueStatus = GetContinueStatus();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Thanks for playing. Bye now!");
        }

        public static bool GetContinueStatus()
        {
            Console.Write("Do you want to continue? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                return true;
            }

            return false;
        }

        public static void ZiggyPiggy(string strInit)
        {
            //prep for translation
            string str1          = strInit.ToLower();
            char[] vowels        = new char[5] { 'a', 'e', 'i', 'o', 'u' };
            int    vowelFirstPos = str1.IndexOfAny(vowels);
            
            //translate
            if (vowelFirstPos == 0)
            {
                Console.WriteLine("Translation: " + str1 + "way");
                return;
            }
            else if (vowelFirstPos < 0 || SpecialCharSearch(strInit))
            {
                Console.WriteLine("Translation: " + str1);
            }
            else
            {
                Console.WriteLine("Translation: " + strInit.Substring(vowelFirstPos) + strInit.Substring(0, vowelFirstPos) + "ay");
            }

            Console.WriteLine();
        }

        public static bool SpecialCharSearch(string str)
        {
            //check for presence of special characters. See ascii table at: https://www.dotnetperls.com/ascii-table

            //characters in the following array ARE allowable. those not in this list and outside of for loop ranges are NOT.
            char[] exclusionList = new char[4] { '!', '?', '.', '\'' };
            for (int i = 0; i < str.Length; i++)
            {
                if (!(str[i] >= 65 && str[i] <= 90) && !(str[i] >= 97 && str[i] <= 122) && str.IndexOfAny(exclusionList) < 0)
                {
                    // if a special character is found stop iterating and return true for presence of special characters
                    return true;
                }
            }

            return false;
        }
    }
}
