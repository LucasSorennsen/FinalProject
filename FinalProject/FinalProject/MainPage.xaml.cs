namespace FinalProject
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

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
            if (UserName.Text == "UserName" && Password.Text == "Password")
            {
                Navigation.PushAsync(new NewPage1());
            }
        }
    }
}
