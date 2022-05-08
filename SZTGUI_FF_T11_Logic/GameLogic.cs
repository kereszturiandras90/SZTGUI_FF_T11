using System;
using SZTGUI_FF_T11_CORE.Models;
using SZTGUI_FF_T11_CORE.Settings;

namespace SZTGUI_FF_T11_Logic
{
    public class GameLogic : IGameLogic
    {
        IGameModel model;
        IGameSettings setting;
        ILoadAndSaveLogic loadAndSaveLogic;

        public GameLogic(IGameModel model, IGameSettings setting)
        {
            this.model = model;
            this.setting = setting;
        }

        public void Save()
        {
            loadAndSaveLogic = new LoadAndSaveLogic();
            loadAndSaveLogic.SaveGameModel(this.model as GameModel, "test.xml");
            loadAndSaveLogic.SaveGameSettings(this.setting as GameSettings, "test.xml.set");
        }

        public void Load()
        {
            loadAndSaveLogic = new LoadAndSaveLogic();
            loadAndSaveLogic.LoadGameModel("test.xml");
            loadAndSaveLogic.LoadGameSettings("test.xml.set");
           // loadAndSaveLogic.LoadGameResults("test.xml")

        }
        public void BallBallCollision()
        {
            foreach (Ball ball1 in model.Balls)
            {
                foreach (Ball ball2 in model.Balls)
                {
                    if (ball1 != ball2 && (Math.Sqrt((Math.Pow(ball1.X - ball2.X, 2) + Math.Pow(ball1.Y - ball2.Y, 2))) < setting.BallSize))
                    {

                        //Compute angles
                        var Alpha1 = Math.Atan2(ball2.Y - ball1.Y, ball2.X - ball1.X);
                        var Beta1 = Math.Atan2(ball1.DY, ball1.DX);
                        var Gamma1 = Alpha1 - Beta1;

                        var normV1 = Math.Sqrt((Math.Pow(ball1.DX + ball1.DY, 2)));
                        var normV2 = Math.Sqrt((Math.Pow(ball2.DX + ball2.DY, 2)));

                        var u11 = normV1 * Math.Sin(Gamma1);
                        var u12 = normV1 * Math.Cos(Gamma1);

                        var Alpha2 = Math.Atan2(ball1.Y - ball2.Y, ball1.X - ball2.X);
                        var Beta2 = Math.Atan2(ball2.DY, ball2.DX);
                        var Gamma2 = Alpha2 - Beta2;

                        var u21 = normV2 * Math.Sin(Gamma2);
                        var u22 = normV2 * Math.Cos(Gamma2);

                        var v12 = -u21;
                        var v21 = -u12;

                        ball1.DX = u11 * (-Math.Sin(Alpha1) + Math.Cos(Alpha1));
                        ball1.DY = u12 * (Math.Cos(Alpha1) + Math.Sin(Alpha1));

                        ball2.DX = u22 * (-Math.Sin(Alpha2) + Math.Cos(Alpha2));
                        ball2.DY = -u21 * (Math.Cos(Alpha2) + Math.Sin(Alpha2));
                    }
                }
            }
            
        //Alpha1 = Math.Atan2((2) - X1(2), X2(1) - X1(1));
           // Beta1 = atan2(u1(2), u1(1));
          //  Gamma1 = Beta1 - Alpha1;
        }

        public void BAllWallCollision()
        {
            foreach  (Ball ball in model.Balls)
            {
                if (ball.DY > 0 && (ball.Y + setting.BallSize >= setting.GameAreaDefaultHeight))
                {
                    ball.DY = -(ball.DY);
                }
                else if (ball.DY < 0 && (ball.Y -setting.BallSize <= 0))
                {
                    ball.DY = -(ball.DY);
                }
            }
        }

        public bool HasCollision(Player player, Ball ball)
        {
            if (Math.Sqrt((Math.Pow(player.X - ball.X, 2) + Math.Pow(player.Y - ball.Y, 2)) ) < setting.BallSize*2)
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
                ball.X = ball.X - setting.BallSize*ball.DX;
                ball.Y = ball.Y + setting.BallSize * ball.DY;
            }
           
        }

        public void MovePlayer(char direction)
        {
            switch (direction)
            {
                
                case 'U':
                     var newPos = model.Player.Y - setting.BallSize;
                    if ((newPos < setting.GameAreaDefaultHeight)  && (newPos > setting.BallSize))
                    {
                        model.Player.Y = model.Player.Y - setting.BallSize;
                        
                    }
                    break;
                case 'D':
                    var newPos2 = model.Player.Y + setting.BallSize;
                    if ((newPos2 < setting.GameAreaDefaultHeight) && (newPos2  > setting.BallSize))
                    {
                        model.Player.Y = model.Player.Y + setting.BallSize;

                    }
                    break;
                case 'L':
                    var newPos3 = model.Player.X - setting.BallSize;
                    if ((newPos3 < setting.GameAreaDefaultWidth) && (newPos3  > setting.BallSize))
                    {
                        model.Player.X = model.Player.X - setting.BallSize;

                    }
                    break;
                case 'R':
                    var newPos4 = model.Player.X + setting.BallSize;
                    if ((newPos4 < setting.GameAreaDefaultWidth) && (newPos4  > setting.BallSize))
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
