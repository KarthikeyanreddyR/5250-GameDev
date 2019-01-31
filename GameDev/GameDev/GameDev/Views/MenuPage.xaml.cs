using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GameDev.Models;

namespace GameDev.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<MenuItems> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<MenuItems>
            {
                new MenuItems {Id = MenuItemTypes.Home, Heading="Home"},
                new MenuItems {Id = MenuItemTypes.Characters, Heading="Characters"},
                new MenuItems {Id = MenuItemTypes.Monsters, Heading="Monsters"},
                new MenuItems {Id = MenuItemTypes.Items, Heading="Items"},
                new MenuItems {Id = MenuItemTypes.Scores, Heading="Scores"},
                new MenuItems {Id = MenuItemTypes.About, Heading="About"}
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((MenuItems)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}