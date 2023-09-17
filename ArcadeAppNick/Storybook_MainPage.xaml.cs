namespace ArcadeAppNick;

public partial class Storybook_MainPage : ContentPage
{
	public Storybook_MainPage()
	{
		InitializeComponent();
	}

    private void Page_1_ToggleText(object sender, EventArgs e)
    {
        if (Page_1_TextBox.IsVisible == true)
        {
            Page_1_TextBox.IsVisible = false;
        }
        else
        {
            Page_1_TextBox.IsVisible = true;
        }
    }
    private void Page_2a_ToggleText(object sender, EventArgs e)
    {
        if (Page_2a_TextBox.IsVisible == true)
        {
            Page_2a_TextBox.IsVisible = false;
        }
        else
        {
            Page_2a_TextBox.IsVisible = true;
        }
    }
    private void Page_3a_ToggleText(object sender, EventArgs e)
    {
        if (Page_3a_TextBox.IsVisible == true)
        {
            Page_3a_TextBox.IsVisible = false;
        }
        else
        {
            Page_3a_TextBox.IsVisible = true;
        }
    }
    private void Page_1_SizeChanged(object sender, EventArgs e)
    {
        if (Width < 950)
        {
            Page_1_ToggleButton.WidthRequest = 300;
            Page_1_ToggleButton.FontSize = 12;

            Page_1_TextBox.WidthRequest = 300;
            Page_1_TextBox.HeightRequest = 250;

            Page_1_Text.FontSize = 12;

            Page_1_Choice1.WidthRequest = 150;
            Page_1_Choice1.FontSize = 12;
            Page_1_Choice1.Margin = new Thickness(0, 400, 150, 0);

            Page_1_Choice2.WidthRequest = 150;
            Page_1_Choice2.FontSize = 12;
            Page_1_Choice2.Margin = new Thickness(150, 400, 0, 0);

        }
        else
        {
            Page_1_ToggleButton.WidthRequest = 500;
            Page_1_ToggleButton.FontSize = 18;

            Page_1_TextBox.WidthRequest = 500;
            Page_1_TextBox.HeightRequest = 350;

            Page_1_Text.FontSize = 18;

            Page_1_Choice1.WidthRequest = 200;
            Page_1_Choice1.FontSize = 18;
            Page_1_Choice1.Margin = new Thickness(0, 300, 300, 0);

            Page_1_Choice2.WidthRequest = 200;
            Page_1_Choice2.FontSize = 18;
            Page_1_Choice2.Margin = new Thickness(300, 300, 0, 0);
        }
    }

    private async void Page_1_Choice1_Clicked(object sender, EventArgs e)
    {
        Page_1_Choice2.IsEnabled = false;
        Page_2a.Opacity = 0; //makes page 2a transparent
        Page_2a.IsVisible = true; //setting page 2a to visible (still transparent)

        await Task.Delay(100); //small delay to load page 2a

        //scrolling to the start of page 2a
        await scrollview.ScrollToAsync(Page_2a, ScrollToPosition.Start, true);

        await Page_2a.FadeTo(1, 100); //over 100 milliseconds, fades to solid opacity
    }
    private async void Page_2a_Choice1_Clicked(object sender, EventArgs e)
    {
        Page_2a_Choice2.IsEnabled = false;
        Page_3a.Opacity = 0; //makes page 2a transparent
        Page_3a.IsVisible = true; //setting page 2a to visible (still transparent)

        await Task.Delay(100); //small delay to load page 2a

        //scrolling to the start of page 2a
        await scrollview.ScrollToAsync(Page_3a, ScrollToPosition.Start, true);

        await Page_3a.FadeTo(1, 100); //over 100 milliseconds, fades to solid opacity
    }
}