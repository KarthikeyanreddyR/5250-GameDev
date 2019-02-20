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
        private List<Monster> _monstersDataSet = new List<Monster>();

        public MockDataStore()
        {
            CreateMockItemsDataSet();
        }

        private void CreateMockItemsDataSet()
        {
            // Mock data for Items
            _itemsDataSet.Add(new Item("Antidote", "desc", GameDevResources.item_1, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("BB Gun", "desc", GameDevResources.item_2, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Clone Gun", "desc", GameDevResources.item_3, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Coil Gun", "desc", GameDevResources.item_4, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Death Ray", "desc", GameDevResources.item_5, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Elixir of Life", "desc", GameDevResources.item_6, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Gun", "desc", GameDevResources.item_7, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Healt Potion", "desc", GameDevResources.item_8, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Ice Skates", "desc", GameDevResources.item_9, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("King Crown", "desc", GameDevResources.item_10, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Machine Gun", "desc", GameDevResources.item_11, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Poison", "desc", GameDevResources.item_12, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Potion", "desc", GameDevResources.item_13, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Pretty Crown", "desc", GameDevResources.item_14, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Ray Gun", "desc", GameDevResources.item_15, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Rocket Boots", "desc", GameDevResources.item_16, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Rocket Luncher", "desc", GameDevResources.item_17, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Roller Ski", "desc", GameDevResources.item_18, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Shotgun", "desc", GameDevResources.item_19, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));
            _itemsDataSet.Add(new Item("Sniper Rifle", "desc", GameDevResources.item_20, AttributeEnum.Unknown, ItemLocationEnum.Unknown, 0, 0));

            // Mock data for Characters
            _charactersDataSet.Add(new Character("Airman", "desc", GameDevResources.char_1));
            _charactersDataSet.Add(new Character("Captain", "desc", GameDevResources.char_2));
            _charactersDataSet.Add(new Character("Colonel", "desc", GameDevResources.char_3));
            _charactersDataSet.Add(new Character("Combat medic", "desc", GameDevResources.char_4));
            _charactersDataSet.Add(new Character("Corporal", "desc", GameDevResources.char_5));
            _charactersDataSet.Add(new Character("Drill Sergeant", "desc", GameDevResources.char_6));
            _charactersDataSet.Add(new Character("General", "desc", GameDevResources.char_7));
            _charactersDataSet.Add(new Character("Paratrooper", "desc", GameDevResources.char_8));
            _charactersDataSet.Add(new Character("Park Rnager", "desc", GameDevResources.char_9));
            _charactersDataSet.Add(new Character("Soldier", "desc", GameDevResources.char_10));

            // Mock data for Monsters
            _monstersDataSet.Add(new Monster("Ghoul", "desc", GameDevResources.mons_1));
            _monstersDataSet.Add(new Monster("Green Dragon", "desc", GameDevResources.mons_2));
            _monstersDataSet.Add(new Monster("Stone Dragon", "desc", GameDevResources.mons_3));
            _monstersDataSet.Add(new Monster("Hell Demon - Male", "desc", GameDevResources.mons_4));
            _monstersDataSet.Add(new Monster("Hell Demon - Female", "desc", GameDevResources.mons_5));
            _monstersDataSet.Add(new Monster("Hydra", "desc", GameDevResources.mons_6));
            _monstersDataSet.Add(new Monster("Medusa", "desc", GameDevResources.mons_7));
            _monstersDataSet.Add(new Monster("Sea Demon", "desc", GameDevResources.mons_8));
            _monstersDataSet.Add(new Monster("Sea Lion", "desc", GameDevResources.mons_9));
            _monstersDataSet.Add(new Monster("Yama", "desc", GameDevResources.mons_10));
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