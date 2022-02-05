using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    interface IOptionalCell
    {
        void Reset();
        bool IsFirstOption();
        bool IsLastOption();
        void NextOption();
        void PrevOption();
        int GetCurrentOption();
    }
}
