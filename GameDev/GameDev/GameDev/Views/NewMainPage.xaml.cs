using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameDev.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewMainPage : ContentPage
	{
		public NewMainPage ()
		{
			InitializeComponent ();
            Title = "Main Page";
        }

        async void OnItemsClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ItemsPage());
        }

        async void OnCharactersClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Characters());
        }

        async void OnHistoryScoreClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new HistoryScore());
        }
    }
}