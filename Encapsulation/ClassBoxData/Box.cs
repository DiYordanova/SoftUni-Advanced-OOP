using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        { 
            get => this.length; 
            private set
            {
                this.ThrowIfInvalidSide(value, nameof(this.Length));

                this.length = value;
            }            
        }

        public double Width
        {
            get => this.width;
            private set
            {
                this.ThrowIfInvalidSide(value, nameof(this.Width));

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                this.ThrowIfInvalidSide(value, nameof(Height));

                this.height = value;
            }
        }

        public double CalculateVolume()
        {
            return this.Length * this.Width * this.Height;
        }

        public double CalculateLateralSurfaceArea()
        {
            return 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        public double CalculateSurfaceArea()
        {
            return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        private void ThrowIfInvalidSide(double value, string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }
        }
    }
}
