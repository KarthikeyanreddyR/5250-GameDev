﻿using GameDev.GameEngines;
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
	public partial class PickMonstersPage : ContentPage
	{
		public PickMonstersPage (BattleEngine battleEngine)
		{
			InitializeComponent ();
		}
	}
}