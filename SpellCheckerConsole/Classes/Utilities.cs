using SpellCheckerConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCheckerConsole.Classes
{
    class Utilities : IUtilities
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// convert given string to lower case
        /// </summary>
        /// <param name="toParse"></param>
        /// <returns></returns>
        public string toLower(string toParse)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// validate input to be {[a-z] | [A-Z]}
        /// </summary>
        /// <param name="toValidate"></param>
        /// <returns></returns>
        public bool validateInput(string toValidate)
        {
            throw new NotImplementedException();
        }
    }
}
