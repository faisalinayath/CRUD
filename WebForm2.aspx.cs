using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication4
{
	public partial class WebForm2 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			
				string connectionString = "Data Source=DESKTOP-MCU9GFE;Initial Catalog=Bulky;Integrated Security=True";
				string query = "SELECT * FROM customers";

				using (SqlConnection connection=new SqlConnection(connectionString)) 
				{
					SqlCommand command=new SqlCommand(query, connection);
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					myRepeater.DataSource = reader;
					myRepeater.DataBind();
					reader.Close();
				}
			
		}

		protected void myRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			if (e.CommandName == "Edit")
			{
				string customerId = e.CommandArgument.ToString();
				// Perform the edit operation here using the customerId
			}
			else if (e.CommandName == "Delete")
			{
				string Id = e.CommandArgument.ToString();
				int customerId = Convert.ToInt32(Id);

				string query = "delete from customers where CustomerID = @CustomerId";

				string connectionString = "Data Source=DESKTOP-MCU9GFE;Initial Catalog=Bulky;Integrated Security=True";

				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@CustomerId", customerId);
						conn.Open();
						int rowsAffected = cmd.ExecuteNonQuery();
						conn.Close();

					}
				}
			}

		}

	}
}