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
    internal class AddSquareMenuItem : MenuItem
    {
        private ShapeManager _manager;

        public AddSquareMenuItem(ShapeManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Add square menu";
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
            Colour colour = (Shape.Colour)selectedIndex;
            int side = ConsoleHelpers.GetIntegerInRange(Square.MIN_SIDE, Square.MAX_SIDE, "What is the side length");
            Square square = new Square(side, colour);
            _manager.AddShape(square);
        }
    }
}
