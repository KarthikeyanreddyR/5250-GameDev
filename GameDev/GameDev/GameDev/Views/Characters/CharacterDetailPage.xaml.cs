using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GameDev.Models;
using GameDev.ViewModels;

namespace GameDev.Views.Characters
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterDetailPage : ContentPage
	{

        public CharacterDetailsViewModel _viewModel;

		public CharacterDetailPage ()
		{
			InitializeComponent ();

            var character = new Character();
            _viewModel = new CharacterDetailsViewModel(character);
            BindingContext = _viewModel;

		}

        public CharacterDetailPage(CharacterDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
        }

        async void Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharacterEditPage(_viewModel));

        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharacterDeletePage(_viewModel));

        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }
    }
}