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

        private List<Item> itemsDataSet = new List<Item>();

        public MockDataStore()
        {
            CreateMockItemsDataSet();           
        }

        #region Items

        private void CreateMockItemsDataSet()
        {
            // string name, string description, string imageUri, int range, int damage, AttributeEnum attribute, ItemLocationEnum location, int value
            itemsDataSet.Add(new Item("Noisy Cricket", "Small, portable gun which make huge boom!!!", null, 0, 10, AttributeEnum.Attack, ItemLocationEnum.OffHand, 10));
            itemsDataSet.Add(new Item("De-Atomizer", "Heavy machinery which can reduce opponents to atoms.", null, 0, 10, AttributeEnum.Attack, ItemLocationEnum.PrimaryHand, 10));
            itemsDataSet.Add(new Item("Anti-Gravity Shoes", "Defy gravity and take your fight in air", null, 0, 10, AttributeEnum.Defense, ItemLocationEnum.Feet, 10));
            itemsDataSet.Add(new Item("Shrink Ray", "Minimize damage you take from powerful attacks", null, 0, 10, AttributeEnum.Defense, ItemLocationEnum.RightFinger, 10));
        }

        public async Task<bool> InsertUpdateAsync_Item(Item data)
        {
            // Check to see if the item exist
            var oldData = await GetAsync_Item(data.Id);
            if (oldData == null)
            {
                itemsDataSet.Add(data);
                return true;
            }

            // Compare it, if different update in the DB
            var UpdateResult = await UpdateAsync_Item(data);
            if (UpdateResult)
            {
                await AddAsync_Item(data);
                return true;
            }

            return false;
        }

        public async Task<bool> AddAsync_Item(Item data)
        {
            itemsDataSet.Add(data);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Item(Item data)
        {
            var myData = itemsDataSet.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Item(Item data)
        {
            var myData = itemsDataSet.FirstOrDefault(arg => arg.Id == data.Id);
            itemsDataSet.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetAsync_Item(string id)
        {
            return await Task.FromResult(itemsDataSet.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetAllAsync_Item(bool forceRefresh = false)
        {
            return await Task.FromResult(itemsDataSet);
        }

        #endregion Items
    }
}