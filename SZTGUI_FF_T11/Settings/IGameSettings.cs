﻿namespace FlappyBirdDemo.Core.Settings
{
    public interface IGameSettings
    {
        #region Player

        double PlayerInitXPosition { get; }

        double PlayerInitYPosition { get; }

        double PlayerSize { get; }

        #endregion

        #region Ball

        int BallCount { get; }

        double BallSize { get; }

        double BallSpeed { get; }

        #endregion

        #region General

         string BackgroudPath { get; }

         double BirdSkinHeight { get; }

        double GameAreaDefaultWidth { get; }

        double GameAreaDefaultHeight { get; }

        #endregion
    }
}
