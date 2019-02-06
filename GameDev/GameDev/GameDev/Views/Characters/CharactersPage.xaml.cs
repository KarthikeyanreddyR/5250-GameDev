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

            BindingContext = null;

            if (ToolbarItems.Count > 0)
                ToolbarItems.Clear();

            InitializeComponent();

            if (viewModel.Dataset.Count == 0 || viewModel.NeedsRefresh())
                viewModel.LoadCharactersCommand.Execute(null);

            BindingContext = viewModel;
        }

        private async void OnCharacterSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Character character))
                return;

            await Navigation.PushAsync(new CharacterDetailPage(new CharacterDetailsViewModel(character)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        private async void AddCharacter(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharacterNewPage());
        }
    }
}