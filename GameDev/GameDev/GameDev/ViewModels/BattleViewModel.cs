using GameDev.GameEngines;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev.ViewModels
{
    public class BattleViewModel : BaseViewModel
    {
        #region Singleton

        private BattleViewModel _instance;

        public BattleViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BattleViewModel();
                }
                return _instance;
            }
        }

        #endregion Singleton

        public BattleEngine BattleEngine { get; set; }

        public BattleViewModel()
        {
            BattleEngine = new BattleEngine();
        }
    }
}
