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

        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<ItemNewPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                await AddItem(newItem);
            });

            MessagingCenter.Subscribe<ItemEditPage, Item>(this, "EditItem", async (obj, item) =>
            {
                var newItem = item as Item;
                await EditItem(newItem);
            });

            MessagingCenter.Subscribe<ItemDeletePage, Item>(this, "DeleteItem", async (obj, item) =>
            {
                var newItem = item as Item;
                await DeleteItem(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetAllAsync_Item(true);
                foreach (var item in items)
                {
                    Items.Add(item);
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

        private async Task<bool> AddItem(Item newItem)
        {
            Items.Add(newItem);
            return await DataStore.AddAsync_Item(newItem);
        }

        public async Task<bool> EditItem(Item editItem)
        {
            // Find the Item, then update it
            var myData = Items.FirstOrDefault(arg => arg.Id == editItem.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(editItem);
            await DataStore.UpdateAsync_Item(myData);

            //_needsRefresh = true;

            return true;
        }

        private async Task<bool> DeleteItem(Item deleteItem)
        {
            Items.Remove(deleteItem);
            return await DataStore.DeleteAsync_Item(deleteItem);
        }
    }
}