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
            DateTimeLabel.Text = String.Format("{0:MMMM d, yyyy HH:mm}", DateTime.Now);

            BindingContext = this.viewModel;

            SettingDataSource.IsToggled = true;
        }

        private void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
            // This will change out the DataStore to be the Mock Store if toggled on, or the SQL if off.

            SetDataSource(SettingDataSource.IsToggled);
        }

        private void SetDataSource(bool isMock)
        {
            var set = DataStoreEnum.SQL;

            if (isMock)
            {
                set = DataStoreEnum.Mock;
            }

            MasterDataStore.ToggleDataStore(set);
        }


        private async void ClearDatabase_Command(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Delete", "Sure you want to Delete All Data, and start over?", "Yes", "No");
            if (answer)
            {
                // Call to the SQL DataStore and have it clear the tables.
                SQLDataStore.Instance.InitializeDatabaseNewTables();
            }
        }
    }
}