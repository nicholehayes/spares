using System;

namespace Spares {

	class MainClass {

		public static void Main (string[] args) {
		
			//TODO: Add a new row in the scoreboard that shows symbols for strikes/spares/open frames.
			//TODO: Implement special tenth frame properly. (It works right now; could be made better)
			//TODO: Implement a way for users to specify how many frames they want.
		
			Console.WriteLine ("Welcome to Spares!\n");
			playGame();
		}
			
		//
		public static void playGame(){
		
			int currentFrame;
			int frameScore;
			int totalScore = 0;
			//string[] symbolScoreArray = new string[10]; (Move to separate function)
			string[] frameScoreArray = new string[10];
			string[] totalScoreArray = new string[10];

			//Plays a game of 10 frames, resets the frame score for each 
			//and draws the scoreboard after each frame
			for(currentFrame = 1; currentFrame <= 10; currentFrame++) {
				frameScore = 0;

				frameScore = frame(currentFrame.ToString());

				totalScore += frameScore;

				//createSymbolArray ();
				frameScoreArray [currentFrame - 1] = frameScore.ToString();
				totalScoreArray [currentFrame - 1] = totalScore.ToString();

				drawScoreboard (frameScoreArray, totalScoreArray);
			}

			Console.WriteLine ("Game Over! Total Score: " + totalScore);
		}


		//The start of a frame without regarding strikes/spares
		public static int frame(string currentFrame){
		
			int currentThrow;
			int numPinsDown;
			int frameScore = 0;
			int numPinsLeft = 10;

			for (currentThrow = 1; currentThrow <= 2; currentThrow++) {
			
				numPinsDown = throwBall (currentFrame, currentThrow, numPinsLeft);

				//If strike
				if (currentThrow == 1 && numPinsDown == numPinsLeft) {
					frameScore += numPinsDown;
					frameScore += strike ();
					break;
				}

				//If spare
				else if (currentThrow == 2 && numPinsDown == numPinsLeft) {
					frameScore += numPinsDown;
					frameScore += spare ();
					break;
				}

				//Else it's an open frame
				else if (numPinsDown <= numPinsLeft) {
					numPinsLeft -= numPinsDown;
					frameScore += numPinsDown;
					Console.WriteLine (numPinsDown + " pin(s) hit! " + numPinsLeft + " pin(s) left."); //Could this be a separate funciton?
				}

			}

			return frameScore;
		}


		public static int throwBall(string currentFrame, int currentThrow, int numPinsLeft){
			int numPinsDown;

			while (true) {
				Console.Write ("FRAME " + currentFrame + " THROW " + currentThrow + ": Enter the number of pins knocked down: ");
				numPinsDown = Convert.ToInt32 (Console.ReadLine ());

				if (0 <= numPinsDown && numPinsDown <= numPinsLeft) {
					return numPinsDown;
				} else {
					Console.WriteLine ("Please enter a number of pins that is less than or equal to the current standing number of pins.");
				}
			}
		}


		public static int strike(){
			string currentFrame = "STRIKE";
			int currentThrow;
			int numPinsLeft = 10;
			int numPinsDown;
			int strikeScore = 0;

			Console.WriteLine ("STRIKE!!");

			for (currentThrow = 1; currentThrow <= 2; currentThrow++) {

				numPinsDown = throwBall (currentFrame, currentThrow, numPinsLeft);

				numPinsLeft -= numPinsDown;
				strikeScore += numPinsDown;
				Console.WriteLine (numPinsDown + " pin(s) hit! " + numPinsLeft + " pin(s) left."); //Could this be a separate funciton?

				//Reset pins if they were all knocked down
				if (numPinsLeft == 0){
					numPinsLeft = 10;
				}
			}
			Console.WriteLine ("Strike Round Score: " + strikeScore);
			return strikeScore;

		}
			

		public static int spare(){
			string currentFrame = "SPARE";
			int currentThrow = 1;
			int numPinsLeft = 10;
			int spareScore = 0;

			Console.WriteLine ("SPARE!");
			spareScore += throwBall (currentFrame, currentThrow, numPinsLeft);

			return spareScore;
		}
			

		//TODO: Add symbol row and final score (maybe). This works fine right now.
		public static void drawScoreboard(string[] roundScoreArray, string[] totalScoreArray){

            Console.WriteLine (" +-------------------------------------------------------------------------+");
			Console.WriteLine (" |    FRAME    |   1 |   2 |   3 |   4 |   5 |   6 |   7 |   8 |   9 |  10 |");
			Console.WriteLine (" |-------------------------------------------------------------------------|");
			Console.Write (" | ROUND SCORE");
			for (int i = 0; i < 10; i++){
				Console.Write(String.Format(" | {0,3}", roundScoreArray[i]));
			}
			Console.Write (" | \n |-------------------------------------------------------------------------| \n");
			Console.Write (" | TOTAL SCORE");
			for (int i = 0; i < 10; i++){
				Console.Write(String.Format(" | {0,3}", totalScoreArray[i]));
			}
			Console.Write (" | \n +-------------------------------------------------------------------------+");
			Console.WriteLine ("\n");
		}
	}
}