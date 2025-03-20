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
using VistaLife.Resource;

namespace VistaLife.View
{
    /// <summary>
    /// Interaction logic for Bill.xaml
    /// </summary>
    public partial class Bill : Window
    {
        public Bill()
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
            txtPName.Text = "";
            combobox_type.Text = "";
            txtdisDate.Text = "";
            chek_blood.IsChecked = false;
            chek_CTscan.IsChecked = false;
            chek_ECG.IsChecked = false;
            chek_Eco.IsChecked = false;
            chek_EEG.IsChecked = false;
            chek_Endoscopy.IsChecked = false;
            chek_MRIscan.IsChecked = false;
            chek_Xray.IsChecked = false;
            
            TotBillShow.Content = "";
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int flag = 0;
            String message = "";
            float total = 0;
            if (chek_blood.IsChecked == true)
            {
                total=total+ 1500;
               
            }
            if (chek_CTscan.IsChecked == true)
            {
                total = total + 50000;
            }
            if (chek_ECG.IsChecked == true)
            {
                total = total + 1000;
            }
            if (chek_Eco.IsChecked == true)
            {
                total = total + 2000;
            }
            if (chek_EEG.IsChecked == true)
            {
                total = total + 3000;
            }
            if (chek_Endoscopy.IsChecked == true)
            {
                total = total + 4000;
            }
            if (chek_MRIscan.IsChecked == true)
            {
                total = total + 60000;
            }
            if (chek_Xray.IsChecked == true)
            {
                total = total + 2000;
            }
            if (String.IsNullOrEmpty(txtPName.Text))
            {
             message += "Please Enter Patient's ID Number";
            }
            if (String.IsNullOrEmpty(combobox_type.Text))
            {
                message +="Please Seletc Patient's Type";
            }
            if (flag == 1)
            {
                MessageBox.Show(message);
            }


            if (combobox_type.Text == "Out Patient")
                    {
                        total = total + 2000;
                    }

                    if (combobox_type.Text == "In Patient")
                    {
                        if (String.IsNullOrEmpty(txtdisDate.Text))
                        {
                            MessageBox.Show("Please Enter Number of Addmitted Date");

                        }
                        else
                        {
                            float date = float.Parse(txtdisDate.Text);
                            float hospital = 5000 * date;
                            total = total + hospital;
                        }

                    }

                TotBillShow.Content = "RS." + total;

            
            
            
        }

        private void btnPayClick(object sender, RoutedEventArgs e)
        {
            int flag = 0;
            String message = "";
            float total = 0;
            if (chek_blood.IsChecked == true)
            {
                total = total + 1500;

            }
            if (chek_CTscan.IsChecked == true)
            {
                total = total + 50000;
            }
            if (chek_ECG.IsChecked == true)
            {
                total = total + 1000;
            }
            if (chek_Eco.IsChecked == true)
            {
                total = total + 2000;
            }
            if (chek_EEG.IsChecked == true)
            {
                total = total + 3000;
            }
            if (chek_Endoscopy.IsChecked == true)
            {
                total = total + 4000;
            }
            if (chek_MRIscan.IsChecked == true)
            {
                total = total + 60000;
            }
            if (chek_Xray.IsChecked == true)
            {
                total = total + 2000;
            }
            if (String.IsNullOrEmpty(txtPName.Text))
            {
                message += "Please Enter Patient's ID Number";
            }
            if (String.IsNullOrEmpty(combobox_type.Text))
            {
                message += "Please Seletc Patient's Type";
            }
            if (flag == 1)
            {
                MessageBox.Show(message);
            }


            if (combobox_type.Text == "Out Patient")
            {
                total = total + 2000;
            }

            if (combobox_type.Text == "In Patient")
            {
                if (String.IsNullOrEmpty(txtdisDate.Text))
                {
                    MessageBox.Show("Please Enter Number of Addmitted Date");

                }
                else
                {
                    float date = float.Parse(txtdisDate.Text);
                    float hospital = 5000 * date;
                    total = total + hospital;
                }

            }

            TotBillShow.Content = "RS." + total;

        }
    }
}
