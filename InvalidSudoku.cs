using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class InvalidSudoku : Exception
    {
        public InvalidSudoku(Sudoku sudoku) : base(sudoku.ToString())
        {
        }
    }
}
