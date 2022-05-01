using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SZTGUI_FF_T11_CORE.Models;

namespace SZTGUI_FF_T11_Repo
{
    public class GameResultRepository : Repository<GameResult>, IGameResultRepository
    {
        public GameResultRepository()
        {
        }

        public override GameResult Load(string path)
        {
            throw new NotImplementedException();
        }

        public List<GameResult> LoadResults(string path)
        {
            List<GameResult> gameResults = new List<GameResult>();
            GameResult gameResult;

            XDocument xDoc = XDocument.Load(path);

            var results = xDoc.Elements("Results").Elements("Result").Select(x => new {
                                                                    PlayerName = x.Element("PlayerName").Value,
                                                                    Score = x.Element("Score").Value,
                                                                    DateTime = x.Element("DateTime").Value
                                                                  });

            foreach (var result in results)
            {
                gameResult = new GameResult();
                gameResult.PlayerName = result.PlayerName;
                gameResult.Score = int.Parse(result.Score);
                gameResult.DateTime = DateTime.ParseExact(result.DateTime, "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                                       System.Globalization.CultureInfo.InvariantCulture);

                gameResults.Add(gameResult);
            }

            return gameResults;
        }

        public override void Save(GameResult entity, string path)
        {
            XDocument outDoc;
            
            try
            {
                outDoc = XDocument.Load(path);
            }
            catch (FileNotFoundException)
            {
                outDoc = new XDocument(
                    new XElement("Results")
               );
            }

            outDoc.Element("Results").Add(
               new XElement("Result",
                   new XElement("PlayerName", entity.PlayerName),
                   new XElement("Score", entity.Score),
                   new XElement("DateTime", entity.DateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")))
               );

            outDoc.Save(path);
        }
    }
}
