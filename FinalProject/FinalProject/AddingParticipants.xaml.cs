using EventManagerProject.Classes;

namespace EventManagerProject;

public partial class AddingParticipants : ContentPage
{
	public AddingParticipants()
	{
		InitializeComponent();
	}
    private List<Participants> _allParticipants = new List<Participants>();

    void OnPartpIDTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = partpID.Text;
    }
    void OnPartpIDCompleted(object sender, EventArgs e)
    {
        int id = Int32.Parse(((Entry)sender).Text);
    }

    void OnPartpNameTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = partpName.Text;
    }
    void OnPartpNameCompleted(object sender, EventArgs e)
    {
        string name = ((Entry)sender).Text;
    }
    void OnPartpEmailTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = partpEmail.Text;
    }
    void OnPartpEmailCompleted(object sender, EventArgs e)
    {
        string emailaddress = ((Entry)sender).Text;
    }

    void OnPartpPhoneTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = partpPhone.Text;
    }
    void OnPartpPhoneCompleted(object sender, EventArgs e)
    {
        int phone = Int32.Parse(((Entry)sender).Text);
    }

    void OnPartpSpecTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
            string myText = partpSpec.Text;
        }
        void OnPartpSpecCompleted(object sender, EventArgs e)
        {
            string special = ((Entry)sender).Text;
        }
    void OnPartpRoleTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = partpRole.Text;
    }
    void OnPartpRoleCompleted(object sender, EventArgs e)
    {
        string role = ((Entry)sender).Text;
    }
    
    public void AddParticipant(int id, string name, string emailaddress, int phone, string special, string role)
    {

        var participant = new Participants(id, name, emailaddress, phone, special, role);
        _allParticipants.Add(participant);
    }

    public void SubmitParticipants(object sender, EventArgs e)
    {
        submitparticipant.Text = viewAllParticipants().ToString();
    }
}
