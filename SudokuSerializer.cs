using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
     public class SudokuSerializer
    {

        public static string SudokuToString(Sudoku sudoku)
        {
            int[,] matrix = sudoku.GetClonedMatrix();
            string str = "";
            foreach (int value in matrix)
            {
                str += ValueToChar(value);
            }
            return str;
        }

        private static char ValueToChar(int value)
        {
            return (char)(value + '0');
        }

        public static Sudoku StringToSudoku(string str)
        // the function get string and return Sudoku with the values of the string or throw exception
        {
            int size = (int)Math.Sqrt(str.Length);
            if(!IsStringSizeValid(str)){
                throw new Exception ("size is inValid");
            }
            int[,] arr = new int[size, size];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    int value = CharToValue(str[i * size + j]);
                    if (value < 0 || value > size)
                    {
                        throw new Exception("invalid value in Sudoku");
                    }
                    arr[i, j] = value;
                }
            }
            return new Sudoku(arr);
        }

        private static int CharToValue(char ch)
        // cast char char into int 
        {
            return ch - '0';
        }

        public static bool IsStringSizeValid(string str)
        // return if string size is valid
        {
            double sqrt = Math.Sqrt(str.Length);
            if (str.Length == 0){
                return false;
            }
            return (int)sqrt == sqrt;
        }

    }
}
