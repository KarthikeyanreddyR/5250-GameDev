using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDev.Models;

namespace GameDev.Services
{
    public class MockDataStore : IDataStore
    {
        #region Singleton
        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static MockDataStore _instance;

        public static MockDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MockDataStore();
                }
                return _instance;
            }
        }

        #endregion Singleton

        private List<Item> _itemsDataSet = new List<Item>();
        private List<Character> _charactersDataSet = new List<Character>();

        public MockDataStore()
        {
            CreateMockItemsDataSet();
        }

        private void CreateMockItemsDataSet()
        {
            // Mock data for Items
            _itemsDataSet.Add(new Item("MOCK - Noisy Cricket", "Small, portable gun which make huge boom!!!", null, 0, 10, AttributeEnum.Attack, ItemLocationEnum.OffHand, 10));
            _itemsDataSet.Add(new Item("MOCK - De-Atomizer", "Heavy machinery which can reduce opponents to atoms.", null, 0, 10, AttributeEnum.Attack, ItemLocationEnum.PrimaryHand, 10));
            _itemsDataSet.Add(new Item("MOCK - Anti-Gravity Shoes", "Defy gravity and take your fight in air", null, 0, 10, AttributeEnum.Defense, ItemLocationEnum.Feet, 10));
            _itemsDataSet.Add(new Item("MOCK - Shrink Ray", "Minimize damage you take from powerful attacks", null, 0, 10, AttributeEnum.Defense, ItemLocationEnum.RightFinger, 10));

            // Mock data for Characters
            _charactersDataSet.Add(new Character("MOCK - 3 Eyed", "Predicts future attacks with extra eye.", GameDevResources.Aliens_Char_1, 100));
            _charactersDataSet.Add(new Character("MOCK - Sea Alien", "Small and quick to attack.", GameDevResources.Aliens_Char_2, 150));
            _charactersDataSet.Add(new Character("MOCK - Happy Alien", "Smiling can be dangerous!!", GameDevResources.Aliens_Char_3, 130));
            _charactersDataSet.Add(new Character("MOCK - 8 Arms", "Multiple arms makes it hard to attack.", GameDevResources.Aliens_Char_4, 180));
            _charactersDataSet.Add(new Character("MOCK - Grass Hopper", "Multiple arms makes it hard to attack.", GameDevResources.Aliens_Char_5, 40));
            _charactersDataSet.Add(new Character("MOCK - Pumpkin Ghost", "Ariel attacks are deadly!!!", GameDevResources.Aliens_Char_6, 500));
            _charactersDataSet.Add(new Character("MOCK - Mixed Horns", "Simple creature with most defense.", GameDevResources.Aliens_Char_7, 100));
            _charactersDataSet.Add(new Character("MOCK - Guitar Ghost", "Attacks with sound of red guitar.", GameDevResources.Aliens_Char_8, 490));
        }

        #region Items

        public async Task<bool> InsertUpdateAsync_Item(Item data)
        {
            // Check to see if the item exist
            var oldData = await GetAsync_Item(data.Id);
            if (oldData == null)
            {
                _itemsDataSet.Add(data);
                return await Task.FromResult(true);
            }

            // Compare it, if different update in the DB
            var UpdateResult = await UpdateAsync_Item(data);
            if (UpdateResult)
            {
                await AddAsync_Item(data);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        public async Task<bool> AddAsync_Item(Item data)
        {
            _itemsDataSet.Add(data);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Item(Item data)
        {
            var myData = _itemsDataSet.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return await Task.FromResult(false);
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Item(Item data)
        {
            var myData = _itemsDataSet.FirstOrDefault(arg => arg.Id == data.Id);
            _itemsDataSet.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetAsync_Item(string id)
        {
            return await Task.FromResult(_itemsDataSet.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetAllAsync_Item(bool forceRefresh = false)
        {
            return await Task.FromResult(_itemsDataSet);
        }
        #endregion Items

        #region Characters

        public async Task<bool> InsertUpdateAsync_Character(Character data)
        {
            // Check to see if the item exist
            var oldData = await GetAsync_Character(data.Id);
            if (oldData == null)
            {
                _charactersDataSet.Add(data);
                return await Task.FromResult(true);
            }

            // Compare it, if different update in the DB
            var UpdateResult = await UpdateAsync_Character(data);
            if (UpdateResult)
            {
                await AddAsync_Character(data);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        public async Task<bool> AddAsync_Character(Character data)
        {
            _charactersDataSet.Add(data);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Character(Character data)
        {
            var myData = _charactersDataSet.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return await Task.FromResult(false);
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Character(Character data)
        {
            var myData = _charactersDataSet.FirstOrDefault(arg => arg.Id == data.Id);
            _charactersDataSet.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Character> GetAsync_Character(string id)
        {
            return await Task.FromResult(_charactersDataSet.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Character>> GetAllAsync_Character(bool forceRefresh = false)
        {
            return await Task.FromResult(_charactersDataSet);
        }

        #endregion Characters
    }
}