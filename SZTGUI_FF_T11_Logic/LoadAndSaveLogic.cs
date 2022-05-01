using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZTGUI_FF_T11_CORE.Models;
using SZTGUI_FF_T11_CORE.Settings;
using SZTGUI_FF_T11_Repo;

namespace SZTGUI_FF_T11_Logic
{
    public class LoadAndSaveLogic : ILoadAndSaveLogic
    {
        public GameModel LoadGameModel(string path)
        {
            GameModelRepository gameModelRepository = new GameModelRepository();

            GameModel gameModel = gameModelRepository.Load(path);

            return gameModel;
        }

        public IList<GameResult> LoadGameResults()
        {
            GameResultRepository gameResultRepository = new GameResultRepository();

            #region Test XML creation
            /*
            GameResult gameResult1 = new GameResult { PlayerName = "Jani", Score = 12, DateTime = DateTime.Now };
            GameResult gameResult2 = new GameResult { PlayerName = "Juli", Score = 38, DateTime = DateTime.Now.AddHours(-1) };

            gameResultRepository.Save(gameResult1, "gameresults.xml");
            gameResultRepository.Save(gameResult2, "gameresults.xml");
            */
            #endregion

            List<GameResult> gameResults = gameResultRepository.LoadResults("gameresults.xml");

            return gameResults;
        }

        public GameSettings LoadGameSettings(string path)
        {
            GameSettingsRepository gameSettingsRepository = new GameSettingsRepository();

            GameSettings gameSettings = gameSettingsRepository.Load(path);

            return gameSettings;
        }

        public void SaveGameModel(GameModel gameModel, string path)
        {
            GameModelRepository gameModelRepository = new GameModelRepository();

            gameModelRepository.Save(gameModel, path);
        }

        public void SaveGameResult(GameResult gameResult)
        {
            GameResultRepository gameResultRepository = new GameResultRepository();

            gameResultRepository.Save(gameResult, "gameresults.xml");
        }

        public void SaveGameSettings(GameSettings gameSettings, string path)
        {
            GameSettingsRepository gameSettingsRepository = new GameSettingsRepository();

            gameSettingsRepository.Save(gameSettings, path);
        }
    }
}
