using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GameDev.Models;

namespace GameDev.Views.Items
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemNewPage : ContentPage
	{
        public Item Data { get; set; }

        public ItemNewPage ()
		{
			InitializeComponent ();

            this.Data = new Item();

            BindingContext = this;
            //Need to make the SelectedItem a string, so it can select the correct item.
            LocationPicker.SelectedItem = this.Data.Location.ToString();
            AttributePicker.SelectedItem = this.Data.Attribute.ToString();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", this.Data);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}