using System;
using System.Collections.Generic;
using System.Text;

using GameDev.Models;

namespace GameDev.ViewModels
{
    public class CharacterDetailsViewModel : BaseViewModel
    {
        public Character Character { get; set; }

        public CharacterDetailsViewModel(Character character = null)
        {
            Character = character;
        }
    }
}
