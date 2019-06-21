using GameDev.GameEngines;
using GameDev.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameDev.Views.Battle
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewMonstersPage : ContentPage
	{
        public BattleViewModel BattleViewModel;


        public ViewMonstersPage (BattleViewModel battleViewModel)
		{
			InitializeComponent ();

            BattleViewModel = battleViewModel;
		}
	}
}