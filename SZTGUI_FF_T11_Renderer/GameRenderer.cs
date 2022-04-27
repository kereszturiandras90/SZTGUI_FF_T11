using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using SZTGUI_FF_T11_CORE.Models;
using SZTGUI_FF_T11_CORE.Settings;

namespace SZTGUI_FF_T11_Renderer
{
    public class GameRenderer : IGameRenderer
    {
        IGameModel gameModel;
        IGameSettings gameSettings;

        Typeface font = new Typeface("Comic Sans");
        Point textStartPoint = new Point(480, 13);
        

        Pen magentaPen = new Pen(Brushes.Magenta, 2);

        public GameRenderer(IGameModel gameModel, IGameSettings gameSettings)
        {
            this.gameModel = gameModel;
            this.gameSettings = gameSettings;
        }

        public void Display(DrawingContext ctx)
        {
            DrawBackground(ctx);
            DrawPlayer(ctx);
            DrawBalls(ctx);
            DrawTime(ctx);
        }

        private void DrawBackground(DrawingContext ctx)
        {
            ctx.DrawRectangle(Brushes.Gray,
                null,
                new Rect(0, 0, gameModel.GameAreaWidth, gameModel.GameAreaHeight));
        }

        private void DrawTime(DrawingContext ctx)
        {
            var text = new FormattedText(
                gameModel.TimeCounter.ToString(),
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                font, 13, Brushes.Black, 1.25);

            ctx.DrawText(text, textStartPoint);
        }

        private void DrawPlayer(DrawingContext ctx)
        {
            Point playerPoint = new Point(gameModel.Player.X, gameModel.Player.Y);
            ctx.DrawEllipse(Brushes.Magenta, magentaPen, playerPoint, gameSettings.BallSize, gameSettings.BallSize);

            var number = new FormattedText(
                gameModel.Player.Value.ToString(),
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                font, gameSettings.BallSize, Brushes.Black, 1.25);

            ctx.DrawText(number, playerPoint);
        }

        

        private void DrawBalls(DrawingContext ctx)
        {

            foreach (Ball ball in gameModel.Balls)
            {
                Point ballPoint = new Point(ball.X, ball.Y);

               // SolidColorBrush brushes = Brushes.White;

                switch (ball.Color)
                {
                    case ConsoleColor.DarkBlue:
                         SolidColorBrush brushes = Brushes.DarkBlue;
                        Pen pen = new Pen(brushes, 2);
                        ctx.DrawEllipse(brushes, pen, ballPoint, gameSettings.BallSize, gameSettings.BallSize);
                        break;
                    case ConsoleColor.Green:
                         brushes = Brushes.Green;
                        Pen pen2 = new Pen(brushes, 2);
                        ctx.DrawEllipse(brushes, pen2, ballPoint, gameSettings.BallSize, gameSettings.BallSize);
                        break;
                    case ConsoleColor.Yellow:
                        brushes = Brushes.Yellow;
                        Pen pen3 = new Pen(brushes, 2);
                        ctx.DrawEllipse(brushes, pen3, ballPoint, gameSettings.BallSize, gameSettings.BallSize);
                        break;
                    case ConsoleColor.Red:
                        brushes = Brushes.Red;
                        Pen pen4 = new Pen(brushes, 2);
                        ctx.DrawEllipse(brushes, pen4, ballPoint, gameSettings.BallSize, gameSettings.BallSize);
                        break;
                    default:
                        break;
                }

              
                

                var number = new FormattedText(
                ball.Value.ToString(),
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                font, gameSettings.BallSize, Brushes.Black, 1.25);

                ctx.DrawText(number, ballPoint);

            }

        }
    }
}
