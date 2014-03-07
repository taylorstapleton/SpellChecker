using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCheckerConsole.Interfaces
{
    public interface IWordProcessor
    {
        string resolveWord(string word);
    }
}
