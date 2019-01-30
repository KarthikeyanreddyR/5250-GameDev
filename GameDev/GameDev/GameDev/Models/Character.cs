using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev.Models
{
    public class Character : Entity<Character>
    {
        public int Age { get; set; }

        public Character()
        {
            CreateDefaultCharacter();
        }

        public Character(string name, string description, string imageUri, int age)
        {
            CreateDefaultCharacter();

            Name = name;
            Description = description;
            ImageURI = imageUri;
            Age = age;
        }

        private void CreateDefaultCharacter()
        {
            Name = "Unknown";
            Description = "Unknown";
            ImageURI = null;
            Age = 0;
        }
    }
}
