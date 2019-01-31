﻿using System;
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
	public partial class CharacterDeletePage : ContentPage
	{
        private CharacterDetailsViewModel _viewModel;

        public Character Data { get; set; }

		public CharacterDeletePage (CharacterDetailsViewModel viewModel)
		{
			InitializeComponent ();

            this.Data = viewModel.Character;

            BindingContext = _viewModel = viewModel;
		}

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteCharacter", this.Data);

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