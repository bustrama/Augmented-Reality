using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebsite
{
    public partial class updateUserPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["secure"]) < 2)
                Response.Redirect("loginPage.aspx");

            Connection conn = new Connection("SELECT * FROM users WHERE UUserName='" + Session["user"] + "';");
            conn.initDS();
            DataRow userData = conn.ds.Tables[0].Rows[0];

            if (Page.IsPostBack)
            {
                if (userData["Upassword"].ToString() == this.oldPassword.Text && this.newPassword.Text == this.reNewPass.Text)
                {
                    string updateUser = "UPDATE users SET ";
                    updateUser += "Upassword='" + this.newPassword.Text + "'";
                    updateUser += " Where UUserName='" + Session["user"] + "';";

                    conn.cmd.CommandText = updateUser;
                    conn.cmd.Connection.Open();
                    int cnt = conn.cmd.ExecuteNonQuery();
                    conn.cmd.Connection.Close();

                    if (cnt == 1)
                    {
                        this.status.ForeColor = System.Drawing.Color.Green;
                        this.status.Text = "Profile Updated Successfully!";
                    }
                    else
                    {
                        this.status.ForeColor = System.Drawing.Color.Red;
                        this.status.Text = "Failed To Update Profile!";
                    }
                }
                else
                {
                    this.status.ForeColor = System.Drawing.Color.Red;
                    this.status.Text = "Password Incorrect!";
                }
            }
        }
    }
}
