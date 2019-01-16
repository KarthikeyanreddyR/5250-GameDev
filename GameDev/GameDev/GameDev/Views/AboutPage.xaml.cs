using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameDev.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            DateTimeLabel = DateTime.Now;

            BindingContext = this;
        }

        public static DateTime Now { get; }
        public DateTime DateTimeLabel { get; private set; }
    }
}