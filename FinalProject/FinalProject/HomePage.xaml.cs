namespace FinalProject;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private void ViewEvents(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new ViewEvents());
    }
    private void CreateEventPage(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new eventCreate());
    }

    private void UpdateExisting(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new updateEvent());
    }
}