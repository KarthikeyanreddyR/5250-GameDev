using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using GameDev.Models;
using GameDev.Views.Items;
using System.Linq;

namespace GameDev.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {

        #region Singleton
        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static ItemsViewModel _instance;

        public static ItemsViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ItemsViewModel();
                }
                return _instance;
            }
        }

        #endregion Singleton

        public ObservableCollection<Item> Dataset { get; set; }
        public Command LoadItemsCommand { get; set; }

        private bool _needsRefresh;

        public ItemsViewModel()
        {
            Dataset = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<ItemNewPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                await AddItem(newItem);
            });

            MessagingCenter.Subscribe<ItemEditPage, Item>(this, "EditItem", async (obj, item) =>
            {
                var newItem = item as Item;
                await UpdateItem(newItem);
            });

            MessagingCenter.Subscribe<ItemDeletePage, Item>(this, "DeleteItem", async (obj, item) =>
            {
                var newItem = item as Item;
                await DeleteItem(newItem);
            });
        }

        #region Refresh

        public bool NeedsRefresh()
        {
            if (_needsRefresh)
            {
                _needsRefresh = false;
                return true;
            }

            return false;
        }

        // Sets the need to refresh
        public void SetNeedsRefresh(bool value)
        {
            _needsRefresh = value;
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Dataset.Clear();
                var items = await DataStore.GetAllAsync_Item(true);
                foreach (var item in items)
                {
                    Dataset.Add(item);
                }

                SetNeedsRefresh(false);
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

        /**
         * Force Data Refresh
         *  -- Used  when DataSore is toggled between Mock and SQL. Check <see cref="Services.MasterDataStore"/>
         */
        public void ForceDataRefresh()
        {
            LoadItemsCommand.Execute(null);
        }

        #endregion Refresh

        private async Task<bool> AddItem(Item newItem)
        {
            Dataset.Add(newItem);
            return await DataStore.AddAsync_Item(newItem);
        }

        public async Task<bool> UpdateItem(Item editItem)
        {
            // Find the Item, then update it
            var myData = Dataset.FirstOrDefault(arg => arg.Id == editItem.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(editItem);
            SetNeedsRefresh(true);
            return await DataStore.UpdateAsync_Item(myData);
        }

        private async Task<bool> DeleteItem(Item deleteItem)
        {
            Dataset.Remove(deleteItem);
            return await DataStore.DeleteAsync_Item(deleteItem);
        }

        public async Task<Item> GetItem(string id) {
            return await DataStore.GetAsync_Item(id);
        }
    }
}