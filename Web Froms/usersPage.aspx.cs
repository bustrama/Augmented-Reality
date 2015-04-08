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
    public partial class usersPage : System.Web.UI.Page
    {
        Connection conn = new Connection("Select * FROM users");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["secure"]) < 80)
            {
                Session["LastPage"] = "usersPage.aspx";
                Response.Redirect("Error.aspx");
            }
            conn.initDS();
        }

        public void ListOfUsers()
        {
            string allUsersString = "";
            allUsersString += "<table border=\"1\" style=\"text-align:center;\"> <tr style=\"background: #FFFF80\"> <td>User Name</td><td>Password</td><td>Secure Level</td><td>First Name</td><td>Last Name</td><td>Gender</td><td>Email</td><td>Date of Birth</td><td>Update User</td><td>Reset Password</td><td>Administrate</td><td>Delete User</td> </tr>";
            foreach (DataRow row in conn.ds.Tables[0].Rows)
            {
                allUsersString += "<tr>";
                if (Convert.ToInt32(row["USecurity"]) < 99)
                {
                    allUsersString += "<td>" + row["UUserName"] + "</td>";
                    allUsersString += "<td>" + row["Upassword"] + "</td>";
                    allUsersString += "<td>" + row["USecurity"] + "</td>";
                    allUsersString += "<td>" + row["UFirstName"] + "</td>";
                    allUsersString += "<td>" + row["ULastName"] + "</td>";
                    if (Convert.ToBoolean(row["UGender"]) == true)
                        allUsersString += "<td>Male</td>";
                    else
                        allUsersString += "<td>Female</td>";
                    allUsersString += "<td>" + row["UEmail"] + "</td>";
                    allUsersString += "<td>" + row["UBirthday"] + "</td>";
                    if (Convert.ToInt32(row["USecurity"]) < 90)
                    {
                        allUsersString += "<td> <a href='AdminUpdate.aspx?user=" + row["UUserName"] + "'> Update </a> </td>";
                        allUsersString += "<td> <a href='AdminUpdatePassword.aspx?user=" + row["UUserName"] + "'> Reset </a> </td>";
                        allUsersString += "<td> <a href='AdminMakeAdmin.aspx?user=" + row["UUserName"] + "'> Admini </a> </td>";
                        allUsersString += "<td> <a href='AdminDelete.aspx?user=" + row["UUserName"] + "'> Delete </a> </td>";
                    }
                }
                allUsersString += "</tr>";
            }
            allUsersString += "</table>";
            Response.Write(allUsersString);
        }
    }
}