using GameDev.ViewModels;
using System;
using System.Collections.Generic;

namespace GameDev.Models
{
    public class Character : BaseCharacter
    {
        public static string DefaultImageUrl = "http://gdurl.com/P7TZ";

        public AttributeBase Attribute { get; set; }

        public Character()
        {
            CreateDefaultCharacter();
        }

        private void CreateDefaultCharacter()
        {
            Name = "Doug";
            Description = "Sample description of character. It's unique properties.";
            ImageURI = DefaultImageUrl;
            Attribute = new AttributeBase();
            Alive = true;
        }

        // Create new Character.
        public Character(string name, string description, string imageUri,
            int level, int xpTotal, bool alive,
            int speed, int attack, int defense, int maxHealth, int currentHealth,
            string head, string feet, string necklace, string primaryHand, string offhand, string rightFinger, string leftFinger)
        {
            Name = name;
            Description = description;
            ImageURI = imageUri;

            Level = level;
            ExperienceTotal = xpTotal;
            Alive = alive;

            Attribute = new AttributeBase(speed, attack, defense, maxHealth, currentHealth);
            AttributeString = AttributeBase.GetAttributeString(this.Attribute);

            Head = head;
            Feet = feet;
            Necklace = necklace;
            PrimaryHand = primaryHand;
            OffHand = offhand;
            RightFinger = rightFinger;
            LeftFinger = leftFinger;
        }

        // Create a new character, based on a passed in BaseCharacter
        // Used for converting from database format to character
        public Character(BaseCharacter newData)
        {
            // Base information
            Name = newData.Name;
            Description = newData.Description;
            Level = newData.Level;
            ExperienceTotal = newData.ExperienceTotal;
            ImageURI = newData.ImageURI;
            Alive = newData.Alive;

            // Database information
            Guid = newData.Guid;
            Id = newData.Id;

            // Populate the Attributes
            AttributeString = newData.AttributeString;
            Attribute = new AttributeBase(newData.AttributeString);

            // Set the strings for the items
            Head = newData.Head;
            Feet = newData.Feet;
            Necklace = newData.Necklace;
            RightFinger = newData.RightFinger;
            LeftFinger = newData.LeftFinger;
            Feet = newData.Feet;
        }

        // Create a new character, based on existing Character
        public Character(Character newData)
        {
            Name = newData.Name;
            Description = newData.Description;
            ImageURI = newData.ImageURI;

            Level = newData.Level;
            ExperienceTotal = newData.ExperienceTotal;
            Alive = newData.Alive;

            AttributeString = newData.AttributeString;
            Attribute = new AttributeBase(newData.AttributeString);

            Head = newData.Head;
            Feet = newData.Feet;
            Necklace = newData.Necklace;
            PrimaryHand = newData.PrimaryHand;
            OffHand = newData.OffHand;
            RightFinger = newData.RightFinger;
            LeftFinger = newData.LeftFinger;
        }

        // Update the character information
        // Updates the attribute string
        public void Update(Character newData)
        {
            if (newData == null)
                return;

            this.Name = newData.Name;
            this.Description = newData.Description;
            this.Level = newData.Level;
            this.ExperienceTotal = newData.ExperienceTotal;
            this.ImageURI = newData.ImageURI;
            this.Alive = newData.Alive;

            // Populate the Attributes
            this.AttributeString = newData.AttributeString;
            this.Attribute = new AttributeBase(newData.AttributeString);

            // Set the strings for the items
            this.Head = newData.Head;
            this.Feet = newData.Feet;
            this.Necklace = newData.Necklace;
            this.RightFinger = newData.RightFinger;
            this.LeftFinger = newData.LeftFinger;
            this.Feet = newData.Feet;
            return;
        }

        #region Basics

        // Upgrades to a set level
        public void ScaleLevel(int level)
        {
            // Implement
        }

        // Level Up
        public bool LevelUp()
        {
            // Implement
            return false;
        }

        // Level up to a number, say Level 3
        public int LevelUpToValue(int value)
        {
            // Implement
            return Level;
        }

        // Add experience
        public bool AddExperience(int newExperience)
        {
            // Implement
            return false;
        }

        // Take Damage
        // If the damage received is > health, then death occurs
        // Return the number of experience received for this attack 
        // monsters give experience to characters.  Characters don't accept experience from monsters
        public void TakeDamage(int damage)
        {
            // Implement
        }

        #endregion Basics

        #region GetAttributes
        // Get Attributes

        // Get Attack
        public int GetAttack()
        {
            // Base Attack
            var myReturn = Attribute.Attack;

            // Implement

            // Attack Bonus from Level

            // Get Attack bonus from Items

            return myReturn;
        }

        // Get Speed
        public int GetSpeed()
        {
            // Base value
            var myReturn = Attribute.Speed;

            // Implement

            // Get Bonus from Level

            // Get bonus from Items

            return myReturn;
        }

