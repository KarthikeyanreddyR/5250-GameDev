﻿using GameDev.ViewModels;
using System.Collections.Generic;

namespace GameDev.Models
{
    // The Monster is the higher level concept.  This is the Character with all attirbutes defined.
    public class Monster : BaseMonster
    {
        // Remaining Experience Points to give
        public int ExperienceRemaining { get; set; }

        // Add in the actual attribute class
        public AttributeBase Attribute { get; set; }

        // Make sure Attribute is instantiated in the constructor
        public Monster()
        {
            Name = "Monster";
            Attribute = new AttributeBase();

            Alive = true;
            Level = 1;

            // Scale up to the level
            // // Implement ScaleLevel(Level);
        }

        public Monster(string name, string description, string imageUri,
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

            // TODO: Not sure of formula. Needed some work here
            ExperienceRemaining = ExperienceTotal - CalculateExperienceEarned(Damage);

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

        // Passed in from creating via the Database, so use the guid passed in...
        public Monster(BaseMonster newData)
        {
            // Base information
            Name = newData.Name;
            Description = newData.Description;
            Level = newData.Level;
            ExperienceTotal = newData.ExperienceTotal;
            ImageURI = newData.ImageURI;
            Alive = newData.Alive;
            Damage = newData.Damage;
            UniqueItem = newData.UniqueItem;

            // TODO: Not sure of formula. Needed some work here
            ExperienceRemaining = ExperienceTotal - CalculateExperienceEarned(Damage);

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

        // For making a new one for lists etc..
        public Monster(Monster newData)
        {
            // Base information
            Name = newData.Name;
            Description = newData.Description;
            Level = newData.Level;
            ExperienceTotal = newData.ExperienceTotal;
            ImageURI = newData.ImageURI;
            Alive = newData.Alive;
            Damage = newData.Damage;
            UniqueItem = newData.UniqueItem;
            ExperienceRemaining = newData.ExperienceRemaining;

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

        // Update the values passed in
        public void Update(Monster newData)
        {
            // Base information
            this.Name = newData.Name;
            this.Description = newData.Description;
            this.Level = newData.Level;
            this.ExperienceTotal = newData.ExperienceTotal;
            this.ImageURI = newData.ImageURI;
            this.Alive = newData.Alive;
            this.Damage = newData.Damage;
            this.UniqueItem = newData.UniqueItem;
            this.ExperienceRemaining = newData.ExperienceRemaining;

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

        // Helper to combine the attributes into a single line, to make it easier to display the item as a string
        public string FormatOutput()
        {
            var UniqueOutput = "Implement";

            var myReturn = "Implement";

            // Implement

            myReturn += " , Unique Item : " + UniqueOutput;

            return myReturn;
        }

        // Add or Replace Unique Item to Monster
        public void AddOrReplaceUniqueItem(string itemId)
        {
            this.UniqueItem = itemId;
        }

        // Update Image for Monster
        public void UpdateMonsterImageURL(string imageUrl)
        {
            this.ImageURI = imageUrl;
        }

        // Update Attributes for Monster
        public void UpdateMonsterAttributes(AttributeBase attributeBase)
        {
            this.Attribute = attributeBase;
            this.AttributeString = AttributeBase.GetAttributeString(this.Attribute);
        }

        // Upgrades a monster to a set level
        public void ScaleLevel(int level)
        {
            // Level must be between 1-20
            if (level < 1 || level > 20)
                return;

            // Dont update if it's same level
            if (level == this.Level)
                return;

            this.Level = level;

        }

        // Take Damage
        // If the damage recived, is > health, then death occurs
        // Return the number of experience received for this attack 
        // monsters give experience to characters.  Characters don't accept expereince from monsters
        public void TakeDamage(int damage)
        {
            // Implement
            return;

            // Implement   CauseDeath();
        }

        // Calculate How much experience to return
        // Formula is the % of Damage done up to 100%  times the current experience
        // Needs to be called before applying damage
        public int CalculateExperienceEarned(int damage)
        {
            // Implement
            return 0;

        }

        #region GetAttributes
        // Get Attributes

        // Get Attack
        public int GetAttack()
        {
            // Base Attack
            var myReturn = Attribute.Attack;

            return myReturn;
        }

        // Get Speed
        public int GetSpeed()
        {
            // Base value
            var myReturn = Attribute.Speed;

            return myReturn;
        }

        // Get Defense
        public int GetDefense()
        {
            // Base value
            var myReturn = Attribute.Defense;

            return myReturn;
        }

        // Get Max Health
        public int GetHealthMax()
        {
            // Base value
            var myReturn = Attribute.MaxHealth;

            return myReturn;
        }

        // Get Current Health
        public int GetHealthCurrent()
        {
            // Base value
            var myReturn = Attribute.CurrentHealth;

            return myReturn;
        }

        // Get the Level based damage
        // Then add in the monster damage
        public int GetDamage()
        {
            var myReturn = 0;
            myReturn += Damage;

            return myReturn;
        }

        // Get the Level based damage
        // Then add the damage for the primary hand item as a Dice Roll
        public int GetDamageRollValue()
        {
            return GetDamage();
        }

        #endregion GetAttributes

        #region Items
        // Gets the unique item (if any) from this monster when it dies...
        public Item GetUniqueItem()
        {
            var myReturn = ItemsViewModel.Instance.GetItem(UniqueItem).Result;

            return myReturn;
        }

        // Drop all the items the monster has
        public List<Item> DropAllItems()
        {
            var myReturn = new List<Item>();

            // Drop all Items
            Item myItem;

            // Implement

            return myReturn;
        }

        #endregion Items
    }
}
