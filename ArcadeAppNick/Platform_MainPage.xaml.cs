namespace ArcadeAppNick;

public partial class Platform_MainPage : ContentPage
{
    private Player user; 
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

                if(i < 4 && j == 0)
                {
                    BoxView newRect = new BoxView()
                    {
                        HeightRequest = 20,
                        Color = Colors.Green,
                        VerticalOptions = LayoutOptions.End,
                        CornerRadius = 10,
                        ZIndex = 1
                    };
                    Platform newPlat = new Platform(newRect, i, j);
                    gameGrid.Add(newRect, newPlat.col, newPlat.row);
                }

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
        user = Create_User();
        gameGrid.Add(user.image, user.col, user.row);
        await Task.Delay(100);
        gameGrid.Add(levelLabel, 4, 4);
    }

    private Player Create_User()
    {
        Image userIcon = new Image { Source = "dotnet_bot.png", ZIndex = 1 };
        user = new Player(userIcon, 4, 2);
        return user;
    }
}

public class Player
{
    public Image image;
    public int row;
    public int col; 

    public Player(Image i, int r, int c)
    {
        image = i; 
        row = r;
        col = c;
    }
}

public class Platform
{
    public BoxView rect;
    public int row;
    public int col;

    public Platform(BoxView rectangle, int r, int c)
    {
        this.rect = rectangle;
        this.row = r;
        this.col = c;

    }
}