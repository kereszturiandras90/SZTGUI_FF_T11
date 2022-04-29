namespace SZTGUI_FF_T11_CORE.Settings
{
    public interface IGameSettings
    {
        #region Player

        double PlayerInitXPosition { get; set; }

        double PlayerInitYPosition { get; set; }

        double PlayerSize { get; set; }

        #endregion

        #region Ball

        int BallCount { get; set; }

        double BallSize { get; set; }

        double BallSpeed { get; set; }

        #endregion

        #region General

         string BackgroudPath { get; set; }

        double GameAreaDefaultWidth { get; set; }

        double GameAreaDefaultHeight { get; set; }

        string Difficulty { get; }

        #endregion
    }
}
