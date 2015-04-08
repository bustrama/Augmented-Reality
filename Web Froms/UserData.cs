using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite
{
    public class UserData
    {
        public string userName { get; private set; }
        public string password { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string email { get; private set; }
        public string dateOfBirth { get; private set; }
        public int securityLevel { get; private set; }
        public bool userGender { get; set; }

        public UserData()
        {
            this.userName = this.password = this.firstName = this.lastName = this.dateOfBirth = this.email = null;
            this.securityLevel = 0;
        }

        public UserData(string userName, string password, string firstName, string lastName, string email, string dateOfBirth, int secureLevel)
        {
            this.userName = userName;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.dateOfBirth = dateOfBirth;
            this.securityLevel = secureLevel;
        }
    }
}