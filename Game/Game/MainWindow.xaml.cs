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

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] PlayerMatrix = new int[10, 10];
        int[,] PlayerAttacksMatrix = new int[10, 10];
        List<Button> PlayerButtons = new();
        List<Button> PlayerAttacksButtons = new();
        Random r = new();

        /*
        The values of the matrixes:
         0 - Empty - Gray
         1 - Ship - Yellow
         2 - Missed attacks - Black
         3 - Hitted attacks - Red
        */

        public MainWindow()
        {
            InitializeComponent();
        }

        public void GenerateMatrix()
        {
            //Clear everything out of the grids
            PlayerSide.RowDefinitions.Clear();
            PlayerSide.ColumnDefinitions.Clear();
            PlayerSide.Children.Clear();

            PlayerAttacks.RowDefinitions.Clear();
            PlayerAttacks.ColumnDefinitions.Clear();
            PlayerAttacks.Children.Clear();

            PlayerRows.RowDefinitions.Clear();
            PlayerRows.ColumnDefinitions.Clear();
            PlayerRows.Children.Clear();

            PlayerAttackRows.RowDefinitions.Clear();
            PlayerAttackRows.ColumnDefinitions.Clear();
            PlayerAttackRows.Children.Clear();

            TheBoardsColumns.RowDefinitions.Clear();
            TheBoardsColumns.ColumnDefinitions.Clear();
            TheBoardsColumns.Children.Clear();

            //Add columns and rows to the grids
            for (int i = 0; i < 10; i++)
            {
                PlayerSide.RowDefinitions.Add(new());
                PlayerSide.ColumnDefinitions.Add(new());

                PlayerAttacks.RowDefinitions.Add(new());
                PlayerAttacks.ColumnDefinitions.Add(new());

                PlayerRows.RowDefinitions.Add(new());
                PlayerAttackRows.RowDefinitions.Add(new());
                TheBoardsColumns.ColumnDefinitions.Add(new());
            }

            for (int i = 0; i < 10; i++) //10 rows
            {
                //The nubers next to the rows
                Label nl = new();
                nl.HorizontalAlignment = HorizontalAlignment.Center;
                nl.VerticalAlignment = VerticalAlignment.Center;
                nl.Content = i + 1;
                Grid.SetRow(nl, i);
                PlayerRows.Children.Add(nl);

                Label nl2 = new();
                nl2.HorizontalAlignment = HorizontalAlignment.Center;
                nl2.VerticalAlignment = VerticalAlignment.Center;
                nl2.Content = i + 1;
                Grid.SetRow(nl2, i);
                PlayerAttackRows.Children.Add(nl2);

                //The letters under/above the columns
                Label nl3 = new();
                nl3.HorizontalAlignment = HorizontalAlignment.Center;
                nl3.VerticalAlignment = VerticalAlignment.Center;
                nl3.Content = Convert.ToChar(i + 65);
                Grid.SetColumn(nl3, i);
                TheBoardsColumns.Children.Add(nl3);

                for (int j = 0; j < 10; j++) //10 columns
                {
                    //Player table
                    PlayerMatrix[i, j] = 0;

                    //Player's attacks
                    PlayerAttacksMatrix[i, j] = 0;
                }
            }
        }

        private void ShowPlayerMatrix()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button nb = new();
                    nb.HorizontalAlignment = HorizontalAlignment.Stretch;
                    nb.VerticalAlignment = VerticalAlignment.Stretch;
                    nb.Content = $"{i}:{j}";
                    switch (PlayerMatrix[i, j])
                    {
                        case 0:
                            nb.Background = new SolidColorBrush(Colors.Gray);
                            break;
                        case 1:
                            nb.Background = new SolidColorBrush(Colors.Yellow);
                            break;
                        case 2:
                            nb.Background = new SolidColorBrush(Colors.Black);
                            break;
                        case 3:
                            nb.Background = new SolidColorBrush(Colors.Red);
                            break;
                        default:
                            nb.Background = new SolidColorBrush(Colors.Blue);
                            break;
                    }
                    Grid.SetRow(nb, i);
                    Grid.SetColumn(nb, j);
                    PlayerSide.Children.Add(nb);
                    PlayerButtons.Add(nb);
                }
            }
        }

        private void ShowPlayerAttacksMatrix()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button nb = new();
                    nb.HorizontalAlignment = HorizontalAlignment.Stretch;
                    nb.VerticalAlignment = VerticalAlignment.Stretch;
                    switch (PlayerMatrix[i, j])
                    {
                        case 0:
                            nb.Background = new SolidColorBrush(Colors.Gray);
                            break;
                        case 1:
                            nb.Background = new SolidColorBrush(Colors.Yellow);
                            break;
                        case 2:
                            nb.Background = new SolidColorBrush(Colors.Black);
                            break;
                        case 3:
                            nb.Background = new SolidColorBrush(Colors.Red);
                            break;
                    }
                    Grid.SetRow(nb, i);
                    Grid.SetColumn(nb, j);
                    PlayerAttacks.Children.Add(nb);
                    PlayerAttacksButtons.Add(nb);
                }
            }
        }

        private void Start()
        {
            GenerateMatrix();
            ShowPlayerMatrix();
            ShowPlayerAttacksMatrix();
        }

        private bool Free(int x, int y)
        {
            if (PlayerMatrix[x, y] == 0)
                return true;
            else
                return false;
        }

        private void Ship5()
        {
            int x;
            int y;
            x = r.Next(1, 9);
            y = r.Next(1, 9);
            try
            {
                //Only downward
                if (Free(x, y) && Free(x + 1, y) && Free(x + 2, y) && Free(x + 3, y) && Free(x + 4, y) && Free(x - 1, y) && Free(x + 5, y) && Free(x, y - 1) && Free(x, y + 1) && Free(x + 1, y - 1) && Free(x + 1, y + 1) && Free(x + 2, y - 1) && Free(x + 2, y + 1) && Free(x + 3, y - 1) && Free(x + 3, y + 1) && Free(x + 4, y - 1) && Free(x + 4, y + 1) && Free(x - 1, y) && Free(x - 1, y + 1) && Free(x - 1, y - 1) && Free(x + 1, y) && Free(x + 1, y - 1) && Free(x + 1, y + 1) && Free(x + 5, y + 1) && Free(x + 5, y - 1))
                {
                    PlayerMatrix[x, y] = 1;
                    PlayerMatrix[x + 1, y] = 1;
                    PlayerMatrix[x + 2, y] = 1;
                    PlayerMatrix[x + 3, y] = 1;
                    PlayerMatrix[x + 4, y] = 1;
                }
            }
            catch (Exception)
            {
                try
                {
                    //Only rightward
                    if (Free(x, y) && Free(x, y + 1) && Free(x, y + 2) && Free(x, y + 3) && Free(x, y + 4) && Free(x - 1, y - 1) && Free(x - 1, y) && Free(x - 1, y + 1) && Free(x - 1, y + 2) && Free(x - 1, y + 3) && Free(x - 1, y + 4) && Free(x - 1, y + 5) && Free(x, y - 1) && Free(x, y + 5) && Free(x + 1, y - 1) && Free(x + 1, y) && Free(x + 1, y + 1) && Free(x + 1, y + 2) && Free(x + 1, y + 3) && Free(x + 1, y + 4) && Free(x + 1, y + 5))
                    {
                        PlayerMatrix[x, y] = 1;
                        PlayerMatrix[x, y + 1] = 1;
                        PlayerMatrix[x, y + 2] = 1;
                        PlayerMatrix[x, y + 3] = 1;
                        PlayerMatrix[x, y + 4] = 1;
                    }
                }
                catch (Exception)
                {
                    try
                    {
                        // Only leftward
                        if (Free(x, y) && Free(x, y - 1) && Free(x, y - 2) && Free(x, y - 3) && Free(x, y - 4) && Free(x - 1, y + 1) && Free(x - 1, y) && Free(x - 1, y - 1) && Free(x - 1, y - 2) && Free(x - 1, y - 3) && Free(x - 1, y - 4) && Free(x - 1, y - 5) && Free(x, y - 5) && Free(x, y + 1) && Free(x + 1, y + 1) && Free(x + 1, y) && Free(x + 1, y - 1) && Free(x + 1, y - 2) && Free(x + 1, y - 3) && Free(x + 1, y - 4) && Free(x + 1, y - 5))
                        {
                            PlayerMatrix[x, y] = 1;
                            PlayerMatrix[x, y - 1] = 1;
                            PlayerMatrix[x, y - 2] = 1;
                            PlayerMatrix[x, y - 3] = 1;
                            PlayerMatrix[x, y - 4] = 1;
                        }
                    }
                    catch (Exception)
                    {
                        try
                        {
                            //Only upward
                            if (Free(x, y) && Free(x - 1, y) && Free(x - 2, y) && Free(x - 3, y) && Free(x - 4, y) && Free(x - 1, y - 1) && Free(x, y - 1) && Free(x + 1, y - 1) && Free(x + 2, y - 1) && Free(x + 3, y - 1) && Free(x + 4, y - 1) && Free(x + 5, y - 1) && Free(x, y - 1) && Free(x, y + 5) && Free(x - 1, y + 1) && Free(x, y + 1) && Free(x + 1, y + 1) && Free(x + 2, y + 1) && Free(x + 3, y + 1) && Free(x + 4, y + 1) && Free(x + 5, y + 1))
                            {
                                PlayerMatrix[x, y] = 1;
                                PlayerMatrix[x - 1, y] = 1;
                                PlayerMatrix[x - 2, y] = 1;
                                PlayerMatrix[x - 3, y] = 1;
                                PlayerMatrix[x - 4, y] = 1;
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }

            }
        }

        private void Ship4()
        {
            bool stop = false;
            int x;
            int y;
            do
            {
                x = r.Next(1, 9);
                y = r.Next(1, 9);
                try
                {
                    // Only downward
                    if (Free(x, y) && Free(x + 1, y) && Free(x + 2, y) && Free(x + 3, y) && Free(x - 1, y - 1) && Free(x, y - 1) && Free(x + 1, y - 1) && Free(x + 2, y - 1) && Free(x + 3, y - 1) && Free(x, y - 1) && Free(x, y + 4) && Free(x - 1, y + 1) && Free(x, y + 1) && Free(x + 1, y + 1) && Free(x + 2, y + 1) && Free(x + 3, y + 1))
                    {
                        PlayerMatrix[x, y] = 1;
                        PlayerMatrix[x + 1, y] = 1;
                        PlayerMatrix[x + 2, y] = 1;
                        PlayerMatrix[x + 3, y] = 1;
                        stop = true;
                    }
                }
                catch (Exception)
                {

                }
            }
            while (!stop);
        }

        private void Randomize()
        {
            Ship5();
            Ship4();
            ShowPlayerMatrix();
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Randomize();
        }

    }
}
