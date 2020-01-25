using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using JOOTASHOP.Models;
using System.Data;

namespace JOOTASHOP.Manager
{
    public class DatabaseOperations
    {

        protected SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-55RJ8FH;Initial Catalog=jootaShop;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

        public DatabaseOperations()
        {

        }


        public int AddDAta(productTable table)
        {
            int a = 0;
            con = new SqlConnection(@"Data Source=DESKTOP-55RJ8FH;Initial Catalog=jootaShopDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            string query = "";
            con.Open();
            query = "insert into productTable(name,catagoryID,imagePath,price,quantity) values('" + table.name + "',(select catagoryID from catagoryTable where catagoryName='" + table.catagoryName + "'),'" + table.imagePath + "','" + table.price + "','" + table.quantity + "')";


            SqlCommand cmd = new SqlCommand(query, con);
            a = cmd.ExecuteNonQuery();
            con.Close();


            return a;

        }

        internal void sendConfirmaOrderMail(confirmOrder model)
        {
            List <menTable> list= readCart();
            String Message = "Name: " + model.name + "\nContact: " + model.Contact + "\nEmail: " + model.Email + "\nAddress: " + model.Address;

            foreach (var item in list)
            {
                Message += "\nName: " + item.Name + " - ProductID: " + item.ID+ " - Price: " + item.Price;

            }

            sendMail mail = new sendMail();
            mail.mail("Order From " + model.name, Message);

            string query = "Delete cartTable";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();


        }

        internal void deleteProduct(object _ID)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-55RJ8FH;Initial Catalog=jootaShopDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            string query = "";
       
                query = "Delete from productTable where(productID='" + _ID + "')";


          
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        internal void Addtocart(int _ID)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-55RJ8FH;Initial Catalog=jootaShopDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            string query = "select * from productTable where productID='"+_ID+"'";
         
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            string[] data = new string[4];

            Models.productTable pt = new productTable();
            while (reader.Read())
            {
                pt.ProductID = Convert.ToInt32(reader[0]);
                pt.name= reader[1].ToString();
                pt.catagoryID = Convert.ToInt32(reader[2]);
                pt.imagePath = reader[3].ToString();
                pt.price = Convert.ToInt32(reader[4]);
                pt.quantity = Convert.ToInt32(reader[5]);

                

                

            }

           
            con.Close();

            con = new SqlConnection(@"Data Source=DESKTOP-55RJ8FH;Initial Catalog=jootaShop;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            con.Open();
            cmd = new SqlCommand("insert into cartTable(Name,Price,ImagePath,Qty) values('" + pt.name + "','" + pt.price + "','" + pt.imagePath + "','" + pt.quantity + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
               return;
        }

        public List<productTable> readManData(int option = 0)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-55RJ8FH;Initial Catalog=jootaShopDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            string query = "Select * from productTable where catagoryID='1'";

            if (option == 1)
            {
                query = "Select * from productTable where catagoryID='3'";

            }
            else if (option == 2)
            {
                query = "Select * from productTable where catagoryID='2'";
            }
            else if (option == 3)
            {
                query = "Select * from productTable where catagoryID='1'";
            }
            else
            {
                query = "Select * from productTable";

            }
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();

            List<productTable> tableData = new List<productTable>();

            foreach (DataRow item in dt.Rows)
            {
                productTable cst = new productTable()
                {
                    ProductID = Convert.ToInt32(item["productID"].ToString()),
                    name = item["name"].ToString(),
                    catagoryID = Convert.ToInt32(item["catagoryID"]),
                    price = Convert.ToInt32(item["price"].ToString()),
                    imagePath = item["imagePath"].ToString(),
                    quantity = Convert.ToInt32(item["quantity"]),






                };

                tableData.Add(cst);


            }
                return tableData;
            
        }


    public void deleteDAtaFromCart(int a)
    {
        string query = "Delete From cartTable where(ID='" + a + "')";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();

    }


    public List<menTable> readCart()
    {
        string query = "Select * from cartTable";


        con.Open();
        SqlDataAdapter adp = new SqlDataAdapter(query, con);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        con.Close();

        List<menTable> tableData = new List<menTable>();
        foreach (DataRow item in dt.Rows)
        {
            menTable cst = new menTable()
            {
                ID = Convert.ToInt32(item["ID"].ToString()),
                productID = item["produtID"].ToString(),
                Name = item["Name"].ToString(),
                Price = Convert.ToInt32(item["Price"].ToString()),
                ImagePath = item["ImagePath"].ToString(),
                





            };

            tableData.Add(cst);

        }

        return tableData;
    }

    public int AddCatagory(string text)
    {
        con = new SqlConnection(@"Data Source=DESKTOP-55RJ8FH;Initial Catalog=jootaShopDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into catagoryTable(catagoryName) values('" + text.ToUpper() + "')", con);
        int a = cmd.ExecuteNonQuery();
        con.Close();
        return a;

    }

    public List<string> getCatagories()
    {
        List<string> data = new List<string>();
        con = new SqlConnection(@"Data Source=DESKTOP-55RJ8FH;Initial Catalog=jootaShopDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        con.Open();
        SqlCommand cmd = new SqlCommand("Select catagoryName from catagoryTable", con);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            data.Add(reader[0].ToString());
        }
        return data;
    }





    }

}
