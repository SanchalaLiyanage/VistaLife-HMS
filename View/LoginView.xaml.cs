using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace VistaLife.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
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

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        

        
        private void btnLogin_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = Brushes.CadetBlue;
            }
        }

        private void btnLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromArgb(160, 14, 16, 71));
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            int count = -1;
            int flag = 0;
            String message = "";
            try
            { 
                if(String.IsNullOrEmpty(txtUser.Text))
                    {
                    message += "Please enter the username\n";
                        flag = 1;
                        
                    }
                if(String.IsNullOrEmpty(password.Password))
                {
                    message += "Please enter the password";
                    flag = 1;
                       
                    }
                if(flag == 1)
                {
                    MessageBox.Show(message);
                }
                else
                {

                    Connectioncs connectioncs = new Connectioncs();
                    SqlConnection con = connectioncs.GetDBCon();


                    string username = txtUser.Text;
                    string pw = new NetworkCredential(string.Empty, password.SecurePassword).Password;

                    //MessageBox.Show(pw);
                    String query = $"SELECT COUNT(*) FROM Users WHERE U_Name = '{username}' AND PW = '{pw}'";

                    SqlCommand cmd = new SqlCommand(query, con);

                    count = (int)cmd.ExecuteScalar();


                    if (count == 1)
                    { 
                    MessageBox.Show("Login Successful");
                        Menue menue = new Menue();
                        menue.Show();
                        this.Close();}
                    else
                    {
                        MessageBox.Show("Invalid Username or Password");
                    }

                    }
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
