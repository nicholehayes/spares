using System;

namespace Spares {

	class MainClass {

		public static void Main (string[] args) {
		
			//TODO: add support for multiplayer.

			int[] scoreArray = {10};
			int numPinsDown;
			int numPinsStanding;
			int currentThrow;
			int currentRound;
			int totalScore = 0;
			int roundScore;

			Console.WriteLine ("Welcome to Spares!\n");

			for(currentRound = 1; currentRound <= 3; currentRound++) {

				roundScore = 0;
				numPinsStanding = 10;

				for (currentThrow = 1; currentThrow <= 2; currentThrow++){
					Console.Write ("ROUND " + currentRound + " THROW " + currentThrow + ": Enter the number of pins knocked down: ");
					numPinsDown = Convert.ToInt32(Console.ReadLine ());

					if(numPinsDown == 10){
						roundScore += strikeTime ();
						break; 				//Maybe this is wrong! I want to get out of the inner 'for', not the outer. (return?)
					}
						
					if (numPinsDown <= numPinsStanding){
						numPinsStanding -= numPinsDown;
						roundScore += numPinsDown;
						Console.WriteLine (numPinsDown + " pins hit! " + numPinsStanding + " pins left.");

					}else{
						Console.WriteLine ("You shouldn't see me!");
						//throw error, return to console.read line (?)
					}
				}
				totalScore += roundScore;

				Console.WriteLine ("Round Score: " + roundScore);
				Console.WriteLine ("Total Score: " + totalScore);
			}
			Console.WriteLine ("");
		}
			

		public static void drawScoreboard(){
			Console.WriteLine("##################################################");
		}

		public static int strikeTime(){
			int roundScore = 10;
			int numPinsStanding = 10;
			int numPinsDown;
			int strikeThrow;

			Console.WriteLine ("STRIKE TIME! ");

			for (strikeThrow = 1; strikeThrow <= 2; strikeThrow++) {
				Console.Write ("STRIKE THROW " + strikeThrow + ": Enter the number of pins knocked down: ");
				numPinsDown = Convert.ToInt32(Console.ReadLine ());

				if (numPinsDown < numPinsStanding) {
					numPinsStanding -= numPinsDown;
					roundScore += numPinsDown;

					Console.WriteLine (numPinsDown + " pins hit! " + numPinsStanding + " pins left.");

				} else if (numPinsDown == 10) {
					roundScore += numPinsDown;
					numPinsStanding = 10;
					Console.WriteLine ("STRIKE!! Strike Round Score: " + roundScore);
				}else {
					Console.WriteLine ("You shouldn't see me!");
					//throw error, return to console.read line (?)
				}
			}
			Console.WriteLine ("Strike Round Score: " + roundScore);
			return roundScore;
		}

		public static void spareTime(){
			Console.WriteLine ("SPARE!");
		}



		/*USE THIS LATER TO SOLVE REDUNDANCIES
		public static void twoThrows(){

		}*/

	}
}
