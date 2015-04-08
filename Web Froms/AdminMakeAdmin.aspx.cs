using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebsite
{
    public partial class AdminMakeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["secure"]) < 10)
                Response.Redirect("Error.aspx");

            if (Page.IsPostBack)
            {
                Connection conn = new Connection("UPDATE users SET USecurity='90' WHERE UUserName='" + Request.QueryString["user"] + "';");

                conn.cmd.Connection.Open();
                int count = conn.cmd.ExecuteNonQuery();
                conn.connection.Close();

                if (count == 1)
                {
                    Response.Redirect("homePage.aspx");
                }
                else
                    status.Text = "<font color=\"Red\" > Failed to admini User ! </font>";
            }
        }
    }
}