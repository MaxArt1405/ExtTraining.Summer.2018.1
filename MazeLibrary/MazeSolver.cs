using System;

namespace MazeLibrary
{
    public class MazeSolver
    {
        public MazeSolver(int[,] mazeModel, int startX, int startY)
        {
            Valid(mazeModel, startX, startY);

            int width = mazeModel.GetUpperBound(0);
            int height = mazeModel.GetUpperBound(1);

            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    
                }
            }
            recursiveSolve(mazeModel, startX, startY);
        }
        private int endX, endY;
        private int[][] correct = new int[6][];
        private bool recursiveSolve(int[,] maze, int x, int y)
        {
            bool solved = false;
            if (x == endX && y == endY)
            {
                solved = true;
            }
            if (maze[x + 1,y] == -1)
            {
                recursiveSolve(maze,x + 1, y);
            }
            else if (maze[x,y + 1] == -1)
            {
                recursiveSolve(maze,x, y -1);
            }
            else if (maze[x - 1,y] == -1)
            {
                recursiveSolve(maze,x - 1, y);
            }
            else if (maze[x,y - 1] == -1)
            {
                recursiveSolve(maze,x,y - 1);
            }
            return solved;
        }
        public int[,] MazeWithPass()
        {
            throw new NotImplementedException();
        }

        public void PassMaze()
        {
        }
        private void Valid(int[,] mazeModel, int startX, int startY)
        {
            if(mazeModel == null)
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
}
