using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Main_Page
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
