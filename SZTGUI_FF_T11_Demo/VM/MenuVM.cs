using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SZTGUI_FF_T11_CORE.Models;
using SZTGUI_FF_T11_CORE.Settings;
using SZTGUI_FF_T11_Logic;

namespace SZTGUI_FF_T11_Demo.VM
{
    public class MenuVM : ViewModelBase
    {
        public ICommand NewGame { get; private set; }
        
        public ICommand LoadGame { get; private set; }

        public ICommand SaveGame { get; private set; }

        public ICommand ExitGame { get; private set; }

        public ICommand ResumeGame { get; private set; }

        public ICommand GameResults { get; private set; }
    
    public MenuVM()
        {
            NewGame = new RelayCommand(() => ShowNewGameWindow());

            GameResults = new RelayCommand(() => ShowGameResultsWindow());

            LoadGame = new RelayCommand(() => LoadGameManually());
        }

    public bool ShowNewGameWindow()
        {
            NewGame newGameWin = new NewGame();
            return newGameWin.ShowDialog() ?? false;
        }
    public bool ShowGameResultsWindow()
        {
            GameResults newGameResultsWin = new GameResults();
            return newGameResultsWin.ShowDialog() ?? false;
        }
    public void LoadGameManually()
        {
            string path = "";
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
            }

            LoadAndSaveLogic logic = new LoadAndSaveLogic();

            GameModel gameModel = logic.LoadGameModel(path);
            GameSettings gameSettings = logic.LoadGameSettings(path);

            MainWindow newMainWin = new MainWindow();
            newMainWin.Show();
        }

    }


}