        // Get Defense
        public int GetDefense()
        {
            // Base value
            var myReturn = Attribute.Defense;

            // Implement

            // Get Bonus from Level

            // Get bonus from Items

            return myReturn;
        }

        // Get Max Health
        public int GetHealthMax()
        {
            // Base value
            var myReturn = Attribute.MaxHealth;

            // Implement

            // Get bonus from Items

            return myReturn;
        }

        // Get Current Health
        public int GetHealthCurrent()
        {
            // Base value
            var myReturn = Attribute.CurrentHealth;

            // Implement

            // Get bonus from Items

            return myReturn;
        }

        // Returns the Dice for the item
        // Sword 10, is Sword Dice 10
        public int GetDamageDice()
        {
            var myReturn = 0;

            // Implement


            return myReturn;
        }

        // Get the Level based damage
        // Then add the damage for the primary hand item as a Dice Roll
        public int GetDamageRollValue()
        {
            var myReturn = GetLevelBasedDamage();

            // Implement


            return myReturn;
        }

        #endregion GetAttributes

        #region Items
        // Drop All Items
        // Return a list of items for the pool of items
        public List<Item> DropAllItems()
        {
            var myReturn = new List<Item>();

            // Get Item Locations for Characters
            var _locationList = ItemLocationHelper.GetListForCharacter;

            foreach (string loc in _locationList)
            {
                Enum.TryParse(loc, true, out ItemLocationEnum locEnum);
                Item _item = RemoveItem(locEnum);
                myReturn.Add(_item);
            }

            return myReturn;
        }

        // Remove Item from a set location
        // Does this by adding a new item of Null to the location
        // This will return the previous item, and put null in its place
        // Returns the item that was at the location
        // Nulls out the location
        public Item RemoveItem(ItemLocationEnum itemLocation)
        {
            return AddItem(itemLocation, null);
        }

        // Get the Item at a known string location (head, foot etc.)
        public Item GetItem(string itemString)
        {
            return ItemsViewModel.Instance.GetItem(itemString).Result;
        }

        // Get the Item at a known string location (head, foot etc.)
        public Item GetItemByLocation(ItemLocationEnum itemLocation)
        {
            var _itemId = "";
            switch (itemLocation)
            {
                case ItemLocationEnum.Head:
                    _itemId = this.Head;
                    break;
                case ItemLocationEnum.Necklass:
                    _itemId = this.Necklace;
                    break;
                case ItemLocationEnum.PrimaryHand:
                    _itemId = this.PrimaryHand;
                    break;
                case ItemLocationEnum.OffHand:
                    _itemId = this.OffHand;
                    break;
                case ItemLocationEnum.RightFinger:
                    _itemId = this.RightFinger;
                    break;
                case ItemLocationEnum.LeftFinger:
                    _itemId = this.LeftFinger;
                    break;
                case ItemLocationEnum.Feet:
                    _itemId = this.Feet;
                    break;
            }
            return GetItem(_itemId);
        }

        // Add Item
        // Looks up the Item
        // Puts the Item ID as a string in the location slot
        // If item is null, then puts null in the slot
        // Returns the item that was in the location
        public Item AddItem(ItemLocationEnum itemLocation, string itemId)
        {
            Item item = null;
            var _prevItem = "";
            if (itemId != null)
                item = GetItem(itemId);

            switch (itemLocation)
            {
                case ItemLocationEnum.Head:
                    _prevItem = this.Head;
                    this.Head = item?.Id;
                    break;
                case ItemLocationEnum.Necklass:
                    _prevItem = this.Necklace;
                    this.Necklace = item?.Id;
                    break;
                case ItemLocationEnum.PrimaryHand:
                    _prevItem = this.PrimaryHand;
                    this.PrimaryHand = item?.Id;
                    break;
                case ItemLocationEnum.OffHand:
                    _prevItem = this.OffHand;
                    this.OffHand = item?.Id;
                    break;
                case ItemLocationEnum.RightFinger:
                    _prevItem = this.RightFinger;
                    this.RightFinger = item?.Id;
                    break;
                case ItemLocationEnum.LeftFinger:
                    _prevItem = this.LeftFinger;
                    this.LeftFinger = item?.Id;
                    break;
                case ItemLocationEnum.Feet:
                    _prevItem = this.Feet;
                    this.Feet = item?.Id;
                    break;
            }
            return GetItem(_prevItem);
        }

        // Walk all the Items on the Character.
        // Add together all Items that modify the Attribute Enum Passed in
        // Return the sum
        public int GetItemBonus(AttributeEnum attributeEnum)
        {
            var res = 0;
            foreach (string loc in ItemLocationHelper.GetListForCharacter)
            {
                Enum.TryParse(loc, true, out ItemLocationEnum locEnum);
                Item item = GetItemByLocation(locEnum);
                if (item.Attribute.Equals(attributeEnum))
                    res += item.Value;
            }
            return res;
        }

        #endregion Items
    }
}
