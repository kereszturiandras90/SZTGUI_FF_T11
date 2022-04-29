﻿namespace SZTGUI_FF_T11_CORE.Settings
{
    public class GameSettings : IGameSettings
    {
        public GameSettings()
        {
            PlayerInitXPosition = 0;
            PlayerInitYPosition = GameAreaDefaultHeight;
            PlayerSize = 10;
            BallCount = 5;
            BallSize = 10;
            BallSpeed = 1;
            BackgroudPath = "Images/bg.png";
            GameAreaDefaultWidth = 640;
            GameAreaDefaultHeight = 480;
            Difficulty = "Easy";
        }

        #region Player

        public double PlayerInitXPosition { get; set; }

        public double PlayerInitYPosition { get; set; }

        public double PlayerSize { get; set; }



        #endregion

        #region Ball

        public int BallCount { get; set; }

        public double BallSize { get; set; }

        public double BallSpeed { get; set; }

        #endregion

        #region General

        public string BackgroudPath { get; set; }

        public double GameAreaDefaultWidth { get; set; }

        public double GameAreaDefaultHeight { get; set; }


        public string Difficulty { get; set; }

        #endregion
    }
}
