using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using GameDev.Models;
using GameDev.Services;

namespace GameDev.ViewModels
{
    public enum DataStoreEnum { Unknown = 0, SQL = 1, Mock = 2 }

    public class BaseViewModel : INotifyPropertyChanged
    {
        private IDataStore DataStoreMock => DependencyService.Get<IDataStore>() ?? MockDataStore.Instance;
        private IDataStore DataStoreSQL => DependencyService.Get<IDataStore>() ?? SQLDataStore.Instance;

        public IDataStore DataStore;

        public BaseViewModel()
        {
            SetDataStore(DataStoreEnum.Mock);
        }

        public void SetDataStore(DataStoreEnum data)
        {
            switch (data)
            {
                case DataStoreEnum.Mock:
                    DataStore = DataStoreMock;
                    break;
                default:
                    DataStore = DataStoreSQL;
                    break;
            }
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged
    }
}
