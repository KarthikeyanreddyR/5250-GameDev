﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GameDev.Models;
using GameDev.Views.Items;
using GameDev.ViewModels;

namespace GameDev.Views.Items
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = ItemsViewModel.Instance;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Item item))
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemNewPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = null;
            InitializeComponent();

            if (viewModel.Dataset.Count == 0 || viewModel.NeedsRefresh())
                viewModel.LoadItemsCommand.Execute(null);

            BindingContext = viewModel;
        }
    }
}