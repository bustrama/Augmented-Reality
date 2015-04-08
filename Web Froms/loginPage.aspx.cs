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
    public partial class loginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["secure"]) > 2)
                Response.Redirect("homePage.aspx");

            if (IsPostBack)
            {
                string user = Request.Form["user"];
                string pass = Request.Form["password"];

                Connection conn = new Connection("SELECT * FROM users WHERE UUserName='" + user + "'AND Upassword='" + pass + "'");
                conn.initDS();

                if (conn.ds.Tables[0].Rows.Count == 0)
                    Response.Redirect("Error.aspx");
                else
                {
                    Session["secure"] = conn.ds.Tables[0].Rows[0]["USecurity"];
                    Session["user"] = conn.ds.Tables[0].Rows[0]["UUserName"];
                    if (Session["LastPage"] != null)
                        Response.Redirect(Session["lastPage"].ToString());
                    else
                        Response.Redirect("homePage.aspx");
                }
            }
        }
    }
}