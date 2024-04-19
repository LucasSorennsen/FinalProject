using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Classes
{
    public class EventOwner
    {
        public int ownerID;
        public string ownerUsername;
        public string ownerPassword;
        public string ownerEmail;
        public int ownerPhone;
        public List<int> ownerList = new List<int>();

        public EventOwner(int ID, string username, string password, string email, int phone)
        {
            ownerID = ID;
            ownerUsername = username;
            ownerPassword = password;
            ownerEmail = email;
            ownerPhone = phone;
        }

        public void AddEvent(int eventID)
        {
            ownerList.Add(eventID);
        }

        public override string ToString()
        {
            return $"\nEvent Owner ID:		 {ownerID}" +
                $"\nUsername:		         {ownerUsername}" +
                $"\nPassword:	             {ownerPassword}" +
                $"\nEmail:		             {ownerEmail}" +
                $"\nPhone Number:		     {ownerPhone}";
        }
    }
}
