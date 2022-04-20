using System;

namespace SZTGUI_FF_T11_Logic
{
    public interface IGameLogic
    {
        void MovePlayer(char direction);

        void MoveBall();

        void PlayerBallCollision();

        void BallBallCollision();

        void BAllWallCollision();
    }
}
