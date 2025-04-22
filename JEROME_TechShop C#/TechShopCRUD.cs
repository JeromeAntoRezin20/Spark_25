using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JEROME_TechShop.Util;
using JEROME_TechShop.dao;
using JEROME_TechShop.Entity;


namespace JEROME_TechShop.dao
{
    public class TechShopCRUD : ICustomerDAO
    {
        public void AddCustomer(Customer customer)
        {
            using (var con = DBConnUtil.GetConnection())
            {
                string query = "INSERT INTO Customers (FirstName, LastName, Email, Phone, Address) VALUES (@fn, @ln, @em, @ph, @ad)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@fn", customer.FirstName);
                cmd.Parameters.AddWithValue("@ln", customer.LastName);
                cmd.Parameters.AddWithValue("@em", customer.Email);
                cmd.Parameters.AddWithValue("@ph", customer.Phone);
                cmd.Parameters.AddWithValue("@ad", customer.Address);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = null;
            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "SELECT * FROM Customers WHERE CustomerID = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customer = new Customer()
                    {
                        CustomerID = (int)reader["CustomerID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString()
                    };
                }
            }
            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "UPDATE Customers SET FirstName=@fn, LastName=@ln, Email=@em, Phone=@ph, Address=@ad WHERE CustomerID=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@fn", customer.FirstName);
                cmd.Parameters.AddWithValue("@ln", customer.LastName);
                cmd.Parameters.AddWithValue("@em", customer.Email);
                cmd.Parameters.AddWithValue("@ph", customer.Phone);
                cmd.Parameters.AddWithValue("@ad", customer.Address);
                cmd.Parameters.AddWithValue("@id", customer.CustomerID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCustomer(int id)
        {
            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "DELETE FROM Customers WHERE CustomerID = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
