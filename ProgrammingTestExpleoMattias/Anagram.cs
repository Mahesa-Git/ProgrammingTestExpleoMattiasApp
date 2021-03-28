using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTestExpleoMattias
{
    public static class Anagram
    {
        //Problem 1. Anagram
        public static bool AnagramChecker(string inputOne, string inputTwo)
        {
            //Using Linq to tidy and arrange the input strings
            var InputOneSorted = inputOne 
                .ToUpper()
                .ToCharArray()
                .Where(x => !char.IsWhiteSpace(x)) 
                .OrderBy(x => x)
                .ToArray();

            var InputTwoSorted = inputTwo
                .ToUpper()
                .ToCharArray()
                .Where(x => !char.IsWhiteSpace(x))
                .OrderBy(x => x)
                .ToArray();

            bool isAnagram = false;
            if (InputOneSorted.Length == InputTwoSorted.Length) 
            {
                for (int i = 0; i < InputOneSorted.Length; i++)
                {
                    isAnagram = InputOneSorted[i] == InputTwoSorted[i]; //Check if all chars are the same.

                    if (!isAnagram)
                        break;
                }
            }

            return isAnagram;
        }
    }
}
