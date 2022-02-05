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
        public void Empty4x4()
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
        [TestMethod]
        public void hardboard16x16()
        {
            try
            {
                Sudoku s = SudokuSerializer.StringToSudoku("00<00010020008000003?=<001:4500000@>;007500=?30020=706800?>0410;000000?>23000000<02;=90@:05>1?07>50000000000003600180002;0009=0000?:00014000@<004;000000000000?8107<240;=0?83:0500000063<:000000@09?0<200;70=5030031500?>0027;0000057>;00<13800000;000@004000900");
                SudokuSolver.SudokuSolver.Solve(s);
            }
            catch
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void easyboard16x16()
        {
            try
            {
                Sudoku s = SudokuSerializer.StringToSudoku("0000000000000000000000000000000000000000000000000000800000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000400000000000000060000000000000002000000500000050000000000000000000000000?00000000000000000000000000500000");
                SudokuSolver.SudokuSolver.Solve(s);
            }
            catch
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void invalidboard()
        {
            try
            {
                Sudoku s = SudokuSerializer.StringToSudoku("1111111111111111");   
                SudokuSolver.SudokuSolver.Solve(s);
                Assert.Fail();
            }
            catch
            {
            }
        }
        [TestMethod]
        public void solvedSudoku()
        {
            try
            {
                Sudoku s = SudokuSerializer.StringToSudoku(";4@836:7=?9>12<5>?634<2;:58197=@<1:2=?95467@>3;8795=81>@23<;:?64984?5:6<@1;72=>362;@?>438:=5<1795<=>;971?423@68:1:37@28=9<>654?;26?9:=58<@34;>178;<:>7345=12?@96=574<@16>;?938:2@3>19;?2786:4<5=4@8;15=>62:?793<3>9528<:17@=6;4?:71<63@?;948=52>?=2674;93>5<8:@1");
                SudokuSolver.SudokuSolver.Solve(s);
            }
            catch
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void invalidValuesInSudoku()
        {
            try
            {
                Sudoku s = SudokuSerializer.StringToSudoku("000000000000000g");
                SudokuSolver.SudokuSolver.Solve(s);
                Assert.Fail();
            }
            catch
            {
            }
        }
        [TestMethod]
        public void empty9x9()
        {
            try
            {
                Sudoku s = SudokuSerializer.StringToSudoku("000000000000000000000000000000000000000000000000000000000000000000000000000000000");
                SudokuSolver.SudokuSolver.Solve(s);
            }
            catch
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void hard9x9()
        {
            try
            {
                Sudoku s = SudokuSerializer.StringToSudoku("006000007970000040520000800000700500400003170050008006000301002000805000603902000");
                SudokuSolver.SudokuSolver.Solve(s);
            }
            catch
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void Unsolvable()
        {
            try
            {
                Sudoku s = SudokuSerializer.StringToSudoku("1000040200203004");
                SudokuSolver.SudokuSolver.Solve(s);
                Assert.Fail();
            }
            catch
            {
            }
        }
    }
}