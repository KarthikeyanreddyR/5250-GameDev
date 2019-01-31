using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GameDev.Models;
using GameDev.Views.Characters;
using GameDev.Views.Monsters;
using GameDev.Views.Items;
using GameDev.Views.Score;

namespace GameDev.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {

        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();


        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemTypes.Home, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {

            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemTypes.Home:
                        MenuPages.Add(id, new NavigationPage(new HomePage()));
                        break;
                    case (int)MenuItemTypes.Aliens:
                        MenuPages.Add(id, new NavigationPage(new CharactersPage()));
                        break;
                    case (int)MenuItemTypes.Agents:
                        MenuPages.Add(id, new NavigationPage(new MonstersPage()));
                        break;
                    case (int)MenuItemTypes.Items:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemTypes.Score:
                        MenuPages.Add(id, new NavigationPage(new ScoresPage()));
                        break;
                    case (int)MenuItemTypes.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                }

            }


            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                {
                    await Task.Delay(100);
                }

                IsPresented = false;
            }
        }
    }
}