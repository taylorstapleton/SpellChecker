using SpellCheckerConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCheckerConsole.Classes
{
    public class WordProcessor : IWordProcessor
    {
        /// <summary>
        /// private utils for class use only
        /// injected through constructor
        /// </summary>
        private IUtilities utilities;

        /// <summary>
        /// private wordDictionary for class use only
        /// injected through constructor
        /// </summary>
        private IWordDictionary wordDictionary;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="injectedUtilities"></param>
        /// <param name="injectedWordDictionary"></param>
        public WordProcessor(IUtilities injectedUtilities, IWordDictionary injectedWordDictionary)
        {
            this.utilities = injectedUtilities;
            this.wordDictionary = injectedWordDictionary;
        }

        /// <summary>
        /// returns {resolvedWord | NO SUGGESTION} where resovledWord = closest english word to the supplied string.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public string resolveWord(string word)
        {
            // first check if input is valid {a-z | A-Z}
            if (utilities.validateInput(word))
            {
                // set the word to lower case
                word = word.ToLower();

                // if we are already a valid word, return
                if (wordDictionary.checkWord(word))
                {
                    return word;
                }

                // create a list of all the possible words regarding duplicate letters
                List<string> duplicateList = utilities.listDuplicateVariations(word);

                // check to see if any of the generated variations are words
                foreach(string i in duplicateList)
                {
                    if (wordDictionary.checkWord(i))
                    {
                        return i;
                    }
                }

                // create a list of all the possible words regarding vowel variations
                // note: this method is notably innefficient when a significant amount of vowels are present
                List<string> vowelList = utilities.listVowelVariations(word);

                // check to see if any of the vowel variations are words
                foreach (string i in vowelList)
                {
                    if (wordDictionary.checkWord(i))
                    {
                        return i;
                    }
                }

                // if we have gotten this far, its time to check combinations of the two lsits
                foreach(string i in vowelList)
                {
                    duplicateList = utilities.listDuplicateVariations(i);
                    foreach(string j in duplicateList)
                    {
                        if(wordDictionary.checkWord(j))
                        {
                            return j;
                        }
                    }
                }
            }
            // finally return default case if no matches
            return "NO SUGGESTION";
        }
    }
}
