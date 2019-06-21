using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDev.Models;
using GameDev.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GameDev.GameEngines;

namespace GameDev.Views.Battle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickCharactersPage : ContentPage
    {
        private PickCharactersViewModel _viewModel;

        public BattleViewModel BattleViewModel;

        public PickCharactersPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = PickCharactersViewModel.Instance;
            BattleViewModel = BattleViewModel.Instance;
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
            // Add selected characters to battle
            BattleViewModel.BattleEngine.CharacterList.AddRange(_viewModel.GetSelectedCharacters());

            // Start Battle
            BattleViewModel.BattleEngine.StartBattle(false);

            // Start Round
            BattleViewModel.BattleEngine.StartRound();

            await Navigation.PushAsync(new ViewMonstersPage(BattleViewModel));
        }

        private void ValidateSelectedData()
        {
            var dataset = _viewModel.DataSet.Where(s => s.IsSelected == true).ToList();
            if (dataset.Count > 0 && dataset.Count <= GameGlobals.MaximumPartyMembers)
                NextButton.IsEnabled = true;
            else
                NextButton.IsEnabled = false;
        }

    }
}