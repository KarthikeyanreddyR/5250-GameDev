using GameDev.Models;
using GameDev.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev.Services
{
    public class SQLDataStore : IDataStore
    {

        #region Singleton
        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static SQLDataStore _instance;

        public static SQLDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SQLDataStore();
                }
                return _instance;
            }
        }

        #endregion Singleton

        public SQLDataStore()
        {
            InitializeDatabaseNewTables();
        }

        public void InitializeDatabaseNewTables()
        {
            // Delete the tables
            DeleteTables();

            // make them again
            CreateTables();

            // Populate them
            InitializeSeedData();

            // Tell View Models they need to refresh
            NotifyViewModelsOfDataChange();

        }

        private void DeleteTables()
        {
            App.Database.DropTableAsync<Item>().Wait();
            App.Database.DropTableAsync<Character>().Wait();
        }


        // Create the Database Tables
        private void CreateTables()
        {
            App.Database.CreateTableAsync<Item>().Wait();
            App.Database.CreateTableAsync<Character>().Wait();
        }

        private void InitializeSeedData()
        {
            // Mock data for Items
            App.Database.InsertAsync(new Item("SQL - Noisy Cricket", "Small, portable gun which make huge boom!!!", null, 0, 10, AttributeEnum.Attack, ItemLocationEnum.OffHand, 10));
            App.Database.InsertAsync(new Item("SQL - De-Atomizer", "Heavy machinery which can reduce opponents to atoms.", null, 0, 10, AttributeEnum.Attack, ItemLocationEnum.PrimaryHand, 10));
            App.Database.InsertAsync(new Item("SQL - Anti-Gravity Shoes", "Defy gravity and take your fight in air", null, 0, 10, AttributeEnum.Defense, ItemLocationEnum.Feet, 10));
            App.Database.InsertAsync(new Item("SQL - Shrink Ray", "Minimize damage you take from powerful attacks", null, 0, 10, AttributeEnum.Defense, ItemLocationEnum.RightFinger, 10));

            // Mock data for Characters
            App.Database.InsertAsync(new Character("SQL - 3 Eyed", "Predicts future attacks with extra eye.", "http://gdurl.com/RxRK", 100));
            App.Database.InsertAsync(new Character("SQL - Sea Alien", "Small and quick to attack.", "http://gdurl.com/dgT5", 150));
            App.Database.InsertAsync(new Character("SQL - Happy Alien", "Smiling can be dangerous!!", "http://gdurl.com/NvcO", 130));
            App.Database.InsertAsync(new Character("SQL - 8 Arms", "Multiple arms makes it hard to attack.", "http://gdurl.com/fxM0", 180));
        }

        private void NotifyViewModelsOfDataChange()
        {
            ItemsViewModel.Instance.SetNeedsRefresh(true);
            CharacterViewModel.Instance.SetNeedsRefresh(true);
        }

        #region Items

        public async Task<bool> AddAsync_Item(Item data)
        {
            int _result = await App.Database.InsertAsync(data);
            if(_result == 1)
                return await Task.FromResult(true);
            return await Task.FromResult(false);
        }

        public async Task<bool> UpdateAsync_Item(Item data)
        {
            int _result = await App.Database.UpdateAsync(data);
            if (_result == 1)
                return await Task.FromResult(true);
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync_Item(Item data)
        {
            int _result = await App.Database.DeleteAsync(data);
            if (_result == 1)
                return await Task.FromResult(true);
            return await Task.FromResult(false);
        }

        public async Task<Item> GetAsync_Item(string id)
        {
            return await App.Database.GetAsync<Item>(id);
        }

        public async Task<IEnumerable<Item>> GetAllAsync_Item(bool forceRefresh = false)
        {
            return await App.Database.Table<Item>().ToListAsync();
        }
        #endregion Items

        #region Characters

        public async Task<bool> AddAsync_Character(Character data)
        {
            int _result = await App.Database.InsertAsync(data);
            if (_result == 1)
                return await Task.FromResult(true);
            return await Task.FromResult(false);
        }

        public async Task<bool> UpdateAsync_Character(Character data)
        {
            int _result = await App.Database.UpdateAsync(data);
            if (_result == 1)
                return await Task.FromResult(true);
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync_Character(Character data)
        {
            int _result = await App.Database.DeleteAsync(data);
            if (_result == 1)
                return await Task.FromResult(true);
            return await Task.FromResult(false);
        }

        public async Task<Character> GetAsync_Character(string id)
        {
            return await App.Database.GetAsync<Character>(id);
        }

        public async Task<IEnumerable<Character>> GetAllAsync_Character(bool forceRefresh = false)
        {
            return await App.Database.Table<Character>().ToListAsync();
        }

        #endregion Characters
    }
}

