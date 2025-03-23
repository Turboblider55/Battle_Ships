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

namespace Battle_Ships
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
    Grid myGrid = null;
    private int ShipSizeX = 0;
    private int ShipSizeY = 0;
        public MainWindow()
        {
            InitializeComponent();

            myGrid = GenerateField("MyGrid");
            Grid EnemyGrid = GenerateField("EnemyGrid");
            

            (FindName("GameField") as Grid)?.Children.Add(myGrid);


            //foreach(Button x in myGrid.Children)
            //{
            //    x.Background = Brushes.Red;
            //}
            
            Grid.SetRow(myGrid, 1);
            Grid.SetColumn(myGrid, 1);

            (this.FindName("GameField") as Grid)?.Children.Add(EnemyGrid);

            

            Grid.SetRow(EnemyGrid, 1);
            Grid.SetColumn(EnemyGrid, 3);


        }

        public Grid GenerateField(string Name)
        {
            Grid myGrid = new Grid();
            List<RowDefinition> Rows = new List<RowDefinition>();
            List<ColumnDefinition> Columns = new List<ColumnDefinition>();
            List<Button> Buttons = new List<Button>();
            myGrid.Name = Name; 

            //Adding 100 Buttons to List

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button Btn = new Button();
                    Btn.Content = "" + i + j;
                    Btn.Click += Button_Click;
                    Btn.MouseEnter += Button_MouseEnter;
                    Btn.MouseLeave += Button_MouseLeave;
                    Btn.MouseWheel += Button_Wheel;

                    myGrid.Children.Add(Btn);
                    Grid.SetRow(Btn, i);
                    Grid.SetColumn(Btn, j);
                }
            }



            for (int i = 0; i < 10; i++)
            {
                Rows.Add(new RowDefinition());
                Columns.Add(new ColumnDefinition());
            }
            foreach (RowDefinition x in Rows)
                myGrid.RowDefinitions.Add(x);

            foreach (ColumnDefinition y in Columns)
                myGrid.ColumnDefinitions.Add(y);

            return myGrid;
        }

        private void Ready_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if ((sender as Button).Background == Brushes.Gray)
            {
                (sender as Button).Background = Brushes.Red;
            }
            else
            {
                (sender as Button).Background = Brushes.Gray;
            }
            
            
            DrawShipSize(sender, ShipSizeX, ShipSizeY, Brushes.Transparent, "O");
            ShipSizeX = 1;
            ShipSizeY = 1;
            
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            //if ((sender as Button).Background == Brushes.Red)
            //    (sender as Button).Background = Brushes.Orange;

            DrawShipSize(sender, ShipSizeX, ShipSizeY, Brushes.Black,"X");
            
            
        }
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            //if((sender as Button).Background == Brushes.Orange)
            //(sender as Button).Background = Brushes.Red;


            DrawShipSize(sender, ShipSizeX , ShipSizeY, Brushes.Transparent,"O");
            
        }

        private void ShipSizeBtn_Click(object sender, RoutedEventArgs e)
        {
            switch((sender as Button).Content.ToString())
            {
                case "1X1 Ship": ShipSizeX = 1; ShipSizeY = 1; break;
                case "1X2 Ship": ShipSizeX = 1; ShipSizeY = 2; break;
                case "1X4 Ship": ShipSizeX = 1; ShipSizeY = 4; break;
                case "2X2 Ship": ShipSizeX = 2; ShipSizeY = 4; break;
            }

        }

        private void DrawShipSize(object sender, int x, int y, Brush Clr,string Ctn)
        {
            int centerIndex = myGrid.Children.IndexOf(sender as Button);

            int HalfX = x / 2;
            int HalfY = y / 2;

            for (int i = -HalfY; i < (y - HalfY ); i++)
            {
                for (int j = -HalfX; j < (x - HalfX ); j++)
                {
                    int Index = centerIndex;
                    if (((centerIndex + j) / 10 != centerIndex / 10) || centerIndex + j < 0 || centerIndex + j > 99)
                    {
                        Index += Math.Sign(j) * (-HalfX) - (Math.Sign(j))*(HalfX - Math.Abs(j)) - Math.Sign(j)*(x %2);
                    }
                    else
                        Index += j;

                    if ((centerIndex + i * 10) < 0 || (centerIndex + i * 10) > 99)
                    {
                        Index += (Math.Sign(i) * (-HalfY) - (Math.Sign(i)) * (HalfY - Math.Abs(i)) - Math.Sign(i) * (y %2)) * 10;
                    }
                    else
                    {
                        Index += i * 10;
                    }

                    (myGrid.Children[Index] as Button).BorderBrush = Clr;
                    (myGrid.Children[Index] as Button).Content = Ctn;
                }
            }
        }

        private void Button_Wheel(object sender, MouseWheelEventArgs e)
        {
            DrawShipSize(sender, ShipSizeX, ShipSizeY, Brushes.Transparent, "O");

            int temp = ShipSizeX;
            ShipSizeX = ShipSizeY;
            ShipSizeY = temp;

            DrawShipSize(sender, ShipSizeX, ShipSizeY, Brushes.Black, "X");
        }
    }   

}
