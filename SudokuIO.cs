using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SudokuSolver
{
    class SudokuIO
    {
        public static Sudoku ReadSudokuFromFile()
        // read from file and return has sudoku
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.ShowDialog();
            TextReader textReader = new StreamReader(openFileDialog.OpenFile());
            Sudoku sudoku = SudokuSerializer.StringToSudoku(textReader.ReadLine().Trim());
            textReader.Close();
            return sudoku;
        }

        public static Sudoku ReadSudokuFromConsole()
        // read from console
        {
            Console.Write("sudoku string=");
            string str = Console.ReadLine();
            return SudokuSerializer.StringToSudoku(str);
        }

        public static void WriteSudokuToFile(Sudoku sudoku)
        // write the solved sudoku into file
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.ShowDialog();
            TextWriter textWriter = new StreamWriter(saveFileDialog.OpenFile());
            textWriter.Write(SudokuSerializer.SudokuToString(sudoku));
            textWriter.Close();
        }

        public static void WriteSudokuToConsole(Sudoku sudoku)
        // write to console the solved sudoku
        {
            Console.WriteLine(sudoku);
        }
    }
}