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
    public partial class Register : System.Web.UI.Page
    {
        public bool isValidy;
        protected UserData userData = new UserData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["secure"]) > 2)
                Response.Redirect("homePage.aspx");

            this.Birthday();
            userData = new UserData(this.userName.Text, this.password.Text, this.firstName.Text, this.lastName.Text, this.email.Text, getBirthday(), 10);

            string repass = this.rePassword.Text;
            
            Connection conn = new Connection("SELECT * FROM users WHERE UUserName='" + userData.userName + "';");
            conn.initDS();

            if (Page.IsPostBack)
            {

                if (userData.password != repass)
                    this.status.Text = "Password Doesn't Match!";
                else if (userData.firstName == null || userData.lastName == null || userData.email == null)
                    this.status.Text = "Few fields are missing";
                else if (Request.Form["Gender"] == null)
                {
                    this.status.Text = "Gender not specified!";
                }
                else
                {
                    bool gender = Request.Form["Gender"].Equals("male") ? true : false;
                    userData.userGender = gender;
                    if (conn.ds.Tables[0].Rows.Count == 0)
                    {
                        conn.cmd.CommandText = @"INSERT INTO users VALUES ('" + userData.userName + "','" + userData.password + "'," + userData.securityLevel + ",'" + userData.firstName + "','" + userData.lastName + "'," + userData.userGender + ",'" + userData.email + "','" + userData.dateOfBirth + "');";
                        conn.cmd.Connection = conn.connection;
                        conn.connection.Open();
                        try
                        {
                            int cnt = conn.cmd.ExecuteNonQuery();
                            conn.connection.Close();

                            if (cnt == 1)
                            {
                                Session["secure"] = 10;
                                Session["user"] = userData.userName;
                                Session["pass"] = userData.password;
                                Response.Redirect("homePage.aspx");
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                        }
                        finally
                        {
                            Response.Redirect("Register.aspx");
                        }

                    }
                }
            }
        }

        public void Birthday()
        {
            for (int i = 1; i <= 31; i++)
            {
                birthdayDay.Items.Add("" + i + "");
            }

            for (int i = 1; i <= 12; i++)
            {
                birthdayMonth.Items.Add("" + i + "");
            }

            for (int i = 1920; i <= 2015; i++)
            {
                birthdayYear.Items.Add("" + i + "");
            }
        }

        public string getBirthday()
        {
            string birthday;
            if (Convert.ToInt32(this.birthdayDay.SelectedValue) < 10)
            {
                birthday = "0" + birthdayDay.SelectedValue + "/";
                if (Convert.ToInt32(this.birthdayMonth.SelectedValue) < 10)
                    birthday += "0" + this.birthdayMonth.SelectedValue + "/";
                else
                    birthday += this.birthdayMonth.SelectedValue + "/";
            }
            else
            {
                birthday = birthdayDay.SelectedValue + "/";
                if (Convert.ToInt32(this.birthdayMonth.SelectedValue) < 10)
                    birthday += "0" + this.birthdayMonth.SelectedValue + "/";
                else
                    birthday += this.birthdayMonth.SelectedValue + "/";
            }
            birthday += this.birthdayYear.SelectedValue;

            return birthday;
        }
    }
}