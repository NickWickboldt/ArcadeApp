namespace ArcadeAppNick;
//Access Key: ac2d7bd5745a8d451c9bfc4478957188

using ArcadeAppNick.Models; 

public partial class Weather : ContentPage
{
	public Weather()
	{
		InitializeComponent();
        BindingContext = new WeatherInfo();
    }
}