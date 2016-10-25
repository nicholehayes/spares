using System;

namespace Spares {

	public class Frame {

		int throw1;
		int throw2;
		int throw3;
		int spareThrow = 0;
		int strikeThrow = 0;
		int strikeIncrement = 0;
		int numPinsLeft;
		bool strike;
		bool spare;
		string symbol = "";

		public Frame () {
			throw1 = 0;
			throw2 = 0;
			throw3 = 0;
			numPinsLeft = 10;
			strike = false;
			spare = false;
		}

		public void setThrow1 (int throw1){
			this.throw1 = throw1;
			numPinsLeft -= throw1;
		}

		public void setThrow2 (int throw2){
			this.throw2 = throw2;
			numPinsLeft -= throw2;
		}

		public void setThrow3 (int throw3){
			this.throw3 = throw3;
		}

		public void setStrikeThrow(int strikeThrow){
			if (strikeIncrement < 2) {
				this.strikeThrow += strikeThrow;
				strikeIncrement++;
			} else {
				strike = false;
			}
		}

		public void setSpareThrow(int spareThrow){
			this.spareThrow = spareThrow;
			spare = false;
		}

		//for debugging
		public bool strikeStatus(){
			return strike;
		}

		public void resetPins(){
			numPinsLeft = 10;
		}

		public void setStrike () {
			strike = true;
		}

		public void setSpare () {
			spare = true;
		}

		public bool isStrike () {
			return strike;
		}

		public bool isSpare () {
			return spare;
		}
			
		public int getPinsLeft() {
			return numPinsLeft;
		}

		public int getThrow1 (){
			return throw1;
		}

		public int getThrow2 (){
			return throw2;
		}

		public int getThrow3 (){
			return throw3;
		}

		public int getframeTotal (){
			return throw1 + throw2 + throw3 + spareThrow + strikeThrow;
		}

		public void setSymbol(string sym){
			symbol += sym;
		}

		public string getSymbol(){
			return symbol;
		}
			
	}
}