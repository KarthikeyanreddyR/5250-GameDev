﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev.Models
{
    public class Character : Entity<Character>
    {
        public static string DefaultImageUrl = "http://gdurl.com/P7TZ";

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
            Name = "Doug";
            Description = "Sample description of character. It's unique properties.";
            ImageURI = DefaultImageUrl;
            Age = 20;
        }

        public void Update(Character newData)
        {
            if (newData == null)
            {
                return;
            }

            // Update all the fields in the Data, except for the Id and guid
            Name = newData.Name;
            Description = newData.Description;
            ImageURI = newData.ImageURI;
            Age = newData.Age;
        }
    }
}
