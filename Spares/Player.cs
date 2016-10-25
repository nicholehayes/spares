using System;

namespace Spares {

	//This class is currently unused.
	//This class is used to create a Player object that's used in a multiplayer game. 
	//Each Player has a name of an arbitrary length, and a "Game" object that's used to differentiate 
	//who is playing at a given time, and which frames and scores belong to which person.
	public class Player {
		static string playerName;
		static Game playerGame;

		//Constructor
		public Player (string name) {
			playerName = name;
			playerGame = new Game ();
		}

		public void getName(){
			Console.WriteLine (playerName);
		}

		public void startGame (){
			playerGame.playGame ();
		}
	}
}