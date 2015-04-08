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
    public partial class updateUser : System.Web.UI.Page
    {
        protected UserData user = new UserData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["secure"]) < 2)
                Response.Redirect("loginPage.aspx");

            this.Birthday();
            Connection conn = new Connection("SELECT * FROM users WHERE UUserName='" + Session["user"] + "';");
            conn.initDS();

            DataRow userData = conn.ds.Tables[0].Rows[0];
            user = new UserData(userData["UUserName"].ToString(), userData["Upassword"].ToString(), userData["UFirstName"].ToString(), userData["ULastName"].ToString(), userData["UEmail"].ToString(), userData["UBirthday"].ToString(), Convert.ToInt32(userData["USecurity"].ToString()));
            user.userGender = (bool)userData["UGender"];
            if (!Page.IsPostBack)
            {
                this.firstName.Text = user.firstName;
                this.lastName.Text = user.lastName;
                this.email.Text = user.email;
                string birthdayDay, birthdayMonth, birthdayYear;
                birthdayDay = user.dateOfBirth.Substring(0, 2);
                birthdayMonth = user.dateOfBirth.Substring(3, 2);
                birthdayYear = user.dateOfBirth.Substring(6, 4);

                this.birthdayDay.SelectedIndex = Convert.ToInt32(birthdayDay) - 1;
                this.birthdayMonth.SelectedIndex = Convert.ToInt32(birthdayMonth) - 1;
                this.birthdayYear.SelectedIndex = Convert.ToInt32(birthdayYear) - 1920;
            }
            else
            {
                bool gender = Request.Form["Gender"].Equals("male") ? true : false;
                user.userGender = gender;
                if (user.password == this.password.Text && user.password == this.rePassword.Text)
                {
                    string updateUser = "UPDATE users SET ";
                    updateUser += "UFirstName='" + this.firstName.Text + "',";
                    updateUser += "ULastName='" + this.lastName.Text + "',";
                    updateUser += "UGender=" + user.userGender + ",";
                    updateUser += "UEmail='" + this.email.Text + "',";
                    updateUser += "UBirthday='" + getBirthday() + "' ";
                    updateUser += "Where UUserName='" + Session["user"] + "' AND Upassword='" + user.password + "';";

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
            if (buttonGender == "male" && user.userGender == true)
                Response.Write("checked");
            else if (buttonGender == "female" && user.userGender == false)
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