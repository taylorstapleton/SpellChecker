using SpellCheckerConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCheckerConsole.Classes
{
    class InputProcessor : IInputProcessor
    {
        /// <summary>
        /// private WordProcessor for class use only
        /// injected through constructor
        /// </summary>
        private IWordProcessor wordProcessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="injectedWordProcessor"></param>
        public InputProcessor(IWordProcessor injectedWordProcessor)
        {
            this.wordProcessor = injectedWordProcessor;
        }

        /// <summary>
        /// start listening for input from the console
        /// processes input as it comes.
        /// </summary>
        public void start()
        {
            Console.Write(">");
            while (true)
            {
                string input = Console.ReadLine();
                Console.WriteLine(wordProcessor.resolveWord(input));
                Console.Write(">");
            }
        }
    }
}
