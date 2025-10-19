using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Summative_8.Shapes.ShapeManager.Shape;
using static Summative_8.Shapes.ShapeManager;

namespace Summative_8.Shapes
{
    class Circle : Shape
    {
        public const int MIN_RADIUS = 0;
        public const int MAX_RADIUS = 50;

        private float _Radius;

        public float Radius
        {
            get { return _Radius; }
            set { if (value >= MIN_RADIUS && value <= MAX_RADIUS) { _Radius = value; } }
        }

        public Circle(float radius, Colour colour)
        {
            Radius = radius;
            ShapeColour = colour;
        }
        public override float Area()
        {
            return MathF.PI * _Radius * _Radius;
        }

        public override float Perimeter()
        {
            return 2 * MathF.PI * _Radius;
        }
        public override string ToString()
        {
            return $"{ShapeColour} circle with radius {Radius}.";
        }
    }
}
