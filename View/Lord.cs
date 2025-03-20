using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;

namespace VistaLife.View
{
    internal class Lord
    {
        public void LoadDoctors(String column, String table, ComboBox combo )
        {

           
           
            try
            {
                {
                    Connectioncs ConObj = new Connectioncs();

                    SqlConnection Con = ConObj.GetDBCon();
                    string query = $"SELECT {column} FROM {table}";
                    SqlCommand command = new SqlCommand(query, Con);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string doctorName = reader[$"{column}"].ToString();
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = doctorName;
                        combo.Items.Add(item);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public void LoadDoctors(String column, String table,String conditioncol,String condition ,ComboBox combo)
        {



            try
            {
                {
                    Connectioncs ConObj = new Connectioncs();

                    SqlConnection Con = ConObj.GetDBCon();
                    string query = $"SELECT {column} FROM {table}  WHERE {conditioncol} = '{condition}'";
                    SqlCommand command = new SqlCommand(query, Con);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string doctorName = reader[$"{column}"].ToString();
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = doctorName;
                        combo.Items.Add(item);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     

}
}
