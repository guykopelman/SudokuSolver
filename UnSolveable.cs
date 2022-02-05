using System;
using System.Runtime.Serialization;

namespace SudokuSolver
{
    [Serializable]
    internal class UnSolveable : Exception
    {
        private Sudoku sudoku;

        public UnSolveable()
        {
        }

        public UnSolveable(Sudoku sudoku) : base($"sudoku unSolveable:\n{sudoku}")
        {
            this.sudoku = sudoku;
        }

        public UnSolveable(string message) : base(message)
        {
        }

        public UnSolveable(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnSolveable(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}