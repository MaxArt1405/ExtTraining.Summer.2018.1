using System;
using NUnit.Framework;

namespace MazeLibrary.Tests
{
    [TestFixture]
    public class MazeSolverTests
    {
        private readonly int[] startXs = { 3, 0, 1, 0 };

        private readonly int[] startYs = { 5, 4, 0, 1 };

        private readonly int[][,] sourceData = new int[][,]
        {
            new int[,]
            {
                { -1, -1, -1, -1, -1, -1 },
                {  0,  0,  0, -1,  0, -1 },
                { -1,  0, -1, -1,  0, -1 },
                { -1,  0, -1,  0,  0,  0 },
                { -1,  0,  0,  0, -1, -1 },
                { -1, -1, -1, -1, -1, -1 }
            }         
        };

        private readonly int[][,] result = new int[][,]
        {
            new int[,]
            {
                { -1, -1, -1, -1, -1, -1 },
                { 10,  9,  0, -1,  0, -1 },
                { -1,  8, -1, -1,  0, -1 },
                { -1,  7, -1,  3,  2,  1 },
                { -1,  6,  5,  4, -1, -1 },
                { -1, -1, -1, -1, -1, -1 }
            }
        };

        [Test]
        public void MazeSolverConstructor_WithNull_ThrowsArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new MazeSolver(null, 1, 2));

        [Test]
        public void MazeSolverConstructor_WithInvalidStartIndexX_ThrowsArgumentException()
            => Assert.Throws<ArgumentException>(() => new MazeSolver(sourceData[0], -12, 2));

        [Test]
        public void MazeSolverConstructor_WithInvalidStartIndexY_ThrowsArgumentException()
            => Assert.Throws<ArgumentException>(() => new MazeSolver(sourceData[0], 0, -2));

        [Test]
        public void PassMaze_SuccessfulTests()
        {
            for (int i = 0; i < sourceData.Length; i++)
            {
                MazeSolver solver = new MazeSolver(sourceData[i], startXs[i], startYs[i]);

                solver.PassMaze();

                if (!MatrixAreEquals(solver.MazeWithPass(), result[i]))
                {
                    //TODO
                }
            }
        }
        private static bool MatrixAreEquals(int[,] lhs, int[,] rhs)
        {
            bool answer = lhs.Equals(rhs);
            return answer;
        }

    }
}
