using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Summative_8.Shapes;
using Summative_8.Menu;

namespace Summative_8.Menu
{
    internal class EditRectangleHeightMenuItem : MenuItem
    {
        private Rectangle _rectangle;

        public EditRectangleHeightMenuItem(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }

        public override string MenuText()
        {
            return "Edit height";
        }

        public override void Select()
        {
            _rectangle.Height = ConsoleHelpers.GetIntegerInRange(Rectangle.MIN_HEIGHT, Rectangle.MAX_HEIGHT, "Enter new height");
        }
    }
}
