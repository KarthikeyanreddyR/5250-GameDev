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
            App.Database.DropTableAsync<Monster>().Wait();
        }


        // Create the Database Tables
        private void CreateTables()
        {
            App.Database.CreateTableAsync<Item>().Wait();
            App.Database.CreateTableAsync<Character>().Wait();
            App.Database.CreateTableAsync<Monster>().Wait();
        }

        private async void InitializeSeedData()
        {
            // Data for Items
            await AddAsync_Item(new Item("Antidote", "Cures sickness. Improves Health",
                 GameDevResources.item_1, AttributeEnum.MaxHealth, ItemLocationEnum.Necklass, 20, 10));
            await AddAsync_Item(new Item("BB Gun", "Handheld air gun in which small round projectiles are propelled by compressed air.",
                GameDevResources.item_2, AttributeEnum.Attack, ItemLocationEnum.OffHand, 10, 10));
            await AddAsync_Item(new Item("Clone Gun", "A gun that shoots cloning magic and creates a duplicate of whatever it hits. It's also a useful object for cloning and spawning.",
                GameDevResources.item_3, AttributeEnum.Defense, ItemLocationEnum.OffHand, 10, 10));
            await AddAsync_Item(new Item("Coil Gun", "A handheld weapon that uses electromagnets to accelerate a projectile to high velocity. It fires a bullets.",
                GameDevResources.item_4, AttributeEnum.Attack, ItemLocationEnum.PrimaryHand, 10, 10));
            await AddAsync_Item(new Item("Death Ray", "A handheld weapon that can kill anything in one shot.",
                GameDevResources.item_5, AttributeEnum.Attack, ItemLocationEnum.PrimaryHand, 30, 50));
            await AddAsync_Item(new Item("Elixir of Life", "Can be used to revive dead. Living creatures will become invincible",
                GameDevResources.item_6, AttributeEnum.Defense, ItemLocationEnum.LeftFinger, 30, 50));
            await AddAsync_Item(new Item("Gun", "A weapon that shoots bullets. It deals light damage",
                GameDevResources.item_7, AttributeEnum.Attack, ItemLocationEnum.OffHand, 5, 5));
            await AddAsync_Item(new Item("Health Potion", "Improves Heath of living.",
                GameDevResources.item_8, AttributeEnum.MaxHealth, ItemLocationEnum.Necklass, 10, 10));
            await AddAsync_Item(new Item("Ice Skates", "Boots with blades attached to the bottom,",
                GameDevResources.item_9, AttributeEnum.Speed, ItemLocationEnum.Feet, 20, 20));
            await AddAsync_Item(new Item("King Crown", "A type of headwear.",
                GameDevResources.item_10, AttributeEnum.Defense, ItemLocationEnum.Head, 10, 10));
            await AddAsync_Item(new Item("Machine Gun", "A projectile weapon. Shoots far faster than a simple gun.",
                GameDevResources.item_11, AttributeEnum.Attack, ItemLocationEnum.PrimaryHand, 20, 20));
            await AddAsync_Item(new Item("Poison", "Degrades Health.",
                GameDevResources.item_12, AttributeEnum.MaxHealth, ItemLocationEnum.RightFinger, -10, 10));
            await AddAsync_Item(new Item("Potion", "Used against Poison. Improves Health.",
                GameDevResources.item_13, AttributeEnum.MaxHealth, ItemLocationEnum.RightFinger, 10, 10));
            await AddAsync_Item(new Item("Pretty Crown", "A type of headwear",
                GameDevResources.item_14, AttributeEnum.Defense, ItemLocationEnum.Head, 10, 10));
            await AddAsync_Item(new Item("Ray Gun", "An extremely powerful gun. It shoots out red magic, and almost always kills with one shot.",
                GameDevResources.item_15, AttributeEnum.Attack, ItemLocationEnum.PrimaryHand, 50, 50));
            await AddAsync_Item(new Item("Rocket Boots", "Can be worn on the feet to allow the wearer to fly.",
                GameDevResources.item_16, AttributeEnum.Speed, ItemLocationEnum.Feet, 10, 10));
            await AddAsync_Item(new Item("Rocket Luncher", "A handheld projectile weapon that shoots rockets.",
                GameDevResources.item_17, AttributeEnum.Attack, ItemLocationEnum.PrimaryHand, 30, 30));
            await AddAsync_Item(new Item("Roller Ski", "Skis which improves speed.",
                GameDevResources.item_18, AttributeEnum.Speed, ItemLocationEnum.Feet, 20, 20));
            await AddAsync_Item(new Item("Shotgun", "A handheld projectile weapon that fires shotgun blast. The range is limited, but it is powerful at close range.",
                GameDevResources.item_19, AttributeEnum.Attack, ItemLocationEnum.PrimaryHand, 10, 10));
            await AddAsync_Item(new Item("Sniper Rifle", "A long-range weapon that fires regular bullets.",
                GameDevResources.item_20, AttributeEnum.Attack, ItemLocationEnum.PrimaryHand, 10, 10));

            // Data for Characters
            await AddAsync_Character(new Character("Airman", "Flies military planes.", GameDevResources.char_1));
            await AddAsync_Character(new Character("Captain", "A commissioned officer rank historically corresponding to command of a company of soldiers.", GameDevResources.char_2));
            await AddAsync_Character(new Character("Colonel", "A military rank of a senior commissioned officer.", GameDevResources.char_3));
            await AddAsync_Character(new Character("Combat medic", "The only medical personnel on the battlefield.", GameDevResources.char_4));
            await AddAsync_Character(new Character("Corporal", "A military rank, corresponds to either commanding or being second-in-command of a section or squad of soldiers.", GameDevResources.char_5));
            await AddAsync_Character(new Character("Drill Sergeant", "A noncommissioned officer who trains soldiers in basic military skills.", GameDevResources.char_6));
            await AddAsync_Character(new Character("General", "An officer of high military rank.", GameDevResources.char_7));
            await AddAsync_Character(new Character("Paratrooper", "Are soldiers trained in parachuting. They spawn wearing a parachute.", GameDevResources.char_8));
            await AddAsync_Character(new Character("Park Ranger", "Works in the wilderness to preserve the natural habitat.", GameDevResources.char_9));
            await AddAsync_Character(new Character("Soldier", "NPC in green military uniform equipped with a Machine Gun.", GameDevResources.char_10));

            // Data for Monsters
            await AddAsync_Monster(new Monster("Ghoul", "Is grey, humanoid monster that slightly resembles a zombie.", GameDevResources.mons_1));
            await AddAsync_Monster(new Monster("Green Dragon", "Dragon", GameDevResources.mons_2));
            await AddAsync_Monster(new Monster("Stone Dragon", "Dragon made of stone. Can spit stone from mouth.", GameDevResources.mons_3));
            await AddAsync_Monster(new Monster("Hell Demon - Male", "Demons from hell. Can spit fire from mouth.", GameDevResources.mons_4));
            await AddAsync_Monster(new Monster("Hell Demon - Female", "Demons from hell. Can spit fire from mouth", GameDevResources.mons_5));
            await AddAsync_Monster(new Monster("Hydra", "A mythical three-headed serpent. It can wear up to three hats due to having three heads.", GameDevResources.mons_6));
            await AddAsync_Monster(new Monster("Medusa", "A monster from Greek mythology, said to being able to turn people to stone, after just looking them in the eyes.", GameDevResources.mons_7));
            await AddAsync_Monster(new Monster("Sea Demon", "A sea monster which lives deep in sea.", GameDevResources.mons_8));
            await AddAsync_Monster(new Monster("Sea Lion", "Monster with Lion head from sea.", GameDevResources.mons_9));
            await AddAsync_Monster(new Monster("Yama", "Is the ox-headed Indian god of death. He is aggressive, though very weak and easily die to most creatures.", GameDevResources.mons_10));

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
            if (_result == 1)
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

        #region Monsters

        public Task<bool> AddAsync_Monster(Monster data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync_Monster(Monster data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync_Monster(Monster data)
        {
            throw new NotImplementedException();
        }

        public Task<Monster> GetAsync_Monster(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Monster>> GetAllAsync_Monster(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        #endregion Monsters

        #region Score

        public Task<bool> AddAsync_Score(Score data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync_Score(Score data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync_Score(Score data)
        {
            throw new NotImplementedException();
        }

        public Task<Score> GetAsync_Score(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Score>> GetAllAsync_Score(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        #endregion Score
    }
}

