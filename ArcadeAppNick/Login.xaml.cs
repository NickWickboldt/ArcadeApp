namespace ArcadeAppNick;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    async private void LoginButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("arcade_main");
    }
}