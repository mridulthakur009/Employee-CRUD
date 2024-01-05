using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeDetails_3Dec_new
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(); //using System.Data.SqlClient;
        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString; //ConfigurationManager -- using System.Configuration;

            dispRec();

            if (con.State == ConnectionState.Closed) //ConnectionState -- using System.Data;
            {
                con.Open();
            }
        }
        public void clearRec() // Function to clear records form the text-boxes and move cursor to 1st text box
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox1.Focus();
        }
        public void dispRec()  // Function to Display records of Employee in grid
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                //Display Data using using inline query:
                //cmd.CommandText = "SELECT * FROM empDetails";

                //Display Data using Stored procedure:
                cmd.CommandText = "dispEmp";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                con.Close();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error while data is loading1234567');", true);
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                //document.querySelector("#empNoError").innerHTML = "Please fill Employee Number";
                //document.querySelector("#nameError").innerHTML = "Please fill Employee Name";
                //document.querySelector("#emailError").innerHTML = "Please fill Employee Email";
                //document.querySelector("#addressError").innerHTML = "Please fill Employee Address";

                //Create Operation using inline query:
                cmd.CommandText = "INSERT INTO empDetails VALUES(@eNo, @empName, @empEmail, @empAdd)";

                //Create Operation using Stored procedure:
                //cmd.CommandText = "saveEmp";
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@eNo", TextBox1.Text);
                cmd.Parameters.AddWithValue("@empName", TextBox2.Text);
                cmd.Parameters.AddWithValue("@empEmail", TextBox3.Text);
                cmd.Parameters.AddWithValue("@empAdd", TextBox4.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data Saved Successfully');", true); // To show alert.
                clearRec();
                dispRec();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error while saving data');", true);
            }
        }
        //[WebMethod]
        //public static string addData(string empNo, string name, string email, string address)
        //{
        //    string msg = "";
        //    SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-TUED6VO\SQLEXPRESS;Initial Catalog=testDB;Integrated Security=True");
        //    SqlDataAdapter cmd = new SqlDataAdapter();
        //    SqlCommand cmd1 = new SqlCommand("INSERT INTO empDetails VALUES(@empNo, @Name, @Email, @Address)");
        //    cmd1.Parameters.AddWithValue("@empNo", empNo);
        //    cmd1.Parameters.AddWithValue("@Name", name);
        //    cmd1.Parameters.AddWithValue("@Email", email);
        //    cmd1.Parameters.AddWithValue("@Address", address);
        //    cmd1.Connection = con1;
        //    con1.Open();
        //    cmd1.ExecuteNonQuery();
        //    return msg;
        //}
        protected void displayButton_Click(object sender, EventArgs e)
        {
            dispRec();
        }
        protected void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                //Update employee details using inline query
                //cmd.CommandText = "UPDATE empDetails SET Name = @empName, Email = @empEmail, Address= @empAdd where empNo=@eNo";

                //Update Employee using Stored procedure:
                cmd.CommandText = "updEmp";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@eNo", TextBox1.Text);
                cmd.Parameters.AddWithValue("@empName", TextBox2.Text);
                cmd.Parameters.AddWithValue("@empEmail", TextBox3.Text);
                cmd.Parameters.AddWithValue("@empAdd", TextBox4.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Employee Data Updated Successfully');", true);
                dispRec();
                clearRec();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error While Updating Data');", true);
            }
        }
        protected void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                //Update employee details using inline query:
                //cmd.CommandText = "DELETE from empDetails where empNo=@eNo";

                //Update Employee using Stored procedure:
                cmd.CommandText = "delEmp";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@eNo", TextBox1.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                dispRec();
                clearRec();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Employee Data Deleted Successfully');", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error While Deleting Data');", true);
            }
        }
    }
}