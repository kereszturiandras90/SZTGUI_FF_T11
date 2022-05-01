using CommonServiceLocator;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZTGUI_FF_T11_CORE.Models;
using SZTGUI_FF_T11_Logic;

namespace SZTGUI_FF_T11_Demo.VM
{
    class GameResultsVM: ViewModelBase
    {
        ILoadAndSaveLogic logic;
        

        public ObservableCollection<GameResult> Results { get; private set; }

        public GameResultsVM(ILoadAndSaveLogic logic)
        {
            this.logic = logic;

            var listResults = this.logic.LoadGameResults();
            var orderedListResults = listResults.OrderByDescending(x => x.Score).ToList();

            Results = new ObservableCollection<GameResult>(orderedListResults);
                        
                        
            if (IsInDesignMode)
            {
                GameResult gameResult1 = new GameResult { PlayerName = "VM Jani", Score = 12, DateTime = DateTime.Now };
                GameResult gameResult2 = new GameResult { PlayerName = "VM Juli", Score = 38, DateTime = DateTime.Now.AddHours(-1) };

                Results.Add(gameResult1);
                Results.Add(gameResult2);
            }
        }

        public GameResultsVM()
           // : this(IsInDesignModeStatic ? null :ServiceLocator.Current.GetInstance<IGameResultLogic>())
        {
            
            LoadAndSaveLogic logic = new LoadAndSaveLogic();

            var listResults = logic.LoadGameResults();
            var orderedListResults = listResults.OrderByDescending(x => x.Score).ToList();

            Results = new ObservableCollection<GameResult>(orderedListResults);
            
        }

    }
}
