using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Summative_8.Shapes;
using Summative_8.Menu;

namespace Summative_8.Menu
{
    internal class EditSquareMenu : EditShapeMenu
    {
        Square _square;

        public EditSquareMenu(Square square) : base(square)
        {
            _square = square;
        }

        public override void CreateMenu()
        {
            base.CreateMenu();
            _menuItems.Add(new EditSquareWidthMenuItem(_square));
            _menuItems.Add(new ExitMenuItem(this));
        }
    }
}
