using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Classes
{
    internal class Participants
    {

        // need participant #, name, email, phone, special needs, type (role)
        public int parID;
        public string parName;
        public string parEmail;
        public int parPhone;
        public string parSpec;
        public string parType;

        public Participants(int ID, string name, string email, int phone, string special, string role)
        {
            parID = ID;
            parName = name;
            parEmail = email;
            parPhone = phone;
            parSpec = special;
            parType = role;
        }

        public override string ToString()
        {
            return $"\nID:			{parID}" +
                $"\nName:		{parName}" +
                $"\nEmail Address:	{parEmail}" +
                $"\nPhone Number:		{parPhone}" +
                $"\nSpecial Needs:		{parSpec}"+
                $"\nRole:	{parType}";
        }
    }
}
