using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Summative_8.Shapes;
using Summative_8.Menu;

namespace Summative_8.Menu
{
    internal class EditRectangleMenu : EditShapeMenu
    {
        Rectangle _rectangle;

        public EditRectangleMenu(Rectangle rectangle) : base(rectangle)
        {
            _rectangle = rectangle;
        }

        public override void CreateMenu()
        {
            base.CreateMenu();
            _menuItems.Add(new EditRectangleSideMenuItem(_rectangle));
            _menuItems.Add(new EditRectangleHeightMenuItem(_rectangle));
            _menuItems.Add(new ExitMenuItem(this));
        }
    }
}
