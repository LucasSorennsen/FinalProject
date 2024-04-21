using System.Globalization;
using MySqlConnector;
using FinalProject.Classes;
using System.Data;

namespace FinalProject;

public partial class ViewEvents : ContentPage
{
	public int userID { get; set; }
	public MySqlConnectionStringBuilder builder { get; set; }

	public ViewEvents(int ID, MySqlConnectionStringBuilder sqlConncector)
	{
		InitializeComponent();
		userID = ID;
		DataTable events = new DataTable();
		builder = sqlConncector;
        MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
        List<Event> eventsList = new List<Event>();

        connection.Open();
		string sql = "SELECT * FROM systemevents WHERE eventOwner = " + userID;
		MySqlCommand command = new MySqlCommand(sql, connection);

		MySqlDataAdapter adapter = new MySqlDataAdapter(command);
		adapter.Fill(events);
		connection.Close();
		
		int i = 0;
		DataRow dr;
		Event event1 = new Event();
		while (i < events.Rows.Count)
		{
			dr = events.Rows[i];
			event1.Id = Convert.ToInt32(dr["eventID"]);
			event1.Name = dr["eventName"] + "";
			event1.eventDate = DateTime.Parse(Convert.ToString(dr["eventDate"]));
			event1.Time = TimeSpan.Parse(Convert.ToString(dr["eventTime"]));
			event1.Description = dr["eventDescription"] + "";
			event1.EventStatus = event1.UpdateStatus();
			event1.EventBudget = Convert.ToInt32(dr["eventBudget"]);
			event1.SpentBudget = Convert.ToInt32(dr["spentBudget"]);
			event1.EventType = dr["eventType"] + "";
			eventsList.Add(event1);
			i++;
		}

		EventsList.ItemsSource = eventsList;

    }
}