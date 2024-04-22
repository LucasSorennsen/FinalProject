using MySqlConnector;

namespace FinalProject;

public partial class HomePage : ContentPage
{
    public int userID { get; set; }
    public MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
    {
        Server = "localhost",
        UserID = "root",
        Password = "password",
        Database = "event_manager"
    };
    
    public HomePage(int ID)
	{
        InitializeComponent();
        userID = ID;
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