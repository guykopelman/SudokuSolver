using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public static class SudokuSolver
    {
        public static Sudoku Solve(Sudoku sudoku)
        // The Function is get the sudoku and return the solve of him if there is
        {
            AssertValidation(sudoku, sudoku.GetSize());

            Sudoku solution = (Sudoku)sudoku.Clone();
            List<OptionalSudokuCell> optionalCells = GenerateOptionalCells(solution);
            int size;
            do
            {
                size = optionalCells.Count();
                optionalCells = SetSinglePossibleOptions(solution, optionalCells);
                optionalCells = SetSinglePossibleOptionsComparingOthers(solution, optionalCells);
            }
            while (optionalCells.Count() != size);

            int optionIndex = 0;
            while (0 <= optionIndex && optionIndex < optionalCells.Count)
            {
                OptionalSudokuCell option = optionalCells[optionIndex];
                Location location = option.GetLocation();
                if (solution.IsEmpty(location) && WillBeValid(solution, location, option.GetCurrentOption()))
                {
                    SetValue(solution, option);
                    optionIndex++;
                }
                else
                {
                    solution.ResetCell(location);
                    if (option.IsLastOption())
                    {
                        option.Reset();
                        optionIndex--;
                    }
                    else
                    {
                        option.NextOption();
                    }
                }
            }
            if (optionIndex == -1)
            {
                throw new UnSolveable(sudoku);
                // throw new Exception ("UnSolveable sudoku ") ;
            }
            return solution;
        }



        private static List<OptionalSudokuCell> SetSinglePossibleOptionsComparingOthers(Sudoku sudoku, List<OptionalSudokuCell> optionalCells)
        // the function is set the single possible options in Every cell by using the helpers function.  
        {
            List<OptionalSudokuCell> singleInRows = SetSinglePossibleOptionsInRow(sudoku, optionalCells);
            List<OptionalSudokuCell> singleInCol = SetSinglePossibleOptionsInCol(sudoku, singleInRows);
            List<OptionalSudokuCell> singleInBox = SetSinglePossibleOptionsInBox(sudoku, singleInCol);
            return singleInBox;
        }
        private static List<OptionalSudokuCell> SetSinglePossibleOptionsInRow(Sudoku sudoku, List<OptionalSudokuCell> optionalCells)
        // the function is set the single possible option in row by using helpers function.
        {
            return SetSinglePossibleOptionsInSequence(sudoku.GetSize(), sudoku, row => GetOptionsByRow(optionalCells, row), row => GetMissingNumbersInRow(sudoku, row));
        }
        private static List<OptionalSudokuCell> SetSinglePossibleOptionsInCol(Sudoku sudoku, List<OptionalSudokuCell> optionalCells)
        // the function is set the single possible option in col by using helpers function.
        {
            return SetSinglePossibleOptionsInSequence(sudoku.GetSize(), sudoku, col => GetOptionsByCol(optionalCells, col), col => GetMissingNumbersInCol(sudoku, col));
        }
        private static List<OptionalSudokuCell> SetSinglePossibleOptionsInBox(Sudoku sudoku, List<OptionalSudokuCell> optionalCells)
        // the function is set the single possible option in box by using helpers function.
        {
            return SetSinglePossibleOptionsInSequence(sudoku.GetBoxSize(), sudoku, box => GetOptionsByBox(sudoku, optionalCells, box), box => GetMissingNumbersInBox(sudoku, box));
        }
        private static List<OptionalSudokuCell> SetSinglePossibleOptionsInSequence(int size, Sudoku sudoku, Func<int, List<OptionalSudokuCell>> getOptionsBySequence, Func<int, List<int>> getMissingNumbersInSequence)
        // Generic function that get a sequence and the function of this sequence (row,box,col) and and set the single possible option in the sequence 
        {
            for (int seqIndex = 0; seqIndex < size; seqIndex++)
            {
                List<OptionalSudokuCell> seqOptions = getOptionsBySequence(seqIndex);
                List<int> missingNumbers = getMissingNumbersInSequence(seqIndex);
                foreach (int num in missingNumbers)
                {
                    List<OptionalSudokuCell> optionsWithNum = seqOptions.Where(option => option.Contains(num)).ToList();
                    if (optionsWithNum.Count() == 1)
                    {
                        OptionalSudokuCell option = optionsWithNum.First();
                        sudoku.SetValue(option.GetLocation(), num);
                    }

                }
            }
            return GenerateOptionalCells(sudoku);
        }

        private static List<int> GetMissingNumbersInRow(Sudoku sudoku, int row)
        // the function get a number of row and the sudoku and by using the generic function of find the missing number in sequence and the function DoesExistInRow and return list of the  Missing Numbers In Row
        {
            return GetMissingNumbersInSequence(sudoku.GetSize(), num => sudoku.DoesExistInRow(num, row));
        }
        private static List<int> GetMissingNumbersInCol(Sudoku sudoku, int col)
        // the function get a number of col and the sudoku and by using the generic function of find the missing number in sequence and the function DoesExistInCol and return list of the  Missing Numbers In Col
        {
            return GetMissingNumbersInSequence(sudoku.GetSize(), num => sudoku.DoesExistInCol(num, col));
        }
        private static List<int> GetMissingNumbersInBox(Sudoku sudoku, int box)
        // the function get a number of box and the sudoku and by using the generic function of find the missing number in sequence and the function DoesExistInBox and return list of the  Missing Numbers In Box
        {
            return GetMissingNumbersInSequence(sudoku.GetSize(), num => sudoku.DoesExistInBox(num, box));
        }
        private static List<int> GetMissingNumbersInSequence(int size, Predicate<int> doesNumberExistInSequence)
        //  the function gets the size of places she needs to runs  on and the function of the sequence (row,box,col) the return if the number exist in the sequence or not the function return list of the missing number in the sequence 
        {
            List<int> missing = new List<int>();
            for (int number = 1; number <= size; number++)
            {
                if (!doesNumberExistInSequence(number))
                {
                    missing.Add(number);
                }
            }
            return missing;
        }

        private static List<OptionalSudokuCell> GetOptionsByRow(List<OptionalSudokuCell> optionsCells, int row)
        // the function return list of the OptionalSudokuCell by row.
        {
            return optionsCells.Where(option => option.GetLocation().GetRow() == row).ToList();
        }
        private static List<OptionalSudokuCell> GetOptionsByCol(List<OptionalSudokuCell> optionsCells, int col)
        // the function return list of the OptionalSudokuCell by col.
        {
            return optionsCells.Where(option => option.GetLocation().GetCol() == col).ToList();
        }
        private static List<OptionalSudokuCell> GetOptionsByBox(Sudoku sudoku, List<OptionalSudokuCell> optionsCells, int box)
        // the function return list of the OptionalSudokuCell by box.
        {
            return optionsCells.Where(option => sudoku.LocationToBox(option.GetLocation()) == box).ToList();
        }

        private static List<OptionalSudokuCell> SetSinglePossibleOptions(Sudoku sudoku, List<OptionalSudokuCell> optionalCells)
        // the function set all the values in all the empty cells who have only single possible option.
        {
            List<OptionalSudokuCell> options = optionalCells;
            List<OptionalSudokuCell> singles = GetSingles(options);
            while (singles.Count > 0)
            {
                foreach (OptionalSudokuCell option in singles)
                {
                    SetValue(sudoku, option);
                }
                options = GenerateOptionalCells(sudoku);
                singles = GetSingles(options);
            }
            return options;
        }

        private static List<OptionalSudokuCell> GetSingles(List<OptionalSudokuCell> optionalCells)
        // the function return list of OptionalSudokuCell who have single option
        {
            return optionalCells.Where(option => option.OptionsAmount() == 1).ToList();
        }

        private static void SetValue(Sudoku sudoku, OptionalSudokuCell option)
        {
            sudoku.SetValue(option.GetLocation(), option.GetCurrentOption());
        }
        private static bool WillBeValid(Sudoku sudoku, Location location, int value)
        // the function return if the value in the location in the sudoku is valid to be or not.  
        {
            int row = location.GetRow(), col = location.GetCol();

            return !sudoku.DoesExistInRow(value, row) &&
             !sudoku.DoesExistInCol(value, col) &&
             !sudoku.DoesExistInBox(value, sudoku.LocationToBox(location));
        }

        private static List<OptionalSudokuCell> GenerateOptionalCells(Sudoku sudoku)
        // the function  Generate Optional Cells return list of OptionalSudokuCell 
        {
            List<Location> emptyCells = sudoku.GetEmptyCellsLocations();
            List<OptionalSudokuCell> options = new List<OptionalSudokuCell>();
            int size = sudoku.GetSize();
            foreach (Location currentLocation in emptyCells)
            {
                List<int> optionalValues = new List<int>();
                for (int value = 1; value <= size; value++)
                {
                    if (WillBeValid(sudoku, currentLocation, value))
                    {
                        optionalValues.Add(value);
                    }
                }
                if (optionalValues.Count == 0)
                    throw new UnSolveable();
                options.Add(new OptionalSudokuCell(currentLocation, optionalValues));
            }
            return options;
        }

        private static void AssertValidation(Sudoku sudoku, int size)
        {
            for (int i = 0; i < size; i++)
            {
                IsRowValid(sudoku, size, i);
                IsColValid(sudoku, size, i);
                IsBoxValid(sudoku, size, i);
            }
        }
        private static bool IsRowValid(Sudoku sudoku, int size, int row)
        {
            int[] counter = new int[size];
            int[,] board = sudoku.GetClonedMatrix();
            for (int i = 0; i < size; i++)
                if (board[row, i] != 0 && ++counter[board[row, i] - 1] > 1)
                    throw new Exception("contain invalid sequence in row " + row);
            return true;
        }


        private static bool IsColValid(Sudoku sudoku, int size, int col)
        {
            int[] counter = new int[size];
            int[,] board = sudoku.GetClonedMatrix();
            for (int i = 0; i < size; i++)
                if (board[i, col] != 0 && ++counter[board[i, col] - 1] > 1)
                    throw new Exception("contain invalid sequence in col " + col);
            return true;
        }


        private static bool IsBoxValid(Sudoku sudoku, int size, int box)
        {
            int boxSize = sudoku.GetBoxSize();
            int[,] board = sudoku.GetClonedMatrix();
            Location start = sudoku.BoxToLocation(box);
            int startrow = start.GetRow();
            int startcol = start.GetCol();
            int[] counter = new int[size];
            for (int i = startrow; i < startrow + boxSize; i++)
                for (int j = startcol; j < startcol + boxSize; j++)
                    if (board[i, j] != 0 && ++counter[board[i, j] - 1] > 1)
                        throw new Exception("contain invalid sequence in box " + box);
            return true;
        }
    }
}
