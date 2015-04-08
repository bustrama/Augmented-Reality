using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebsite
{
    public partial class AdminUpdatePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["secure"]) < 10)
                Response.Redirect("Error.aspx");

            Connection myConn = new Connection("SELECT * FROM users WHERE UUserName='" + Request.QueryString["user"] + "';");
            myConn.initDS();
            DataRow userData = myConn.ds.Tables[0].Rows[0];

            if (Page.IsPostBack)
            {
                if (oldPassword.Text == userData["Upassword"].ToString() && newPassword.Text == reNewPass.Text)
                {
                    myConn = new Connection();

                    string updateUser = "UPDATE users SET ";
                    updateUser += "Upassword='" + newPassword.Text + "'";
                    updateUser += " Where UUserName='" + Request.QueryString["user"] + "';";

                    myConn.cmd.CommandText = updateUser;
                    myConn.cmd.Connection = myConn.connection;
                    myConn.connection.Open();
                    int cnt = myConn.cmd.ExecuteNonQuery();
                    myConn.connection.Close();

                    if (cnt == 1)
                    {
                        this.status.Text = "Updated Successfully!";
                    }
                    else
                    {
                        this.status.Text = "Updated Failed!";
                    }
                }
                else
                    this.status.Text = "Password isn't match!";
            }
        }
    }
}