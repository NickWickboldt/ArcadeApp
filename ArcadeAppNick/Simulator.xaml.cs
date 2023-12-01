namespace ArcadeAppNick;

public partial class Simulator : ContentPage
{
	public Simulator()
	{
		InitializeComponent();
	}

    async private void OpenPackButton_Clicked(object sender, EventArgs e)
    {
		await TopPack.TranslateTo(TopPack.X - 340, 0, 2000, Easing.Linear);
		await TopPack.FadeTo(0);

		await BottomPack.TranslateTo(0, BottomPack.Y + 300, 2000, Easing.Linear);
		await BottomPack.FadeTo(0);

		await Card1.TranslateTo(Card1.X - 340, 0);
		await Card4.TranslateTo(Card4.X + 490, 0);
		await Card2.TranslateTo(Card2.X - 60, 0);
		await Card3.TranslateTo(Card3.X + 215, 0); 
    }
}