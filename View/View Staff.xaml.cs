using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using VistaLife.Resource;

namespace VistaLife.View
{
    /// <summary>
    /// Interaction logic for View_Staff.xaml
    /// </summary>
    public partial class View_Staff : Window
    {
        public View_Staff()
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

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Menue menue = new Menue();
            menue.ShowDialog();
            this.Close();
        }

        private void btnAddpatient_Click(object sender, RoutedEventArgs e)
        {
            InPatient inPatient = new InPatient();
            inPatient.ShowDialog();
            this.Close();
        }

        private void btnChannel_Click(object sender, RoutedEventArgs e)
        {
            OutPatient outPatient = new OutPatient();
            outPatient.ShowDialog();
            this.Close();
        }

        private void BtnPDetails_Click(object sender, RoutedEventArgs e)
        {
            ViewPatient viewPatient = new ViewPatient();
            viewPatient.ShowDialog();
            this.Close();
        }

        private void BtnStaffDetails_Click(object sender, RoutedEventArgs e)
        {
            View_Staff viewStaff = new View_Staff();
            viewStaff.ShowDialog();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtjob.SelectedItem = null;
            txtID.Text = "";
            Dgridstaffdetails.ItemsSource = null;
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            if( String.IsNullOrEmpty(txtjob.Text) )
            {
                MessageBox.Show("Please Select the Job");
            }
            else
            {
                

                try
                {
                    String id = txtID.Text;
                    String job = txtjob.Text;
                    String column = "";
                    String table = "";
                    String query = "";

                    if (job =="Doctor")
                    {
                        column ="D_ID";
                        table = "Doctor";
                    }
                    if (job == "Nurse")
                    {
                        column = "N_ID";
                        table = "nurse";
                    }
                    if(String.IsNullOrEmpty(txtID.Text))
                    {
                        query = $"SELECT * FROM {table}";
                    }
                    if(!String.IsNullOrEmpty(txtID.Text))
                    {
                        query = $"SELECT * FROM {table} WHERE {column} = '{id}'";
                    }
                    

                    Connectioncs connectioncs = new Connectioncs();
                    SqlConnection con = connectioncs.GetDBCon();

                    

                    SqlCommand cmd = new SqlCommand(query, con);
                    DataTable datatableobj = new DataTable();
                    using SqlDataAdapter adapObj = new SqlDataAdapter(cmd);
                    {
                        adapObj.Fill(datatableobj);
                    }
                    Dgridstaffdetails.ItemsSource = datatableobj.DefaultView;

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }                                                                       
            {

            }
        }
    }
}
