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
            App.Database.InsertAsync(new Item("Noisy Cricket", "Small, portable gun which make huge boom!!!", null, 0, 10, AttributeEnum.Attack, ItemLocationEnum.OffHand, 10));
            App.Database.InsertAsync(new Item("De-Atomizer", "Heavy machinery which can reduce opponents to atoms.", null, 0, 10, AttributeEnum.Attack, ItemLocationEnum.PrimaryHand, 10));
            App.Database.InsertAsync(new Item("Anti-Gravity Shoes", "Defy gravity and take your fight in air", null, 0, 10, AttributeEnum.Defense, ItemLocationEnum.Feet, 10));
            App.Database.InsertAsync(new Item("Shrink Ray", "Minimize damage you take from powerful attacks", null, 0, 10, AttributeEnum.Defense, ItemLocationEnum.RightFinger, 10));

            // Mock data for Characters
            App.Database.InsertAsync(new Character("3 Eyed", "Predicts future attacks with extra eye.", GameDevResources.Aliens_Char_1, 100));
            App.Database.InsertAsync(new Character("Sea Alien", "Small and quick to attack.", GameDevResources.Aliens_Char_2, 150));
            App.Database.InsertAsync(new Character("Happy Alien", "Smiling can be dangerous!!", GameDevResources.Aliens_Char_3, 130));
            App.Database.InsertAsync(new Character("8 Arms", "Multiple arms makes it hard to attack.", GameDevResources.Aliens_Char_4, 180));
            App.Database.InsertAsync(new Character("Grass Hopper", "Multiple arms makes it hard to attack.", GameDevResources.Aliens_Char_5, 40));
            App.Database.InsertAsync(new Character("Pumpkin Ghost", "Ariel attacks are deadly!!!", GameDevResources.Aliens_Char_6, 500));
            App.Database.InsertAsync(new Character("Mixed Horns", "Simple creature with most defense.", GameDevResources.Aliens_Char_7, 100));
            App.Database.InsertAsync(new Character("Guitar Ghost", "Attacks with sound of red guitar.", GameDevResources.Aliens_Char_8, 490));
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

