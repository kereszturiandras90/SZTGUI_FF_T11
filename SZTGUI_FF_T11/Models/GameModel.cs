
using System;
using System.Collections.Generic;
using SZTGUI_FF_T11_CORE.Settings;

namespace SZTGUI_FF_T11_CORE.Models
{
    public class GameModel : IGameModel
    {
        public Player Player { get; private set; }

        public List<Ball> Balls { get; private set; }

        public int TimeCounter { get; set; }

        // játékos pontszáma külön megjelenítve ?

        public double GameAreaWidth { get; set; }
        public double GameAreaHeight { get; set; }

        public GameModel(double gameAreaWidth, double gameAreaHeight, IGameSettings gameSettings, bool NotFirst = false)
        {
            GameAreaWidth = gameAreaWidth;
            GameAreaHeight = gameAreaHeight;
            Balls = new List<Ball>();

            InitDefaultValues(gameSettings, gameAreaWidth, gameAreaHeight);
            if (NotFirst)
            {
                InitBalls(gameSettings, gameAreaWidth, gameAreaHeight);
                

            }
        }

        public void InitBalls(IGameSettings gameSettings, double gameAreaWidth, double gameAreaHeight)
        {
            Balls = new List<Ball>();

            var YInitialPositions = new HashSet<int>();

            int BallGrid = (int)gameAreaHeight / (int)gameSettings.BallSize;

            for (int i = 0; i < gameSettings.BallCount; i++)
            {
                Random rnd = new Random();
                int num = rnd.Next(0, BallGrid); //arrange the ball sttart Y position

                Random rnd2 = new Random();
                int num2 = rnd2.Next(0, 4);
                ConsoleColor cc = new ConsoleColor();

                switch (num2)
                {
                    case 0:
                        cc = ConsoleColor.DarkBlue;
                        break;

                    case 1:
                        cc = ConsoleColor.Green;
                        break;
                    case 2:
                        cc = ConsoleColor.Yellow;
                        break;
                    case 3:
                        cc = ConsoleColor.Red;
                        break;
                    default: break;
                }

                Random rnd3 = new Random();
                int num3 = rnd3.Next(0, 11);



                if (!YInitialPositions.Contains(num))
                {
                    Balls.Add(new Ball(gameAreaWidth, num * gameSettings.BallSize, 5, cc, num3));
                }
                else if (YInitialPositions.Contains(num) && (num * gameSettings.BallSize == gameAreaHeight))
                {
                    Balls.Add(new Ball(gameAreaWidth, 0, 5, cc, num3));
                }
                else
                {
                    Balls.Add(new Ball(gameAreaWidth, num * gameSettings.BallSize + 1, 5, cc, num3));
                }
            }
        }

        private void InitDefaultValues(IGameSettings gameSettings, double gameAreaWidth, double gameAreaHeight)
        {

            Player = new Player(gameSettings.BallSize/2, gameAreaHeight-gameSettings.BallSize/2, 0);

            //Random rnd = new Random();

            // InitBalls(gameSettings, gameAreaWidth, gameAreaHeight);

            Balls = new List<Ball>();

            var YInitialPositions = new HashSet<int>();

            int BallGrid = (int)gameAreaHeight / (int)gameSettings.BallSize;

            for (int i = 0; i < gameSettings.BallCount; i++)
            {
                Random rnd = new Random();
                int num = rnd.Next(0, BallGrid); //arrange the ball sttart Y position

                Random rnd2 = new Random();
                int num2 = rnd2.Next(0, 4);
                ConsoleColor cc = new ConsoleColor();

                switch (num2)
                {
                    case 0:
                        cc = ConsoleColor.DarkBlue;
                        break;

                    case 1:
                        cc = ConsoleColor.Green;
                        break;
                    case 2:
                        cc = ConsoleColor.Yellow;
                        break;
                    case 3:
                        cc = ConsoleColor.Red;
                        break;
                    default: break;
                }

                Random rnd3 = new Random();
                //  int num3 = rnd3.Next(0, 11);
                int num3 = rnd3.Next(Player.Value - 5, Player.Value + 5);



                if (!YInitialPositions.Contains(num))
                {
                    Balls.Add(new Ball(gameAreaWidth, num * gameSettings.BallSize, 5, cc, num3));
                }
                else if (YInitialPositions.Contains(num) && (num * gameSettings.BallSize == gameAreaHeight))
                {
                    Balls.Add(new Ball(gameAreaWidth, 0, 5, cc, num3));
                }
                else
                {
                    Balls.Add(new Ball(gameAreaWidth, num * gameSettings.BallSize + 1, 5, cc, num3));
                }
            }
        }


     /*   private void InitBalls(IGameSettings gameSettings, double gameAreaWidth, double gameAreaHeight)
        {
            Balls = new List<Ball>();

            var YInitialPositions = new HashSet<int>();

            int BallGrid = (int)gameAreaHeight / (int)gameSettings.BallSize;

            for (int i = 0; i < gameSettings.BallCount; i++)
            {
                Random rnd = new Random();
                int num = rnd.Next(0, BallGrid); //arrange the ball sttart Y position

                Random rnd2 = new Random();
                int num2 = rnd2.Next(0, 4);
                ConsoleColor cc = new ConsoleColor();

                switch (num2)
                {
                    case 0:
                        cc = ConsoleColor.DarkBlue;
                        break;

                    case 1:
                        cc = ConsoleColor.Green;
                        break;
                    case 2:
                        cc = ConsoleColor.Yellow;
                        break;
                    case 3:
                        cc = ConsoleColor.Red;
                        break;
                    default: break;
                }

                Random rnd3 = new Random();
                int num3 = rnd3.Next(0, 11);



                if (!YInitialPositions.Contains(num))
                {
                    Balls.Add(new Ball(gameAreaWidth, num * gameSettings.BallSize, 5, cc, num3));
                }
                else if (YInitialPositions.Contains(num) && (num * gameSettings.BallSize == gameAreaHeight))
                {
                    Balls.Add(new Ball(gameAreaWidth, 0, 5, cc, num3));
                }
                else
                {
                    Balls.Add(new Ball(gameAreaWidth, num * gameSettings.BallSize + 1, 5, cc, num3));
                }
            }
        }*/

        // TODO: create other ctor for load data from saved game
    }
}
