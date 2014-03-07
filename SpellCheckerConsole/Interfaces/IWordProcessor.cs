using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCheckerConsole.Interfaces
{
    interface IWordProcessor
    {
        string resolveWord(string word);
    }
}
