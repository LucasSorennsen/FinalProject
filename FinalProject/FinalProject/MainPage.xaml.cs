using MySqlConnector;
namespace FinalProject
{
    public partial class MainPage : ContentPage
    {
        string username_entry;
        string password_entry;
        public int userID;
        public MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            UserID = "root",
            Password = "password",
            Database = "event_manager"
        };

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void OnConfirm(object sender, EventArgs e)
        {
            username_entry = Username.Text;
            password_entry = Password.Text;
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

            connection.Open();

            try
            {
                string sql = "SELECT ownerID FROM owners WHERE ownerUsername = '" + username_entry + "' AND ownerPassword = '" + password_entry + "'";
                MySqlCommand command = new MySqlCommand(sql, connection);

                userID = (int)command.ExecuteScalar();

                connection.Close();
                Navigation.PushAsync(new HomePage(userID));
            } catch (Exception ex)
            {
                error1.Text = ex.Message;
            }
        }
    }
}
