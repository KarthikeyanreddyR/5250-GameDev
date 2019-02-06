﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GameDev.Models;

namespace GameDev.Views.Characters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterNewPage : ContentPage
    {
        public Character Data { get; set; }

        public CharacterNewPage()
        {
            InitializeComponent();

            this.Data = new Character();

            BindingContext = this;
        }

        async void SaveCharacter(object sender, EventArgs e)
        {
            // If the image in teh data box is empty, use the default one..
            if (string.IsNullOrEmpty(Data.ImageURI))
            {
                this.Data.ImageURI = Character.DefaultImageUrl;
            }
            MessagingCenter.Send(this, "AddCharacter", this.Data);
            await Navigation.PopAsync();
        }

        async void CancelCharacter(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ToolbarItems.Count > 0)
                ToolbarItems.Clear();
            InitializeComponent();
            BindingContext = this;
        }
    }
}