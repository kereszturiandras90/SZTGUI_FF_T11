using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZTGUI_FF_T11_CORE.Models;
using SZTGUI_FF_T11_CORE.Settings;

namespace SZTGUI_FF_T11_Logic
{
    public interface ILoadAndSaveLogic
    {
        public IList<GameResult> LoadGameResults();

        public GameModel LoadGameModel(string path);

        public GameSettings LoadGameSettings(string path);

        public void SaveGameResult(GameResult gameResult);

        public void SaveGameModel(GameModel gameModel, string path);

        public void SaveGameSettings(GameSettings gameSettings, string path);

    }
}
