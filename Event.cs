using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace Final
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int eventDate { get; set; }
        public int Time { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }
        public string EventType { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public decimal EventBudget { get; set; }
        public decimal SpentBudget { get; set; }
        public List<string> eventAttendance { get; set; }

        public Event(int eventNumber, string eventName, string venue, string description, DateTime eventDate, TimeSpan eventTime, string eventType, decimal eventBudget, decimal spentBudget)
        {
            Id = eventNumber;
            Name = eventName;
            Venue = venue;
            Description = description;
            EventDate = eventDate;
            EventTime = eventTime;
            EventType = eventType;
            EventBudget = eventBudget;
            SpentBudget = spentBudget;
            eventAttendance = new List<string>();
        }

        public string EventStatus()
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime combinedDateTime = EventDate.Date + EventTime;

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


        public decimal GetTotalBudget()
        {
            return EventBudget;
        }

        public decimal GetSpentBudget()
        {
            return SpentBudget;
        }

        public List<string> GetEventAttendance()
        {
            return eventAttendance;
        }





    }
}
