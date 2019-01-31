using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using GameDev.Models;
using Xamarin.Forms;
using System.Linq;

using GameDev.Views.Characters;

namespace GameDev.ViewModels
{
    public class CharacterViewModel : BaseViewModel
    {

        #region Singleton
        // Create one instance of view model
        private static CharacterViewModel _instance;

        public static CharacterViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CharacterViewModel();
                return _instance;
            }
        }
        #endregion Singleton

        public ObservableCollection<Character> Dataset { set; get; }

        public Command LoadCharactersCommand { get; set; }

        private bool _needsRefresh;

        public CharacterViewModel()
        {
            Dataset = new ObservableCollection<Character>();
            LoadCharactersCommand = new Command(async () => await ExecuteLoadItemsCommand());

            #region Messages
            MessagingCenter.Subscribe<CharacterDeletePage, Character>(this, "DeleteCharacter", async (obj, data) =>
            {
                await DeleteCharacter(data);
            });

            MessagingCenter.Subscribe<CharacterNewPage, Character>(this, "AddCharacter", async (obj, data) =>
            {
                await AddCharacter(data);
            });

            MessagingCenter.Subscribe<CharacterEditPage, Character>(this, "EditCharacter", async (obj, data) =>
            {
                await UpdateCharacter(data);
            });

            #endregion Messages
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
                var characters = await DataStore.GetAllAsync_Character(true);
                foreach (var charcter in characters)
                {
                    Dataset.Add(charcter);
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

        #endregion Refresh

        private async Task<bool> DeleteCharacter(Character data)
        {
            var myData = Dataset.FirstOrDefault(arg => arg.Id == data.Id);
            Dataset.Remove(myData);
            return await DataStore.DeleteAsync_Character(data);
        }

        private async Task<bool> AddCharacter(Character data)
        {
            Dataset.Add(data);
            return await DataStore.AddAsync_Character(data);
        }

        private async Task<bool> UpdateCharacter(Character data)
        {
            var myData = Dataset.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
                return await Task.FromResult(false);

            myData.Update(data);
            SetNeedsRefresh(true);
            return await DataStore.UpdateAsync_Character(data);
        }
    }
}
