using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Summative_8.Shapes;
using Summative_8.Menu;

namespace Summative_8.Menu
{
    internal class EditCircleMenu : EditShapeMenu
    {
        private Circle _circle;

        public EditCircleMenu(Circle circle) : base(circle)
        {
            _circle = circle;
        }

        public override void CreateMenu()
        {
            base.CreateMenu();
            _menuItems.Add(new EditCircleRadiusMenuItem(_circle));
            _menuItems.Add(new ExitMenuItem(this));
        }
    }
}
