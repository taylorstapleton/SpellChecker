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
            throw new NotImplementedException();
        }

        /// <summary>
        /// convert given string to upper case
        /// </summary>
        /// <param name="toParse"></param>
        /// <returns></returns>
        public string toUpper(string toParse)
        {
            return toParse.ToUpper();
        }

        /// <summary>
        /// convert given string to lower case
        /// </summary>
        /// <param name="toParse"></param>
        /// <returns></returns>
        public string toLower(string toParse)
        {
            return toParse.ToLower();
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
