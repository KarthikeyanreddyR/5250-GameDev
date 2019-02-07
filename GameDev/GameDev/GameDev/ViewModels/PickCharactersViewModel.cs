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
    public class MultiSelectData
    {
        public Character Data { get; set; }

        public bool IsSelected { get; set; }

        public MultiSelectData( Character character, bool isSelected)
        {
            Data = character;
            IsSelected = isSelected;
        }
    }
    public class PickCharactersViewModel : BaseViewModel
    {
        #region Singleton
        // Create one instance of view model
        private static PickCharactersViewModel _instance;

        public static PickCharactersViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PickCharactersViewModel();
                return _instance;
            }
        }
        #endregion Singleton

        public ObservableCollection<MultiSelectData> DataSet { get; set; }

        public Command LoadCommand { get; set; }

        private bool _needsRefresh;

        public PickCharactersViewModel()
        {
            DataSet = new ObservableCollection<MultiSelectData>();
            LoadCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                DataSet.Clear();
                var characters = await DataStore.GetAllAsync_Character(true);
                foreach (var character in characters)
                {
                    DataSet.Add(new MultiSelectData(character, false));
                }
                //SetNeedsRefresh(false);
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
