namespace ArcadeAppNick;

public partial class Zoo : ContentPage
{
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
        App.UserRepo.AddCard("sea_serpent", "seap_serpent", 80, 120, "legendary");

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

				Gameboard.Add(sq, i, j); 
			}
		}
	}
}