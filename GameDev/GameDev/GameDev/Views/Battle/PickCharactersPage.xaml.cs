using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDev.Models;
using GameDev.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameDev.Views.Battle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickCharactersPage : ContentPage
    {
        private PickCharactersViewModel _viewModel;

        private BattleEngine _battleEngine;

        public PickCharactersPage(BattleEngine battleEngine)
        {
            InitializeComponent();
            BindingContext = _viewModel = PickCharactersViewModel.Instance;
            _battleEngine = battleEngine;
            if (_viewModel.DataSet.Count == 0)
                _viewModel.LoadCommand.Execute(null);
        }

        private void OnCharacterTapped(object sender, ItemTappedEventArgs e)
        {
            if (!(e.Item is MultiSelectData multiSelectData))
                return;
            var index = _viewModel.DataSet.IndexOf(multiSelectData);
            _viewModel.DataSet[index].IsSelected = _viewModel.DataSet[index].IsSelected ? false : true;
            _viewModel.DataSet[index].Image = _viewModel.DataSet[index].Image.Equals("checkbox_unchecked_icon.png")
                ? "checkbox_checked_icon.png" : "checkbox_unchecked_icon.png";

            CharactersListView.SelectedItem = null;
            ValidateSelectedData();
        }

        private async void NextClicked(object sender, EventArgs e)
        {
            var _list = new List<Character>();
            var dataset = _viewModel.DataSet.Where(s => s.IsSelected == true).ToList();
            foreach(MultiSelectData i in dataset)
            {
                _list.Add(i.Data);
            }

            _battleEngine.CharacterList = _list;

            await Navigation.PushAsync(new PickMonstersPage(_battleEngine));
        }

        private void ValidateSelectedData()
        {
            var dataset = _viewModel.DataSet.Where(s => s.IsSelected == true).ToList();
            if (dataset.Count > 0 && dataset.Count < 7)
                NextButton.IsEnabled = true;
            else
                NextButton.IsEnabled = false;
        }

    }
}