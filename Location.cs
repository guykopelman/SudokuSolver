using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Location
    {
        private int row, col;

        public Location(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
        public int GetRow()
        {
            return this.row;
        }
        public void SetRow(int row)
        {
            this.row = row;
        }
        public int GetCol()
        {
            return this.col;
        }
        public void SetCol(int col)
        {
            this.col = col;
        }
        public override string ToString()
        {
            return $"({this.row},{this.col})";
        }
    }
}
