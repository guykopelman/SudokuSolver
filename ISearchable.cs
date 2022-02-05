using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    interface ISearchable
    {
        bool DoesExistInRow(int value, int row);
        bool DoesExistInCol(int value, int col);
        bool DoesExistInBox(int value, int box);
    }
}
