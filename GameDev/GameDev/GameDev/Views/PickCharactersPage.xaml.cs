using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDev.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameDev.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PickCharactersPage : ContentPage
    {
        private PickCharactersViewModel _viewModel;

		public PickCharactersPage ()
		{
			InitializeComponent ();
            BindingContext = _viewModel = PickCharactersViewModel.Instance;
            if(_viewModel.DataSet.Count == 0)
            _viewModel.LoadCommand.Execute(null);
        }

        private void OnCharacterSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is MultiSelectData multiSelectData))
                return;

            Console.WriteLine(multiSelectData);
            multiSelectData.IsSelected = true;
        }

        private void NextClicked(object sender, EventArgs e)
        {
            Console.WriteLine(_viewModel);
        }
    }
}