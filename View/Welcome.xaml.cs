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
using System.Windows.Shapes;

namespace VistaLife.View
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }



        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void SetGridBorders()
        {
            // Create a Border element
            Border border = new Border
            {
                BorderBrush = Brushes.AliceBlue, // Set border color
                BorderThickness = new Thickness(1) // Set border thickness
            };

            // Set the grid as the child of the Border
            border.Child = WlcmGrid;

            // Set the modified Border as the content of the window
            Content = border;
        }

        private void btnLogClick(object sender, RoutedEventArgs e)
        {
           Console.WriteLine("Login button clicked");
            LoginView loginView = new LoginView();
            
           loginView.Show();
            this.Close();
        }
    }
}
