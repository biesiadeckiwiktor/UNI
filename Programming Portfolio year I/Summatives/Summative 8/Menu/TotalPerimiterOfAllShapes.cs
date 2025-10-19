using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Summative_8.Shapes;
using Summative_8.Menu;

namespace Summative_8.Menu
{
    internal class TotalPerimiterOfAllShapes : MenuItem
    {
        private ShapeManager manager;

        private float _perimeter;

        public float perimeter;


        public TotalPerimiterOfAllShapes(ShapeManager manager)
        {
            this.manager = manager;
        }

        public override string MenuText()
        {
            return "Total perimeter of all shapes ";
        }

        public override void Select()
        {
            foreach (var shape in manager.Shapes)
            {
                _perimeter += shape.Perimeter();
            }
            Console.WriteLine($"Total perimeter of all shapes: {_perimeter}");
        }
    }
}
