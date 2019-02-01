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
	public partial class ItemDeletePage : ContentPage
	{
        public ItemDetailViewModel _viewModel { get; set; }

        public Item Data { set; get; }

		public ItemDeletePage (ItemDetailViewModel viewModel)
		{
			InitializeComponent ();
            this.Data = viewModel.Item;
            BindingContext = _viewModel = viewModel;
		}

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteItem", this.Data);

            // Remove Item Details Page manualy
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

            await Navigation.PopAsync();
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}