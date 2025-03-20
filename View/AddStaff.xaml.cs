using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddStaff.xaml
    /// </summary>
    public partial class AddStaff : Window
    {
        public AddStaff()
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
             txtDAge.Text = "";
             txtDName.Text = "";
             txtAddress.Text = "";
             txtDType.Text = "";
             txtExperience.Text = "";
             txtSpeciality.Text = "";

          

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
           int Flag=0;
            var message = "";



            if (string.IsNullOrWhiteSpace(txtDName.Text))
            {
                Flag = 1;
                message += "Doctor Name is Required\n";
            }
            if (string.IsNullOrWhiteSpace(txtExperience.Text))
            {
                Flag = 1;
                message += "Experience is Required\n";
            }
            if (txtExperience.Text != "")
            {
                bool NotNumeric = !int.TryParse(txtExperience.Text, out _) || txtExperience.Text.Length > 2;//It will provide true for not numeric or length above two digits.
                if (NotNumeric)
                {

                    Flag = 1;
                    message += "Experience is Invalid\n";


                }
            }
           
            if (string.IsNullOrWhiteSpace(txtSpeciality.Text))
            {
                Flag = 1;
                message += "Speciality is Required\n";
            }
            if (string.IsNullOrWhiteSpace(txtDAge.Text))
            {
                Flag = 1;
                message += "Age is Required\n";
               
            }
            if (txtDAge.Text != "")
            {
                bool isNotNumeric = !int.TryParse(txtDAge.Text, out _) || txtDAge.Text.Length > 2;
                if (isNotNumeric)
                {

                    Flag = 1;
                    message += "Age is Invalid\n";


                }

            }
           

            if (string.IsNullOrWhiteSpace(txtDType.Text))
            {
                Flag = 1;
                message += "Type is Required\n  ";


            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                Flag = 1;
                message += "Address is Required\n";

            }
                if (Flag == 1)
                {
                    MessageBox.Show(message);
                }

            else
                {
                    try
                    {
                       // MessageBox.Show("Connection Successfull");
                        Connectioncs conobj = new Connectioncs();
                        SqlConnection con = conobj.GetDBCon();


                        IDGenerator id = new IDGenerator();
                        string did = id.GenerateID("D_ID");

                    string expereince = txtExperience.Text + " years";



                    string query = "insert into Doctor(D_ID,D_Name,D_Expirenace,D_Speciality,D_Age,D_type,D_Address) VALUES('" + did + "','" + txtDName.Text + "','" + expereince + "','" + txtSpeciality.Text + "','" + txtDAge.Text + "','" + txtDType.Text + "','" + txtAddress.Text + "')";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Saved Successfully\nDoctor's ID = " + did);
                       
                        con.Close();

                        txtDAge.Text = "";
                        txtDName.Text = "";
                        txtAddress.Text = "";
                        txtDType.Text = "";
                        txtExperience.Text = "";
                        txtSpeciality.Text = "";

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }

            }
       
    }
    }
    


