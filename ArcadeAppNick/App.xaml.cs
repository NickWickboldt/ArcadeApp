namespace ArcadeAppNick;
using ArcadeAppNick.Models;

public partial class App : Application
{
    public static UserRepository UserRepo { get; set; }

    public App(UserRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		UserRepo = repo; 
	}
}
