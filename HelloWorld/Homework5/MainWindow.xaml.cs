using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int turn = 1;
        string[,] board = new string[3, 3];
        public MainWindow()
        {
            InitializeComponent();
            uxTurn.Text = "X's Turn";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string mark = turn % 2 == 0 ? "O" : "X";
            string tags = btn.Tag.ToString();
            if (btn.Content == null && int.TryParse(tags[0].ToString(), out int row) && int.TryParse(tags[tags.Length - 1].ToString(), out int col))
            {
                btn.Content = mark;
                board[row, col] = mark;
                turn++;
            }
            if (checkScores())
            {
                uxTurn.Text = $"{mark} wins!";
            }
            else
            {
                string next = mark == "O" ? "X" : "O";
                uxTurn.Text = $"{next}'s Turn";
            }
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement el in uxGrid.Children)
            {
                Button btn = (Button)el;
                btn.IsEnabled = true;
                btn.Content = null;
            }
            uxTurn.Text = "X's Turn";
            turn = 1;
            Array.Clear(board, 0, board.Length);
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool checkScores()
        {
            bool winner = false;
            for (int i = 0; i < 3; i++)
            {
                int j;
                int k;
                for (j = 0; j < 3; j++)
                {
                    if (board[i, j] != null && board[i, 0] != null && board[i, j] == board[i, 0])
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                for (k = 0; k < 3; k++)
                {
                    if (board[k, i] != null && board[0, i] != null && board[k, i] == board[0, i])
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                if (j == 3 || k == 3)
                {
                    winner = true;
                }
            }

            if ((board[0, 0] != null && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) || (board[0, 2] != null && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]))
            {
                winner = true;
            }
            foreach (UIElement el in uxGrid.Children)
            {
                Button btn = (Button)el;
                btn.IsEnabled = !winner;
            }
            return winner;

        }
    }
}
