using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SZTGUI_FF_T11_CORE.Models;

namespace SZTGUI_FF_T11_Repo
{
    public class GameModelRepository : Repository<GameModel>, IGameModelRepository
    {
        public override GameModel Load(string path)
        {
            GameModel gameModel = new GameModel();
            Ball ball;

            XDocument xDoc = XDocument.Load(path);

            gameModel.Player.X = double.Parse(xDoc.Element("GameModel").Element("Player").Element("X").Value);
            gameModel.Player.Y = double.Parse(xDoc.Element("GameModel").Element("Player").Element("Y").Value);
            gameModel.Player.Angle = double.Parse(xDoc.Element("GameModel").Element("Player").Element("Angle").Value);
            gameModel.Player.Value = int.Parse(xDoc.Element("GameModel").Element("Player").Element("Value").Value);
            gameModel.Player.Angle = double.Parse(xDoc.Element("GameModel").Element("Player").Element("Angle").Value);
            gameModel.Player.Color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), xDoc.Element("GameModel").Element("Player").Element("Color").Value, true);
            gameModel.Player.AngleInRad = double.Parse(xDoc.Element("GameModel").Element("Player").Element("AngleInRad").Value);
            gameModel.Player.DX = double.Parse(xDoc.Element("GameModel").Element("Player").Element("DX").Value);
            gameModel.Player.DY = double.Parse(xDoc.Element("GameModel").Element("Player").Element("DY").Value);

            var balls = xDoc.Element("GameModel").Element("Balls").Elements("Ball").Select(x => new { X = x.Element("X").Value,
                                                                                 Y = x.Element("Y").Value,
                                                                                 Angle = x.Element("Angle").Value,
                                                                                 Value = x.Element("Value").Value,
                                                                                 Color = x.Element("Color").Value,
                                                                                 AngleInRad = x.Element("AngleInRad").Value,
                                                                                 DX = x.Element("DX").Value,
                                                                                 DY = x.Element("DY").Value
                                                                                });
            
            foreach (var aBall in balls)
            {
                ball = new Ball();
                ball.X = double.Parse(aBall.X);
                ball.Y = double.Parse(aBall.Y);
                ball.Angle = double.Parse(aBall.Angle);
                ball.Value = int.Parse(aBall.Value);
                ball.Color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), aBall.Color, true);
                ball.AngleInRad = double.Parse(aBall.AngleInRad);
                ball.DX = double.Parse(aBall.DX);
                ball.DY = double.Parse(aBall.DY);

                gameModel.Balls.Add(ball);
            }

            gameModel.TimeCounter = int.Parse(xDoc.Element("GameModel").Element("TimeCounter").Value);
            gameModel.GameAreaWidth = double.Parse(xDoc.Element("GameModel").Element("GameAreaWidth").Value);
            gameModel.GameAreaHeight = double.Parse(xDoc.Element("GameModel").Element("GameAreaHeight").Value);

            return gameModel;
        }

        public override void Save(GameModel entity, string path)
        {
            XDocument outDoc = new XDocument(
                new XElement("GameModel",
                    new XElement("Player",
                        new XElement("X", entity.Player.X),
                        new XElement("Y", entity.Player.Y),
                        new XElement("Angle", entity.Player.Angle),
                        new XElement("Value", entity.Player.Value),
                        new XElement("Color", entity.Player.Color),
                        new XElement("AngleInRad", entity.Player.AngleInRad),
                        new XElement("DX", entity.Player.DX),
                        new XElement("DY", entity.Player.DY)),
                    new XElement("Balls"),
                    new XElement("TimeCounter", entity.TimeCounter),
                    new XElement("GameAreaWidth", entity.GameAreaWidth),
                    new XElement("GameAreaHeight", entity.GameAreaHeight))
                );

            foreach (var ball in entity.Balls)
            {
                XElement node = new XElement("Ball",
                    new XElement("X", ball.X),
                    new XElement("Y", ball.Y),
                    new XElement("Angle", ball.Angle),
                    new XElement("Value", ball.Value),
                    new XElement("Color", ball.Color),
                    new XElement("AngleInRad", ball.AngleInRad),
                    new XElement("DX", ball.DX),
                    new XElement("DY", ball.DY)
                    );
                outDoc.Element("GameModel").Element("Balls").Add(node);
            }

            outDoc.Save(path);
        }
    }
}
