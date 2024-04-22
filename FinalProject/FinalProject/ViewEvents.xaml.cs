using System.Globalization;
using MySqlConnector;
using FinalProject.Classes;
using System.Data;
using Microsoft.Extensions.Logging;

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
        try
        {
            string sql = "SELECT * FROM systemevents WHERE eventOwner = " + userID;
            MySqlCommand command = new MySqlCommand(sql, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(events);
        } catch (Exception ex)
        {
            error1.Text = ex.Message;
        }
		connection.Close();

		int i = 0;
		DataRow dr;
        while (i < events.Rows.Count)
        {
            dr = events.Rows[i];
            eventsList.Add(new Event
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
            });
            eventsList[i].UpdateStatus();
            i++;
        }

        EventsList.ItemsSource = eventsList;

    }

    public void EventEdit(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Event selectedEvent = (Event)btn.BindingContext;
        Navigation.PushAsync(new UpdateEvents(selectedEvent.Name, builder));
    }

    public void ToInventory(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Event selectedEvent = (Event)btn.BindingContext;
        Navigation.PushAsync(new InventoryPage(selectedEvent.Name, builder));
    }

    public void ToParticipants(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Event selectedEvent = (Event)btn.BindingContext;
        Navigation.PushAsync(new AddingParticipants(selectedEvent.Name, builder));
    }
}