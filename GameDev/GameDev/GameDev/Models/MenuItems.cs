using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev.Models
{

    public enum MenuItemTypes
    {
        Home,
        Items,
        Characters,
        Monsters,
        Scores,
        About
    }

    class MenuItems
    {
        public MenuItemTypes Id { get; set; }

        public string Heading { get; set; }
    }
}
