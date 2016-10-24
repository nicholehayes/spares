using System;
using System.Collections.Generic;

namespace Spares {

	public class Game {

		//If there's going to be multiple games (IE, multiplayer), need to remove "static" from variables
		//List<Pin> pinList = new List<Pin>();
	
		//static string[] pinNums = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};

		Frame[] frameArray = new Frame[10];
		int[] frameScoreArray = new int[10];

		static int numFrames;
		static int currentFrameNum = 0;
		static int currentThrow;
		static int numPinsDown;
		static int totalScore = 0;
		//static string playerName;

		public Game (int frames){
			numFrames = frames;
		}


		public void playGame(){
			//string[] symbolScoreArray = new string[10]; (Move to separate function)

			//Sets up the ten frames
			for (int i = 0; i < frameArray.Length; i++) {
				frameArray [i] = new Frame ();
			}

			//Sets up pin list, should be the same for every game given there are 10 pins in each game
			//for(int i = 0; i <= 9; i++) {
			//	pinList.Add (new Pin(i));
			//}
				
			//Plays a game of 10 frames, resets the frame score for each 
			//and draws the scoreboard after each frame
			foreach (Frame frame in frameArray) {
				totalScore = 0;
				currentFrameNum++;

				//Check for tenth frame
				if (frame == frameArray [9]) {
					playTenthFrame (frame);
				} else {
					playFrame (frame); 
				}

				//createSymbolArray ();
				for (int i = 0; i < frameScoreArray.Length; i++){
					totalScore += frameScoreArray[i];
				}
				frameScoreArray [currentFrameNum - 1] = frame.getframeTotal();
				//totalScoreArray [currentFrame - 1] = totalScore.ToString();

				drawScoreboard (frameScoreArray, totalScore);
			}

			Console.WriteLine ("Game Over! Total Score: " + totalScore);
		}


		//The start of frames 1-9
		public void playFrame(Frame frame){

			for (currentThrow = 1; currentThrow <= 2; currentThrow++) {

				numPinsDown = throwBall (frame, currentFrameNum, currentThrow, frame.getPinsLeft());

				if (currentThrow == 1) {
					frame.setThrow1 (numPinsDown);
				}else if (currentThrow == 2){
					frame.setThrow2 (numPinsDown);
				}

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
									
				if (currentThrow == 1 && frame.getPinsLeft() == 0){
					Console.WriteLine ("STRIKE!!");
					frame.setStrike ();
					break;
				}

				if (currentThrow == 2 && frame.getPinsLeft() == 0){
					Console.WriteLine ("SPARE!");
					frame.setSpare ();
					break;
				}

			}
			totalScore += frame.getframeTotal();
		}

		public void playTenthFrame(Frame frame){

			for (currentThrow = 1; currentThrow <= 2; currentThrow++) {

				numPinsDown = throwBall (frame, currentFrameNum, currentThrow, frame.getPinsLeft ());

				if (currentThrow == 1) {
					frame.setThrow1 (numPinsDown);
				}else if (currentThrow == 2){
					frame.setThrow2 (numPinsDown);
				}

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

				if (currentThrow == 1 && frame.getPinsLeft() == 0){
					Console.WriteLine ("STRIKE!!");
					frame.setStrike ();
					strike (frame);
					break;
				}

				if (currentThrow == 2 && frame.getPinsLeft() == 0){
					Console.WriteLine ("SPARE!");
					currentThrow++;
					frame.setSpare ();
					frame.resetPins ();
					numPinsDown = throwBall (frame, currentFrameNum, currentThrow, frame.getPinsLeft ());
					frame.setThrow3 (numPinsDown);
					totalScore += frame.getframeTotal ();
					break;
				}
			}

		}
			
		public void strike(Frame frame){
			string currentFrame = "STRIKE";
			int currentThrow;

			Console.WriteLine ("STRIKE!!");

			for (currentThrow = 1; currentThrow <= 2; currentThrow++) {

				numPinsDown = throwBall (frame, currentFrameNum, currentThrow, frame.getPinsLeft());

				frame.setThrow2 (numPinsDown);


				//Reset pins if they were all knocked down
				if (frame.getPinsLeft() == 0){
					frame.resetPins ();
				}
			}
		}

		public int throwBall(Frame frame, int currentFrameNum, int currentThrow, int numPinsLeft){
			/*string input;

			I PLACED THIS HERE, IT DOESN'T BELONG HERE
			foreach(Pin pin in pinList){
				if(Convert.ToInt32(pin.getPinNumber()) == 3){
					pin.isKnockedDown = true;
				}
			}
			drawPins();*/
			Console.WriteLine ("FRAME " + currentFrameNum + " THROW " + currentThrow + ", " + numPinsLeft + " pins standing:");

			while (true) {
				/*
				Console.Write ("Which pins were knocked down on this throw? Enter their numbers here, separated by spaces: ");
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
				numPinsDown = Convert.ToInt32 (Console.ReadLine ());

				if (numPinsDown <= numPinsLeft && numPinsDown >= 0) {
					return numPinsDown;
				} else {
					Console.WriteLine ("Please enter a number of pins that is less than or equal to the current standing number of pins.");
				}
			}
		}


		/*This is super sloppy
		public void drawPins(){

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


		//TODO: Add symbol row and final score (maybe). This works fine right now.
		//TODO: If multiplayer is implemented, change PLAYER NAME to PLAYER 1, 2, etc
		public static void drawScoreboard(int[] frameScoreArray, int totalScore){

			Console.WriteLine (" +---------------------------------------------------------------------------------+");
			Console.WriteLine (" |    FRAME    |   1 |   2 |   3 |   4 |   5 |   6 |   7 |   8 |   9 |  10 | TOTAL |");
			Console.WriteLine (" |---------------------------------------------------------------------------------|");
			Console.Write (" | PLAYER NAME"); //playerName here
			for (int i = 0; i < 10; i++){
				Console.Write(String.Format(" | {0,3}", frameScoreArray[i]));
			}
			Console.Write(String.Format(" | {0,5}", totalScore));

			Console.Write (" | \n +---------------------------------------------------------------------------------+");
			Console.WriteLine ("\n");
		}

	}
}