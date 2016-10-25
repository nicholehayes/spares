using System;

namespace Spares {

	//This class is currently unused.
	//This class is used to create a Pin object that's used for drawing a layout of pins after each throw. 
	//Each Pin has an ID (1-10) and a status (is either standing up or knocked down).
	public class Pin {

		public bool isKnockedDown;
		public string pinNumber;

		public Pin (int num) {
			this.isKnockedDown = false;
			this.pinNumber = num.ToString();
		}

		public void knockDown() {
			this.isKnockedDown = true;
			this.pinNumber = "X";
		}

		public bool getStatus(){
			return this.isKnockedDown;
		}

		public string getPinNumber(){
			return this.pinNumber;
		}
	}
}