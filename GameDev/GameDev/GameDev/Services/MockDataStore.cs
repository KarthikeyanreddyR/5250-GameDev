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
        private List<Character> _charctersDataSet = new List<Character>();

        public MockDataStore()
        {
            CreateMockItemsDataSet();           
        }
        
        private void CreateMockItemsDataSet()
        {
            // Mock data for Items
            _itemsDataSet.Add(new Item("Noisy Cricket", "Small, portable gun which make huge boom!!!", null, 0, 10, AttributeEnum.Attack, ItemLocationEnum.OffHand, 10));
            _itemsDataSet.Add(new Item("De-Atomizer", "Heavy machinery which can reduce opponents to atoms.", null, 0, 10, AttributeEnum.Attack, ItemLocationEnum.PrimaryHand, 10));
            _itemsDataSet.Add(new Item("Anti-Gravity Shoes", "Defy gravity and take your fight in air", null, 0, 10, AttributeEnum.Defense, ItemLocationEnum.Feet, 10));
            _itemsDataSet.Add(new Item("Shrink Ray", "Minimize damage you take from powerful attacks", null, 0, 10, AttributeEnum.Defense, ItemLocationEnum.RightFinger, 10));

            // Mock data for Characters
            _charctersDataSet.Add(new Character("3 Eyed", "Predicts future attacks with extra eye.", "http://gdurl.com/RxRK", 100));
            _charctersDataSet.Add(new Character("Sea Alien", "Small and quick to attack.", "http://gdurl.com/dgT5", 150));
            _charctersDataSet.Add(new Character("Happy Alien", "Smiling can be dangerous!!", "http://gdurl.com/NvcO", 130));
            _charctersDataSet.Add(new Character("8 Arms", "Multiple arms makes it hard to attack.", "http://gdurl.com/fxM0", 180));
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
                _charctersDataSet.Add(data);
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
            _charctersDataSet.Add(data);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Character(Character data)
        {
            var myData = _charctersDataSet.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return await Task.FromResult(false);
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Character(Character data)
        {
            var myData = _charctersDataSet.FirstOrDefault(arg => arg.Id == data.Id);
            _charctersDataSet.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Character> GetAsync_Character(string id)
        {
            return await Task.FromResult(_charctersDataSet.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Character>> GetAllAsync_Character(bool forceRefresh = false)
        {
            return await Task.FromResult(_charctersDataSet);
        }

        #endregion Characters
    }
}