using System;
using System.Collections.Generic;

namespace Spares {

	class MainClass {
	
		static bool userCorrectInput = false;
		static int numFrames = 10;
		//static List<Player> playerList = new List<Player>();
		//static int numPlayers;
		//static int playerNum;
		//static string playerName;

		public static void Main (string[] args) {
		
			//TODO: Add a new row in the scoreboard that shows symbols for strikes/spares/open frames.
			//TODO: Implement strikes/spares properly. Has to read the next rolls after the strike/spare.
			//TODO: Implement a way for users to specify how many frames they want.
			//TODO: Ask the user how many players are playing, then ask for their names. This eliminates the List problem.

			//TODO: Need to check input thats not of the right type, right now it crashes.
			//TODO: Create pin objects, assign them indexes in a pin array (keeps track of which pins are down/up)
			//TODO: Maybe implement a game object class with a specified number of frames? Could help with multiplayer.
			//TODO: try to use "foreach" in loops if an index isn't required

			Console.WriteLine ("Welcome to Spares!\n");

			//enterFrames ();

			Game game = new Game (numFrames);
			game.playGame ();

			//enterPlayerNum ();
			//enterPlayerName ();

			//Console.WriteLine (playerList.Count);

			//foreach(Player player in playerList){
			//	player.getName ();
				//Game game = new Game (numFrames, player.getName());
			//}

			//Game game1 = new Game (numFrames);

			//game1.playGame ();
		}

		/*
		public static void enterFrames() {

			do {
				Console.Write ("Please enter the number of desired frames (Up to 10): ");
				numFrames = Convert.ToInt32 (Console.ReadLine ()); //How to test if user input a letter/symbol?

				if(numFrames < 1 || numFrames > 10) {
					continue;
				}else{
					userCorrectInput = true;
				}
			} while(userCorrectInput == false);
			Console.WriteLine ();
		}


		public static void enterPlayerNum() {
		
			do {
				Console.Write ("Please enter the number of players that will be bowling today (Up to 4): ");
				numPlayers = Convert.ToInt32 (Console.ReadLine ()); //How to test if user input a letter/symbol?

				if (numPlayers < 1 || numPlayers > 4) {
					continue;
				} else {
					userCorrectInput = true;
				}

			} while(userCorrectInput == false);
				
			userCorrectInput = false;
		}


		public static void enterPlayerName() {

			for (playerNum = 0; playerNum < numPlayers; playerNum++) {
				do {
					Console.Write ("Enter Player " + (playerNum + 1) + "'s name: ");
					playerName = Console.ReadLine ();

					//If the user just entered spaces without a name
					if(string.IsNullOrWhiteSpace(playerName)){
						continue;
					}else{
						userCorrectInput = true;
					}
				} while (userCorrectInput == false);

				playerList.Add (new Player(playerName) );
			}
		}
		*/
	}
}