using System;
using System.Collections.Generic;

namespace Spares {

	class MainClass {
	
		public static void Main (string[] args) {
		
			Console.WriteLine ("Welcome to Spares!\n");

			Game game = new Game ();
			game.playGame ();

		}
	}
}