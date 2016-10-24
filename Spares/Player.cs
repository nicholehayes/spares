using System;

namespace Spares {

	public class Player {
		static string playerName;
		//int totalScore = 0;

		//Constructor
		public Player (string name) {
			playerName = name;
		}

		public void getName(){
			Console.WriteLine (playerName);
		}
	}
}