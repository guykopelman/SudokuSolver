using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Sudoku : ICloneable, ISearchable
    {
        public static int EMPTY_VALUE = 0;

        private int[,] matrix;

        public Sudoku(int[,] matrix)
        {
            this.matrix = matrix;
        }

        public Sudoku(Sudoku sudoku)
        {
            this.matrix = new int[sudoku.matrix.GetLength(0), sudoku.matrix.GetLength(1)];
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    this.matrix[i, j] = sudoku.matrix[i, j];
                }
            }
        }

        public object Clone()
        {
            return new Sudoku(this);
        }

        public void SetValue(Location location, int value)
        {
            if (IsInRange(location))
            {
                this.matrix[location.GetRow(), location.GetCol()] = value;
            }
        }
        public int GetValue(Location location)
        {
            if (IsInRange(location))
            {
                return this.matrix[location.GetRow(), location.GetCol()];
            }
            // TODO: add correct exception type
            throw new Exception();
        }

        public bool IsEmpty(Location location)
        {
            return this.GetValue(location) == Sudoku.EMPTY_VALUE;
        }
        public void ResetCell(Location location)
        {
            this.SetValue(location, Sudoku.EMPTY_VALUE);
        }

        private bool IsInRange(Location location)
        {
            return (0 <= location.GetRow() && location.GetRow() < this.matrix.GetLength(0)) &&
             (0 <= location.GetCol() && location.GetCol() < this.matrix.GetLength(1));
        }

        public bool DoesExistInRow(int value, int row)
        // the function return if the value is exist in row
        {
            for (int col = 0; col < this.matrix.GetLength(1); col++)
            {
                if (this.matrix[row, col] == value)
                    return true;
            }
            return false;
        }

        public bool DoesExistInCol(int value, int col)
        // the function return if the value is exist in col
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                if (this.matrix[row, col] == value)
                    return true;
            }
            return false;
        }

        public bool DoesExistInBox(int value, int box)
        // the function return if the value is exist in box
        {
            Location location = BoxToLocation(box);
            int firstRow = location.GetRow(), firstCol = location.GetCol();
            int size = GetBoxSize();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (this.matrix[firstRow + i, firstCol + j] == value)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal List<Location> GetEmptyCellsLocations()
        //  the function return list of location that empty
        {
            List<Location> locations = new List<Location>();
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    if (this.matrix[row, col] == Sudoku.EMPTY_VALUE)
                    {
                        locations.Add(new Location(row, col));
                    }
                }
            }
            return locations;
        }

        private Location BoxToLocation(int box)
        {
            int size = GetBoxSize();
            int firstRow = (box / size) * size;
            int firstCol = (box % size) * size;
            return new Location(firstRow, firstCol);
        }

        public int GetBoxSize()
        {
            return (int)Math.Sqrt(this.matrix.GetLength(0));
        }

        public int GetSize()
        {
            return this.matrix.GetLength(0);
        }

        public int[,] GetClonedMatrix()
        {
            return ((Sudoku)this.Clone()).matrix;
        }
        public int LocationToBox(Location location)
        {
            int size = GetBoxSize();
            int row = location.GetRow(), col = location.GetCol();

            int firstRow = row - (row % size);
            int firstCol = col - (col % size);

            int box = firstRow + firstCol / size;
            return box;
        }

        public override string ToString()
        {
            string str = "";
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    str += $"[{this.matrix[row, col]}]";
                }
                str += "\n";
            }
            return str;
        }
    }
}
