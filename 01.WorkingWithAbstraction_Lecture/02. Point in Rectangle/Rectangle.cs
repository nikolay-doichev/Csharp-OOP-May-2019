using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Point_in_Rectangle
{
    class Rectangle
    {
        public Point TopLeft { get; set; }
        public Point BottemRight { get; set; }

        public Rectangle( Point topLeft, Point bottemRight)
        {
            TopLeft = topLeft;
            BottemRight = bottemRight;
        }

        public bool Contains(Point point)
        {
            bool insidByX = point.CoordinateX >= TopLeft.CoordinateX 
                && point.CoordinateX <= BottemRight.CoordinateX;

            bool insideByY = point.CoordinateY >= TopLeft.CoordinateY
                && point.CoordinateY <= BottemRight.CoordinateY;

            return insidByX && insideByY;
        }
    }
}
