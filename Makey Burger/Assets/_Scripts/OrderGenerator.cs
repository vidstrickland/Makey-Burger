using UnityEngine;
using System.Collections;

public class OrderGenerator : MonoBehaviour {

	//This is how many toppings this burger can potentially have.
	public int potentialToppings = 0;

	//This is how many toppings have been random chosen for this burger so far.
	int toppingCount = 0;

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
	string topping1 = "z";

	string orderUp = "Please make me a burger with ";

	// Use this for initialization
	void Start () {
		BurgerGenerator ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (topping1)) {
			print ("You push the button!");
		}
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
			topping1 = "q";
		}
		if (Random.Range (0, 2) == 1) {
			lettuce = true;
			toppingCount++;
			orderUp = orderUp + "lettuce, ";
		}
		if (Random.Range (0, 2) == 1) {
			pickles = true;
			toppingCount++;
			orderUp = orderUp + "pickles, ";
		}
		if (Random.Range (0, 2) == 1) {
			tomatoes = true;
			toppingCount++;
			orderUp = orderUp + "tomatoes, ";
		}
		if (Random.Range (0, 2) == 1) {
			mushrooms = true;
			toppingCount++;
			orderUp = orderUp + "mushrooms, ";
		}
		if (Random.Range (0, 2) == 1) {
			ketchup = true;
			toppingCount++;
			orderUp = orderUp + "ketchup, ";
		}
		if (Random.Range (0, 2) == 1) {
			mustard = true;
			toppingCount++;
			orderUp = orderUp + "mustard, ";
		}
		if (Random.Range (0, 2) == 1) {
			relish = true;
			toppingCount++;
			orderUp = orderUp + "relish, ";
		}
		if (Random.Range (0, 2) == 1) {
			onions = true;
			toppingCount++;
			orderUp = orderUp + "onions, ";
		}
		if (Random.Range (0, 2) == 1) {
			bacon = true;
			toppingCount++;
			orderUp = orderUp + "bacon, ";
		}
		BurgerGenerator ();
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
	}
}
