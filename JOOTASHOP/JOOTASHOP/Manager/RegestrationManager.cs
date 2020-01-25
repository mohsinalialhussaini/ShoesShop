using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using JOOTASHOP.Models;
using System.Web;

namespace JOOTASHOP.Manager
{
    public class RegestrationManager
    {
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-55RJ8FH;Initial Catalog=jootaShopDB;Integrated Security=True");
        public int AddDAta(RegestrationModel _regestrationModel)
        {
            int a = -1;
            if (!AlreadyRegesterd(_regestrationModel))
            {

                con.Open();
                string query = "Insert into loginTable(userName,password) values('" + _regestrationModel.Email + "', '" + _regestrationModel.UserPassword + "')";
                //string query = "Insert into loginTable(Name,Email,CNIC,Password,Contact,isAdmin) values('" + _regestrationModel.firstName + " " + _regestrationModel.lastName + "', '" + _regestrationModel.Email + "','" + _regestrationModel.CNIC + "','" + _regestrationModel.UserPassword + "','" + _regestrationModel.Contact + "','1')";
                
                SqlCommand cmd = new SqlCommand(query, con);
                a = cmd.ExecuteNonQuery();

               query = "Insert into AdminData(ID,name,contact,cnic) values((Select ID from loginTable where userName='" + _regestrationModel.Email + "' And password='" + _regestrationModel.UserPassword + "'),'" + _regestrationModel.firstName + " " + _regestrationModel.lastName + "','" + _regestrationModel.Contact + "','" + _regestrationModel.CNIC + "')";
                cmd = new SqlCommand(query, con);
                a += cmd.ExecuteNonQuery();
                con.Close();
                
            }
            return a;

        }

        public bool AlreadyRegesterd(RegestrationModel _regestrationModel)
        {
            string query = "select * from loginTable where(userName='" + _regestrationModel.Email + "' )";

            con.Open();
            SqlCommand cmd = new SqlCommand(query,con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                con.Close();
                return true;
                
            }

            con.Close();
            return false;

        }
    }
    

}