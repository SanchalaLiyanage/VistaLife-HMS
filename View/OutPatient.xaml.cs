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
    /// Interaction logic for OutPatient.xaml
    /// </summary>
    public partial class OutPatient : Window
    {
        public OutPatient()
        {
            InitializeComponent();
            // Load doctors 
            Lord lord1 = new Lord();
           lord1.LoadDoctors("D_Name", "Doctor",  txtDName);

          /*  Lord lord2 = new Lord();
            lord2.LoadDoctors("D_Speciality", "Doctor",txtSpeciality);*/


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
            txtDName.Text = "";
            txtDate.Text = "";
            txtPAddress.Text = "";
            txtPAge.Text = "";
            txtPName.Text = "";
            txtSpeciality.Text = "";


        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            var flag = 0;
            var message = "";


            if (string.IsNullOrWhiteSpace(txtPName.Text))
            {   flag = 1;
                message += "Patient Name is required\n";
            }
            if (string.IsNullOrWhiteSpace(txtPAge.Text))
            {        flag = 1;
                     message += "Patient Age is required\n";
            }
            if (txtPAge.Text != "")
            {
                bool isNotNumeric = !int.TryParse(txtPAge.Text, out _) || txtPAge.Text.Length > 2;
                if (isNotNumeric)
                {

                    flag = 1;
                    message += "Age is Invalid\n";


                }

            }
            if (string.IsNullOrWhiteSpace(txtPAddress.Text))
            {        flag = 1;
                      message += "Patient Address is required\n";
            }
            if (string.IsNullOrWhiteSpace(txtDName.Text))
            {        flag = 1;
                     message += "Doctor Name is required\n";
            }
            if (string.IsNullOrWhiteSpace(txtDate.Text))
            {        flag = 1;
                     message += "Date is required\n";
             }
            if (string.IsNullOrWhiteSpace(txtSpeciality.Text))
            {        flag = 1;
                     message += "Speciality is required\n";
            }


            if (flag == 1)
            {
                MessageBox.Show(message);
            }

            else
            {
                try
                {
                    //Make connection whith connection class

                    Connectioncs ConObj = new Connectioncs();

                    SqlConnection Con = ConObj.GetDBCon();


                          string sqlRead = $"SELECT D_ID from Doctor where D_Name='{txtDName.Text}'";

                          SqlCommand cmdobj1 = new SqlCommand(sqlRead,Con);
                          SqlDataReader reader = cmdobj1.ExecuteReader();
                    String rr = "";
                    if (reader.Read())
                    {
                        rr = reader.GetString(0);
                    }
                    reader.Close();
                    


                        IDGenerator id = new IDGenerator();
                    string opid = id.GenerateID("OP_ID");
                    String pid = id.GenerateID("P_ID");
                    String apid = id.GenerateID("AP_ID");
                  //  MessageBox.Show("Your Patient's ID = " + pid);

                    
                    string query1 = "INSERT INTO patient (P_ID,P_Name,P_Age,P_Address) VALUES ('" + pid + "','" + txtPName.Text + "','" + txtPAge.Text + "','" + txtPAddress.Text + "')";
                    SqlCommand cmd1 = new SqlCommand(query1, Con);
                    cmd1.ExecuteNonQuery();

                    string query2 = "INSERT INTO OutPatient (OP_ID,Dates,P_ID) VALUES ('" + opid + "','" + txtDate.Text + "','" + pid + "')";
                    SqlCommand cmd2 = new SqlCommand(query2, Con);
                    cmd2.ExecuteNonQuery();

                    string query3 = "INSERT INTO Doctor_OutPatient (OP_ID,AP_ID,D_ID) VALUES ('" + opid + "','" + apid + "','"+rr+"')";
                    SqlCommand cmd3 = new SqlCommand(query3, Con);
                    cmd3.ExecuteNonQuery();

                    Con.Close();

                    MessageBox.Show("Data Saved Successfully\nYour Patient's ID = " + pid);

                    txtDName.Text = "";
                    txtDate.Text = "";
                    txtPAddress.Text = "";
                    txtPAge.Text = "";
                    txtPName.Text = "";
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
