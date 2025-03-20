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
    /// Interaction logic for Menue.xaml
    /// </summary>
    public partial class Menue : Window
    {
        public Menue()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void btn1AddmitPatient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn1AddmitPatient_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = Brushes.CadetBlue;
            }
        }

        private void btn1AddmitPatient_MouseLeave(object sender, MouseEventArgs e)
        {

            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromArgb(160, 14, 16, 71));
            }
        }

        private void btn2ChanelDoctor_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = Brushes.CadetBlue;
            }
        }

        private void btn2ChanelDoctor_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromArgb(160, 14, 16, 71));
            }
        }

        private void btn3AddDoctor_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = Brushes.CadetBlue;
            }
        }

        private void btn3AddDoctor_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromArgb(160, 14, 16, 71));
            }

        }

        private void btn4AddNurse_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = Brushes.CadetBlue;
            }
        }

        private void btn4AddNurse_MouseLeave(object sender, MouseEventArgs e)
        {

            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromArgb(160, 14, 16, 71));
            }


        }

        private void btn5ViewPatient_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = Brushes.CadetBlue;
            }

        }

        private void btn5ViewPatient_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromArgb(160, 14, 16, 71));
            }

        }

        private void btn6ViewStaff_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = Brushes.CadetBlue;
            }
        }

        private void btn6ViewStaff_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromArgb(160, 14, 16, 71));
            }

        }

        private void btn7Bill_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = Brushes.CadetBlue;
            }
        }

        private void btn7Bill_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromArgb(160, 14, 16, 71));
            }
        }

        private void btn8DeleteRecord_MouseEnter(object sender, MouseEventArgs e)
        {

            if (sender is Button button)
            {
                button.Background = Brushes.CadetBlue;
            }
        }

        private void btn8DeleteRecord_MouseLeave(object sender, MouseEventArgs e)
        {

            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromArgb(160, 14, 16, 71));
            }
        }

        private void btn2ChanelDoctor_Click(object sender, RoutedEventArgs e)
        {
            OutPatient outPatient = new OutPatient();
            outPatient.ShowDialog();
            this.Close();
        }

        private void btn3AddDoctor_Click(object sender, RoutedEventArgs e)
        {
            AddStaff addsttaff = new AddStaff();
            addsttaff.ShowDialog(); 
            this.Close();
        }

        private void btn1AddmitPatient_Click_1(object sender, RoutedEventArgs e)
        {
            OutPatient outpatient = new OutPatient();
            outpatient.ShowDialog();
            this.Close();
        }

        private void btn4AddNurse_Click(object sender, RoutedEventArgs e)
        {
            AddNurse addnurse = new AddNurse();
            addnurse.ShowDialog();
            this.Close();
        }

        private void btn5ViewPatient_Click(object sender, RoutedEventArgs e)
        {
            ViewPatient viewPatient = new ViewPatient();
            viewPatient.ShowDialog();
            this.Close();
        }

        private void btn6ViewStaff_Click(object sender, RoutedEventArgs e)
        {
            View_Staff viewStaff = new View_Staff();
            viewStaff.ShowDialog();
            this.Close();
        }

        private void btn7Bill_Click(object sender, RoutedEventArgs e)
        {
            Bill bill = new Bill();
            bill.ShowDialog();
            this.Close();
        }

        private void btn8DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            DeleteRecode deleteRecode = new DeleteRecode();
            deleteRecode.ShowDialog();
            this.Close();
        }
    }
}
