using UnityEngine;
using System.Collections;

public class OrderGenerator : MonoBehaviour {

	//This is how many toppings this burger can potentially have.
	public int potentialToppings = 0;

	//This is how many toppings have been random chosen for this burger so far.
	int toppingCount = 0;

	//This determines whether or not each of the selected toppings have been placed yet.
	bool topping1Placed = false;
	bool topping2Placed = false;
	bool topping3Placed = false;
	bool topping4Placed = false;
	bool topping5Placed = false;
	bool topping6Placed = false;

	//These are the available toppings.
	bool patty = false;
	bool lettuce = false;
	bool pickles = false;
	bool tomatoes = false;
	bool mushrooms = false;
	bool ketchup = false;
	bool mustard = false;
	bool relish = false;
	bool onions = false;
	bool bacon = false;

	//These contain the keybindings for the current toppings.
	//Key Bindings 
	//(Patty : Q)
	//(Lettuce : W)
	//(Pickles : E)
	//(Tomatoes : R)
	//(Mushrooms : T)
	//(Ketchup : Y)
	//(Mustard : U)
	//(Relish : I)
	//(Onions : O)
	//(Bacon : P)

	string topping1 = "z";
	string topping2 = "z";
	string topping3 = "z";
	string topping4 = "z";
	string topping5 = "z";
	string topping6 = "z";
	string toppingDesc1 = "Empty";
	string toppingDesc2 = "Empty";
	string toppingDesc3 = "Empty";
	string toppingDesc4 = "Empty";
	string toppingDesc5 = "Empty";
	string toppingDesc6 = "Empty";
	bool youWin = false;

	string orderUp = "Please make me a burger with ";

	// Use this for initialization
	void Start () {
		BurgerGenerator ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (topping1)) {
			print (toppingDesc1);
			topping1Placed = true;
		}
		if (Input.GetKeyDown (topping2)) {
			print (toppingDesc2);
			topping2Placed = true;
		}
		if (Input.GetKeyDown (topping3)) {
			print (toppingDesc3);
			topping3Placed = true;
		}
		if (Input.GetKeyDown (topping4)) {
			print (toppingDesc4);
			topping4Placed = true;
		}
		if (Input.GetKeyDown (topping5)) {
			print (toppingDesc5);
			topping5Placed = true;
		}
		if (Input.GetKeyDown (topping6)) {
			print (toppingDesc6);
			topping6Placed = true;
		}
		WinCheck ();
	}

	void BurgerGenerator(){
		
		if (toppingCount < potentialToppings	) {
			toppingRandomizer ();
		} else if (toppingCount == potentialToppings) {
			orderUp = orderUp + "and hold the mayo, PLEASE!";
			print (orderUp);
		} else {
			OrderReset ();
			BurgerGenerator ();
		}
	}

	//This randomizes the toppings ordered on the burger.
	void toppingRandomizer(){
		if (Random.Range (0, 2) == 1) {
			patty = true;
			toppingCount++;
			orderUp = orderUp + "one patty, ";
			string toppingKey = "q";
			string toppingDescriptor = "One Patty!";
			toppingControls (toppingKey, toppingDescriptor);
		}
		if (Random.Range (0, 2) == 1) {
			lettuce = true;
			toppingCount++;
			orderUp = orderUp + "lettuce, ";
			string toppingKey = "w";
			string toppingDescriptor = "Lettuce!";
			toppingControls (toppingKey, toppingDescriptor);
		}
		if (Random.Range (0, 2) == 1) {
			pickles = true;
			toppingCount++;
			orderUp = orderUp + "pickles, ";
			string toppingKey = "e";
			string toppingDescriptor = "Pickles!";
			toppingControls (toppingKey, toppingDescriptor);
		}
		if (Random.Range (0, 2) == 1) {
			tomatoes = true;
			toppingCount++;
			orderUp = orderUp + "tomatoes, ";
			string toppingKey = "r";
			string toppingDescriptor = "Tomatoes!";
			toppingControls (toppingKey, toppingDescriptor);
		}
		if (Random.Range (0, 2) == 1) {
			mushrooms = true;
			toppingCount++;
			orderUp = orderUp + "mushrooms, ";
			string toppingKey = "t";
			string toppingDescriptor = "Mushrooms!";
			toppingControls (toppingKey, toppingDescriptor);
		}
		if (Random.Range (0, 2) == 1) {
			ketchup = true;
			toppingCount++;
			orderUp = orderUp + "ketchup, ";
			string toppingKey = "y";
			string toppingDescriptor = "Ketchup!";
			toppingControls (toppingKey, toppingDescriptor);
		}
		if (Random.Range (0, 2) == 1) {
			mustard = true;
			toppingCount++;
			orderUp = orderUp + "mustard, ";
			string toppingKey = "u";
			string toppingDescriptor = "Mustard!";
			toppingControls (toppingKey, toppingDescriptor);
		}
		if (Random.Range (0, 2) == 1) {
			relish = true;
			toppingCount++;
			orderUp = orderUp + "relish, ";
			string toppingKey = "i";
			string toppingDescriptor = "Relish!";
			toppingControls (toppingKey, toppingDescriptor);
		}
		if (Random.Range (0, 2) == 1) {
			onions = true;
			toppingCount++;
			orderUp = orderUp + "onions, ";
			string toppingKey = "o";
			string toppingDescriptor = "Onions!";
			toppingControls (toppingKey, toppingDescriptor);
		}
		if (Random.Range (0, 2) == 1) {
			bacon = true;
			toppingCount++;
			orderUp = orderUp + "bacon, ";
			string toppingKey = "p";
			string toppingDescriptor = "Bacon!";
			toppingControls (toppingKey, toppingDescriptor);
		}
		BurgerGenerator ();
	}

	void toppingControls(string toppingKey, string toppingDescriptor){
		if (toppingCount == 1) {
			topping1 = toppingKey;
			toppingDesc1 = toppingDescriptor;

		} else if (toppingCount == 2) {
			topping2 = toppingKey;
			toppingDesc2 = toppingDescriptor;

		}else if (toppingCount == 3) {
			topping3 = toppingKey;
			toppingDesc3 = toppingDescriptor;

		}else if (toppingCount == 4) {
			topping4 = toppingKey;
			toppingDesc4 = toppingDescriptor;

		}else if (toppingCount == 5) {
			topping5 = toppingKey;
			toppingDesc5 = toppingDescriptor;

		}else if (toppingCount == 6) {
			topping6 = toppingKey;
			toppingDesc6 = toppingDescriptor;
		}
	}
	//Resets the toppings ordered.
	void OrderReset(){
		toppingCount = 0;
		patty = false;
		lettuce = false;
		pickles = false;
		tomatoes = false;
		mushrooms = false;
		ketchup = false;
		mustard = false;
		relish = false;
		onions = false;
		bacon = false;
		orderUp = "Please make me a burger with ";
		topping1 = "z";
		topping2 = "z";
		topping3 = "z";
		topping4 = "z";
		topping5 = "z";
		topping6 = "z";
		topping1Placed = false;
		topping2Placed = false;
		topping3Placed = false;
		topping4Placed = false;
		topping5Placed = false;
		topping6Placed = false;
	}
	void WinCheck(){
		if (topping1Placed == true) {
			if(topping2Placed== true){
				if(topping3Placed== true){
					if (topping4Placed == true) {
						if (topping5Placed == true) {
							if (topping6Placed == true) {
								if (youWin == false) {
									youWin = true;
									print ("Order completed!");
								}
							}
						}
					}
				}
			}
		}
	}
}