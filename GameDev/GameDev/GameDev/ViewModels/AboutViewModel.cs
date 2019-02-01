using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace GameDev.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        #region Singleton
        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static AboutViewModel _instance;

        public static AboutViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AboutViewModel();
                }
                return _instance;
            }
        }

        #endregion Singleton

        public AboutViewModel()
        {
        }
    }
}