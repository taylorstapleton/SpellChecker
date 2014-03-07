using SpellCheckerConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCheckerConsole.Classes
{
    class WordDictionary : IWordDictionary
    {
        /// <summary>
        /// hash set of strings representing the english language
        /// </summary>
        private HashSet<string> hashSet;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="filePath"></param>
        public WordDictionary(string filePath)
        {
            hashSet = new HashSet<string>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        hashSet.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// returns true if word exists in dictionary, false if absent. 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool checkWord(string word)
        {
            return hashSet.Contains(word);
        }
    }
}
