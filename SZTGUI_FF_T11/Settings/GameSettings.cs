namespace SZTGUI_FF_T11_CORE.Settings
{
    public class GameSettings : IGameSettings
    {
        #region Player

        public double PlayerInitXPosition => 0;

        public double PlayerInitYPosition => GameAreaDefaultHeight;

        public double PlayerSize => 10;



        #endregion

        #region Ball

        public int BallCount => 5;

        public double BallSize => 10;

        public double BallSpeed => 1;

        #endregion

        #region General

        public string BackgroudPath => "Images/bg.png";

        public double GameAreaDefaultWidth => 640;

        public double GameAreaDefaultHeight => 480;

        #endregion
    }
}
