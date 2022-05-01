using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SZTGUI_FF_T11_CORE.Models;
using SZTGUI_FF_T11_CORE.Settings;
//using static SZTGUI_FF_T11_CORE.Settings.GameSettings;

namespace SZTGUI_FF_T11_Demo.VM
{
   

    class NewGameVM : ViewModelBase
    {
        Player player;
        GameSettings gameSettings;

        public Player Player
        {
            get { return player; }
            set { Set(ref player, value); }
        }

        public GameSettings GameSettings
        {
            get { return gameSettings; }
            set { Set(ref gameSettings, value); }
        }

        public Array Difficulty
        {
            get { return Enum.GetValues(typeof(GameSettings.DifficultyType)); }
        }

        public ICommand NewGame { get; private set; }

        public NewGameVM()
        {
            player = new Player(0,0,0);
            gameSettings = new GameSettings();

            NewGame = new RelayCommand(() => StartNewGame(player, gameSettings));

            if(IsInDesignMode)
            {
                player.Name = "VM Elek";
                gameSettings.Difficulty = "Medium";
            }
        }

        private void StartNewGame(Player player, GameSettings gameSettings)
        {
            MainWindow newMainWin = new MainWindow();
            newMainWin.Show();
            //throw new NotImplementedException();
        }
    }
}
