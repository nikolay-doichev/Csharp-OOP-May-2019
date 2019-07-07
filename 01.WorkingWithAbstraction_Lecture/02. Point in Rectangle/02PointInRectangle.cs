namespace _02._Point_in_Rectangle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class PointOfRectangle
    {
        public static void Main(string[] args)
        {
            int[] coordinates = ParseInput();
            Point topLeft = new Point(coordinates[0], coordinates[1]);
            Point bottemRight = new Point(coordinates[2], coordinates[3]);

            Rectangle rectangle = new Rectangle(topLeft, bottemRight);

            int numberOfPoints = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPoints; i++)
            {
                int[] arrayPoint = ParseInput();
                Point pointToCheck = new Point(arrayPoint[0], arrayPoint[1]);

                Console.WriteLine(rectangle.Contains(pointToCheck));
            }
        }

        private static int[] ParseInput()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
