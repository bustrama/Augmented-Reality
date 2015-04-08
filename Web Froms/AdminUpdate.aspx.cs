using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MyWebsite
{
    public partial class AdminUpdate : System.Web.UI.Page
    {
        public string updateUser = null;
        protected bool gender { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["secure"]) < 10)
                Response.Redirect("Error.aspx");

            Birthday();
            Connection myConn = new Connection("SELECT * FROM users WHERE UUserName='" + Request.QueryString["user"] + "';");
            myConn.initDS();
            DataRow userData = myConn.ds.Tables[0].Rows[0];
            gender = (bool)userData["UGender"];

            if (!Page.IsPostBack)
            {
                if (this.password.Text != this.rePassword.Text)
                {
                    this.status.Text = "Password Doesn't Match!";
                }
                else
                {
                    this.firstName.Text = userData["UFirstName"].ToString();
                    this.lastName.Text = userData["ULastName"].ToString();
                    this.email.Text = userData["UEmail"].ToString();
                    string birthdayDay, birthdayMonth, birthdayYear;
                    birthdayDay = userData["UBirthday"].ToString().Substring(0, 2);
                    birthdayMonth = userData["UBirthday"].ToString().Substring(3, 2);
                    birthdayYear = userData["UBirthday"].ToString().Substring(6, 4);

                    this.birthdayDay.SelectedIndex = Convert.ToInt32(birthdayDay) - 1;
                    this.birthdayMonth.SelectedIndex = Convert.ToInt32(birthdayMonth) - 1;
                    this.birthdayYear.SelectedIndex = Convert.ToInt32(birthdayYear) - 1920;
                }
            }
            else
            {
                myConn = new Connection();

                gender = Request.Form["Gender"].Equals("male") ? true : false;
                string updateUser = "UPDATE users SET ";
                updateUser += "UFirstName='" + this.firstName.Text + "',";
                updateUser += "ULastName='" + this.lastName.Text + "',";
                updateUser += "UGender=" + gender + ",";
                updateUser += "UEmail='" + this.email.Text + "',";
                updateUser += "UBirthday='" + getBirthday() + "'";
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

        public void checkIfChecked(string buttonGender)
        {
            if (buttonGender == "male" && gender == true)
                Response.Write("checked");
            else if (buttonGender == "female" && gender == false)
                Response.Write("checked");
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