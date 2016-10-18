using System;

namespace Spares {

	class MainClass {

		public static void Main (string[] args) {
		
			//TODO: add support for multiplayer.

			string[] symbolScoreArray = new string[10];
			string[] roundScoreArray = new string[10];
			string[] totalScoreArray = new string[10];
			bool isStrikeOrSpare = false;
			int numPinsDown;
			int numPinsLeft;
			int currentThrow;
			int currentRound;
			int roundScore;
			int totalScore = 0;

			Console.WriteLine ("Welcome to Spares!\n");

			for(currentRound = 1; currentRound <= 3; currentRound++) {

				roundScore = 0;
				numPinsLeft = 10;
				isStrikeOrSpare = false;

				/*
				for (currentThrow = 1; currentThrow <= 2; currentThrow++){
					Console.Write ("ROUND " + currentRound + " THROW " + currentThrow + ": Enter the number of pins knocked down: ");
					numPinsDown = Convert.ToInt32(Console.ReadLine ());


					//Spares can be dealt with better
					//if (currentThrow == 2 && numPinsDown == numPinsStanding){
					//	spareTime();
					//	break;
					//}

					if(currentThrow == 1 && numPinsDown == numPinsLeft){
						roundScore += strikeTime ();
						break; 				//Maybe this is wrong! I want to get out of the inner 'for', not the outer. (return?)
					}
						
					if (numPinsDown <= numPinsLeft){
						numPinsLeft -= numPinsDown;
						roundScore += numPinsDown;
						Console.WriteLine (numPinsDown + " pin(s) hit! " + numPinsLeft + " pin(s) left.");

					}else{
						Console.WriteLine ("Please enter a number of pins that is less than or equal to the current standing number of pins.");
						//throw error, return to console.read line (?)
					}
				}
				*/

				roundScore = twoThrows(currentRound, isStrikeOrSpare);

				totalScore += roundScore;

				roundScoreArray [currentRound - 1] = roundScore.ToString();
				totalScoreArray [currentRound - 1] = totalScore.ToString();

				drawScoreboard (roundScoreArray, totalScoreArray);

				//Console.WriteLine ("Round Score: " + roundScore);
				//Console.WriteLine ("Total Score: " + totalScore);
			}
			Console.WriteLine ("");
		}
			


		//TODO: Add symbol row and final score (maybe). This works fine right now.
		public static void drawScoreboard(string[] roundScoreArray, string[] totalScoreArray){
			Console.WriteLine (" #####################################################################################");
			Console.Write (" # ROUND SCORE");
			for (int i = 0; i < 10; i++){
				Console.Write(String.Format(" # {0,4}", roundScoreArray[i]));
			}
			Console.Write (" # \n ##################################################################################### \n");
			Console.Write (" # TOTAL SCORE");
			for (int i = 0; i < 10; i++){
				Console.Write(String.Format(" # {0,4}", totalScoreArray[i]));
			}
			Console.Write (" # \n #####################################################################################");
			Console.WriteLine ();
		}




		//public static int strikeTime(){
			//int roundScore = 10;
			//int numPinsLeft = 10;
			//int numPinsDown;
			//int strikeThrow;

			//int roundScore = 0;

			//Console.WriteLine ("STRIKE!!");
			//roundScore = twoThrows();
			//Console.WriteLine ("Strike Round Score: " + roundScore);
			//return roundScore;


			/*
			for (strikeThrow = 1; strikeThrow <= 2; strikeThrow++) {
				Console.Write ("STRIKE THROW " + strikeThrow + ": Enter the number of pins knocked down: ");
				numPinsDown = Convert.ToInt32(Console.ReadLine ());

				if (numPinsDown < numPinsLeft) {
					numPinsLeft -= numPinsDown;
					roundScore += numPinsDown;

					Console.WriteLine (numPinsDown + " pins hit! " + numPinsLeft + " pins left.");

				} else if (numPinsDown == 10) {
					roundScore += numPinsDown;
					numPinsLeft = 10;
					Console.WriteLine ("STRIKE!! Strike Round Score: " + roundScore);
				}else {
					Console.WriteLine ("You shouldn't see me!");
					//throw error, return to console.read line (?)
				}
			}
			Console.WriteLine ("Strike Round Score: " + roundScore);
			return roundScore;
			*/
		//}



		//public static int spareTime(){
		//	Console.WriteLine ("SPARE!");
		//}
			



		public static int twoThrows(int currentRound, bool isStrikeOrSpare){

			bool correctUserInput;
			int currentThrow = 1;
			int numPinsDown;
			int roundScore = 0;
			int numPinsLeft = 10;


			for (currentThrow = 1; currentThrow <= 2; currentThrow++){

				correctUserInput = false;

				while (correctUserInput == false){

					if (isStrikeOrSpare == false) {
						Console.Write ("ROUND " + currentRound + " THROW " + currentThrow + ": Enter the number of pins knocked down: ");
					} else {
						Console.Write ("STRIKE ROUND THROW " + currentThrow + ": Enter the number of pins knocked down: ");
					}

					numPinsDown = Convert.ToInt32 (Console.ReadLine ());


					//If strike
					if(currentThrow == 1 && numPinsDown == numPinsLeft){
						correctUserInput = true;
						roundScore += numPinsDown;

						if (isStrikeOrSpare == false) {
							isStrikeOrSpare = true;
							Console.WriteLine ("STRIKE!!");
							roundScore += twoThrows (currentRound, isStrikeOrSpare);
						}

						//roundScore += strikeTime ();
						//strikeTime ();
					}

					//If spare
					else if (currentThrow == 2 && numPinsDown == numPinsLeft){
						correctUserInput = true;
						isStrikeOrSpare = true;
						//spareTime();
					}

					//Else it's a normal hit
					else if (numPinsDown <= numPinsLeft){
						correctUserInput = true;
						numPinsLeft -= numPinsDown;
						roundScore += numPinsDown;
						Console.WriteLine (numPinsDown + " pin(s) hit! " + numPinsLeft + " pin(s) left.");
					}

					//Error catcher
					else{
						Console.WriteLine ("Please enter a number of pins that is less than or equal to the current standing number of pins.");
					}

				}

			}

			return roundScore;


		}

	}
}
