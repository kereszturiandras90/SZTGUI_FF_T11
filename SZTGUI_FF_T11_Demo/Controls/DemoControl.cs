using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using static SZTGUI_FF_T11_CORE.Settings.GameSettings;

namespace SZTGUI_FF_T11_Demo.Controls
{
    public class DemoControl : FrameworkElement
    {
        public IGameModel gameModel;
        public IGameLogic gameLogic;
        IGameRenderer gameRenderer;
        public IGameSettings gameSettings;
        DisplaySettings displaySettings;
        DispatcherTimer timer;
        DispatcherTimer timer2;

        public string PlayerName { get; set; }
        public Array Difficulties
        {
            get { return Enum.GetValues(typeof(GameSettings.DifficultyType)); }
        }

        public string Difficulty { get; set; }

        public ICommand NewMenu { get; private set; }
        public ICommand NewGame { get; private set; }
        public ICommand OpenMenu { get; private set; }
        public ICommand SaveMenu { get; private set; }
        public ICommand GameResultsMenu { get; private set; }
        public ICommand ExitMenu { get; private set; }


        public DemoControl()
        {
            Loaded += DemoControl_Loaded;

            NewMenu = new RelayCommand(() => New_Menu());
            NewGame = new RelayCommand(() => New_Game());
            OpenMenu = new RelayCommand(() => Open_Menu());
            SaveMenu = new RelayCommand(() => Save_Menu());
            GameResultsMenu = new RelayCommand(() => GameResults_Menu());
            ExitMenu = new RelayCommand(() => Exit_Menu());

            gameSettings = new GameSettings();
            gameModel = new GameModel(0, 0, gameSettings);
            

        }

        private void New_Menu()
        {
        }
        private void New_Game()
        {
            MessageBox.Show("Starting new game");
        }

        private void Open_Menu()
        {
            string path = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
            }

            LoadAndSaveLogic logic = new LoadAndSaveLogic();

            gameModel = logic.LoadGameModel(path);
            gameSettings = logic.LoadGameSettings(path+".set");
            
        }

        private void Save_Menu()
        {
            string path = "";
            FileInfo fileInfo = null;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.DefaultExt = "xml";
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            
            if (saveFileDialog.ShowDialog() == true)
            {
                path = saveFileDialog.FileName;
                fileInfo = new FileInfo(path);
            }

            LoadAndSaveLogic logic = new LoadAndSaveLogic();

            logic.SaveGameModel(gameModel as GameModel,path );
            logic.SaveGameSettings(gameSettings as GameSettings, path + ".set");
            ;
        }

        private void GameResults_Menu()
        {
            GameResults newGameResultsWin = new GameResults();
            newGameResultsWin.ShowDialog();
        }

        private void Exit_Menu()
        {
        }


        private void DemoControl_Loaded(object sender, RoutedEventArgs e)
        {
            //gameSettings = new GameSettings();
            gameModel = new GameModel(ActualWidth, ActualHeight, gameSettings);
            //gameModel.GameAreaHeight = ActualHeight;
            //gameModel.GameAreaWidth = ActualWidth;
            
            gameLogic = new GameLogic(gameModel, gameSettings);
            gameRenderer = new GameRenderer(gameModel, gameSettings);
            displaySettings = new DisplaySettings();

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


              /*  if (gameModel.TimeCounter % 30 == 0 && gameModel.TimeCounter != 0)
                {
                    timer.Interval = timer.Interval * 0.9;
                }*/
            }

        }

        private void Seconds_Tick(object sender, EventArgs e)
        {  // second -> min minute conv
            gameModel.TimeCounter++;
            if (gameModel.TimeCounter % 20 == 0) //
            {
                double playerx = gameModel.Player.X;
                double playery = gameModel.Player.Y;
                int playerValue = gameModel.Player.Value;
                int count = gameModel.TimeCounter;
                //gameModel = new GameModel(ActualWidth, ActualHeight, gameSettings, true);
                gameModel.Player.X = playerx;
                gameModel.Player.Y = playery;
                gameModel.Player.Value = playerValue;
                gameModel.TimeCounter = count;
                gameLogic = new GameLogic(gameModel, gameSettings);
                gameRenderer = new GameRenderer(gameModel, gameSettings);
                foreach (Ball ball in gameModel.Balls)
                {
                    Random rnd = new Random();
                    int ballValue = rnd.Next(gameModel.Player.Value-5, gameModel.Player.Value + 5);
                    ball.Value = ballValue;
                }
                timer.Interval = timer.Interval * 0.9;
                

                InvalidateVisual(); // Call the renderer

                ;
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
                    ball.X = -150;
                    ball.Y = -150;
                }
            }

            gameLogic.BAllWallCollision();
            if (gameSettings.Difficulty == "Hard")
            {
                gameLogic.BallBallCollision();
            }

            ;
            InvalidateVisual();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    timer.IsEnabled = !timer.IsEnabled;
                    break;
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
            if (gameModel.GameAreaWidth != 0)
            {
                gameRenderer.Display(drawingContext, displaySettings);
            }
        }
    }
}
