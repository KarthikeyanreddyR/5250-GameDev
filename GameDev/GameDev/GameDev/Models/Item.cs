using System;

namespace GameDev.Models
{
    public class Item : Entity<Item>
    {
        public int Range { get; set; }

        public int Damage { get; set; }

        public AttributeEnum Attribute { get; set; }

        public ItemLocationEnum Location { get; set; }

        public int Value { get; set; }

        public Item(string name, string description, string imageUri, int range, int damage, AttributeEnum attribute, ItemLocationEnum location, int value)
        {

            CreateDefaultItem();

            Name = name;
            Description = description;
            ImageURI = imageUri;

            Range = range;
            Damage = damage;
            Attribute = attribute;
            Location = location;
            Value = value;
        }

        public Item()
        {
            CreateDefaultItem();
        }

        private void CreateDefaultItem()
        {
            Name = "Unknown";
            Description = "Unknown";
            ImageURI = null;

            Range = 0;
            Value = 0;
            Damage = 0;

            Location = ItemLocationEnum.Unknown;
            Attribute = AttributeEnum.Unknown;
        }

        public void Update(Item newData)
        {
            if (newData == null)
            {
                return;
            }

            // Update all the fields in the Data, except for the Id and guid
            Name = newData.Name;
            Description = newData.Description;            
            ImageURI = newData.ImageURI;

            Value = newData.Value;
            Attribute = newData.Attribute;
            Location = newData.Location;

            Range = newData.Range;
            Damage = newData.Damage;
        }
    }
}