using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using GameDev.Models;
using Xamarin.Forms;

namespace GameDev.ViewModels
{
    public class MultiSelectData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Character Data { get; set; }

        private bool _IsSelected;
        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                _IsSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        private string _Image;
        public string Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                OnPropertyChanged("Image");
            }
        }

        public MultiSelectData(Character character, bool isSelected)
        {
            Data = character;
            IsSelected = isSelected;
            Image = IsSelected ? "checkbox_checked_icon.png" : "checkbox_unchecked_icon.png";
        }

        private void OnPropertyChanged(string props)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(props));
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
