using System;
using SZTGUI_FF_T11_CORE.Models;
using SZTGUI_FF_T11_CORE.Settings;

namespace SZTGUI_FF_T11_Logic
{
    public class GameLogic : IGameLogic
    {
        IGameModel model;
        IGameSettings setting;

        public GameLogic(IGameModel model, IGameSettings setting)
        {
            this.model = model;
            this.setting = setting;
        }

        public void BallBallCollision()
        {
            throw new NotImplementedException();
        }

        public void BAllWallCollision()
        {
            throw new NotImplementedException();
        }

        public bool HasCollision(Player player, Ball ball)
        {
            if (Math.Sqrt((Math.Pow(player.X - ball.X, 2) + Math.Pow(player.Y - ball.Y, 2)) ) < 2*setting.BallSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MoveBall()
        {
            foreach (Ball ball in model.Balls)
            {
                ball.X = ball.X - setting.BallSize;
            }
           
        }

        public void MovePlayer(char direction)
        {
            switch (direction)
            {
                case 'U':
                    if ((model.Player.Y - setting.BallSize <= setting.GameAreaDefaultHeight)  && (model.Player.Y - setting.BallSize >= 0))
                    {
                        model.Player.Y = model.Player.Y - setting.BallSize;
                        
                    }
                    break;
                case 'D':
                    if ((model.Player.Y + setting.BallSize <= setting.GameAreaDefaultHeight) && (model.Player.Y + setting.BallSize >= 0))
                    {
                        model.Player.Y = model.Player.Y + setting.BallSize;

                    }
                    break;
                case 'L':
                    if ((model.Player.X - setting.BallSize <= setting.GameAreaDefaultWidth) && (model.Player.X - setting.BallSize >= 0))
                    {
                        model.Player.X = model.Player.X - setting.BallSize;

                    }
                    break;
                case 'R':
                    if ((model.Player.X + setting.BallSize <= setting.GameAreaDefaultWidth) && (model.Player.X -+setting.BallSize >= 0))
                    {
                        model.Player.X = model.Player.X + setting.BallSize;

                    }
                    break;
                default:
                    break;
            }
        }

        public void PlayerBallCollision(Player player, Ball ball)
        {
            if (player.Value >= ball.Value && !ball.IsDamaging )
            {
                player.Value = player.Value + ball.Value;
            }
            else if (player.Value < ball.Value && ball.IsHealing)
            {
                player.Value = player.Value + ball.Value;
            } else if(player.Value >= ball.Value && ball.IsDamaging) 
            {
                player.Value = player.Value - ball.Value;
            }
            else
            {
                // end of game;
            }
        }

    }
}
