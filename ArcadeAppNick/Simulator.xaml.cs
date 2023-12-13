namespace ArcadeAppNick;

public partial class Simulator : ContentPage
{
	List<String> cards = new List<String>()
	{
		"baby_goat.png",
		"buffalo.png",
		"hyena.png",
		"moose.png",
		"polar_bear.png",
		"rat.png",
		"seal.png",
		"tiger.png"
	}; 


	public Simulator()
	{
		InitializeComponent();
	}

    async private void OpenPackButton_Clicked(object sender, EventArgs e)
    {
        var rand = new Random();
        int rand1 = rand.Next(8);

		rand = new Random(); 
		int rand2 = rand.Next(8);

		rand = new Random(); 
		int rand3 = rand.Next(8);

		rand = new Random();
		int rand4 = rand.Next(8);

		String imageSource1 = cards[rand1]; 
		String imageSource2 = cards[rand2];
		String imageSource3 = cards[rand3];
		String imageSource4 = cards[rand4];

		Card1.Source = imageSource1;
		Card2.Source = imageSource2;
		Card3.Source = imageSource3;
		Card4.Source = imageSource4;

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