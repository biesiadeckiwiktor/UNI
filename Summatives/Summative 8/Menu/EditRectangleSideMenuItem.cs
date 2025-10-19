using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Summative_8.Shapes;
using Summative_8.Menu;

namespace Summative_8.Menu
{
    internal class EditRectangleSideMenuItem : MenuItem
    {
        private Rectangle _rectangle;

        public EditRectangleSideMenuItem(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }

        public override string MenuText()
        {
            return "Edit side";
        }

        public override void Select()
        {
            _rectangle.Side = ConsoleHelpers.GetIntegerInRange(Rectangle.MIN_SIDE, Rectangle.MAX_SIDE, "Enter new side");
        }
    }
}
