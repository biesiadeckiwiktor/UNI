using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Summative_8.Shapes;
using Summative_8.Menu;

namespace Summative_8.Menu
{
    internal class EditSquareWidthMenuItem : MenuItem
    {
        private Square _square;

        public EditSquareWidthMenuItem(Square square)
        {
            _square = square;
        }

        public override string MenuText()
        {
            return "Edit width";
        }

        public override void Select()
        {
            _square.Side = ConsoleHelpers.GetIntegerInRange(Square.MIN_SIDE, Square.MAX_SIDE, "Enter new side");
        }
    }
}
