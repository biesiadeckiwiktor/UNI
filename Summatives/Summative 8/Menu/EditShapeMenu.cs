using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Summative_8.Shapes.ShapeManager;

namespace Summative_8.Menu
{
    internal abstract class EditShapeMenu : ConsoleMenu
    {
        protected Shape _shape;

        public EditShapeMenu(Shape shape)
        {
            _shape = shape;
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
            _menuItems.Add(new ColourShapeMenuItem(_shape));
        }

        public override string MenuText()
        {
            return _shape.ToString();
        }

        public override string ToString()
        {
            return $"Edit {base.ToString()}";
        }
    }
}
