using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Summative_8.Shapes.ShapeManager.Shape;
using static Summative_8.Shapes.ShapeManager;

namespace Summative_8.Shapes
{
     class Square : Shape
    {
        public const int MIN_SIDE = 0;
        public const int MAX_SIDE = 50;

        private float _Side;
        public float Side
        {
            get { return _Side; }
            set { if (value >= MIN_SIDE && value <= MAX_SIDE) { _Side = value; } }
        }

        public Square(float side, Colour colour)
        {
            Side = side;
            ShapeColour = colour;
        }

        public override float Area()
        {
            return Side * Side;
        }

        public override float Perimeter()
        {
            return 4 * Side;
        }
        public override string ToString()
        {
            return $"{ShapeColour} square with side {Side}.";
        }

    }
}
