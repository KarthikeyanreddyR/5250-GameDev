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
    public partial class CharacterEditPage : ContentPage
    {
        private CharacterDetailsViewModel _viewModel;

        public Character Data { get; set; }

        public CharacterEditPage(CharacterDetailsViewModel viewModel)
        {
            InitializeComponent();

            this.Data = viewModel.Character;

            BindingContext = _viewModel = viewModel;
        }

        private async void CancelCharacter(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void SaveCharacter(object sender, EventArgs e)
        {
            // If the image in teh data box is empty, use the default one..
            if (string.IsNullOrEmpty(Data.ImageURI))
            {
                this.Data.ImageURI = GameDevResources.DefaultImageUrl;
            }

            MessagingCenter.Send(this, "EditCharacter", this.Data);

            // removing the old ItemDetails page, 2 up counting this page
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

            // Add a new items details page, with the new Item data on it
            await Navigation.PushAsync(new CharacterDetailPage(new CharacterDetailsViewModel(this.Data)));

            // Last, remove this page
            Navigation.RemovePage(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ToolbarItems.Count > 0)
                ToolbarItems.Clear();
            InitializeComponent();
            this.Data = _viewModel.Character;
            BindingContext = _viewModel;
        }
    }
}