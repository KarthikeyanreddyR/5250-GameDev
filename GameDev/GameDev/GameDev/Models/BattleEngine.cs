using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev.Models
{
    public class BattleEngine
    {
        public List<Character> CharacterList { get; set; }

        public List<Monster> MonsterList { get; set; }

        public BattleEngine()
        {
            CharacterList = new List<Character>();
            MonsterList = new List<Monster>();
        }
    }
}
