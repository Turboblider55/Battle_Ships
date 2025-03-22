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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            Grid myGrid = new Grid();
            List<RowDefinition> Rows = new List<RowDefinition>();
            List<ColumnDefinition> Columns = new List<ColumnDefinition>();
            List<Button> Buttons = new List<Button>();
            
            //Adding 100 Buttons to List

            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Button Btn = new Button();
                    Btn.Content = ""+i+j;
                    Btn.cli

                    myGrid.Children.Add(Btn);
                    Grid.SetRow(Btn, i);
                    Grid.SetColumn(Btn, j);
                }
            }

            

            for(int i = 0; i < 10; i++)
            {
                Rows.Add(new RowDefinition());
                Columns.Add(new ColumnDefinition());
            }
            foreach (RowDefinition x in Rows) 
                myGrid.RowDefinitions.Add(x);
            
            foreach (ColumnDefinition y in Columns)
                myGrid.ColumnDefinitions.Add(y);

            (this.FindName("GameField") as Grid)?.Children.Add(myGrid);

            Grid.SetRow(myGrid, 1);
            Grid.SetColumn(myGrid, 1);


        }

        
    }
}
