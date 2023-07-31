using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Job_Portal.Models
{
    public class Procs
    {
        public static string Getconnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["JobContext"].ConnectionString;
            }
        }
        public static void InsertContactForAnyQuery(string Name,int? Mobile, string Email,string Subjects,string Message)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("InsertContactForAnyQuery", con);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Subject", Subjects);
            cmd.Parameters.AddWithValue("@Message", Message);
            
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally { con.Close(); }
        }
    }
}