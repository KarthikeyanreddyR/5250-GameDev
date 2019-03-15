using GameDev.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev.GameEngines
{
    public class TurnEngine
    {
        protected Score BattleScore { get; set; }

        public List<Character> CharacterList { get; set; }

        public List<Monster> MonsterList { get; set; }

        public List<Item> ItemPool { get; set; }

        public TurnEngine()
        {

        }

        public void StartTurn()
        {

        }
    }
}
