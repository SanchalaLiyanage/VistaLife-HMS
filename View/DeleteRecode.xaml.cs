using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
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
using System.Data.Common;
using System.Windows.Controls.Primitives;

namespace VistaLife.View
{
    /// <summary>
    /// Interaction logic for DeleteRecode.xaml
    /// </summary>
    public partial class DeleteRecode : Window
    {
        public DeleteRecode()
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

            txtPID.Text = "";
            DataGridViewIN.ItemsSource = null;
            DataGridViewOUT.ItemsSource = null;
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(txtPID.Text))
            {
                MessageBox.Show("Please fill the required fields");
            }
            else
            {

                String id = txtPID.Text;

                Connectioncs connectioncs = new Connectioncs();
                SqlConnection con = connectioncs.GetDBCon();


                string query1 = $"SELECT P.*, OP.*, B.* " +
                $"FROM patient P " +
                $"LEFT JOIN OutPatient OP ON P.P_ID = OP.P_ID " +
                $"LEFT JOIN bill B ON P.P_ID = B.P_ID " +
                $"WHERE P.P_ID = '{id}'";




                string query = $"SELECT P.P_ID, IP.IP_ID, P.P_Name,IP.IP_Admitted_Date,B.Payment_type, B.cost " +
                  $"FROM patient P" +
                  $" LEFT JOIN IN_Patient IP ON P.P_ID = IP.P_ID" +
                  $" LEFT JOIN Bill B ON P.P_ID=B.P_ID " +
                  $"WHERE P.P_ID = '{id}'";

                SqlCommand cmd = new SqlCommand(query, con);
                DataTable datatableobj = new DataTable();
                using SqlDataAdapter adapObj = new SqlDataAdapter(cmd);
                {
                    adapObj.Fill(datatableobj);
                }
                DataGridViewIN.ItemsSource = datatableobj.DefaultView;





                string query2 = $"SELECT P.P_ID, OP.OP_ID, P.P_Name, OP.Dates, B.Payment_type, B.cost " +
                $"FROM patient P " +
                $"LEFT JOIN OutPatient OP ON P.P_ID = OP.P_ID " +
                $"LEFT JOIN Bill B ON P.P_ID = B.P_ID " +
                $"WHERE P.P_ID = '{id}'";

                SqlCommand cmd1 = new SqlCommand(query2, con);
                DataTable datatableobj1 = new DataTable();
                using SqlDataAdapter adapObj1 = new SqlDataAdapter(cmd1);
                {
                    adapObj1.Fill(datatableobj1);
                }
                DataGridViewOUT.ItemsSource = datatableobj1.DefaultView;




            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)

        {
         /*   // Get the selected row
            DataGridRow selectedRow1 = (DataGridRow)DataGridViewOUT.ItemContainerGenerator.ContainerFromItem(DataGridViewOUT.SelectedItem);
            DataGridRow selectedRow2 = (DataGridRow)DataGridViewOUT.ItemContainerGenerator.ContainerFromItem(DataGridViewOUT.SelectedItem);

            if (selectedRow1 != null && selectedRow2 != null)
            {
                // Get the data item behind the selected row
                DataRowView rowView1 = (DataRowView)selectedRow1.Item;
                DataRowView rowView2 = (DataRowView)selectedRow2.Item;


                // Read data from the selected row
                string cellValue1 = rowView1.Row["IP_ID"].ToString();
                string cellValue2 = rowView2.Row["OP_ID"].ToString();

                // Do something with the data
                MessageBox.Show($"Selected row data: {cellValue1}, {cellValue2}");
            }
            else
            {
                MessageBox.Show("Please View and Select a record to do Billing Process");
            }*/

        }
    }
}
