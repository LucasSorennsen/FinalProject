using FinalProject.Classes;
using MySqlConnector;

namespace FinalProject;

public partial class AddingParticipants : ContentPage
{
    public string selectedEventName;
    public int eventID;
    public MySqlConnectionStringBuilder builder { get; set; }
    private List<Participants> _allParticipants = new List<Participants>();
    public AddingParticipants(string Name, MySqlConnectionStringBuilder sqlConnector)
	{
		InitializeComponent();
        selectedEventName = Name;
        builder = sqlConnector;
        MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
        connection.Open();
        try
        {
            string sql = "SELECT eventID FROM systemevents WHERE eventName = '" + selectedEventName + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);

            eventID = (int)command.ExecuteScalar();
        } catch (Exception ex)
        {
            error1.Text = ex.Message;
        }

        connection.Close();
    }

    public void SubmitParticipants(object sender, EventArgs e)
    {
        MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

        string parId = partpID.Text;
        string parName = partpName.Text;
        string parEmail = partpEmail.Text;
        string parPhone = partpPhone.Text;
        string parSpec = partpSpec.Text;
        string parType = partpRole.Text;

        connection.Open();
        try
        {
            string sql = "INSERT INTO participants VALUES (" + parId + ", '" + parName + "', '" + parEmail + "', " + parPhone + ", '" + parSpec + "', '" + parType + "')";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
        } catch (Exception ex)
        {
            error2.Text = ex.Message;
        }
        connection.Close();
    }
}
