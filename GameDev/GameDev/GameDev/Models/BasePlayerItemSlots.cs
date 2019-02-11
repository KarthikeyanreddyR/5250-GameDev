using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev.Models
{
    public class BasePlayerItemSlots<T> : Entity<T>
    {
        // Item is a string referencing the database table
        public string Head { get; set; }

        // Feet is a string referencing the database table
        public string Feet { get; set; }

        // Necklace is a string referencing the database table
        public string Necklace { get; set; }

        // PrimaryHand is a string referencing the database table
        public string PrimaryHand { get; set; }

        // Offhand is a string referencing the database table
        public string OffHand { get; set; }

        // RightFinger is a string referencing the database table
        public string RightFinger { get; set; }

        // LeftFinger is a string referencing the database table
        public string LeftFinger { get; set; }

        // This uses reflection, to get the property from a string
        // Then based on the property, it gets the value which will be the string pointing to the item
        // Then it calls to the view model who has the list of items, and asks for it
        // then it returns the formatted string for the Item, and Value.
        private string FormatOutputSlot(string slot)
        {
            var myReturn = "Implement";

            return myReturn;
        }

        public string ItemSlotsFormatOutput()
        {
            var myReturn = "Implement";

            return myReturn.Trim();
        }
    }

}
