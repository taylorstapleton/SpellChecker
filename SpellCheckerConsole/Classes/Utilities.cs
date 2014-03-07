using SpellCheckerConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpellCheckerConsole.Classes
{
    public class Utilities : IUtilities
    {
        /// <summary>
        /// constructor
        /// </summary>
        public Utilities()
        {

        }

        /// <summary>
        /// list variations of a given string that has duplicate letters
        /// </summary>
        /// <param name="toParse"></param>
        /// <returns></returns>
        public List<string> listDuplicateVariations(string toParse)
        {
            if (toParse.Length < 2)
            {
                return new List<string>() { toParse };
            }

            int index;
            char duplicate = char.MinValue;
            int count = 0;

            for (index = 1; index < toParse.Length; index++)
            {
                char current = toParse[index];
                char prev = toParse[index - 1];

                if (current != prev)
                {
                    if (count > 0)
                    {
                        break;
                    }
                }
                else
                {
                    count++;
                    duplicate = current;
                }
            }
            if(count == 0)
            {
                return new List<string>() { toParse };
            }

            string wordBase = toParse.Substring(0, index - count - 1);

            List<string> wordBaseList = new List<string>();
            for(int i = 0; i <= count; i++)
            {
                wordBase += duplicate.ToString();
                wordBaseList.Add(wordBase);
            }

            List<string> recursiveVariations = listDuplicateVariations(toParse.Substring(index));
            List<string> toReturn = new List<string>();
            foreach(string i in wordBaseList)
            {
                foreach(string j in recursiveVariations)
                {
                    toReturn.Add(i + j);
                }
            }

            return toReturn;
        }

        /// <summary>
        /// list variations of a given string that has vowels
        /// </summary>
        /// <param name="toParse"></param>
        /// <returns></returns>
        public List<string> listVowelVariations(string toParse)
        {
            List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
            if(toParse.Length < 1)
            {
                return new List<string>() { toParse };
            }

            List<string> toReturn = new List<string>();

            for (int i = 0; i < toParse.Length; i++ )
            {
                if(IsVowel(toParse[i]))
                {
                    string wordBase = toParse.Substring(0, i);
                    List<string> wordBaseList = new List<string>();

                    foreach(char vowel in vowels)
                    {
                        wordBaseList.Add(wordBase + vowel.ToString());
                    }

                    List<string> recursiveResults = listVowelVariations(toParse.Substring(i + 1));

                    foreach(string j in wordBaseList)
                    {
                        foreach(string k in recursiveResults)
                        {
                            toReturn.Add(j + k);
                        }
                    }

                    break;
                }
            }
            if (toReturn.Count == 0)
            {
                return new List<string>(){toParse};
            }
            else
            {
                return toReturn;
            }
        }

        /// <summary>
        /// helper vowel method
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private static bool IsVowel(char character)
        {
            return new[] { 'a', 'e', 'i', 'o', 'u' }.Contains(char.ToLower(character));
        }

        /// <summary>
        /// validate input to be {[a-z] | [A-Z]}
        /// </summary>
        /// <param name="toValidate"></param>
        /// <returns></returns>
        public bool validateInput(string toValidate)
        {
            if(string.IsNullOrWhiteSpace(toValidate))
            {
                return false;
            }
            else if (!Regex.IsMatch(toValidate, @"^[a-zA-Z]+$"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
