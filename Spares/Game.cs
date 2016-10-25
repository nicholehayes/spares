using System;
using System.Collections.Generic;

namespace Spares {

	public class Game {
	
		//Creates various arrays for each frame in the game. In this case, the game is 10 frames in length.
		static Frame[] frameArray = new Frame[10];
		string[] symbolArray = new string[10];
		static int[] frameScoreArray = new int[10];

		//Initialize various ints
		static int currentFrameNum = 0;
		static int totalScore = 0;
		static int currentThrow;
		static int numPinsDown;

		//Construct game object
		public Game (){
		}

		//Main function of Game. Plays a game of 10 frames.
		public void playGame(){

			//Sets up the ten Frames in frameArray
			for (int i = 0; i < frameArray.Length; i++) {
				frameArray [i] = new Frame ();
			}

				
			//Plays a game of 10 frames, resets the frame score, total score and draws the scoreboard after each frame.
			foreach (Frame frame in frameArray) {
				totalScore = 0;
				currentFrameNum++;

				//Plays the frame
				frameScoreArray [currentFrameNum - 1] = playFrame (frame, currentFrameNum);

				//Adds the current frame's score into the total score of the game.
				for (int i = 0; i < frameScoreArray.Length; i++){
					totalScore += frameScoreArray[i];
				}

				//Builds up the symbol array used when drawing the scoreboard.
				createSymbolArray (frame);
				symbolArray[currentFrameNum - 1] = frame.getSymbol();

				drawScoreboard (symbolArray, frameScoreArray, totalScore);
			}
				
			Console.WriteLine ("Game Over! Total Score: " + totalScore);
		}


		//The start of a frame.
		public int playFrame(Frame frame, int currentFrameNum){

			//There are a max of two throws for frames 1-9.
			for (currentThrow = 1; currentThrow <= 2; currentThrow++) {

				numPinsDown = throwBall (frame, currentFrameNum, currentThrow, frame.getPinsLeft());

				if (currentThrow == 1) {
					frame.setThrow1 (numPinsDown);
				}else if (currentThrow == 2){
					frame.setThrow2 (numPinsDown);
				}
					
				//For every frame after the first, checks if the previous throws were strikes 
				//or if the previous throw was a spare. If so, it adds the number of pins knocked down 
				//on the current throw to the previous frame's score.
				if (currentFrameNum > 1){
					for(int i = 0; i < currentFrameNum; i++){
						if (frameArray[i].isStrike()){
							frameArray[i].setStrikeThrow (numPinsDown);
							frameScoreArray [i] = frameArray[i].getframeTotal ();
						}
						if (frameArray[i].isSpare ()) {
							frameArray[i].setSpareThrow (numPinsDown);
							frameScoreArray [i] = frameArray[i].getframeTotal ();
						}
					}
				}
							
				//If the first throw knocked down all 10 pins, set the Frame's strike bool.
				//If it's currently the tenth frame, run the special strike function.
				if (currentThrow == 1 && frame.getPinsLeft() == 0){
					Console.WriteLine ("STRIKE!!");
					frame.setStrike ();
					if (currentFrameNum == 10) {
						strike (frame, currentFrameNum);
					}
					break;
				}

				//If the second throw resulted in a spare, set the Frame's spare bool.
				//If it's currently the tenth frame, adds an extra third throw.
				if (currentThrow == 2 && frame.getPinsLeft() == 0){
					Console.WriteLine ("SPARE!");
					frame.setSpare ();
					if(currentFrameNum == 10){
						currentThrow++;
						frame.resetPins ();
						numPinsDown = throwBall (frame, currentFrameNum, currentThrow, frame.getPinsLeft ());
						frame.setThrow3 (numPinsDown);
					}
					break;
				}

			}
			//Returns the total score for the frame.
			return frame.getframeTotal ();
		}

		//This is the special strike function called by the tenth frame.
		public static void strike(Frame frame, int currentFrame){
			int currentThrow;
			int numPinsLeft = 10;
			int numPinsDown;

			//If the first throw of the tenth frame is a strike, player gets two extra throws.
			for (currentThrow = 1; currentThrow <= 2; currentThrow++) {

				numPinsDown = throwBall (frame, 2, currentThrow, numPinsLeft);

				if (currentThrow == 1) {
					frame.setThrow2 (numPinsDown);
				}else if (currentThrow == 2){
					frame.setThrow3 (numPinsDown);
				}

				//If the ninth frame was a strike, add in the first extra throw of the tenth frame.
				if (currentThrow == 1 && frameArray[8].isStrike()){ 
					frameArray[8].setStrikeThrow (numPinsDown);
					frameScoreArray [8] = frameArray[8].getframeTotal ();
				}

				numPinsLeft -= numPinsDown;

				//Reset pins if they were all knocked down.
				if (numPinsLeft == 0){
					numPinsLeft = 10;
				}
			}

		}

		//Function that's called every time a throw occurs. Asks the player for the number of pins 
		//knocked down in the throw, and returns that value.
		public static int throwBall(Frame frame, int currentFrameNum, int currentThrow, int numPinsLeft){
		
			Console.WriteLine ("FRAME " + currentFrameNum + " THROW " + currentThrow + ", " + numPinsLeft + " pins standing:");

			while (true) {

				//This block is used if I get drawPins working. Not currently used.
				/*Console.Write ("Which pins were knocked down on this throw? Enter their numbers here, separated by spaces: ");
				input = Console.ReadLine ();
				string[] tokens = input.Split (' ');
				int[] pins = Array.ConvertAll (tokens, int.Parse);

				foreach (int num in pins) {
					foreach (Pin pin in pinList) {
						if (Convert.ToInt32(pin.getPinNumber()) == num) {
							pin.isKnockedDown = true;
						}
					}
				}*/

				Console.Write ("Enter the number of pins knocked down: ");

				//Reads the string entered into the console. If the given value is not an int between 0
				//and the number of pins currently standing, the program asks for a valid int.
				string readNumber = Console.ReadLine ();

				if (int.TryParse(readNumber, out numPinsDown)){
					if (numPinsDown <= numPinsLeft && numPinsDown >= 0) {
						return numPinsDown;
					} else {
						Console.WriteLine ("Please enter a number of pins that is less than or equal to the current standing number of pins.");
					}
				}else {
					Console.WriteLine ("Please enter a number of pins that is less than or equal to the current standing number of pins.");
				}
			}
		}
			
