using NUnit.Framework;
using System;
using SZTGUI_FF_T11_CORE.Models;
using SZTGUI_FF_T11_CORE.Settings;
using SZTGUI_FF_T11_Logic;

namespace SZTGUI_FF_T11_Test
{
    [TestFixture]
    public class GameLogicTest
    {
        [Test]
        public void PlayerColorIsMagenta()
        {
            //Arrange
            GameSettings gameSettings = new GameSettings();

            // Act
            GameModel game = new GameModel(640, 480, gameSettings);

            //Assert 
            Assert.That(game.Player.Color is ConsoleColor.Magenta);

        }


        [Test]
        public void BallIsDamagingColorIsRed()
        {
            //Arrange
            GameSettings gameSettings = new GameSettings();


            // Act
            GameModel game = new GameModel(640, 480, gameSettings);

            foreach (Ball ball in game.Balls)
            {
                ball.Color = ConsoleColor.Red;
            }

            foreach (Ball ball in game.Balls)
            {
                Assert.That(ball.IsDamaging is true);
            }
        }

        [Test]
        public void BallIHealingColorIsGreen()
        {
            //Arrange
            GameSettings gameSettings = new GameSettings();


            // Act
            GameModel game = new GameModel(640, 480, gameSettings);

            foreach (Ball ball in game.Balls)
            {
                ball.Color = ConsoleColor.Green;
            }

            foreach (Ball ball in game.Balls)
            {
                Assert.That(ball.IsHealing is true);
            }
        }


        [Test]
        public void BallNotHealingNotDamagingColorIsNotGreenOrRed()
        {
            //Arrange
            GameSettings gameSettings = new GameSettings();


            // Act
            GameModel game = new GameModel(640, 480, gameSettings);

            foreach (Ball ball in game.Balls)
            {
                Random rnd = new Random();
                int random = rnd.Next(0, 2);
                if (random == 0)
                {
                    ball.Color = ConsoleColor.Yellow;
                }
                else
                {
                    ball.Color = ConsoleColor.Blue;
                }
            }


            //Assert
            foreach (Ball ball in game.Balls)
            {
                Assert.That(ball.IsHealing is not true);
                Assert.That(ball.IsDamaging is not true);
            }
        }

        [Test]
        public void MovePlayerToLeft()
        {
            //Arrange
            GameSettings gameSettings = new GameSettings();
            GameModel game = new GameModel(640, 480, gameSettings);
            GameLogic gameLogic = new GameLogic(game as IGameModel, gameSettings as IGameSettings);

            game.Player.X = 200;
            game.Player.Y = 200;

            //Act
            gameLogic.MovePlayer('L');

            //Assert
            Assert.That(game.Player.X.Equals(200 - gameSettings.BallSize));
        }


        [Test]
        public void MovePlayerToRight()
        {
            //Arrange
            GameSettings gameSettings = new GameSettings();
            GameModel game = new GameModel(640, 480, gameSettings);
            GameLogic gameLogic = new GameLogic(game as IGameModel, gameSettings as IGameSettings);

            game.Player.X = 200;
            game.Player.Y = 200;

            //Act
            gameLogic.MovePlayer('R');

            //Assert
            Assert.That(game.Player.X.Equals(200 + gameSettings.BallSize));
        }

        [Test]
        public void MovePlayerToUp()
        {
            //Arrange
            GameSettings gameSettings = new GameSettings();
            GameModel game = new GameModel(640, 480, gameSettings);
            GameLogic gameLogic = new GameLogic(game as IGameModel, gameSettings as IGameSettings);

            game.Player.X = 200;
            game.Player.Y = 200;

            //Act
            gameLogic.MovePlayer('U');

            //Assert
            Assert.That(game.Player.Y.Equals(200 - gameSettings.BallSize));
        }


        [Test]
        public void MovePlayerToDown()
        {
            //Arrange
            GameSettings gameSettings = new GameSettings();
            GameModel game = new GameModel(640, 480, gameSettings);
            GameLogic gameLogic = new GameLogic(game as IGameModel, gameSettings as IGameSettings);

            game.Player.X = 200;
            game.Player.Y = 200;

            //Act
            gameLogic.MovePlayer('D');

            //Assert
            Assert.That(game.Player.Y.Equals(200 + gameSettings.BallSize));
        }

        [Test]
        public void PlayerCannotMoveOutToLeft()
        {
            //Arrange
            GameSettings gameSettings = new GameSettings();
            GameModel game = new GameModel(640, 480, gameSettings);
            GameLogic gameLogic = new GameLogic(game as IGameModel, gameSettings as IGameSettings);

            game.Player.X = gameSettings.BallSize;
            game.Player.Y = 200;

            //Act

            gameLogic.MovePlayer('L');

            //Assert

            Assert.That(game.Player.X.Equals(gameSettings.BallSize));
        }

        [Test]
        public void PlayerCannotMoveOutToRight()
        {
            //Arrange
            GameSettings gameSettings = new GameSettings();
            GameModel game = new GameModel(640, 480, gameSettings);
            GameLogic gameLogic = new GameLogic(game as IGameModel, gameSettings as IGameSettings);

            game.Player.X = 640 - gameSettings.BallSize;
            game.Player.Y = 200;

            //Act

            gameLogic.MovePlayer('R');

            //Assert

            Assert.That(game.Player.X.Equals(640 - gameSettings.BallSize));
        }

        [Test]
        public void PlayerCannotMoveOutToTop()
        {
            //Arrange
            GameSettings gameSettings = new GameSettings();
            GameModel game = new GameModel(640, 480, gameSettings);
            GameLogic gameLogic = new GameLogic(game as IGameModel, gameSettings as IGameSettings);

            game.Player.X = 200;
            game.Player.Y = gameSettings.BallSize;

            //Act

            gameLogic.MovePlayer('U');

            //Assert

            Assert.That(game.Player.Y.Equals(gameSettings.BallSize));
        }

