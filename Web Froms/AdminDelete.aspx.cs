using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebsite
{
    public partial class AdminDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["secure"]) < 2)
                Response.Redirect("loginPage.aspx");
            else if (Convert.ToInt32(Session["secure"]) < 80)
                Response.Redirect("homePage.aspx");

            if (Page.IsPostBack)
            {
                Connection conn = new Connection("DELETE FROM users WHERE UUserName='" + Request.QueryString["user"] + "' AND Upassword='" + deletionPass.Text + "';");

                conn.cmd.Connection.Open();
                int count = conn.cmd.ExecuteNonQuery();
                conn.connection.Close();

                if (count == 1)
                {
                    Response.Redirect("usersPage.aspx");
                }
                else
                    status.Text = "<font color=\"Red\" > Failed to delete User ! </font>";
            }

        }
    }
}