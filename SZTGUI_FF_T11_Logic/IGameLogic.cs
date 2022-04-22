using System;
using SZTGUI_FF_T11_CORE.Models;

namespace SZTGUI_FF_T11_Logic
{
    public interface IGameLogic
    {
        void MovePlayer(char direction);

        void MoveBall();

        void PlayerBallCollision(Player player, Ball ball);

        void BallBallCollision();

        void BAllWallCollision();

        bool HasCollision(Player player, Ball ball);
    }
}
