using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Summative_8.Shapes.ShapeManager.Shape;
using static Summative_8.Shapes.ShapeManager;
using Summative_8.Shapes;

namespace Summative_8.Menu
{
    internal class AddRectangleMenuItem : MenuItem
    {
        private ShapeManager _manager;

        public AddRectangleMenuItem(ShapeManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Add rectangle menu";
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
            int height = ConsoleHelpers.GetIntegerInRange(Rectangle.MIN_HEIGHT, Rectangle.MAX_HEIGHT, "What is the height length");
            Rectangle rectangle = new Rectangle(height, side, colour);
            _manager.AddShape(rectangle);
        }
    }
}
