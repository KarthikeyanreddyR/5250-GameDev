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

        public BattleEngine() : base()
        {
            BattleScore = new Score();
            CharacterList = new List<Character>();
        }

        public void StartBattle()
        {
            IsBattleRunning = true;
            StartRound();
            IsBattleRunning = false;
        }

        public Score GetFinalScore()
        {
            return new Score(BattleScore);
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
