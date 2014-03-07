using SpellCheckerConsole.Classes;
using SpellCheckerConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCheckerConsole
{
    class Program
    {
        /// <summary>
        /// Main method
        /// Takes no arguments
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // set text path
            string textFilePath = "../../Resources/dictionary.txt";

            // initialize our wordDictionary with path
            IWordDictionary wordDictionary = new WordDictionary(textFilePath);

            // initialize our utilities class
            IUtilities utilities = new Utilities();

            // initialize our worProcessor, injecting the utilities and dictionary
            IWordProcessor wordProcessor = new WordProcessor(utilities, wordDictionary);

            // initialize input processor, injecting the wordProcessor
            IInputProcessor inputProcessor = new InputProcessor(wordProcessor);

            // start the inputProcessor
            inputProcessor.start();
        }
    }
}
