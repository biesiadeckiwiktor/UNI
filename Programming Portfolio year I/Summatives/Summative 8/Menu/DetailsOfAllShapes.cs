using Summative_8.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_8.Menu
{
    internal class DetailsOfAllShapes : MenuItem
    {
        private ShapeManager manager;

        private float _area;
        private float _perimeter;

        public float area;
        public float perimeter;


        public DetailsOfAllShapes(ShapeManager manager)
        {
            this.manager = manager;
        }

        public override string MenuText()
        {
            return "Details of all shapes ";
        }

        public override void Select()
        {
            foreach (var shape in manager.Shapes)
            {
                _area = shape.Area();
                _perimeter = shape.Perimeter();
                Console.WriteLine($"The shape of {shape.ShapeColour} colour has are of {_area} and perimeter of {_perimeter}");
            }
        }
    }
}
