namespace GameDev.Models
{
    public class Item : Entity<Item>
    {
        // Type of Item.
        public AttributeEnum Attribute { get; set; }

        // Location where Items go on like Head, Hand, etc.
        public ItemLocationEnum Location { get; set; }

        // Used in increasing or decreasing Value of an Item based on given Attribute.
        public int Value { get; set; }

        // Damge caused by Item when used
        public int Damage { get; set; }

        public Item(string name, string description, string imageUri,
            AttributeEnum attribute, ItemLocationEnum location, int value, int damage)
        {
            CreateDefaultItem();

            Name = name;
            Description = description;
            ImageURI = imageUri;
            Attribute = attribute;
            Location = location;
            Value = value;
            Damage = damage;
        }

        public Item()
        {
            CreateDefaultItem();
        }

        private void CreateDefaultItem()
        {
            Name = "Item Name";
            Description = "Item description";
            ImageURI = GameDevResources.DefaultImageUrl;
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
            Damage = newData.Damage;
            Attribute = newData.Attribute;
            Location = newData.Location;
        }
    }
}