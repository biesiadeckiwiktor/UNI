using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Summative_8.Shapes.ShapeManager;

namespace Summative_8.Shapes
{
    class Rectangle : Shape
    {
        public const int MIN_SIDE = 0;
        public const int MAX_SIDE = 50;
        public const int MIN_HEIGHT = 0;
        public const int MAX_HEIGHT = 50;

        private float _Side;
        public float Side
        {
            get { return _Side; }
            set { if (value >= MIN_SIDE && value <= MAX_SIDE) { _Side = value; } }
        }

        private float _Height;
        public float Height
        {
            get { return _Height; }
            set { if (value >= MIN_HEIGHT && value <= MAX_HEIGHT) { _Height = value; } }
        }


        public Rectangle(float height, float side, Colour colour)
        {
            Side = side;
            Height = height;
            ShapeColour = colour;
        }

        public override float Area()
        {
            return Side * Height;
        }

        public override float Perimeter()
        {
            return (2 * Side) + (2 * Height);
        }
        public override string ToString()
        {
            return $"{ShapeColour} rectangle with side {Side} and height {Height}.";
        }

    }
}
