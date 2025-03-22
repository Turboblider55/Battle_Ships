﻿using System;
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

            /*
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
            */

            Grid myGrid = GenerateField("MyGrid");
            Grid EnemyGrid = GenerateField("EnemyGrid");
            


            (FindName("GameField") as Grid)?.Children.Add(myGrid);


            foreach(Button x in myGrid.Children)
            {
                x.Background = Brushes.Red;
            }
            
            
 
                    

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
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            if ((sender as Button).Background == Brushes.Red)
                (sender as Button).Background = Brushes.Orange;
            
        }
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            if((sender as Button).Background == Brushes.Orange)
            (sender as Button).Background = Brushes.Red;
            
        }
    }   

}
