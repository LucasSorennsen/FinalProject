namespace FinalProject
{
    public partial class MainPage : ContentPage
    {
        string username_entry;
        string password_entry;

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
            Navigation.PushAsync(new HomePage(username_entry, password_entry));
        }
    }
}
