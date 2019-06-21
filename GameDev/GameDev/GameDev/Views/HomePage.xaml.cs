using GameDev.Views.Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDev.GameEngines;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameDev.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void OnAutoBattleClicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new AutoBattlePage());
        }

        private async void OnBattleClicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new PickCharactersPage());
        }
    }
}