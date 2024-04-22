using MySqlConnector;

namespace FinalProject;

public partial class HomePage : ContentPage
{
    public string username { get; set; }
    public string password { get; set; }
    public int userID { get; set; }
    public MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
    {
        Server = "localhost",
        UserID = "root",
        Password = "password",
        Database = "event_manager"
    };
    
    public HomePage(string usernameEntry, string passwordEntry)
	{
        InitializeComponent();
        username = usernameEntry;
        password = passwordEntry;
        MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

        connection.Open();

        string sql = "SELECT ownerID FROM owners WHERE ownerUsername = '" + usernameEntry + "' AND ownerPassword = '" + passwordEntry + "'";
        MySqlCommand command = new MySqlCommand(sql, connection);

        userID = (int)command.ExecuteScalar();

        connection.Close();

	}

    private void ViewEvents(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ViewEvents(userID, builder));
    }
    private void CreateEventPage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CreateEvents(userID, builder));
    }
}