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
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            gameModel.GameAreaWidth = ActualWidth;
            gameModel.GameAreaHeight = ActualHeight;

            //gameLogic.MovePlayer();
            //  gameLogic.MoveTubes();

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
