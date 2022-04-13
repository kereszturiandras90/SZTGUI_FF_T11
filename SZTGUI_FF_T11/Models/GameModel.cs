using FlappyBirdDemo.Core.Settings;
using System.Collections.Generic;

namespace FlappyBirdDemo.Core.Models
{
    public class GameModel : IGameModel
    {
        public Bird Bird { get; private set; }

        public List<Tube> Tubes { get; private set; }

        public int Errors { get; set; }

        public double GameAreaWidth { get; set; }
        public double GameAreaHeight { get; set; }

        public GameModel(double gameAreaWidth, double gameAreaHeight, IGameSettings gameSettings)
        {
            GameAreaWidth = gameAreaWidth;
            GameAreaHeight = gameAreaHeight;
            Tubes = new List<Tube>();

            InitDefaultValues(gameSettings, gameAreaWidth, gameAreaHeight);
        }

        private void InitDefaultValues(IGameSettings gameSettings, double gameAreaWidth, double gameAreaHeight)
        {
            Bird = new Bird(gameSettings.BirdInitXPosition, gameAreaHeight / 2, gameSettings.BirdInitXVelocity);

            var tubeDistance = GameAreaWidth / gameSettings.TubeCount;

            for (int i = 0; i < gameSettings.TubeCount; i++)
            {
                Tubes.Add(new Tube(i * tubeDistance, GameAreaHeight));
            }
        }

        // TODO: create other ctor for load data from saved game
    }
}
