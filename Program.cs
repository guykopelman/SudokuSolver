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
        public static bool HandleMenuDisplay()
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
        [STAThread]
        static void Main(string[] args)
        {
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
        }
    }
}
