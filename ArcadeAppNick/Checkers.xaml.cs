namespace ArcadeAppNick;

public partial class Checkers : ContentPage
{
    //class attributes 
    public List<CheckerboardSquare> CheckerBoard = new List<CheckerboardSquare>();
    public List<Checker> AIPieces = new List<Checker>();
    public List<Checker> UserPieces = new List<Checker>();
    public bool checkerIsSelected = false; 
    //class constructor
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
                    Checker newPiece = new Checker(i, j);
                    AIPieces.Add(newPiece); 
                }

                //create user pieces
                if ((j == 5 || j == 6 || j == 7) && sq.BackgroundColor.Equals(new Color(0, 0, 0)))
                {
                    sq.Source = "red_piece.png";
                    Checker newPiece = new Checker(i, j);
                    UserPieces.Add(newPiece); 
                }

                Gameboard.Add(sq, i, j);
                CheckerBoard.Add(new CheckerboardSquare(this, sq, i, j)); 
            }
        }
    }

    public Checker IdentifyChecker(int[] location)
    {
        foreach (Checker piece in UserPieces)
        {
            if (piece.currentLocation[0] == location[0] && piece.currentLocation[1] == location[1])
            {
                return piece;
            }
        }
        return null; 
    }

    public CheckerboardSquare IdentifyCheckerBoardSquare(int[] location)
    {
        foreach (CheckerboardSquare square in CheckerBoard)
        {
            if (square.location[0] == location[0] && square.location[1] == location[1])
            {
                return square;
            }
        }
        return null; 
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
    Checkers p;
    public ImageButton square;
    public int[] location = new int[2];
    public bool isActive = false;
    public bool choosingForMove = false;
    public int currentState = 0;
    public EventHandler DoToggle;
    public EventHandler DoMove; 

    public CheckerboardSquare(Checkers page, ImageButton sq, int i, int j)
    {
        p = page; 
        location[0] = i;
        location[1] = j;
        square = sq;
        TestActive(); 
    }

    public void AddBorder()
    {
        square.BorderColor = Color.FromRgb(255, 223, 0);
        square.BorderWidth = 5;
    }

    public void RemoveBorder()
    {
        square.BorderColor = Color.FromRgb(0, 0, 0);
        square.BorderWidth = 0;
    }

    public void TestActive()
    {
        if (Convert.ToString(square.Source).Length > 7)
        {
            isActive = true;
            if (Convert.ToString(square.Source).Substring(6) == "red_piece.png")
            {
                DefineRedClick(); 
            }
        }
        else
        {
            isActive = false; 
        }
    }

    public void DefineRedClick()
    {
        DoToggle = (sender, args) =>    //arrow function ~ lambda expression
        {
            if(currentState == 0 && (p.checkerIsSelected == false))
            {
                square.Source = "red_piece_active.png";
                choosingForMove = true; 
                currentState = 1;   //toggle
                p.checkerIsSelected = true; 
            }else if (choosingForMove)
            {
                square.Source = "red_piece.png";
                currentState = 0;
                choosingForMove = false;
                p.checkerIsSelected = false; 
            }
        };
        square.Clicked += DoToggle; 
    }
}