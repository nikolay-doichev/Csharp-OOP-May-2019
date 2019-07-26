using _01ClassBoxData.Exception;
using System;
using System.Text;

namespace _01ClassBoxData.Models
{
    public class Box
    {
        private double lenght;

        private double width;

        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Length = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.lenght;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.lenght = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double LateralSurfaceArea()
        {
            double lateralSurfaceArea = (2 * this.Length * this.Height) + 
                                        (2 * this.Width * this.Height);
            return lateralSurfaceArea;
        }
        public double SurfaceArea()
        {
            double surfaceArea = (2 * this.Length * this.Width) + 
                                 (2 * this.Length * this.Height) + 
                                 (2 * this.Width * this.Height);

            return surfaceArea;
        }
        public double Volume()
        {
            double volume = this.Length * this.Width * this.Height;
            return volume;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result
                .AppendLine($"Surface Area - {this.SurfaceArea():F2}")
                .AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():F2}")
                .AppendLine($"Volume - {this.Volume():F2}");

            return result.ToString().TrimEnd();
        }
    }
}
