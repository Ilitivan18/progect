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

namespace paint
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IsDraw = false; 

            R = 1; 

            Color = Brushes.Red; 
            rbRed.IsChecked = true; 
        }

        Brush Color; 

        bool IsDraw; 
        double R; 

        private void cmDown(object sender, MouseButtonEventArgs e)
        {
            IsDraw = true;
        }

        private void cmUp(object sender, MouseButtonEventArgs e)
        {
            IsDraw = false; 
        }

        private void cmMove(object sender, MouseEventArgs e)
        {
            if (IsDraw) 
            {
                
                if ((e.GetPosition(g).X < 0) || (e.GetPosition(g).X > g.Width))
                {
                    return;
                }
                if ((e.GetPosition(g).Y < 0) || (e.GetPosition(g).Y > g.Height))
                {
                    return;
                }

                
                Ellipse O = new Ellipse(); 
                O.Width = R; 
                O.Height = R;
                O.Fill = Color; 
                O.Margin = new Thickness(e.GetPosition(g).X - R / 2, e.GetPosition(g).Y - R / 2, 0, 0); // центр под указателем мышки
                g.Children.Add(O); 
            }
        }

        private void cmClear(object sender, RoutedEventArgs e)
        {
            g.Children.Clear(); 
        }

        private void cmRed(object sender, RoutedEventArgs e)
        {
            Color = Brushes.Green; 
            rColor.Fill = Color;
        }

        private void cmBlue(object sender, RoutedEventArgs e)
        {
            Color = Brushes.Black; 
            rColor.Fill = Color; 
        }

        private void cmGreen(object sender, RoutedEventArgs e)
        {
            Color = Brushes.Blue; 
            rColor.Fill = Color; 
        }

        private void cmSize(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            R = slSize.Value; 
        }
    }
}
