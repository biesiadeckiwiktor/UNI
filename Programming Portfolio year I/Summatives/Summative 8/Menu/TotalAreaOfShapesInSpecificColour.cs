using Summative_8.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Summative_8.Shapes.ShapeManager.Shape;
using static Summative_8.Shapes.ShapeManager;

namespace Summative_8.Menu
{
    internal class TotalAreaOfShapesInSpecificColour : MenuItem
    {
        private ShapeManager manager;

        private float _area;

        public float area;


        public TotalAreaOfShapesInSpecificColour(ShapeManager manager)
        {
            this.manager = manager;
        }

        public override string MenuText()
        {
            return "Total area of shapes by colour ";
        }

        public override void Select()
        {
            StringBuilder sb = new StringBuilder($"{MenuText()}{Environment.NewLine}");
            int i = 1;
            foreach (Shape.Colour c in Enum.GetValues(typeof(Shape.Colour)))
            {
                sb.AppendLine($"{i}. {c}");
                i++;
            }
            string colourMenu = sb.ToString();
            int selectedIndex = ConsoleHelpers.GetIntegerInRange(1, Enum.GetValues(typeof(Shape.Colour)).Length, colourMenu) - 1;
            Colour selectedColour = (Shape.Colour)selectedIndex;

            _area = 0;
            foreach (var shape in manager.Shapes)
            {
                if (shape.ShapeColour == selectedColour)
                {
                    _area += shape.Area();
                }
            }

            Console.WriteLine($"Total area of shapes in {selectedColour}: {_area}");
        }
       
    }
}

