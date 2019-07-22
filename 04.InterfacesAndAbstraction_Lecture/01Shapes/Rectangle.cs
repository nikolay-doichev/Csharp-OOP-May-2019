﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private readonly int width;
        private readonly int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public void Draw()
        {
            DrawLine('*', '*');
            for (int i = 0; i < height; i++)
            {
                DrawLine('*', ' ');
            }
            DrawLine('*', '*');
        }

        private void DrawLine(char borderSymbol, char innerSymbol)
        {
            Console.Write(borderSymbol);

            for (int i = 0; i < width - 2; i++)
            {
                Console.Write(innerSymbol);
            }

            Console.WriteLine(borderSymbol);
        }
    }
}
