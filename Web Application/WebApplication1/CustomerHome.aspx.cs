using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class CustomerHome : System.Web.UI.Page
    {
        string _connStr = ConfigurationManager.ConnectionStrings["OliviaDBContext"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string queryStr = "SELECT * FROM Customer WHERE @custID = custID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@custID", 1);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Session["custID"] = int.Parse(dr["custID"].ToString());
                Session["custFname"] = dr["custFname"].ToString();
                Session["custLname"] = dr["custLname"].ToString();
                Session["custEmail"] = dr["custEmail"].ToString();

            }
            else
            {
                Session["custID"] = null;
                Session["custFname"] = null;
                Session["custLname"] = null;
                Session["custEmail"] = null;

            }

            conn.Close();
            dr.Close();
            dr.Dispose();
        }

    }
}