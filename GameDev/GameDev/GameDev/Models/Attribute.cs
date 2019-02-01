using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameDev.Models
{
    public enum AttributeEnum
    {
        // Not specified
        Unknown = 0,

        // The speed of the character, impacts movement, and initiative
        Speed = 10,

        // The defense score, to be used for defending against attacks
        Defense = 12,

        // The Attack score to be used when attacking
        Attack = 14,

        // Current Health which is always at or below MaxHealth
        CurrentHealth = 16,

        // The highest value health can go
        MaxHealth = 18,
    }

    // Helper functions for the AttribureList
    public static class AttributeHelper
    {
        public static List<string> GetList
        {
            get
            {
                return Enum.GetNames(typeof(AttributeEnum)).ToList();
            }
        }

        public static List<string> GetListForItems
        {
            get
            {
                var _list = Enum.GetValues(typeof(AttributeEnum)).Cast<AttributeEnum>()
                    .Where(e => e != AttributeEnum.MaxHealth && e!= AttributeEnum.CurrentHealth)
                    .Select(v => v.ToString())
                    .ToList();
                return _list;
            }
        }

        public static AttributeEnum ConvertStringToEnum(string value)
        {
            return (AttributeEnum)Enum.Parse(typeof(AttributeEnum), value);
        }
    }
}
