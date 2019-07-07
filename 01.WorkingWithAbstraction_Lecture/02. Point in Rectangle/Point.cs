using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Point_in_Rectangle
{
    public class Point
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }

        public Point( int coordinateX, int coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }
    }
}