        [Test]
        public void PlayerCannotMoveOutToDown()
        {
            //Arrange
            GameSettings gameSettings = new GameSettings();
            GameModel game = new GameModel(640, 480, gameSettings);
            GameLogic gameLogic = new GameLogic(game as IGameModel, gameSettings as IGameSettings);

            game.Player.X = 200;
            game.Player.Y = 480 - gameSettings.BallSize;

            //Act

            gameLogic.MovePlayer('D');

            //Assert

            Assert.That(game.Player.Y.Equals(480 - gameSettings.BallSize));
        }


        [Test]
        public void BallMoveToLeft()
        {
            //Arrange
            GameSettings gameSettings = new GameSettings();
            GameModel game = new GameModel(640, 480, gameSettings);
            GameLogic gameLogic = new GameLogic(game as IGameModel, gameSettings as IGameSettings);

            gameSettings.Difficulty = "Easy";

            foreach (Ball ball in game.Balls)
            {
                ball.X = 200;
            }

            gameLogic.MoveBall();

            foreach (Ball ball in game.Balls)
            {
                ball.X = 200 - gameSettings.BallSize;
            }
        }

        [Test]
        public void BallWallCollision()
        {
            //Arrange
            GameSettings gameSettings = new GameSettings();
            GameModel game = new GameModel(640, 480, gameSettings);
            GameLogic gameLogic = new GameLogic(game as IGameModel, gameSettings as IGameSettings);

            gameSettings.Difficulty = "Medium";

            foreach (Ball ball in game.Balls)
            {
                ball.DY = -1;
                ball.Y = gameSettings.BallSize;
                ball.X = 200;
            }

            //Act

            gameLogic.BAllWallCollision();


            //Assert
            foreach (Ball ball in game.Balls)
            {
                Assert.That(ball.DY.Equals(1));
            }


        }

        [Test]
        public void BallWallCollisionFromBottom()
        {
            //Arrange
            GameSettings gameSettings = new GameSettings();
            GameModel game = new GameModel(640, 480, gameSettings);
            GameLogic gameLogic = new GameLogic(game as IGameModel, gameSettings as IGameSettings);

            gameSettings.Difficulty = "Medium";

            foreach (Ball ball in game.Balls)
            {
                ball.DY = 1;
                ball.Y = 480 - gameSettings.BallSize;
                ball.X = 200;
            }

            //Act

            gameLogic.BAllWallCollision();


            //Assert
            foreach (Ball ball in game.Balls)
            {
                Assert.That(ball.DY.Equals(-1));
            }


        }

        [Test]
        public void PlayerWithValueSmallerThanBallValue_BallNotDamagingOrHealing()
        {

            //Arrange
            GameSettings gameSettings = new GameSettings();
            GameModel game = new GameModel(640, 480, gameSettings);
            GameLogic gameLogic = new GameLogic(game as IGameModel, gameSettings as IGameSettings);


            Ball ball = new Ball(200, 200, 1, 0, ConsoleColor.Yellow, 6);

            //Act
            gameLogic.PlayerBallCollision(game.Player, ball);

            //Assert
            Assert.That(game.Player.Value.Equals(5));
        }

        [Test]
        public void PlayerWithValueSmallerThanBallValue_BallIsHealing()
        {

            //Arrange
            GameSettings gameSettings = new GameSettings();
            GameModel game = new GameModel(640, 480, gameSettings);
            GameLogic gameLogic = new GameLogic(game as IGameModel, gameSettings as IGameSettings);


            Ball ball = new Ball(200, 200, 1, 0, ConsoleColor.Green, 6);

            //Act
            gameLogic.PlayerBallCollision(game.Player, ball);

            //Assert
            Assert.That(game.Player.Value.Equals(11));
        }

        [Test]
        public void PlayerWithValueSmallerThanBallValue_BallIsDamaging()
        {

            //Arrange
            GameSettings gameSettings = new GameSettings();
            GameModel game = new GameModel(640, 480, gameSettings);
            GameLogic gameLogic = new GameLogic(game as IGameModel, gameSettings as IGameSettings);


            Ball ball = new Ball(200, 200, 1, 0, ConsoleColor.Red, 2);

            //Act
            gameLogic.PlayerBallCollision(game.Player, ball);

            //Assert
            Assert.That(game.Player.Value.Equals(3));
        }

        [Test]
        public void PlayerWithValueEqualToBallValue_BallNotDamagingOrHealing()
        {

            //Arrange
            GameSettings gameSettings = new GameSettings();
            GameModel game = new GameModel(640, 480, gameSettings);
            GameLogic gameLogic = new GameLogic(game as IGameModel, gameSettings as IGameSettings);


            Ball ball = new Ball(200, 200, 1, 0, ConsoleColor.Yellow, 5);

            //Act
            gameLogic.PlayerBallCollision(game.Player, ball);

            //Assert
            Assert.That(game.Player.Value.Equals(10));
        }


        [Test]
        public void PlayerWithValueGreaterBallValue_BallNotDamagingOrHealing()
        {

            //Arrange
            GameSettings gameSettings = new GameSettings();
            GameModel game = new GameModel(640, 480, gameSettings);
            GameLogic gameLogic = new GameLogic(game as IGameModel, gameSettings as IGameSettings);

            game.Player.Value = 7;
            Ball ball = new Ball(200, 200, 1, 0, ConsoleColor.DarkBlue, 5);

            //Act
            gameLogic.PlayerBallCollision(game.Player, ball);

            //Assert
            Assert.That(game.Player.Value.Equals(12));
        }

    }
}
