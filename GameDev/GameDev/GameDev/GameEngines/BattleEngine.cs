using GameDev.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameDev.GameEngines
{
    public class BattleEngine : RoundEngine
    {

        public bool IsBattleRunning { get; set; } = false;

        public Boolean AutoBattle { get; set; }

        public BattleEngine() : base()
        {
            InitializeBattle();
        }

        private void InitializeBattle()
        {
            BattleScore = new Score();
            CharacterList = new List<Character>();
        }

        public void StartBattle(bool isAutoBattle)
        {
            if(IsBattleRunning)
            {
                return;
            }
            if(CharacterList.Count < 1)
            {
                return;
            }
            AutoBattle = isAutoBattle;
            IsBattleRunning = true;
        }

        public void EndBattle()
        {
            IsBattleRunning = false;

        }

        public Score GetFinalScore()
        {
            return BattleScore;
        }

        //// Game Over Condition check
        //public async Task<bool> CheckGameEndCondition()
        //{
        //    // if all characters are dead then game is over
        //    var _aliveCharacters = CharacterList.Where(arg => arg.Alive).Count();
        //    if (_aliveCharacters > 0)
        //    {
        //        // some Characters are alive
        //        return await Task.FromResult(false);
        //    }
        //    else
        //    {
        //        // all Characters died
        //        return await Task.FromResult(true);
        //    }
        //}
    }
}
