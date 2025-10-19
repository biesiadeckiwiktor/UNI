using Summative_8.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_8.Menu
{
    
    class ShapeManagerMenu : ConsoleMenu
    {
        private ShapeManager _manager;

        public ShapeManagerMenu(ShapeManager manager)
        {
            _manager = manager;
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
            _menuItems.Add(new AddCircleMenuItem(_manager));
            _menuItems.Add(new AddSquareMenuItem(_manager));
            _menuItems.Add(new AddRectangleMenuItem(_manager));
            _menuItems.Add(new TotalArea(_manager));
            _menuItems.Add(new TotalPerimiterOfAllShapes(_manager));
            _menuItems.Add(new RemoveShape(_manager));
            _menuItems.Add(new DetailsOfAllShapes(_manager));
            if (_manager.Shapes.Count > 0)
            {
                _menuItems.Add(new EditExistingShapeMenu(_manager));
            }
            _menuItems.Add(new ExitMenuItem(this));
        }

        public override string MenuText()
        {
            return "Shape Manager Menu" + Environment.NewLine + _manager.ToString();
        }
    }
}
