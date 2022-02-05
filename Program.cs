using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        static bool IsSolved(Sudoku sudoku)
        {
            int size = sudoku.GetSize();
            for (int value = 1; value <= size; value++)
            {
                for (int i = 0; i < size; i++)
                {
                    if (!sudoku.DoesExistInRow(value, i))
                    {
                        return false;
                    }
                    if (!sudoku.DoesExistInCol(value, i))
                    {
                        return false;
                    }
                    if (!sudoku.DoesExistInBox(value, i))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        [STAThread]
        static void Main(string[] args)
        {
            #region comment
            // int[,] matrix = {{0,3,0,14,0,1,1,1,6,1,1,9,2,0,4,0},
            //                     {5,16,0,0,12,0,0,11,0,0,6,3,0,0,0,7},
            //                     {0,15,0,9,0,0,0,0,0,0,0,4,0,11,16,0},
            //                     {0,7,0,0,0,0,1,0,16,11,0,0,0,0,0,0},
            //                     {0,0,0,1,0,14,0,0,0,0,0,0,0,13,0,0},
            //                     26,0,0,11,0,0,0,0,0,9,2,13,4,0,0,1},
            //                     {0,9,0,0,0,8,11,0,0,0,0,0,2,0,7,0},
            //                     {0,0,0,4,0,12,0,15,0,0,0,8,0,5,0,0},
            //                     {0,0,14,13,1,6,0,12,0,1,0,7,0,0,9,8},
            //                     {0,0,0,2,0,0,0,0,1,0,0,0,11,12,15,0},
            //                     {12,0,0,0,11,0,0,1,0,0,0,16,0,13,0,0},
            //                     {16,0,9,0,14,3,0,7,0,2,0,0,1,0,0,0},
            //                     {0,0,0,0,4,1,15,0,2,0,0,5,0,0,0,9},
            //                     {14,0,0,0,0,7,0,0,0,0,11,0,6,0,3,0},
            //                     {0,0,0,0,6,0,0,0,0,14,0,1,0,1,16,5},
            //                     {15,2,0,0,0,0,3,0,0,0,0,0,0,0,0,1}};

            // int[,] matrix = {
            //     {5,3,0,0,7,0,0,0,0},
            //     {6,0,0,1,9,5,0,0,0},
            //     {0,9,8,0,0,0,0,6,0},
            //     {8,0,0,0,6,0,0,0,3},
            //     {4,0,0,8,0,3,0,0,1},
            //     {7,0,0,0,2,0,0,0,6},
            //     {0,6,0,0,0,0,2,8,0},
            //     {0,0,0,4,1,9,0,0,5},
            //     {0,0,0,0,8,0,0,7,9}
            // };
            #endregion

            bool shouldContinue = true;
            while (shouldContinue)
            {
                try
                {
                    shouldContinue = HandleMenuDisplay();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("\n\n\n");
            }


            // string str = "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
            // if (SudokuSerializer.IsStringSizeValid(str))
            // {
            //     // Sudoku temp = SudokuSerializer.StringToSudoku(str);
            //     Sudoku temp = SudokuIO.ReadSudokuFromFile();
            //     Console.WriteLine(temp);
            //     Sudoku sol = SudokuSolver.Solve(temp);
            //     Console.WriteLine(sol);
            //     SudokuIO.WriteSudokuToFile(sol);
            //     // Console.WriteLine(SudokuSerializer.SudokuToString(sol));
            // }

            // Sudoku sudoku = new Sudoku(matrix);
            // Console.WriteLine(sudoku);

            // Stopwatch stopWatch = new Stopwatch();
            // stopWatch.Start();

            // Console.WriteLine("\n\n\n\n");
            // Sudoku solution = SudokuSolver.Solve(sudoku);
            // stopWatch.Stop();
            // // Get the elapsed time as a TimeSpan value.
            // TimeSpan ts = stopWatch.Elapsed;

            // // Format and display the TimeSpan value.
            // string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            // Console.WriteLine("RunTime " + elapsedTime);
            // Console.WriteLine(solution);
            // Console.WriteLine("\n\n\n\n");
            // Console.WriteLine("Is correct? " + IsSolved(solution));
            // Console.WriteLine("\n\n\n\n");
            // Console.WriteLine(sudoku);
        }

        private static bool HandleMenuDisplay()
        {
            Console.WriteLine("Choose input type:");
            Console.WriteLine("c - from console");
            Console.WriteLine("f - from file");
            Console.WriteLine("e - exit");
            Console.Write("choice: ");
            string choice = Console.ReadLine();

            if (choice.StartsWith("c"))
            {
                Sudoku sudoku = SudokuIO.ReadSudokuFromConsole();
                SudokuIO.WriteSudokuToConsole(SudokuSolver.Solve(sudoku));
                return true;
            }

            if (choice.StartsWith("f"))
            {
                Sudoku sudoku = SudokuIO.ReadSudokuFromFile();
                SudokuIO.WriteSudokuToFile(SudokuSolver.Solve(sudoku));
                return true;
            }

            return false;
        }
    }
}
