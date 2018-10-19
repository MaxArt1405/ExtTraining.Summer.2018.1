using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeLibrary
{
    public class MazeSolver
    {
        private readonly int startY;
        private readonly int startX;
        private readonly int _dimension;
        private readonly int[,] mazeModel;

        public MazeSolver(int[,] mazeModel, int startX, int startY)
        {
            this.startY = startY;
            this.startX = startX;
            Valid(mazeModel, startX, startY);
            _dimension = (int)Math.Sqrt(mazeModel.Length);
            this.mazeModel = new int[_dimension, _dimension];
            Array.Copy(mazeModel, this.mazeModel, mazeModel.Length);
        }
        public int[,] MazeWithPass()
        {
            return (int[,])mazeModel.Clone();
        }
        public List<Point> PointsFromEntranceToExit()
        {
            var pointList = new List<Point>();
            int max = 0;
            for (int i = 0; i < _dimension; i++)
            {
                for (int j = 0; j < _dimension; j++)
                {
                    if (mazeModel[i, j] > max)
                    {
                        max = mazeModel[i, j];
                    }
                }
            }
            for (int i = 1; i <= max; i++)
            {
                for (int j = 0; j < _dimension; j++)
                {
                    for (int k = 0; k < _dimension; k++)
                    {
                        if (i == mazeModel[j, k])
                        {
                            pointList.Add(new Point(j, k));

                        }
                    }
                }
            }
            return pointList;
        }
        public void PassMaze() => FindAWay();
        private void FindAWay()
        {
            bool[,] mapBools = new bool[_dimension, _dimension];
            for (int i = 0; i < _dimension; i++)
            {
                for (int j = 0; j < _dimension; j++)
                {
                    mapBools[i, j] = (mazeModel[i, j] == 0);
                }
            }
            int variable = 1;
            NextStep(mapBools, startX, startY, variable);
        }
        private bool NextStep(bool[,] map, int x, int y, int variable)
        {
            if (!(x == startX && y == startY))
            {
                if (x < 0 || y < 0)
                {
                    return true;
                }
                if (x >= _dimension || y >= _dimension)
                {
                    return true;
                }
                if (!map[x, y])
                {
                    return false;
                }
            }
            map[x, y] = false;

            var up = NextStep(map, x + 1, y, variable + 1);
            var down = NextStep(map, x - 1, y, variable + 1);
            var right = NextStep(map, x, y + 1, variable + 1);
            var left = NextStep(map, x, y - 1, variable + 1);

            if (up || down || right || left)
            {
                mazeModel[x, y] = variable;
                return true;
            }
            return false;
        }
        private void Valid(int[,] mazeModel, int startX, int startY)
        {
            if (mazeModel == null)
            {
                throw new ArgumentNullException($"The {nameof(mazeModel)} can't be null!");
            }
            if (startX < 0)
            {
                throw new ArgumentException($"The start point{nameof(startX)} is invalid!");
            }
            if (startY < 0)
            {
                throw new ArgumentException($"The start point{nameof(startY)} is invalid!");
            }
        }
    }
    public struct Point
    {
        public Point(int x, int y) : this()
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
