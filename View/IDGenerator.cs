using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VistaLife.View
{
    internal class IDGenerator
    {
        //random number generator

        public  string GenerateID(String idType)
        {

            Connectioncs ConObj = new Connectioncs();
            SqlConnection Con = ConObj.GetDBCon();
            int idcount = -1;
            int idLength = 0;
            string idStart = "null";
            string table = "null";

            if (idType == "M_ID")
            {
                idStart = "M";
                idLength = 4;
                table = "Minor_Staff";
            }
            if (idType == "D_ID")
            {
                idStart = "D";
                idLength = 4;
                table = "Doctor";
            }
            if (idType == "P_ID")
            {
                idStart = "P";
                idLength = 4;
                table = "patient";
            }
            if (idType == "N_ID")
            {
                idStart = "N";
                idLength = 4;
                table = "nurse";
            }

            if (idType == "OP_ID")
            {
                idStart = "OP";
                idLength = 4;
                table = "OutPatient";
            }
            if (idType == "IP_ID")
            {
                idStart = "AD";
                idLength = 4;
                table = "InPatient";
            }
            if (idType == "W_ID")
            {
                idStart = "W";
                idLength = 4;
                table = "Ward";
            }
            if (idType == "S_ID")
            {
                idStart = "S";
                idLength = 4;
                table = "Service";
            }
            if (idType=="AP_ID")
            {
                idStart = "AP";
                idLength = 4;
                table = "Doctor_OutPatient";
                
            }
            if (idType == "AD_ID")
            {
                idStart = "AD";
                idLength = 4;
                table = "Ward_InPatient_Doctor";

            }
            if(idType == "B_ID")
            {
                idStart = "B";
                idLength = 4;
                table = "Bill";

            }


            if (idType != null && idStart != "null" && idLength != 0 && table != "null")
            {
                Random random = new Random();
                const string chars = "0123456789";
                StringBuilder ID = new StringBuilder(idStart, idLength);  //Creating string using stringbuilder

                while (idcount != 0)
                {
                    while (ID.Length < idLength)
                    {
                        ID.Append(chars[random.Next(chars.Length)]); //Add random string to from chars to ID 
                    }

                    try
                    {
                        string sql = $"SELECT COUNT(*) FROM {table} WHERE {idType} = '{ID.ToString()}'"; //Find if the genarated ID is already available in the database
                        SqlCommand cmd = new SqlCommand(sql,Con);

                        idcount = (int)cmd.ExecuteScalar(); //Set the result to idcount in int format 

                        if (idcount == 0)
                        {
                            break;
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show($"An Error occured while genarating new {idType} ID\n" + ex.Message);
                        break;
                    }
                }

                if (idcount == 0) //When ID genarate success return the ID
                {
                    return ID.ToString();
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }

        }
    }
}



    




