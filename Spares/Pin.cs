using System;

namespace Spares {

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