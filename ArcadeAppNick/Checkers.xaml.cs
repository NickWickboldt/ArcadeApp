namespace ArcadeAppNick;

public partial class Checkers : ContentPage
{
	public Checkers()
	{
		InitializeComponent();
        PopulateGameboard(); 
	}

	public void PopulateGameboard()
	{
		int rows = 8;
		int columns = 8;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
				Color color = new Color(); 
				if(i % 2 == 0)
				{
					//even row
					if(j % 2 == 0)
					{
                        color = Color.FromRgb(255, 255, 255);
					}
					else
					{
                        color = Color.FromRgb(0, 0, 0);
                    }
				}
				else
				{
                    //odd row
                    if (j % 2 == 0)
                    {
                        color = Color.FromRgb(0, 0, 0);
                    }
                    else
                    {
                        color = Color.FromRgb(255, 255, 255);
                    }
                }
                ImageButton sq = new ImageButton()
                {
                    BackgroundColor = color,
                };

                //create AI pieces
                if ((j == 0 || j == 1 || j == 2) && sq.BackgroundColor.Equals(new Color(0, 0, 0)))
                {
                    sq.Source = "black_piece.png";
                }

                //create user pieces
                if ((j == 5 || j == 6 || j == 7) && sq.BackgroundColor.Equals(new Color(0, 0, 0)))
                {
                    sq.Source = "red_piece.png";
                }

                Gameboard.Add(sq, i, j); 
            }
        }
    }
}
public class Checker
{
    public int[] currentLocation = new int[2];

    public Checker(int i, int j)
    {
        currentLocation[0] = i;
        currentLocation[1] = j;
    }

}

public class CheckerboardSquare
{
    MainPage p;
    private ImageButton square;
    public int[] location = new int[2]; 
    private bool isActive = false;
    public bool choosingForMove;

    public CheckerboardSquare(int i, int j, ImageButton sq, MainPage page)
    {
        p = page;
        location[0] = i;
        location[1] = j;
        square = sq;
        choosingForMove = false;
    }
}