using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebsite
{
    public partial class searchUser : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["secure"]) < 90)
                Response.Redirect("homePage.aspx");

            if (Page.IsPostBack)
            {
                string sql = "SELECT * FROM users";
                string searchOption = this.searchOption.SelectedValue;
                string search = this.searchInput.Text;

                if (search != null && searchOption != "USecurity")
                    sql = "SELECT * FROM users WHERE " + searchOption + " LIKE " + "'%" + search + "%';";
                else if(search != null && searchOption == "USecurity")
                    sql = "SELECT * FROM users WHERE " + searchOption + "=" + search + ";";

                string connectionString = @"Provider=Microsoft.jet.OleDb.4.0;Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data/SiteDatabase.mdb");
                OleDbConnection connection = new OleDbConnection(connectionString);

                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = sql;
                cmd.Connection = connection;
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

                adapter.Fill(ds);
                connection.Close();
            }
        }

        public void ListOfUsers()
        {
            if (Page.IsPostBack)
            {
                string allUsersString = "<h1>List Of Users</h1>";
                allUsersString += "<table border=\"1\" style=\"text-align:center;\"> <tr style=\"text-align:center;\"> <td>User Name</td><td>Password</td><td>Secure Level</td><td>First Name</td><td>Last Name</td><td>Gender</td><td>Email</td><td>Birthday</td> </tr>";
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    allUsersString += "<tr>";
                    allUsersString += "<td>" + row["UUserName"] + "</td>";
                    allUsersString += "<td>" + row["Upassword"] + "</td>";
                    allUsersString += "<td>" + row["USecurity"] + "</td>";
                    allUsersString += "<td>" + row["UFirstName"] + "</td>";
                    allUsersString += "<td>" + row["ULastName"] + "</td>";
                    if ((bool)row["UGender"])
                        allUsersString += "<td>Male</td>";
                    else
                        allUsersString += "<td>Female</td>";
                    allUsersString += "<td>" + row["UEmail"] + "</td>";
                    allUsersString += "<td>" + row["UBirthday"] + "</td>";
                    allUsersString += "</tr>";
                }
                allUsersString += "</table>";
                Response.Write(allUsersString);
            }
        }
    }
}