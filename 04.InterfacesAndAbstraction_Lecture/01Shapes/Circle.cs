using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private readonly int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            double rIn = radius - 0.4;
            double rOut = radius + 0.4;

            for (double y = this.radius; y >= -this.radius; --y)
            {
                for (double x = -this.radius; x < rOut; x+=0.5)
                {
                    double point = x * x + y * y;
                    if (point >= rIn* rIn && point <= rOut * rOut)
                    {
                        Console.Write("*");
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