		//This draws the scoreboard seen after each frame finishes. It's very static right now.
		//TODO: If multiplayer is implemented, change SCORE to PLAYER 1, 2, etc, or given names under a certain length
		public static void drawScoreboard(string[] symbolArray, int[] frameScoreArray, int totalScore){

			Console.WriteLine (" +-----------------------------------------------------------------------------+");
			Console.WriteLine (" | FRAME |   1 |   2 |   3 |   4 |   5 |   6 |   7 |   8 |   9 |    10 | TOTAL |");
			Console.WriteLine (" |-----------------------------------------------------------------------------|");
			Console.Write (" | SCORE");
			for (int i = 0; i < 9; i++){
				Console.Write(String.Format(" | {0,3}", symbolArray[i]));
			}
			Console.Write(String.Format(" | {0,5}", symbolArray[9]));
			Console.WriteLine (" |       |");
			Console.Write (" |      ");
			for (int i = 0; i < 9; i++){
				Console.Write(String.Format(" | {0,3}", frameScoreArray[i]));
			}
			Console.Write(String.Format(" | {0,5}", frameScoreArray[9]));
			Console.Write(String.Format(" | {0,5}", totalScore));

			Console.Write (" |\n +-----------------------------------------------------------------------------+\n\n");
		}


		//This sets the symbols for each frame that are used to show strikes, spares, or open frames.
		//(ex. "X X", "3 /", "2 4", "X 3 /", etc.)
		public static void createSymbolArray(Frame frame){
		
			//If it's the 10th frame, display the results of the two/three throws
			if (currentFrameNum == 10) {

				//If the first throw is a strike
				if (frame.getThrow1 () == 10) {
					frame.setSymbol ("X");
				} 
				//Else if first throw was a gutterball
				else if (frame.getThrow1 () == 0){
					frame.setSymbol ("-");
				} else {
					frame.setSymbol("" + frame.getThrow1());
				}

				//If the second throw is a strike
				if (frame.getThrow2 () == 10) {
					frame.setSymbol (" X");
				} 
				//Else if second throw was a gutterball
				else if (frame.getThrow2 () == 0){
					frame.setSymbol (" -");
				}
				//Else if throw 1 and throw 2 create a spare
				else if (frame.getThrow1 () < 10 && frame.getThrow2 () < 10 && (frame.getThrow1 () + frame.getThrow2 ()) == 10) {
					frame.setSymbol (" /");
				} else {
					frame.setSymbol(" " + frame.getThrow2());
				}

				//If the third throw is a strike
				if (frame.getThrow3 () == 10) {
					frame.setSymbol (" X");
				} 
				//Else if third throw was a gutterball (only exists after a strike or spare)
				else if((frame.getThrow1 () == 10 || (frame.getThrow1 () + frame.getThrow2 ()) == 10) && frame.getThrow3 () == 0){
					frame.setSymbol (" -");
				}
				//Else if throw 2 and throw 3 create a spare
				else if (frame.getThrow2 () < 10 && frame.getThrow3 () < 10 && (frame.getThrow2 () + frame.getThrow3 ()) == 10) {
					frame.setSymbol (" /");
				} 
				//Else print out the third throw (only exists after a strike or spare)
				else if ((frame.getThrow1 () == 10 || (frame.getThrow1 () + frame.getThrow2 ()) == 10)){
					frame.setSymbol (" " + frame.getThrow3 ());
				}
					
			} 
			//If it's not the 10th frame, it must be frame 1-9. Print the two symbols normally.
			else {
				//If the first throw was a strike
				if (frame.getThrow1 () == 10) {
					frame.setSymbol ("X");
					return;
				} 
				//Else if the first throw was a gutterball
				else if (frame.getThrow1 () == 0) {
					frame.setSymbol ("-");
				} else {
					frame.setSymbol ("" + frame.getThrow1());
				}
					
				//If the second throw resulted in a spare
				if ((frame.getThrow1 () + frame.getThrow2 ()) == 10) {
					frame.setSymbol (" /");
				} 
				//Else if the second throw was a gutterball
				else if (frame.getThrow2 () == 0) {
					frame.setSymbol (" -");
				}else {
					frame.setSymbol (" " + frame.getThrow2 ());
				}
			}
		}


		//This is used to draw a pyramid of pins after each throw, showing which pins are up and which pins are down.
		//Pins that are standing are represented with their pin number 1-10, those that are down are represented with an "X".
		/*public void drawPins(){

			foreach (Pin pin in pinList) {
				if (pin.isKnockedDown == true){
					pinNums[Convert.ToInt32(pin.getPinNumber())] = "X";
				}
			}

			Console.WriteLine ("   " + pinNums[0] + "   ");
			Console.WriteLine ("  " + pinNums[1] + " " + pinNums[2] + "  ");
			Console.WriteLine (" " + pinNums[3] + " " + pinNums[4] + " " + pinNums[5] + " ");
			Console.WriteLine (pinNums[6] + " " + pinNums[7] + " " + pinNums[8] + " " + pinNums[9]);
		}*/
	}
}