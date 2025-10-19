using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Summative_8.Shapes.ShapeManager;

namespace Summative_8.Menu
{
    class ColourShapeMenuItem : MenuItem
    {
        public Shape.Colour Colour { get; private set; }

        private Shape _shape;

        public ColourShapeMenuItem(Shape shape)
        {
            _shape = shape;
        }

        public ColourShapeMenuItem() : this(null)
        {
        }

        public override void Select()
        {
            int selectedIndex = ConsoleHelpers.GetIntegerInRange(1, Enum.GetValues(typeof(Shape.Colour)).Length, ToString()) - 1;
            Colour = (Shape.Colour)selectedIndex;
            if (_shape != null)
            {
                _shape.ShapeColour = Colour;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"{MenuText()}{Environment.NewLine}");
            int i = 1;
            foreach (Shape.Colour colour in Enum.GetValues(typeof(Shape.Colour)))
            {
                sb.AppendLine($"{i}. {colour}");
                i++;
            }
            return sb.ToString();
        }

        public override string MenuText()
        {
            return "Select colour";
        }
    }
}
