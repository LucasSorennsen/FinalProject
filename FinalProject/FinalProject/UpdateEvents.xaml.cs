using MySqlConnector;
using FinalProject.Classes;
using System.Data;
namespace FinalProject;

public partial class UpdateEvents : ContentPage
{
	public string selectedEventName;
    public int eventID;
    public MySqlConnectionStringBuilder builder { get; set; }

    public UpdateEvents(string Name, MySqlConnectionStringBuilder sqlConncector)
	{
		InitializeComponent();
		selectedEventName = Name;
		builder = sqlConncector;
        DataTable events = new DataTable();
        MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

		connection.Open();

		string sql = "SELECT * FROM systemevents WHERE eventName = '" + selectedEventName + "'";
		MySqlCommand command = new MySqlCommand(sql, connection);

        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
        adapter.Fill(events);
        connection.Close();

        DataRow dr;
        dr = events.Rows[0];
        Event displayEvent = new Event
        {
            Id = Convert.ToInt32(dr["eventID"]),
            Name = dr["eventName"] + "",
            eventDate = DateTime.Parse(Convert.ToString(dr["eventDate"])),
            Time = TimeSpan.Parse(Convert.ToString(dr["eventTime"])),
            Description = dr["eventDescription"] + "",
            EventStatus = dr["eventStatus"] + "",
            EventBudget = Convert.ToInt32(dr["eventBudget"]),
            SpentBudget = Convert.ToInt32(dr["spentBudget"]),
            EventType = dr["eventType"] + "",
            Venue = dr["eventVenue"] + ""
        };

        eventName.Text = displayEvent.Name;
        eventDescription.Text = displayEvent.Description;
        eventVenue.Text = displayEvent.Venue;
        Type.Text = displayEvent.EventType;
        eventDate.Date = displayEvent.eventDate.Date;
        eventTime.Time = displayEvent.Time;
        eventBudget.Text = Convert.ToString(displayEvent.EventBudget);
        spentBudget.Text = Convert.ToString(displayEvent.SpentBudget);
        eventID = displayEvent.Id;
    }

    public void ConfirmUpdate(object sender, EventArgs e)
    {
        MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
        connection.Open();

        string sql = "UPDATE systemevents SET eventName = '" + eventName.Text + "', eventDescription = '" + eventDescription.Text + 
            "', eventVenue = '" + eventVenue.Text + "', eventType = '" + Type.Text + "', eventDate = '" + eventDate.Date.ToString("d")
            + "', eventTime = '" + eventTime.Time.ToString() + "', eventBudget = " + eventBudget.Text + ", spentBudget = " + spentBudget.Text
            + " WHERE eventID = " + eventID;

        MySqlCommand command = new MySqlCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }
}