﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Classes
{
    public class SystemAdmin
    {
        public int adminID;
        public string adminUsername;
        public string adminPassword;
        public string adminEmail;
        public int adminPhone;

        public SystemAdmin(int ID, string username, string password, string email, int phone)
        {
            adminID = ID;
            adminUsername = username;
            adminPassword = password;
            adminEmail = email;
            adminPhone = phone;
        }

        public override string ToString()
        {
            return $"\nSystem Admin ID:		  {adminID}" +
                $"\nUsername:		          {adminUsername}" +
                $"\nPassword:	              {adminPassword}" +
                $"\nEmail:		              {adminEmail}" +
                $"\nPhone Number:		      {adminPhone}";
        }
    }
}
