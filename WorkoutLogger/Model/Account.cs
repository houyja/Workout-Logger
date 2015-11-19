using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutLogger.Model
{
    public class Account
    {
        public string Username { get; private set; }
        public string AccountID { get; private set; }
        string Firstname;
        string Lastname;
        DateTime Birthday;

        public Account(string username, string accountID, string firstname, string lastname, DateTime birthday)
        {
            Username = username;
            AccountID = accountID;
            Firstname = firstname;
            Lastname = lastname;
            Birthday = birthday;
        }
        
    }

}