using ArcadeAppNick.Models;

namespace ArcadeAppNick;

public partial class Zoo : ContentPage
{
	public List<Card> PlayerDeck = new List<Card>();
	public List<Card> PlayerHand = new List<Card>();
	public List<Card> PlayerField = new List<Card>();

	public List<Card> AIDeck = new List<Card>();
	public List<Card> AIHand = new List<Card>();
	public List<Card> AIField = new List<Card>(); 

	List<String> commonList = new List<String>()
	{
        "baby_goat",
        "hyena",
        "moose",
        "zebra",
        "fox",
		"horse"
    };
	List<String> rareList = new List<String>()
	{
        "buffalo",
        "polar_bear",
        "rat",
        "seal",
        "tiger",
        "shark",
        "vampire_bat",
		"wolf_pack"
    };
	List<String> legendaryList = new List<String>()
	{
        "blue_whale",
        "centipede",
        "king_kong",
        "king_cobra",
        "sea_serpent",
        "pterodactyl",
		"virus"
    };

	public Zoo()
	{
		InitializeComponent();
		AddDatabase(); 
	}

	public void AddDatabase()
	{
		App.UserRepo.ClearCards(); //clear card table

		//commons
		App.UserRepo.AddCard("baby_goat", "baby_goat.png", 5, 10, "common");
        App.UserRepo.AddCard("hyena", "hyena.png", 35, 15, "common");
        App.UserRepo.AddCard("moose", "moose.png", 15, 25, "common");
        App.UserRepo.AddCard("fox", "fox.jpg", 20, 25, "common");
        App.UserRepo.AddCard("zebra", "zebra.jpg", 10, 20, "common");
		App.UserRepo.AddCard("horse", "horse.png", 15, 30, "common");
        //rares
        App.UserRepo.AddCard("buffalo", "buffalo.png", 10, 30, "rare");
        App.UserRepo.AddCard("polar_bear", "polar_bear.png", 15, 35, "rare");
        App.UserRepo.AddCard("rat", "rat.png", 50, 1, "rare");
        App.UserRepo.AddCard("seal", "seal.png", 20, 20, "rare");
        App.UserRepo.AddCard("shark", "shark.png", 35, 20, "rare");
        App.UserRepo.AddCard("tiger", "tiger.png", 25, 30, "rare");
        App.UserRepo.AddCard("vampire_bat", "vampire_bat.png", 50, 25, "rare");
		App.UserRepo.AddCard("wolf_pack", "wolf_pack.png", 40, 50, "rare");
        //legendary
        App.UserRepo.AddCard("blue_whale", "blue_whale.png", 5, 200, "legendary");
        App.UserRepo.AddCard("centipede", "centipede.png", 40, 60, "legendary");
        App.UserRepo.AddCard("king_cobra", "king_cobra.png", 65, 40, "legendary");
        App.UserRepo.AddCard("king_kong", "king_kong.png", 125, 150, "legendary");
        App.UserRepo.AddCard("pterodactyl", "pterodactyl.png", 75, 60, "legendary");
        App.UserRepo.AddCard("sea_serpent", "sea_serpent.png", 80, 120, "legendary");
		App.UserRepo.AddCard("virus", "virus.png", 200, 1, "legendary"); 

		//Populate Decks
		PopulateDeck(AIDeck); 
		PopulateDeck(PlayerDeck);

        CreateBoard(); 
	}

	public void CreateBoard()
	{
		int rows = 4;
		int columns = 5; 

		for(int i = 0; i < columns; i++)
		{
			for(int j = 0; j < rows; j++)
			{
				Color color = new Color(); 

				if(j == 1 || j == 2)
				{
					color = Color.FromRgb(255, 255, 255); //white
				}
				else
				{
					color = Color.FromRgb(0, 0, 0); //black
				}

				ImageButton sq = new ImageButton()
				{
					BackgroundColor = color
				};

				if(j == 0) //AI Hand
				{
					sq.Source = AIDeck[i].Name + ".png";
					Card newCard = new Card(AIDeck[i].Name, i, j);
					AIHand.Add(newCard);
					AIDeck.RemoveAt(i); 
				}

				if(j == 3) //Player hand
				{
					sq.Source = PlayerDeck[i].Name + ".png";
					Card newCard = new Card(PlayerDeck[i].Name, i, j);
					PlayerHand.Add(newCard);
					PlayerDeck.RemoveAt(i); 
				}

				Gameboard.Add(sq, i, j); 
			}
		}
	}

	public void PopulateDeck(List<Card> Deck)
	{
		int common = 15;
		int rare = 10;
		int legendary = 5;
		Random rand = new Random(); 

		for(int i = 0; i < common; i++)
		{
            //A random number will be generated.
            int randNum = rand.Next(commonList.Count());
            //A card will be drawn from the rarity list.
            string name = commonList[randNum];
            //A card will be drawn from the database.
            Cards result = App.UserRepo.GetCard(name);
            //A new Card object will be created. 
            Card newCard = new Card(result.Name, 0, 0);
            //The new Card will be added to the deck
            Deck.Add(newCard); 
		}

        for (int r = 0; r < rare; r++)
        {
            int randNum = rand.Next(rareList.Count);
            string name = rareList[randNum];
            Cards result = App.UserRepo.GetCard(name);
            Card newCard = new Card(result.Name, 0, 0);
            Deck.Add(newCard);
        }

        for (int l = 0; l < legendary; l++)
        {
            int randNum = rand.Next(legendaryList.Count);
            string name = legendaryList[randNum];
            Cards result = App.UserRepo.GetCard(name);
            Card newCard = new Card(result.Name, 0, 0);
            Deck.Add(newCard);
        }

		//shuffle deck
		ShuffleDeck(Deck); 
    }

	public List<Card> ShuffleDeck(List<Card> deck)
	{
		for(int i = deck.Count() - 1; i >= 0; i--)
		{
			Random shuffleNum = new Random();
			int k = shuffleNum.Next(i + 1);
			var card = deck[k];
			deck[k] = deck[i];
			deck[i] = card;
		}
		return deck; 
	}

	public Card IdentifyCard(int[] location)
	{
        foreach (Card card in PlayerHand)
        {
            if (card.currentLocation[0] == location[0] && card.currentLocation[1] == location[1])
            {
                return card;
            }
        }
        foreach (Card card in AIHand)
        {
            if (card.currentLocation[0] == location[0] && card.currentLocation[1] == location[1])
            {
                return card;
            }
        }
        return null; 
	}
}

public class Card
{
	public string Name;
	public int[] currentLocation = new int[2]; 

	public Card(string name, int i, int j)
	{
		Name = name;
		currentLocation[0] = i;
		currentLocation[1] = j;
	}
}

public class CardBoardSquare
{
	public Zoo p;
	public ImageButton square;
	public int[] location = new int[2];
	public bool isActive = false;
	public bool chosenForMove = false;
	public bool chosenForAttack = false;
	public int currentState = 0;
	public EventHandler DoToggle;
	public EventHandler DoMove;
	public EventHandler CanAttack; 

	public CardBoardSquare(Zoo page, ImageButton sq, int i, int j)
	{
		p = page;
		location[0] = i;
		location[1] = j;
		square = sq; 
	}
}