using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GameDev.ViewModels;
using GameDev.Models;

namespace GameDev.Views.Items
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemEditPage : ContentPage
    {
        private ItemDetailViewModel _viewModel;

        public Item Data { get; set; }

        public ItemEditPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            this.Data = viewModel.Item;
            BindingContext = _viewModel = viewModel;

            //Need to make the SelectedItem a string, so it can select the correct item.
            LocationPicker.SelectedItem = this.Data.Location.ToString();
            AttributePicker.SelectedItem = this.Data.Attribute.ToString();
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            // If the image in teh data box is empty, use the default one..
            if (string.IsNullOrEmpty(Data.ImageURI))
            {
                this.Data.ImageURI = Item.DefaultImageUrl;
            }

            MessagingCenter.Send(this, "EditItem", this.Data);

            // removing the old ItemDetails page, 2 up counting this page
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

            // Add a new items details page, with the new Item data on it
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(this.Data)));

            // Last, remove this page
            Navigation.RemovePage(this);
        }
    }
}