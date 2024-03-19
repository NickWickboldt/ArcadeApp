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

	public int playerHealthNumber = 10;
	public int AIHealthNumber = 10; 

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

		UserHealth.Text = playerHealthNumber.ToString(); 
		AIHealth.Text = AIHealthNumber.ToString();
    }

	public void AddDatabase()
	{
		App.UserRepo.ClearCards(); //clear card table

		//commons
		App.UserRepo.AddCard("baby_goat", "baby_goat.png", 5, 10, "common");
        App.UserRepo.AddCard("hyena", "hyena.png", 35, 15, "common");
        App.UserRepo.AddCard("moose", "moose.png", 15, 25, "common");
        App.UserRepo.AddCard("fox", "fox.png", 20, 25, "common");
        App.UserRepo.AddCard("zebra", "zebra.png", 10, 20, "common");
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
		int handSize = 5; 

		for(int i = 0; i< handSize; i++)
		{
			ImageButton sq = new ImageButton();
			sq.Source = AIDeck[0].Name = ".png";
			Card newCard = AIDeck[0];
			newCard.spot = i;
			newCard.location = "aiHand";
			AIHand.Add(newCard);
			AIDeck.RemoveAt(0);
			AIHandGrid.Add(sq, i, 0);
			CardBoard.Add(new CardBoardSquare(this, sq, i, "aiHand", false)); 
		}

		for(int i = 0; i< handSize; i++)
		{
			ImageButton sq = new ImageButton();
			AIFieldGrid.Add(sq, i, 0);
			CardBoard.Add(new CardBoardSquare(this, sq, i, "aiField", true)); 
		}

		for(int i = 0; i< handSize; i++)
		{
			ImageButton sq = new ImageButton();
			PlayerFieldGrid.Add(sq, i, 0);
			CardBoard.Add(new CardBoardSquare(this, sq, i, "playerField", true)); 
		}

		for(int i = 0; i< handSize; i++)
		{
			ImageButton sq = new ImageButton();
			sq.Source = PlayerDeck[0].Name = ".png";
			Card newCard = PlayerDeck[0];
			newCard.spot = i;
			newCard.location = "playerHand";
			PlayerHand.Add(newCard);
			PlayerDeck.RemoveAt(0);
			PlayerHandGrid.Add(sq, i, 0);
			CardBoard.Add(new CardBoardSquare(this, sq, i, "playerHand", false)); 
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
            Card newCard = new Card(result.Name, 0, "DECK");
            //The new Card will be added to the deck
            Deck.Add(newCard); 
		}

        for (int r = 0; r < rare; r++)
        {
            int randNum = rand.Next(rareList.Count);
            string name = rareList[randNum];
            Cards result = App.UserRepo.GetCard(name);
            Card newCard = new Card(result.Name, 0, "DECK");
            Deck.Add(newCard);
        }

        for (int l = 0; l < legendary; l++)
        {
            int randNum = rand.Next(legendaryList.Count);
            string name = legendaryList[randNum];
            Cards result = App.UserRepo.GetCard(name);
            Card newCard = new Card(result.Name, 0, "DECK");
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

    public Card IdentifyCard(int spot, string location)
    {
        foreach (Card card in PlayerHand)
        {
            if (card.spot == spot && card.location == location)
            {
                return card;
            }
        }
        foreach (Card card in AIHand)
        {
            if (card.spot == spot && card.location == location)
            {
                return card;
            }
        }
        foreach (Card card in PlayerField)
        {
            if (card.spot == spot && card.location == location)
            {
                return card;
            }
        }
        foreach (Card card in AIField)
        {
            if (card.spot == spot && card.location == location)
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

    }


	public void DeleteCard(Card card)
	{
		CardBoardSquare cbsq = null; 

		if (card.location == "aiField")
		{
            cbsq = IdentifyCardBoardSquare(card.spot, "aiField");
			cbsq.square.Source = null;
			cbsq.empty = true; 
            AIField.Remove(card);
			AIHealthNumber--;
			UpdateHealth(AIHealthNumber, playerHealthNumber); 
		}
		if (card.location == "playerField")
		{
            cbsq = IdentifyCardBoardSquare(card.spot, "playerField");
            cbsq.square.Source = null;
            cbsq.empty = true;
            PlayerField.Remove(card);
			playerHealthNumber--;
			UpdateHealth(AIHealthNumber, playerHealthNumber); 
		}
	}

    public CardBoardSquare IdentifyCardBoardSquare(int spot, string location)
    {
        foreach (CardBoardSquare square in CardBoard)
        {
            if (square.spot == spot && square.location == location)
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

    private void EndTurnButton_Clicked(object sender, EventArgs e)
    {
		AITurn(); 
    }

	public void AITurn()
	{
		int cardsInField = AIField.Count;
		int playerHighestHitpointCard = 0;
		Cards playerCard = null;
		Card target = null;
		Card AICard = null;
		bool endTurn = false; 
		List<Card> playableAICard = new List<Card>(); //used to store playable cards

        foreach (Card card in PlayerField)
        {
			playerCard = App.UserRepo.GetCard(card.Name); 
			
			if(playerCard.Hitpoint > playerHighestHitpointCard)
			{
				playerHighestHitpointCard = playerCard.Hitpoint;
				target = card; 
			}
        }

        foreach (Card card in AIHand)
        {
			Cards AICardData = App.UserRepo.GetCard(card.Name); 
			
			if(AICardData.Attack > playerHighestHitpointCard)
			{
				playableAICard.Add(card); 
			}
			else
			{
				if(AICardData.Hitpoint > playerHighestHitpointCard)
				{
                    playableAICard.Add(card);
                }
			}
        }

        foreach (Card card in playableAICard)
        {
			AICard = card; 
			int currentCardAttack = App.UserRepo.GetCard(AICard.Name).Attack;
			int cardInListAttack = App.UserRepo.GetCard(card.Name).Attack; 

			if(currentCardAttack >= cardInListAttack) //find greatest attacking value from playable cards
			{
				AICard = card; 
			}
        }

		if(cardsInField < 2)
		{
			//play the card
			AIPlayCard(AICard); 
		}
		else
		{
            //issue attack
            foreach (Card card in AIField)
            {
				Cards cardData = App.UserRepo.GetCard(card.Name);

				if(cardData.Attack > playerCard.Hitpoint)
				{
					//attack
					AIAttack(card, target); 
				}
            }
        }

        foreach (CardBoardSquare cbs in CardBoard)//reset toggles on CardBoard
        {
			cbs.ToggleCard(); 
        }
    }

	public void AIPlayCard(Card card)
	{
		int[] currentLocation = new int[2] { card.currentLocation[0], card.currentLocation[1] };
		int[] downMove = new int[2] { card.currentLocation[0], card.currentLocation[1] + 1 };
		int[] downRightMove = new int[2] { card.currentLocation[0] + 1, card.currentLocation[1] + 1 };
		int[] downLeftMove = new int[2] { card.currentLocation[0] - 1, card.currentLocation[1] + 1 };
		CardBoardSquare fromSquare = IdentifyCardBoardSquare(currentLocation);
		CardBoardSquare toSquare = IdentifyCardBoardSquare(downMove); 

		if(Convert.ToString(toSquare.square.Source).Length > 2) //check down move
		{
			toSquare = IdentifyCardBoardSquare(downLeftMove);

			if (Convert.ToString(toSquare.square.Source).Length > 2) //check left move
			{
				toSquare = IdentifyCardBoardSquare(downRightMove); //choose down right move

                card.currentLocation = toSquare.location;
                fromSquare.square.Source = AIDeck[0].Name + ".png";
                toSquare.square.Source = card.Name + ".png";
                Card newCard = new Card(card.Name, toSquare.location[0], toSquare.location[1]);
                AIField.Add(newCard);
            }
			else //chose left move
			{
                card.currentLocation = toSquare.location;
                fromSquare.square.Source = AIDeck[0].Name + ".png";
                toSquare.square.Source = card.Name + ".png";
                Card newCard = new Card(card.Name, toSquare.location[0], toSquare.location[1]);
                AIField.Add(newCard);
            }
		}
		else //choose down move
		{
            card.currentLocation = toSquare.location;
            fromSquare.square.Source = AIDeck[0].Name + ".png";
            toSquare.square.Source = card.Name + ".png";
            Card newCard = new Card(card.Name, toSquare.location[0], toSquare.location[1]);
            AIField.Add(newCard);
        }


        foreach (CardBoardSquare cbs in CardBoard)
        {
			cbs.EnemySquare(); 
        }
    } 

	public void AIAttack(Card attack, Card target)
	{
		Cards attacker = App.UserRepo.GetCard(attack.Name);
		Cards defender = App.UserRepo.GetCard(target.Name); 

		if(attacker.Attack > defender.Hitpoint) //attacker wins
		{
			DeleteCard(target);
		}
		else
		{
			if(attacker.Attack == defender.Hitpoint) //trade
			{
				DeleteCard(attack);
				DeleteCard(target);
			}
			else
			{
				DeleteCard(attack); //self-defeat
			}
		}
	}

	public void UpdateHealth(int aH, int pH) //update text values
	{
		UserHealth.Text = pH.ToString();
		AIHealth.Text = aH.ToString(); 
	}
}

public class Card
{
	public string Name;
	public string location;
	public int spot; 

	public Card(string name, int s, string l)
	{
		Name = name;
		spot = s;
		location = l; 
	}
}

public class CardBoardSquare
{
	public Zoo p;
	public ImageButton square;
	public string location;
	public bool empty = true;
	public int spot = 0; 
	public bool chosenForMove = false;
	public bool chosenForAttack = false;
	public int currentState = 0;
	public EventHandler DoToggle;
	public EventHandler DoMove;
	public EventHandler CanAttack; 

	public CardBoardSquare(Zoo page, ImageButton sq, int s, string l, bool e)
	{
		p = page;
		square = sq;
		spot = s;
		location = l;
		empty = e; 
		ToggleCard(); 
	}

	public void ToggleCard()
	{
		if (empty == false) //if there is a card
		{
			if (IsUserCard())
			{
				DoToggle = (sender, args) =>
				{
					if (currentState == 0 && (p.cardIsSelected == false))
					{
						square.Scale = 1.1;
						currentState = 1;
						p.cardIsSelected = true;
                        //check for attack or move validity
                        if (location == "playerHand")
                        {
                            chosenForMove = true;
                        }
                        if (location == "playerField")
                        {
                            chosenForAttack = true;
                        }
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
			if (location == "playerField")
			{
                //user can move here
                EmptySquare();
            }
			if (location == "aiField")
			{
                //user can attack here
                EnemySquare();
            }
		}
	}

	public bool IsUserCard()
	{
		if (location == "playerHand" || location == "playerField")
		{
			return true; 
		}
		return false; 
	}

	public void EmptySquare()
	{
        DoMove = (sender, args) =>
        {
            if (Convert.ToString(square.Source).Length == 0)
            {
                currentState = 0;
                chosenForMove = false;
                p.cardIsSelected = false;
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
            if (Convert.ToString(square.Source).Length > 0)
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