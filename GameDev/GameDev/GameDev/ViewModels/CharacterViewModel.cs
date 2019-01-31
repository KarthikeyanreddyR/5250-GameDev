using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using GameDev.Models;
using Xamarin.Forms;

namespace GameDev.ViewModels
{
    public class CharacterViewModel : BaseViewModel
    {

        #region Singleton
        // Create one instance of view model
        private static CharacterViewModel _instance;

        public static CharacterViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CharacterViewModel();
                return _instance;
            }
        }
        #endregion Singleton

        public ObservableCollection<Character> Dataset { set; get; }

        public Command LoadItemsCommand { get; set; }

        public CharacterViewModel()
        {
            Dataset = new ObservableCollection<Character>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Dataset.Clear();
                var characters = await DataStore.GetAllAsync_Character(true);
                foreach (var charcter in characters)
                {
                    Dataset.Add(charcter);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
