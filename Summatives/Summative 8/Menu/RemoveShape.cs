using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Summative_8.Shapes;

namespace Summative_8.Menu
{
    internal class RemoveShape : MenuItem
    {
        private ShapeManager manager;

        public RemoveShape(ShapeManager manager)
        {
            this.manager = manager;
        }

        public override string MenuText()
        {
            return "Remove a shape";
        }

        public override void Select()
        {
            if (manager.Shapes.Count == 0)
            {
                Console.WriteLine("No shapes available to remove.");
                return;
            }

            Console.WriteLine("Select a shape to remove:");
            for (int i = 0; i < manager.Shapes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {manager.Shapes[i]}");
            }

            int selectedIndex = ConsoleHelpers.GetIntegerInRange(1, manager.Shapes.Count, "Enter the number of the shape to remove:") - 1;
            manager.Shapes.RemoveAt(selectedIndex);
            Console.WriteLine("Shape removed successfully.");
        }
    }
}
