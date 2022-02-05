using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        
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
