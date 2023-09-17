namespace ArcadeAppNick;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

    private async void ImageButton1_Clicked(object sender, EventArgs e)
    {
		ImageButton1.BackgroundColor = Colors.Pink;
        await Shell.Current.GoToAsync("quiz_home"); 
    }

    private async void ImageButton2_Clicked(object sender, EventArgs e)
    {
        ImageButton2.BackgroundColor = Colors.Red;
        await Shell.Current.GoToAsync("storybook_home"); 
    }

    private void ImageButton3_Clicked(object sender, EventArgs e)
    {
        ImageButton3.BackgroundColor = Colors.Beige;
    }

    private void ImageButton4_Clicked(object sender, EventArgs e)
    {
        ImageButton4.BackgroundColor = Colors.Green;
    }

    private void ImageButton5_Clicked(object sender, EventArgs e)
    {
        ImageButton5.BackgroundColor = Colors.Orange;
    }

    private void ImageButton6_Clicked(object sender, EventArgs e)
    {
        ImageButton6.BackgroundColor = Colors.Violet;
    }
}

