using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class WrongDimentions : InvalidSudoku
    {
        public WrongDimentions(Sudoku sudoku) : base(sudoku)
        {
        }
    }
}
