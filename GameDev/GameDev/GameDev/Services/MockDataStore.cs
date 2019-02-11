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
            _itemsDataSet.Add(new Item("MOCK - Noisy Cricket", "Small, portable gun which make huge boom!!!", null, AttributeEnum.Attack, ItemLocationEnum.OffHand, 10, 10));
            _itemsDataSet.Add(new Item("MOCK - De-Atomizer", "Heavy machinery which can reduce opponents to atoms.", null, AttributeEnum.Attack, ItemLocationEnum.PrimaryHand, 10, 10));
            _itemsDataSet.Add(new Item("MOCK - Anti-Gravity Shoes", "Defy gravity and take your fight in air", null, AttributeEnum.Defense, ItemLocationEnum.Feet, 10, 10));
            _itemsDataSet.Add(new Item("MOCK - Shrink Ray", "Minimize damage you take from powerful attacks", null, AttributeEnum.Defense, ItemLocationEnum.RightFinger, 10, 10));

            // Mock data for Characters
            _charactersDataSet.Add(new Character(
                "3 Eyed", "Predicts future attacks with extra eye.", GameDevResources.Aliens_Char_1,
                1, 10, true, 10, 10, 10, 20, 20,
                "head", "feet", "necklace", "primaryHand", "offHand", "rightFinger", "leftFinger"));

            _charactersDataSet.Add(new Character(
                "Happy Alien", "Smiling can be dangerous!!", GameDevResources.Aliens_Char_3,
                1, 10, true, 10, 10, 10, 20, 20,
                "head", "feet", "necklace", "primaryHand", "offHand", "rightFinger", "leftFinger"));

            _charactersDataSet.Add(new Character(
                "Pumpkin Ghost", "Ariel attacks are deadly!!!", GameDevResources.Aliens_Char_6,
                1, 10, true, 10, 10, 10, 20, 20,
                "head", "feet", "necklace", "primaryHand", "offHand", "rightFinger", "leftFinger"));

            _charactersDataSet.Add(new Character(
                "Mixed Horns", "Simple creature with most defense.", GameDevResources.Aliens_Char_7,
                1, 10, true, 10, 10, 10, 20, 20,
                "head", "feet", "necklace", "primaryHand", "offHand", "rightFinger", "leftFinger"));

            _charactersDataSet.Add(new Character(
                "Guitar Ghost", "Attacks with sound of red guitar.", GameDevResources.Aliens_Char_8,
                1, 10, true, 10, 10, 10, 20, 20,
                "head", "feet", "necklace", "primaryHand", "offHand", "rightFinger", "leftFinger"));
        }

        #region Items

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