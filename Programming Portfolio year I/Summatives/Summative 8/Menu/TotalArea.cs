using Summative_8.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Summative_8.Menu;

namespace Summative_8.Menu
{
    internal class TotalArea : ConsoleMenu
    {
        private ShapeManager _manager;


        public TotalArea(ShapeManager manager)
        {
            this._manager = manager;
        }

        public override string MenuText()
        {
            return "Total area of shapes ";
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
            _menuItems.Add(new TotalAreaOfAllShapes(_manager));
            _menuItems.Add(new TotalAreaOfShapesInSpecificColour(_manager));
            _menuItems.Add(new ExitMenuItem(this));
        }

    }
}
