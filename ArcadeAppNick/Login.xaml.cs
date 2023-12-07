namespace ArcadeAppNick;
using ArcadeAppNick.Models;

public partial class Login : ContentPage
{

	public Login()
	{
		InitializeComponent();
        //current entry: username: dev | password: abc
	}

    async private void LoginButton_Clicked(object sender, EventArgs e)
    {
        string result = App.UserRepo.GetUser(UsernameEntry.Text).Username;
        if(UsernameEntry.Text == result)
        {
            await Shell.Current.GoToAsync("arcade_main");
        }
    }
}