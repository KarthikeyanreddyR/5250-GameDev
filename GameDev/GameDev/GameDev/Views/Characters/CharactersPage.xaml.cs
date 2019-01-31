using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GameDev.ViewModels;
using GameDev.Models;

namespace GameDev.Views.Characters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharactersPage : ContentPage
    {

        CharacterViewModel viewModel;

        public CharactersPage()
        {
            InitializeComponent();
            BindingContext = viewModel = CharacterViewModel.Instance;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //if (viewModel.Items.Count == 0)
            viewModel.LoadItemsCommand.Execute(null);
        }

        async void OnCharacterSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Character character))
                return;

           // await Navigation.PushAsync(new CharacterDetailPage(new CharacterDetailsViewModel(character)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CharacterNewPage());

        }
    }
}