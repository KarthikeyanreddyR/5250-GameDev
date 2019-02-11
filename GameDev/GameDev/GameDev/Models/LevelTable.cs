using System.Collections.Generic;

namespace GameDev.Models
{
    class LevelTable
    {
        #region Singleton
        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static LevelTable _instance;

        public static LevelTable Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LevelTable();
                }
                return _instance;
            }
        }

        #endregion Singleton

        // Level Max
        public const int MaxLevel = 20;

        // List of all the levels
        public List<LevelDetails> LevelDetailsList { get; set; }

        // Data for the Levels
        public LevelTable()
        {
            ClearAndLoadDatTable();
        }
        public void ClearAndLoadDatTable()
        {
            LevelDetailsList = new List<LevelDetails>();
            LoadLevelData();
        }

        // Level data set, 0 - 21
        public void LoadLevelData()
        {
            // Init the level list, going to index into it like an array, so making 0 be a null value.  That way Level can be Array Index.
            LevelDetailsList.Add(new LevelDetails(0, 0, 0, 0, 0));

            // Character Level Chart...
            LevelDetailsList.Add(new LevelDetails(1, 0, 1, 1, 1));
            LevelDetailsList.Add(new LevelDetails(2, 300, 1, 2, 1));
            LevelDetailsList.Add(new LevelDetails(3, 900, 2, 3, 1));
            LevelDetailsList.Add(new LevelDetails(4, 2700, 2, 3, 1));
            LevelDetailsList.Add(new LevelDetails(5, 6500, 2, 4, 2));
            LevelDetailsList.Add(new LevelDetails(6, 14000, 3, 4, 2));
            LevelDetailsList.Add(new LevelDetails(7, 23000, 3, 5, 2));
            LevelDetailsList.Add(new LevelDetails(8, 34000, 3, 5, 2));
            LevelDetailsList.Add(new LevelDetails(9, 48000, 3, 5, 2));
            LevelDetailsList.Add(new LevelDetails(10, 64000, 4, 6, 3));
            LevelDetailsList.Add(new LevelDetails(11, 85000, 4, 6, 3));
            LevelDetailsList.Add(new LevelDetails(12, 100000, 4, 6, 3));
            LevelDetailsList.Add(new LevelDetails(13, 120000, 4, 7, 3));
            LevelDetailsList.Add(new LevelDetails(14, 140000, 5, 7, 3));
            LevelDetailsList.Add(new LevelDetails(15, 165000, 5, 7, 4));
            LevelDetailsList.Add(new LevelDetails(16, 195000, 5, 8, 4));
            LevelDetailsList.Add(new LevelDetails(17, 225000, 5, 8, 4));
            LevelDetailsList.Add(new LevelDetails(18, 265000, 6, 8, 4));
            LevelDetailsList.Add(new LevelDetails(19, 305000, 7, 9, 4));
            LevelDetailsList.Add(new LevelDetails(20, 355000, 8, 10, 5));

            // Level 21, is for Monster Experience points...
            LevelDetailsList.Add(new LevelDetails(21, 400000, 0, 0, 0));
        }
    }

    // Level details for each level
    class LevelDetails
    {
        public int Level;
        public int Experience;
        public int Attack;
        public int Defense;
        public int Speed;

        // Create a new level based on values passed in
        public LevelDetails(int level, int experience, int attack, int defense, int speed)
        {
            Level = level;
            Experience = experience;
            Attack = attack;
            Defense = defense;
            Speed = speed;
        }
    }
}
