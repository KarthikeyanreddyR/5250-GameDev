using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameDev.Views.Score
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScoresPage : ContentPage
	{
		public ScoresPage ()
		{
			InitializeComponent ();
            Title = "Scores";
		}
	}
}