using FinalProject.Classes;
using MySqlConnector;

namespace FinalProject;

public partial class CreateEvents : ContentPage
{
	public int userID;
    public MySqlConnectionStringBuilder builder { get; set; }

    public CreateEvents(int ID, MySqlConnectionStringBuilder sqlConncector)
	{
		InitializeComponent();
		userID = ID;
		builder = sqlConncector;
		EventDate.Date = DateTime.Now;
    }

	public void EventCreation(object sender, EventArgs e)
	{
        MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
        connection.Open();

		string sql = "SELECT MAX(eventID) FROM systemevents";
		MySqlCommand command = new MySqlCommand(sql, connection);

		int eventID = (int)command.ExecuteScalar() + 1;
		connection.Close();

		string eventName = EventName.Text;
		string eventDescription = EventDescription.Text;
		DateTime dateEntry = EventDate.Date;
		string eventDate = dateEntry.ToString("d");
		TimeSpan timeEntry = EventTime.Time;
		string eventTime = timeEntry.ToString();
		string eventVenue = Venue.Text;
		string eventBudget = EventBudget.Text;
		string eventType = EventType.Text;
        
		connection.Open();
		sql = "INSERT INTO systemevents VALUES (" + eventID + ", '" + eventName + "', '" + eventVenue + "', '" + eventDescription + "', '" + eventDate + 
			"', '" + eventTime + "', " + eventBudget + ", " + 0 + ", 'Future', '" + eventType + "', " + userID + ")";
		command = new MySqlCommand(sql, connection);

		command.ExecuteNonQuery();

		connection.Close();

    }
}