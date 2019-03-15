using GameDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameDev.GameEngines
{
    public class RoundEngine : TurnEngine
    {
        public bool IsRoundRunning { get; set; } = false;

        private static Random rnd = new Random();

        public RoundEngine() : base()
        {
            MonsterList = new List<Monster>();
            ItemPool = new List<Item>();
        }

        /// <summary>
        /// Start a Round
        /// </summary>
        public void StartRound()
        {
            IsRoundRunning = true;
            while (CheckRoundEndCondtion())
            {
                if(CheckRoundRestartCondtion())
                {
                    // generate monsters again and start new round
                    ScaleMonsters();
                    BattleScore.RoundCount++;
                }
                StartTurn();
            }
            IsRoundRunning = false;

        }

        /// <summary>
        /// Randomly select monsters based on Characters level
        /// </summary>
        public void ScaleMonsters()
        {
            // get random monsters from monsterviewmodel. 
            // no. of monsters == no. of characters
            // basedon characters highest level, scale monsters.
            // modify attributes of monsters.
            // assign items to monsters.
            // assign unique items to monsters.
        }

        public void AssignItemsToMonster()
        {

        }

        public void AssignUniqueItemToMonster()
        {
            var _rndNum = rnd.Next(1, 101);
            if(_rndNum < 26)
            {
                // dont assign
            }
            if(_rndNum > 74)
            {
                // assign
            }
        }

        /// <summary>
        /// Round is ended when all characters are killed.
        /// </summary>
        /// <returns></returns>
        public bool CheckRoundEndCondtion()
        {
            // if all characters are dead then round is over
            var _aliveCharacters = CharacterList.Where(arg => arg.Alive).Count();
            if (_aliveCharacters > 0)
            {
                // some Characters are alive
                return false;
            }
            else
            {
                // all Characters died
                return true;
            }
        }

        /// <summary>
        /// Round is restarted when all monsters are killed.
        /// </summary>
        /// <returns></returns>
        public bool CheckRoundRestartCondtion()
        {
            // if all monsters are dead then round is restarted
            var _aliveMonsters = MonsterList.Where(arg => arg.Alive).Count();
            if (_aliveMonsters > 0)
            {
                // some Monsters are alive
                return false;
            }
            else
            {
                // all Monsters died
                return true;
            }
        }

    }
}
