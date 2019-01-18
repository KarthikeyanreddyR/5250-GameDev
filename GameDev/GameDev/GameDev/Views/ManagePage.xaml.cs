using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GameDev.Views.Characters;
using GameDev.Views.Score;
using GameDev.Views.Items;

namespace GameDev.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ManagePage : ContentPage
	{
		public ManagePage ()
		{
			InitializeComponent ();
            Title = "Manage";
        }

        async void OnItemsClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ItemsPage());
        }

        async void OnCharactersClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CharactersPage());
        }

        async void OnHistoryScoreClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ScoresPage());
        }
    }
}