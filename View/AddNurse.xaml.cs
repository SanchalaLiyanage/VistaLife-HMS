using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VistaLife.Resource;

namespace VistaLife.View
{
    /// <summary>
    /// Interaction logic for AddNurse.xaml
    /// </summary>
    public partial class AddNurse : Window
    {
        public AddNurse()
        {
            InitializeComponent();
            // Load doctors 
            Lord lord1 = new Lord();
            lord1.LoadDoctors("W_Name", "Ward",comboboxWard);
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
            txtExperience.Text = "";
            
            txtNName.Text = "";
            txtNAge.Text = "";
            txtNAddress.Text = "";
            comboboxWard.Items.Clear();
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
           int Flag=0;
            string message = "";
            if(string.IsNullOrEmpty(txtNName.Text))
            {
                Flag = 1;
                message += "Name is Empty\n";

            }
            if (string.IsNullOrEmpty(txtNAge.Text))
            {
                Flag = 1;
                message += "Age is Empty\n";

            }
            if (!string.IsNullOrEmpty(txtNAge.Text))
            {
                bool isNotNumeric = !int.TryParse(txtNAge.Text, out _) || txtNAge.Text.Length > 2;
                if (isNotNumeric)
                {

                    Flag = 1;
                    message += "Age is Invalid\n";


                }
            }
            
            if (string.IsNullOrEmpty(txtNAddress.Text))
            {
                Flag = 1;
                message += "Address is Empty\n";

            }
            if (string.IsNullOrEmpty(txtExperience.Text))
            {
                Flag = 1;
                message += "Experience is Empty\n";

            }
            if(!string.IsNullOrEmpty(txtExperience.Text))
            {
                bool NotNumeric = !int.TryParse(txtExperience.Text, out _) || txtExperience.Text.Length > 2;
                if (NotNumeric)
                {

                    Flag = 1;
                    message += "Experience is Invalid\n";


                }

            }
            
            if (comboboxWard.SelectedItem == null)
            {
                Flag = 1;
                message += "Ward is Empty";

            }
            if (Flag == 1)
            {
                MessageBox.Show(message);
            }
            else
            {
                try
                {
                    IDGenerator id = new IDGenerator();
                    string nid = id.GenerateID("N_ID");

                    Connectioncs ConObj = new Connectioncs();
                    SqlConnection Con = ConObj.GetDBCon();

                    string sqlRead = $"SELECT W_ID from Ward where W_Name='{comboboxWard.Text}'";

                          SqlCommand cmdobj1 = new SqlCommand(sqlRead,Con);
                          SqlDataReader reader = cmdobj1.ExecuteReader();
                    String rr = "";
                    if (reader.Read())
                    {
                        rr = reader.GetString(0);
                    }
                    reader.Close();
                   // MessageBox.Show(rr);
                   string expereince = txtExperience.Text+" years";
                   // MessageBox.Show(expereince);

                    string query = "INSERT INTO Nurse (N_ID,N_Name,N_Age,N_Address,N_Experience,W_ID) VALUES('"+nid+"','"+txtNName.Text+ "','"+txtNAge.Text+"','"+txtNAddress.Text +"','"+expereince+"','"+rr+"')";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Nurse Added Successfully");
                    Con.Close();
                    txtExperience.Text = "";

                    txtNName.Text = "";
                    txtNAge.Text = "";
                    txtNAddress.Text = "";
                    comboboxWard.Items.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboboxWard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

