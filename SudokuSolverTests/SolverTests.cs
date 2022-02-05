using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SudokuSolver;
namespace SudokuSolverTests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void invalidSudoku()
        {

            try
            {
                Sudoku s = SudokuSerializer.StringToSudoku("");
                SudokuSolver.SudokuSolver.Solve(s);
                Assert.Fail();
            }
            catch
            {
            }
        }
        [TestMethod]
        public void invalidSudoku_with_values()
        {

            try
            {
                Sudoku s = SudokuSerializer.StringToSudoku("12345");
                SudokuSolver.SudokuSolver.Solve(s);
                Assert.Fail();
            }
            catch
            {
            }
        }
        [TestMethod]
        public void Emptyboard()
        {
            try
            {
                Sudoku s = SudokuSerializer.StringToSudoku("0000000000000000");
                SudokuSolver.SudokuSolver.Solve(s);
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
}
