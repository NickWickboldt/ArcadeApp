namespace ArcadeAppNick;

public partial class Platform_MainPage : ContentPage
{
    public int level = 1;
    public int score = 0;
    public Label scoreLabel;
    public Label levelLabel;

    public Platform_MainPage()
	{
		InitializeComponent();
	}

    private void Start_Button_Clicked(object sender, EventArgs e)
    {
        Fill_Grid(); 

        Start_Button.IsEnabled = false; 
    }

    private void Reset_Button_Clicked(object sender, EventArgs e)
    {
       
    }

    async public void Fill_Grid()
    {
        int rows = 5;
        int columns = 5;
        
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                StackLayout unit = new StackLayout() { ZIndex = 0 };
                unit.BackgroundColor = Colors.LightSkyBlue;
                gameGrid.Add(unit, j, i);

                await Task.Delay(100); 
            }
        }

        scoreLabel = new Label()
        {
            Text = "Score: " + score,
            FontSize = 30,
            ZIndex = 1,
            TextColor = Colors.White,
            Margin = new Thickness(10),
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
        };

        levelLabel = new Label()
        {
            Text = "Level: " + level,
            FontSize = 30,
            ZIndex = 1,
            TextColor = Colors.White,
            Margin = new Thickness(10),
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
        };

        await Task.Delay(100);
        gameGrid.Add(scoreLabel, 0, 4);
        await Task.Delay(100);
        gameGrid.Add(levelLabel, 4, 4);
    }
}