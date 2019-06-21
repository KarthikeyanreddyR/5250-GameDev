using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GameDev.ViewModels;
using GameDev.Services;

namespace GameDev.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutViewModel viewModel;

        public AboutPage()
        {
            InitializeComponent();
            DateTimeLabel.Text = string.Format("{0:MMMM d, yyyy HH:mm}", DateTime.Now);

            BindingContext = viewModel = AboutViewModel.Instance;

            SettingDataSource.IsToggled = true;
            ClearSqlName.IsVisible = !SettingDataSource.IsToggled;
        }

        private void ToggleDatastoreSwitch_OnToggled(object sender, ToggledEventArgs e)
        {
            // This will change out the DataStore to be the Mock Store if toggled on, or the SQL if off.

            viewModel.SetDataSource(SettingDataSource.IsToggled);
            ClearSqlName.IsVisible = !SettingDataSource.IsToggled;
        }

        private async void ClearDatabase_Command(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Delete", "Are you sure you want to DELETE all data and start over?", "Yes", "No");
            if (answer)
            {
                // Call to the SQL DataStore and have it clear the tables.
                SQLDataStore.Instance.InitializeDatabaseNewTables();
            }
        }
    }
}