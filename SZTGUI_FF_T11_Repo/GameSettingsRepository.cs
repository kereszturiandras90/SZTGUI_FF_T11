using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SZTGUI_FF_T11_CORE.Settings;

namespace SZTGUI_FF_T11_Repo
{
    public class GameSettingsRepository : Repository<GameSettings>, IGameSettingsRepository
    {
        public override GameSettings Load(string path)
        {
            GameSettings gameSettings = new GameSettings();
            
            XDocument xDoc = XDocument.Load(path);
            
            gameSettings.PlayerInitXPosition = double.Parse(xDoc.Element("GameSettings").Element("PlayerInitXPosition").Value);
            gameSettings.PlayerInitYPosition = double.Parse(xDoc.Element("GameSettings").Element("PlayerInitYPosition").Value);
            gameSettings.PlayerSize = double.Parse(xDoc.Element("GameSettings").Element("PlayerSize").Value);
            gameSettings.BallCount = int.Parse(xDoc.Element("GameSettings").Element("BallCount").Value);
            gameSettings.BallSize = double.Parse(xDoc.Element("GameSettings").Element("BallSize").Value);
            gameSettings.BallSpeed = double.Parse(xDoc.Element("GameSettings").Element("BallSpeed").Value);
            gameSettings.BackgroudPath = xDoc.Element("GameSettings").Element("BackgroudPath").Value;
            gameSettings.GameAreaDefaultWidth = double.Parse(xDoc.Element("GameSettings").Element("GameAreaDefaultWidth").Value);
            gameSettings.GameAreaDefaultHeight = double.Parse(xDoc.Element("GameSettings").Element("GameAreaDefaultHeight").Value);

            return gameSettings;
        }

        public override void Save(GameSettings entity, string path)
        {
            XDocument outDoc = new XDocument(
                new XElement("GameSettings",
                    new XElement("PlayerInitXPosition", entity.PlayerInitXPosition),
                    new XElement("PlayerInitYPosition", entity.PlayerInitYPosition),
                    new XElement("PlayerSize", entity.PlayerSize),
                    new XElement("BallCount", entity.BallCount),
                    new XElement("BallSize", entity.BallSize),
                    new XElement("BallSpeed", entity.BallSpeed),
                    new XElement("BackgroudPath", entity.BackgroudPath),
                    new XElement("GameAreaDefaultWidth", entity.GameAreaDefaultWidth),
                    new XElement("GameAreaDefaultHeight", entity.GameAreaDefaultHeight))
                );

            outDoc.Save(path);
        }
    }
}
