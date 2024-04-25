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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            PlayerSide.RowDefinitions.Clear(); //Clear everything from the grids
            PlayerSide.ColumnDefinitions.Clear();
            PlayerSide.Children.Clear();

            PlayerAttacks.RowDefinitions.Clear();
            PlayerAttacks.ColumnDefinitions.Clear();
            PlayerAttacks.Children.Clear();

            Rows.RowDefinitions.Clear();
            Rows.ColumnDefinitions.Clear();
            Rows.Children.Clear();

            Rows2.RowDefinitions.Clear();
            Rows2.ColumnDefinitions.Clear();
            Rows2.Children.Clear();

            Columns.RowDefinitions.Clear();
            Columns.ColumnDefinitions.Clear();
            Columns.Children.Clear();

            for (int i = 0; i < 10; i++)
            {
                PlayerSide.RowDefinitions.Add(new());
                PlayerSide.ColumnDefinitions.Add(new());

                PlayerAttacks.RowDefinitions.Add(new());
                PlayerAttacks.ColumnDefinitions.Add(new());

                Rows.RowDefinitions.Add(new());
                Rows2.RowDefinitions.Add(new());
                Columns.ColumnDefinitions.Add(new());
            }

            for (int i = 0; i < 10; i++) //10 rows
            {
                //The nubers of the rows
                Label nl = new();
                nl.HorizontalAlignment = HorizontalAlignment.Center;
                nl.VerticalAlignment = VerticalAlignment.Center;
                nl.Content = i + 1;
                Grid.SetRow(nl, i);
                Rows.Children.Add(nl);

                Label nl2 = new();
                nl2.HorizontalAlignment = HorizontalAlignment.Center;
                nl2.VerticalAlignment = VerticalAlignment.Center;
                nl2.Content = i + 1;
                Grid.SetRow(nl2, i);
                Rows2.Children.Add(nl2);

                //The letters of the columns
                Label nl3 = new();
                nl3.HorizontalAlignment = HorizontalAlignment.Center;
                nl3.VerticalAlignment = VerticalAlignment.Center;
                nl3.Content = Convert.ToChar(i + 65);
                Grid.SetColumn(nl3, i);
                Columns.Children.Add(nl3);

                for (int j = 0; j < 10; j++) //10 columns
                {
                    Button nb = new();
                    nb.HorizontalAlignment = HorizontalAlignment.Stretch;
                    nb.VerticalAlignment = VerticalAlignment.Stretch;
                    Grid.SetRow(nb, i);
                    Grid.SetColumn(nb, j);
                    PlayerSide.Children.Add(nb);

                    Button nb2 = new();
                    nb2.HorizontalAlignment = HorizontalAlignment.Stretch;
                    nb2.VerticalAlignment = VerticalAlignment.Stretch;
                    Grid.SetRow(nb2, i);
                    Grid.SetColumn(nb2, j);
                    PlayerAttacks.Children.Add(nb2);

                }
            }
        }
    }
}
