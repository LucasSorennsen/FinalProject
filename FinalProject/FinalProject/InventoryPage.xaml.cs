using FinalProject.Classes;
using MySqlConnector;

namespace FinalProject;

public partial class InventoryPage : ContentPage
{
    public string selectedEventName;
    public int eventID;
    public MySqlConnectionStringBuilder builder { get; set; }
    private List<Inventory> _allProducts = new List<Inventory>();

    public InventoryPage(string Name, MySqlConnectionStringBuilder sqlConnector)
    {
        InitializeComponent();
        selectedEventName = Name;
        builder = sqlConnector;
        MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
        connection.Open();
        string sql = "SELECT eventID FROM systemevents WHERE eventName = '" + selectedEventName + "'";
        MySqlCommand command = new MySqlCommand(sql, connection);

        eventID = (int)command.ExecuteScalar();

        connection.Close();
    }

    public void SubmitProductInfo(object sender, EventArgs e)
    {
        MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

        string prodId = productID.Text;
        string prodName = productName.Text;
        string prodPrice = productPrice.Text;
        string prodStock = productStock.Text;
        string prodSold = productSold.Text;

        connection.Open();
        string sql = "INSERT INTO inventory VALUES (" + prodId + ", '" + prodName + "', " + prodPrice + ", " + prodStock + ", " + prodSold + ", " + eventID + ")";
        MySqlCommand command = new MySqlCommand( sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }
}