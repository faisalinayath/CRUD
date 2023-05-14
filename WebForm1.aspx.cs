using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnSubmit_Click(object sender, EventArgs e)
		{
		
			string firstName = Request.Form["txtFirstName"];
			string lastName = Request.Form["txtLastName"];
			string email = Request.Form["txtEmail"];
			string phone = Request.Form["txtPhone"];

			string connectionString = "Data Source=DESKTOP-MCU9GFE;Initial Catalog=Bulky;Integrated Security=True";

			string query = "INSERT INTO Customers(FirstName, LastName, Email, Phone) VALUES (@firstName, @lastName, @email, @phone)";

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@firstName", firstName);
						command.Parameters.AddWithValue("@lastName", lastName);
						command.Parameters.AddWithValue("@email", email);
						command.Parameters.AddWithValue("@phone", phone);

						connection.Open();
						int rowsAffected = command.ExecuteNonQuery();
						connection.Close();

						Response.Write("Record inserted successfully!");
					}
				}
			}
			catch (Exception ex)
			{
				Response.Write("Error: " + ex.Message);
			}
		}


	}
}