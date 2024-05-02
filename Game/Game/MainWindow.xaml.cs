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
                    Grid.SetRow(nb, i);
                    Grid.SetColumn(nb, j);
                    PlayerSide.Children.Add(nb);
                    PlayerButtons.Add(nb);
                    switch (PlayerMatrix[i, j])
                    {
                        case 0:
                            nb.Foreground = new SolidColorBrush(Colors.Gray);
                            break;
                    }
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
                    Grid.SetRow(nb, i);
                    Grid.SetColumn(nb, j);
                    PlayerAttacks.Children.Add(nb);
                    PlayerAttacksButtons.Add(nb);
                    switch (PlayerMatrix[i, j])
                    {
                        case 0:
                            nb.Foreground = new SolidColorBrush(Colors.Gray);
                            break;
                    }
                }
            }

        }


        private void Start()
        {
            GenerateMatrix();
            ShowPlayerMatrix();
            ShowPlayerAttacksMatrix();
        }


        private void Randomize()
        {
            PlayerButtons[r.Next(0, PlayerButtons.Count)].Foreground = new SolidColorBrush(Colors.Aqua);
            Console.WriteLine(r.Next(0, PlayerButtons.Count + 1));
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
