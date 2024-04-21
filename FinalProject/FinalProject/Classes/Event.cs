using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Classes
{
    internal class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime eventDate { get; set; }
        public TimeSpan Time { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }
        public string EventType { get; set; }
        public int EventBudget { get; set; }
        public int SpentBudget { get; set; }
        public string EventStatus { get; set; }

        public string UpdateStatus()
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime combinedDateTime = eventDate + Time;

            if (combinedDateTime < currentDateTime)
            {
                return "Past";
            }
            else if (combinedDateTime.Date == currentDateTime.Date)
            {
                return "Present";
            }
            else
            {
                return "Future";
            }
        }


        public int GetTotalBudget()
        {
            return EventBudget;
        }

        public int GetSpentBudget()
        {
            return SpentBudget;
        }


        public override string ToString()
        {
            return $"\nEvent Number:		  {Id}" +
                $"\nEvent Name:		          {Name}" +
                $"\nDescription:	          {Description}" +
                $"\nDate:		              {eventDate}" +
                $"\nTime:		              {Time}" +
                $"\nType:		              {EventType}" +
                $"\nTotal Budget:		      {EventBudget}" +
                $"\nSpent Budget:		      {SpentBudget}" +
                $"\nEvent Status:		      {EventStatus}";
        }
    }
}
