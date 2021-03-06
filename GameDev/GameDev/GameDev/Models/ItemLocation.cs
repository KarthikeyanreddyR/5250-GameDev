﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GameDev.Models
{
    public enum ItemLocationEnum
    {
        // Not specified
        Unknown = 0,

        // The head includes, Hats, Helms, Caps, Crowns, Hair Ribbons, Bunny Ears, and anything else that sits on the head
        Head = 10,

        // Things to put around the neck, such as necklass, broaches, scarfs, neck ribbons.  Can have at the same time with Head items ex. Ribbon for Hair, and Ribbon for Neck is OK to have
        Necklass = 12,

        // The primary hand used for fighting with a sword or a staff.  
        PrimaryHand = 20,

        // The second hand used for holding a shield or dagger, or wand.  OK to have both primary and offhand loaded at the same time
        OffHand = 22,

        // Any finger, used for rings, because they can go on any finger.
        Finger = 30,

        // A finger on the Right hand for rings.  Can only have one right on the right hand
        RightFinger = 31,

        // A finger on the left hand for rings.  Can only have one ring on the left hand.  Can have ring on left and right at the same time
        LeftFinger = 32,

        // Boots, shoes, socks or anything else on the feet
        Feet = 40,

    }

    // Helper functions for the Item Locations
    public static class ItemLocationHelper
    {
        public static List<string> GetList
        {
            get
            {
                return Enum.GetNames(typeof(ItemLocationEnum)).ToList();
            }
        }

        public static List<string> GetListForCharacter
        {
            get
            {
                var _list = Enum.GetValues(typeof(ItemLocationEnum)).Cast<ItemLocationEnum>()
                    .Where(e => e != ItemLocationEnum.Finger && e != ItemLocationEnum.Unknown)
                    .Select(v => v.ToString())
                    .ToList();
                return _list;
            }
        }

        public static ItemLocationEnum ConvertStringToEnum(string value)
        {
            return (ItemLocationEnum)Enum.Parse(typeof(ItemLocationEnum), value);
        }

    }
}
