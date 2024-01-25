namespace ArcadeAppNick;

public partial class TicTacToe : ContentPage
{
    public BoardSquare sq0;
    public BoardSquare sq1; 
    public BoardSquare sq2;
    public BoardSquare sq3;
    public BoardSquare sq4;
    public BoardSquare sq5;
    public BoardSquare sq6;
    public BoardSquare sq7;
    public BoardSquare sq8;
    public List<BoardSquare> squares = new List<BoardSquare>();
    public int currentTurn = 0; 

	public TicTacToe()
	{
		InitializeComponent();
        sq0 = new BoardSquare(Square0, 0);
        squares.Add(sq0); 
        sq1 = new BoardSquare(Square1, 1);
        squares.Add(sq1);
        sq2 = new BoardSquare(Square2, 2);
        squares.Add(sq2);
        sq3 = new BoardSquare(Square3, 3);
        squares.Add(sq3);
        sq4 = new BoardSquare(Square4, 4);
        squares.Add(sq4);
        sq5 = new BoardSquare(Square5, 5);
        squares.Add(sq5);
        sq6 = new BoardSquare(Square6, 6);
        squares.Add(sq6);
        sq7 = new BoardSquare(Square7, 7);
        squares.Add(sq7);
        sq8 = new BoardSquare(Square8, 8);
        squares.Add(sq8);
    }

    private void Square0_Clicked(object sender, EventArgs e)
    {
        sq0.PlayerTurn();
        currentTurn++; 
        squares.Remove(sq0);
        RandomLocation();
    }

    private void Square1_Clicked(object sender, EventArgs e)
    {
        sq1.PlayerTurn();
        currentTurn++; 
        squares.Remove(sq1);
        RandomLocation();
    }

    private void Square2_Clicked(object sender, EventArgs e)
    {
        sq2.PlayerTurn();
        currentTurn++; 
        squares.Remove(sq2);
        RandomLocation();
    }

    private void Square3_Clicked(object sender, EventArgs e)
    {
        sq3.PlayerTurn();
        currentTurn++;
        squares.Remove(sq3);
        RandomLocation();
    }

    private void Square4_Clicked(object sender, EventArgs e)
    {
        sq4.PlayerTurn();
        currentTurn++;
        squares.Remove(sq4);
        RandomLocation();
    }

    private void Square5_Clicked(object sender, EventArgs e)
    {
        sq5.PlayerTurn();
        currentTurn++;
        squares.Remove(sq5);
        RandomLocation();
    }

    private void Square6_Clicked(object sender, EventArgs e)
    {
        sq6.PlayerTurn();
        currentTurn++;
        squares.Remove(sq6);
        RandomLocation();
    }

    private void Square7_Clicked(object sender, EventArgs e)
    {
        sq7.PlayerTurn();
        currentTurn++;
        squares.Remove(sq7);
        RandomLocation();
    }

    private void Square8_Clicked(object sender, EventArgs e)
    {
        sq8.PlayerTurn();
        currentTurn++;
        squares.Remove(sq8);
        RandomLocation();
    }

    public void RandomLocation()
    {
        if(squares.Count > 0)
        {
            var rand = new Random();
            int loc = rand.Next(squares.Count);
            
            squares[loc].AITurn();
            squares.Remove(squares[loc]);
        }
         
    }
}

public class BoardSquare
{
    public ImageButton square; 
    public int squareNumber;
    public bool isX = false;
    public bool isO = false;
    public string imageSource; 

    public BoardSquare(ImageButton ib, int number)
    {
        square = ib;
        squareNumber = number;
    }

    public void PlayerTurn()
    {
        isX = true;
        imageSource = "tictactoe_x.png"; 
        square.IsEnabled = false;
        square.Source = imageSource; 
    }

    public void AITurn()
    {
        isO = true;
        imageSource = "tictactoe_o.png";
        square.IsEnabled =false;
        square.Source = imageSource; 
    }
}