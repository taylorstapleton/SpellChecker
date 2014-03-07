﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCheckerConsole.Interfaces
{
    interface IUtilities
    {
        /// <summary>
        /// returns a list of all the possible variations of duplicate letters in the given string
        /// </summary>
        /// <param name="toParse"></param>
        /// <returns>list of possible strings</returns>
        List<string> listDuplicateVariations(string toParse);

        /// <summary>
        /// returns a list of all possible vowel permutations in the given string
        /// </summary>
        /// <param name="toParse"></param>
        /// <returns>list of all possible strings</returns>
        List<string> listVowelVariations(string toParse);

        /// <summary>
        /// returns the given string in all upperCase
        /// </summary>
        /// <param name="toParse"></param>
        /// <returns>upperCase</returns>
        string toUpper(string toParse);

        /// <summary>
        /// returns the given string in all lowerCase
        /// </summary>
        /// <param name="toParse"></param>
        /// <returns>lowerCase</returns>
        string toLower(string toParse);

        /// <summary>
        /// returns true if the given string is valid input ex: {(a-b)* | (A-B)*}
        /// </summary>
        /// <param name="toValidate"></param>
        /// <returns></returns>
        bool validateInput(string toValidate);
    }
}
