using ArcadeAppNick.Models;

namespace ArcadeAppNick;

public partial class Inventory : ContentPage
{
	public Inventory()
	{
		InitializeComponent();
		
		Users user = App.UserRepo.GetUser(App.LoggedInUser);

		BabyGoatLabel.Text = Convert.ToString(user.BabyGoat);
		BuffaloLabel.Text = Convert.ToString(user.Buffalo);
		HyenaLabel.Text = Convert.ToString(user.Hyena);
		MooseLabel.Text = Convert.ToString(user.Moose);
		PolarBearLabel.Text = Convert.ToString(user.PolarBear);
		RatLabel.Text = Convert.ToString(user.Rat);
		SealLabel.Text = Convert.ToString(user.Seal);
		TigerLabel.Text = Convert.ToString(user.Tiger);
		SharkLabel.Text = Convert.ToString(user.Shark); 
	}

}