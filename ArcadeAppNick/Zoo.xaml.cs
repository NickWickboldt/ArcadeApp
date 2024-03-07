using ArcadeAppNick.Models;

namespace ArcadeAppNick;

public partial class Zoo : ContentPage
{
	public List<CardBoardSquare> CardBoard = new List<CardBoardSquare>(); 
	public List<Card> PlayerDeck = new List<Card>();
	public List<Card> PlayerHand = new List<Card>();
	public List<Card> PlayerField = new List<Card>();

	public List<Card> AIDeck = new List<Card>();
	public List<Card> AIHand = new List<Card>();
	public List<Card> AIField = new List<Card>();

	public bool cardIsSelected = false; 

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
				CardBoard.Add(new CardBoardSquare(this, sq, i, j)); 
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

	public void PlayerMoveCard(CardBoardSquare newSquare)
	{
		newSquare.isActive = true;
		int[] fromLocation = new int[2];

        foreach (CardBoardSquare boardCard in CardBoard)
        {
			if (boardCard.chosenForMove)
			{
				fromLocation = boardCard.location;

                foreach (Card card in PlayerHand)
                {
					if (card.currentLocation[0] == fromLocation[0] && card.currentLocation[1] == fromLocation[1])
					{
                        card.currentLocation[0] = newSquare.location[0];//move the card
                        card.currentLocation[1] = newSquare.location[1];

                        newSquare.square.Source = card.Name + ".png"; //set the image to new square

                        PlayerField.Add(card);//add the card to field
                    }
                }

				boardCard.square.Source = PlayerDeck[0].Name = ".png";
				boardCard.square.Scale = 1;
				boardCard.chosenForMove = false; 
            }
        }
        foreach (CardBoardSquare boardCard in CardBoard)
        {
			boardCard.RemoveEvents(); //remove miscellaneous events
        }

		DrawCard(PlayerDeck, fromLocation, PlayerHand); 
    }

	public void DrawCard(List<Card> deck, int[] fromLocation, List<Card> hand)
	{
		Card newCard = new Card(deck[0].Name, fromLocation[0], fromLocation[1]);

		hand.Add(newCard);

		deck.RemoveAt(0); 
	}

	public void DeleteCard(Card card)
	{
		CardBoardSquare effectedSquare = IdentifyCardBoardSquare(card.currentLocation);

		effectedSquare.square.Source = null;
		effectedSquare.square.BackgroundColor = Color.FromRgb(255, 255, 255);

		if (card.currentLocation[1] == 1)
		{
			AIField.Remove(card); 
		}
		if (card.currentLocation[1] == 2)
		{
			PlayerField.Remove(card); 
		}
	}

	public CardBoardSquare IdentifyCardBoardSquare(int[] location)
	{
        foreach (CardBoardSquare square in CardBoard)
        {
            if (square.location[0] == location[0] && square.location[1] == location[1])
            {
                return square;
            }
        }
        return null;
    }

	public void AttackThis(CardBoardSquare targetBoard)
	{
		int[] targetLocation = new int[2] { targetBoard.location[0], targetBoard.location[1] };

		Card target = IdentifyCard(targetLocation);

		Cards targetData = App.UserRepo.GetCard(target.Name);

        foreach (CardBoardSquare playerCard in CardBoard)
        {
			if (playerCard.chosenForAttack)
			{
				Card attacker = IdentifyCard(playerCard.location);

				Cards attackerData = App.UserRepo.GetCard(attacker.Name); 

				if(attackerData.Attack > targetData.Hitpoint)
				{
					DeleteCard(target); 
				}
				if(attackerData.Hitpoint < targetData.Attack)
				{
					DeleteCard(attacker); 
				}

				playerCard.square.Scale = 1; 
			}
        }
        foreach (CardBoardSquare boardCard in CardBoard)
        {
			boardCard.ToggleCard(); 
        }
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
		ToggleCard(); 
	}

	public void ToggleCard()
	{
		if (Convert.ToString(square.Source).Length > 3) //if there is a card
		{
			isActive = true;
			if (IsUserCard())
			{
				DoToggle = (sender, args) =>
				{
					Card currentCard = p.IdentifyCard(location); //get current Card
					if (currentState == 0 && (p.cardIsSelected == false))
					{
						square.Scale = 1.1;
						currentState = 1;
						p.cardIsSelected = true;
						//check for attack or move validity
						CheckMoveOrAttack(currentCard); 
					}
					else if (chosenForAttack || chosenForMove)
					{
						chosenForMove = false;
						chosenForAttack = false; 
						currentState = 0;
						p.cardIsSelected = false;
						square.Scale = 1; 
					}
				};
				square.Clicked += DoToggle; 
			}
		}
		else
		{
			//there is no card (square is empty)
			if (location[1] == 2)
			{
                //user can move here
                EmptySquare();
            }
			if (location[1] == 1)
			{
                //user can attack here
                EnemySquare();
            }
		}
	}

	public bool IsUserCard()
	{
		if (location[1] == 2 || location[1] == 3)
		{
			return true; 
		}
		return false; 
	}

	public void CheckMoveOrAttack(Card card)
	{
		if (card.currentLocation[1] == 3) //if card is in user's hand
		{
			chosenForMove = true; 
		}
		else //else is in user's field
		{
			chosenForAttack = true;
		}
	}

	public void EmptySquare()
	{
        DoMove = (sender, args) =>
        {
            if (Convert.ToString(square.BackgroundColor) == Convert.ToString(Color.FromRgb(255, 255, 255))
                || Convert.ToString(square.Source).Length == 0)
            {
                currentState = 0;
                chosenForMove = false;
                p.cardIsSelected = false;
                square.BackgroundColor = Color.FromRgb(0, 0, 0);//black
				//player move
				p.PlayerMoveCard(this); 
            }
        };
        square.Clicked += DoMove;
    }

	public void EnemySquare()
	{
        CanAttack = (sender, args) =>
        {
            if (Convert.ToString(square.Source).Length > 1)
            {
                currentState = 0;
                chosenForAttack = false;
                p.cardIsSelected = false;
				//player attack
				p.AttackThis(this); 
            }
        };
        square.Clicked += CanAttack;
    }

	public void RemoveEvents()
	{
		square.Clicked -= DoToggle;
		square.Clicked -= DoMove; 
	}
}