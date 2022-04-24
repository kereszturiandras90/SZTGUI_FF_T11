using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using SZTGUI_FF_T11_CORE.Models;
using SZTGUI_FF_T11_CORE.Settings;
using SZTGUI_FF_T11_Logic;
using SZTGUI_FF_T11_Renderer;

namespace SZTGUI_FF_T11_Demo.Controls
{
    public class DemoControl: FrameworkElement
    {
        IGameModel gameModel;
        IGameLogic gameLogic;
        IGameRenderer gameRenderer;
        IGameSettings gameSettings;
       // DisplaySettings displaySettings;
        DispatcherTimer timer;
        DispatcherTimer timer2;

        public DemoControl()
        {
            Loaded += DemoControl_Loaded;
        }

        private void DemoControl_Loaded(object sender, RoutedEventArgs e)
        {
            gameSettings = new GameSettings();
            gameModel = new GameModel(ActualWidth, ActualHeight, gameSettings);
            gameLogic = new GameLogic(gameModel, gameSettings);
            gameRenderer = new GameRenderer(gameModel, gameSettings);

            InvalidateVisual(); // Call the renderer

            var window = Window.GetWindow(this);

            if (window != null)
            {
                window.KeyDown += Window_KeyDown;

                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(130);
                timer.Tick += Timer_Tick;
                timer.Start();

                timer2 = new DispatcherTimer();
                timer2.Interval = TimeSpan.FromMilliseconds(1000);
                timer2.Tick += Seconds_Tick;
                timer2.Start();
            }

        }

        private void Seconds_Tick(object sender, EventArgs e)
        {
            gameModel.TimeCounter++;
            if (gameModel.TimeCounter % 20 == 0)
            {
                double playerx = gameModel.Player.X;
                double playery = gameModel.Player.Y;
                int playerValue = gameModel.Player.Value;
                int count = gameModel.TimeCounter;
                gameModel = new GameModel(ActualWidth, ActualHeight, gameSettings);
                gameModel.Player.X = playerx;
                gameModel.Player.Y = playery;
                gameModel.Player.Value = playerValue;
                gameModel.TimeCounter = count;
                gameLogic = new GameLogic(gameModel, gameSettings);
                gameRenderer = new GameRenderer(gameModel, gameSettings);

                InvalidateVisual(); // Call the renderer


            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            gameModel.GameAreaWidth = ActualWidth;
            gameModel.GameAreaHeight = ActualHeight;

            gameLogic.MoveBall();

            foreach (Ball ball in gameModel.Balls)
            {
                if (gameLogic.HasCollision(gameModel.Player, ball))
                {
                    gameLogic.PlayerBallCollision(gameModel.Player, ball);
                }
            }

            InvalidateVisual();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
               
                case Key.Up:
                    gameLogic.MovePlayer('U');
                    break;
                case Key.Down:
                    gameLogic.MovePlayer('D');
                    break;
                case Key.Left:
                    gameLogic.MovePlayer('L');
                    break;
                case Key.Right:
                    gameLogic.MovePlayer('R');
                    break;
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (gameModel != null)
            {
                gameRenderer.Display(drawingContext);
            }
        }
    }
}
