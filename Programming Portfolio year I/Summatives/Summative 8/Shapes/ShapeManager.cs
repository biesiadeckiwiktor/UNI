using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_8.Shapes
{
    internal class ShapeManager
    {
        public List<Shape> Shapes { get; private set; }

        public ShapeManager()
        {
            Shapes = new List<Shape>();
        }

        public void AddShape(Shape pShape)
        {
            Shapes.Add(pShape);
        }

        internal abstract class Shape
        {
            public enum Colour { Red, Green, Blue, Yellow, Pink, Black }
            public Colour ShapeColour { set; get; }
            public abstract float Area();
            public abstract float Perimeter();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Shape pShape in Shapes)
            {
                sb.Append(pShape.ToString() + Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
