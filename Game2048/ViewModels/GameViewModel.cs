using Game2048.Commands;
using Game2048.Models;
using Game2048.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048.ViewModels
{
    public class GameViewModel : ViewModel
    {
        private GameBoard gameBoard;
        private Random random;

        public int[,] Board { get => gameBoard.board; private set => Set(ref gameBoard.board, value); }
        public int Score { get => gameBoard.score; private set => Set(ref gameBoard.score, value); }
        public GameViewModel()
        {
            gameBoard = new GameBoard();
            random = new Random();

            Reset();
        }
        public NavigationCommand NavigateToMenuPage { get => new(NavigateToPage, new Uri("Views/Pages/MenuPage.xaml", UriKind.RelativeOrAbsolute)); }

        #region Operations
        private void Reset()
        {
            Board = new int[gameBoard.boardSize, gameBoard.boardSize];
            Score = 0;
            GenerateRandomNumber();
            GenerateRandomNumber();
            Update();
        }

        private void GenerateRandomNumber()
        {
            int row, col;

            do
            {
                row = random.Next(gameBoard.boardSize);
                col = random.Next(gameBoard.boardSize);
            } while (gameBoard.board[row, col] != 0);

            gameBoard.board[row, col] = random.Next(100) < 90 ? 2 : 4;
        }

        private void Update()
        {
            Board = gameBoard.Board;
            Score = gameBoard.Score;
        }

        #endregion

    }
}
