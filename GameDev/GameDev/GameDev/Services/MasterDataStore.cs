using GameDev.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev.Services
{
    public static class MasterDataStore
    {
        // Holds which datastore to use.

        private static DataStoreEnum _dataStoreEnum = DataStoreEnum.Mock;

        // Returns which datastore to use
        public static DataStoreEnum GetDataStoreMockFlag()
        {
            return _dataStoreEnum;
        }

        // Switches the datastore values.
        // Loads the databases...
        public static void ToggleDataStore(DataStoreEnum dataStoreEnum)
        {
            switch (dataStoreEnum)
            {
                case DataStoreEnum.Mock:
                    _dataStoreEnum = DataStoreEnum.Mock;
                    break;
                case DataStoreEnum.SQL:
                default:
                    _dataStoreEnum = DataStoreEnum.SQL;
                    break;
            }

            // Change DataStore
            ModifyDataStoreOnViewModels();

            // Load the Data
            ForceDataRestoreAll();
        }

        private static void ModifyDataStoreOnViewModels()
        {
            ItemsViewModel.Instance.SetDataStore(_dataStoreEnum);
            CharacterViewModel.Instance.SetDataStore(_dataStoreEnum);
            // Implement Monster
            // Implement Score
        }

        // Force all modes to load data...
        public static void ForceDataRestoreAll()
        {
            ItemsViewModel.Instance.ForceDataRefresh();
            CharacterViewModel.Instance.ForceDataRefresh();
            // Implement Monster
            // Implement Score
        }
    }
}
