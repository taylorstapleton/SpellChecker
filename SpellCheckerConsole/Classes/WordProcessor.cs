﻿using SpellCheckerConsole.Interfaces;
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
            if (utilities.validateInput(word))
            {
                word = word.ToLower();

                if (wordDictionary.checkWord(word))
                {
                    return word;
                }

                List<string> duplicateList = utilities.listDuplicateVariations(word);

                foreach(string i in duplicateList)
                {
                    if (wordDictionary.checkWord(i))
                    {
                        return i;
                    }
                }

                List<string> vowelList = utilities.listVowelVariations(word);

                foreach (string i in vowelList)
                {
                    if (wordDictionary.checkWord(i))
                    {
                        return i;
                    }
                }

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
            return "NO SUGGESTION";
        }
    }
}
