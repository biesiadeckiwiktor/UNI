using System;

namespace Capstone.Menus
{
    internal class StaffMenuItem : MenuItem
    {
        private readonly string _menuText;
        private readonly Action _action;

        public StaffMenuItem(string menuText, Action action)
        {
            _menuText = menuText;
            _action = action;
        }

        public override void Select()
        {
            _action();
        }

        public override string MenuText()
        {
            return _menuText;
        }
    }
} 