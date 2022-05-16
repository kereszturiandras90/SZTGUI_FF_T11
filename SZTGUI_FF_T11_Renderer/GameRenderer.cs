using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SZTGUI_FF_T11_CORE.Models;
using SZTGUI_FF_T11_CORE.Settings;

namespace SZTGUI_FF_T11_Renderer
{
    public class GameRenderer : IGameRenderer
    {
        IGameModel gameModel;
        IGameSettings gameSettings;

        Typeface font = new Typeface("Comic Sans");
        Point textStartPoint;
        Point difficultyTextStartPoint;
        

        Pen magentaPen = new Pen(Brushes.Magenta, 2);

        Brush backgroundPattern;

        public GameRenderer(IGameModel gameModel, IGameSettings gameSettings)
        {
            this.gameModel = gameModel;
            this.gameSettings = gameSettings;

            textStartPoint = new Point(500, 13);
            difficultyTextStartPoint = new Point(500, 50);

            backgroundPattern = new ImageBrush(new BitmapImage(new System.Uri(gameSettings.BackgroudPath, System.UriKind.Relative)));
        }

        public void Display(DrawingContext ctx, DisplaySettings displaySettings)
        {
            DrawBackground(ctx, displaySettings);
            DrawPlayer(ctx);
            DrawBalls(ctx);
            DrawTime(ctx);
            DrawDifficulty(ctx);
        }

        private void DrawBackground(DrawingContext ctx, DisplaySettings displaySettings)
        {
            /*  ctx.DrawRectangle(Brushes.Gray,
                  null,
                  new Rect(0, 0, gameModel.GameAreaWidth, gameModel.GameAreaHeight));*/
            displaySettings.EnableBackgroundPattern = true;
            ctx.DrawRectangle(
                displaySettings.EnableBackgroundPattern
                    ? backgroundPattern
                    : Brushes.Gray,
                null,
                new Rect(0, 0, gameModel.GameAreaWidth, gameModel.GameAreaHeight));
        }

        private void DrawTime(DrawingContext ctx)
        {
            var text = new FormattedText( gameModel.TimeCounter <= 60 ? 
                $"{gameModel.TimeCounter.ToString()} s"  : $"{gameModel.TimeCounter/60} min {gameModel.TimeCounter % 60} s",
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                font, 18, Brushes.Black, 1.25);


            ctx.DrawText(text, textStartPoint);


        }

        private void DrawDifficulty(DrawingContext ctx)
        {
            var text = new FormattedText($"Difficulty: {gameSettings.Difficulty}",System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, font, 18, Brushes.Black, 1.25);
            ctx.DrawText(text, difficultyTextStartPoint);

        }

        private void DrawPlayer(DrawingContext ctx)
        {

           /* if (5 < gameModel.Player.Value && gameModel.Player.Value <= 10)
            {
                gameSettings.BallSize = gameSettings.BallSize * 1.1;
            }
            else if (10 < gameModel.Player.Value && gameModel.Player.Value <= 15)
            {
                gameSettings.BallSize = gameSettings.BallSize * 1.1;
            }
            else if (15 <= gameModel.Player.Value )
            {
                gameSettings.BallSize = (gameSettings.BallSize / 15) * gameModel.Player.Value;
            }*/
            Point playerPoint = new Point(gameModel.Player.X, gameModel.Player.Y);
            ctx.DrawEllipse(Brushes.Magenta, magentaPen, playerPoint, gameSettings.PlayerSize, gameSettings.PlayerSize);
           

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
                         Brush brushes = Brushes.DarkBlue;
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
