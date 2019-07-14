using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_JediGalaxy
{
    public class Engine
    {
        private int[,] matrix;
        private long totalSum;
        public void Run()
        {
            int[] dimensions = Console.ReadLine()
                ?.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];
            
            this.InitializeMatrix(rows, cols);

            string command = Console.ReadLine();
            
            while (command != "Let the Force be with you")
            {
                int[] playerCoordinates = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilCoordinates = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evelRow = evilCoordinates[0];
                int evelCol = evilCoordinates[1];

                //MoveEvelToTopLeftConer
                MoveEvelToTopLeftConer(evelRow, evelCol);

                int playerRow = playerCoordinates[0];
                int playerCol = playerCoordinates[1];

                //MovePlayerToTopRightCorner
                MovePlayerToTopRightCorner(playerRow, playerCol);

                command = Console.ReadLine();
            }
            Console.WriteLine(totalSum);
        }
        private void MovePlayerToTopRightCorner(int playerRow, int playerCol)
        {
            while (playerRow >= 0 && playerCol < matrix.GetLength(1))
            {
                if (this.IsInside(playerRow, playerCol))
                {
                    totalSum += matrix[playerRow, playerCol];
                }

                playerCol++;
                playerRow--;
            }
        }

        private void MoveEvelToTopLeftConer(int evelRow, int evelCol)
        {
            while (evelRow >= 0 && evelCol >= 0)
            {
                //IsInside
                if (this.IsInside(evelRow, evelCol))
                {
                    matrix[evelRow, evelCol] = 0;
                }

                evelRow--;
                evelCol--;
            }
        }
        private bool IsInside(int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < matrix.GetLength(0) 
                                && targetCol >= 0 
                                && targetCol < matrix.GetLength(1);
        }
        private void InitializeMatrix(int rows, int cols)
        {
            matrix = new int[rows, cols];
            int value = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }
    }
}
