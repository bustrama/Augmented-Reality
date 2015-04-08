using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebsite
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["countUpdated"] == null)
            {
                if (Application["count"] != null)
                {
                    Application.Lock();
                    int x = int.Parse(Application["count"].ToString());
                    x++;
                    Application["count"] = x;
                    Application.UnLock();
                    Session["countUpdated"] = "";
                }
            }
        }

        public void siteMenu()
        {
            string menu = null;

            if (Convert.ToInt32(Session["secure"]) < 10)
            {
                menu += "<li><a href=\"loginPage.aspx\"><span>Login</span></a></li>"; //Login Tab
                menu += "<li class='last'><a href=\"Register.aspx\"><span>Register</span></a></li>"; //Register Tab
            }
            if (Convert.ToInt32(Session["secure"]) >= 10)
            {
                menu += "<li class='active has-sub'><a href='#'><span>" + Session["user"] + "</span></a><ul>"; //User Control
                if (Convert.ToInt32(Session["secure"]) > 80)
                {
                    menu += "<li class='last'><a href=\"usersPage.aspx\"><span>Users List</span></a></li>";
                    menu += "<li class='last'><a href=\"searchUser.aspx\"><span>Search User</span></a></li>";
                }
                menu += "<li class='last'><a href=\"updateUser.aspx\"><span>Edit Profile</span></a></li>";
                menu += "<li class='last'><a href=\"updateUserPassword.aspx\"><span>Change Password</span></a></li>";
                if (Convert.ToInt32(Session["secure"]) < 80)
                {
                    menu += "<li class='last'><a href=\"deleteUser.aspx\"><span>Delete User</span></a></li>";
                }
                menu += "<li class='last'><a href=\"logout.aspx\"><span>Logout</span></a></li>";
                menu += "</ul></li>";
            }
            menu += "</ul>";

            Response.Write(menu);
        }

        public void paddingRight()
        {
            string padding = "style=\"padding-right: ";

            if (Convert.ToInt32(Session["secure"]) >= 10)
                padding += "50%";
            else
                padding += "45%";
            padding += "; padding-top: 4%; float: right\"";

            Response.Write(padding);
        }
    }
}