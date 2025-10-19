using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Summative_8.Menu;
using Summative_8.Shapes;

namespace Summative_8.Menu
{
    internal class TotalAreaOfAllShapes : MenuItem
    {
        private ShapeManager manager;

        private float _area;

        public float area;
        

        public TotalAreaOfAllShapes(ShapeManager manager)
        {
            this.manager = manager;
        }

        public override string MenuText()
        {
            return "Total area of all shapes ";
        }

        public override void Select()
        {
            foreach (var shape in manager.Shapes)
            {
                _area += shape.Area();
            }
            Console.WriteLine($"Total area of all shapes: {_area}");
        }

    }
}

    

