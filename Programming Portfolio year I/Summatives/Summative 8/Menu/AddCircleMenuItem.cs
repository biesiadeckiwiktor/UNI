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
    internal class AddCircleMenuItem : MenuItem
    {
        private ShapeManager _manager;

        public AddCircleMenuItem(ShapeManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Add circle menu";
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
            ColourShapeMenuItem selectColourMenu = new ColourShapeMenuItem();
            selectColourMenu.Select();
            Colour colour = selectColourMenu.Colour;
            int radius = ConsoleHelpers.GetIntegerInRange(Circle.MIN_RADIUS, Circle.MAX_RADIUS, "What is the radius");
            Circle circle = new Circle(radius, colour);
            _manager.AddShape(circle);
        }
    }
}
