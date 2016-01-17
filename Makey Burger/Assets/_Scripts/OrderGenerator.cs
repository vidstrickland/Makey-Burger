﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//TODO
//Add UI elements for toppings
//Toggle UI elements as toppings are used
//How to reset game using burger controller?
//ART ALL OF THE THINGS

public class OrderGenerator : MonoBehaviour {
	public PattyHider isHidingPatty;
	public LettuceHider isHidingLettuce;
	public PicklesHider isHidingPickles;
	public TomatoesHider isHidingTomatoes;
	public MushroomsHider isHidingMushrooms;
	public KetchupHider isHidingKetchup;
	public MustardHider isHidingMustard;
	public RelishHider isHidingRelish;
	public OnionsHider isHidingOnions;
	public BaconHider isHidingBacon;

	public Text DisplayOrderText;
	public Text DisplayOrdersCompleted;
	public Text MoneyEarned;
	public Text Timer;
	public Text OrderTimer;

	//Time to play game
	private float timeLeft = 20.0f;

	//Time taken on current order
	private float timeTaken = 0.0f;

	private double calculate;
	private double highScore;

	//This is how many toppings this burger can potentially have.
	public int potentialToppings = 0;

	//This is how many toppings have been random chosen for this burger so far.
	int toppingCount = 0;

	//This is how many orders have been completed.
	int ordersCompleted = 0;

	//This is the time need for the best possible bonus for Additional Scoring.
	public int fastestBonus = 5;

	//This is the time need for the second possible bonus for Additional Scoring.
	public int fastBonus = 10;

	//If you go over this, you will lose money.
	public int standardTime = 20;

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
	string orderUp = "Please make me a burger with ";

	public bool youWin = false;
	public bool grossBurger = false;

	double scoreCalculator;


	// Use this for initialization
	void Start () {
		BurgerGenerator ();
		orderUp = "Please make me a burger with ";
	}
	
	// Update is called once per frame
	void Update () {
		UIHider ();
		ErrorCheck ();
		scoreCalculator = ordersCompleted;

		timeLeft -= Time.deltaTime;
		timeTaken += Time.deltaTime;
		Timer.text = Mathf.Round(timeLeft) + " seconds remaining";
		OrderTimer.text = "You've spent " + Mathf.Round (timeTaken) + " seconds on this order.";

		if(timeLeft < 0)
		{
			gameEnd ();
		}

		if (Input.GetKeyDown (topping1)) {
			print (toppingDesc1);
			topping1Placed = true;
		}
		if (Input.GetKeyUp (topping1)) {
			//topping1Placed = false;
			print ("burg off");
		}
		if (Input.GetKeyDown (topping2)) {
			print (toppingDesc2);
			topping2Placed = true;
		}
		if (Input.GetKeyUp (topping2)) {
			//topping2Placed = false;
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
		//calculate = scoreCalculator * 5.98;
		//MoneyEarned.text = calculate.ToString ();
		WinCheck ();
	}

	public void BurgerGenerator(){
		
		if (toppingCount < potentialToppings	) {
			toppingRandomizer ();
		} else if (toppingCount == potentialToppings) {
			orderUp = orderUp + "and hold the mayo, PLEASE!";
			print (orderUp);
			DisplayOrderText.text = orderUp;
			timeTaken = 0;
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

	//Attaches chosen toppings to keys
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


	//Additional scoring
	void Scoring(){
		if(Mathf.Round(timeTaken) < fastestBonus){
			print ("Whoa! That's fast!");
			calculate += 4.91;
		}else if(Mathf.Round(timeTaken) < fastBonus){
			print("That was fast!");
			calculate += 4.31;
		}else if(Mathf.Round(timeTaken) < standardTime){
			print ("Thanks for the burger!");
			calculate += 3.91;
		}else{
			print ("You took so long! I'm not even hungry now!");
			calculate -= 0.28;
		}
		MoneyEarned.text = "$"+calculate.ToString ();
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
		orderUp = "Make me a burger with ";
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
		youWin = false;
		isHidingPatty.Show ();
		isHidingLettuce.Show ();
		isHidingPickles.Show ();
		isHidingTomatoes.Show ();
		isHidingMushrooms.Show ();
		isHidingKetchup.Show ();
		isHidingMustard.Show ();
		isHidingRelish.Show ();
		isHidingOnions.Show ();
		isHidingBacon.Show ();
	}

	void gameEnd(){
		if (calculate > 0) {
			orderUp = "Good job, you earned " + calculate + " today!";
		} else if (calculate < 0) {
			orderUp = "Looks like you're going to pay for that wasted food!";
		} else {
			orderUp = "Taking the day off, huh?";
		}
		DisplayOrderText.text = orderUp;
		if (Input.GetKeyDown ("b")) {
			gameReset();
		}
	}

	void gameReset(){
		ordersCompleted = 0;
		calculate = 0.00;
		DisplayOrdersCompleted.text = ordersCompleted.ToString();
		timeLeft = 10.0f;
		OrderReset ();
		BurgerGenerator ();
	}

	void WinCheck(){
		if (topping1Placed) {
			if(topping2Placed){
				if(!topping3Placed){
					if (!topping4Placed) {
						if (!topping5Placed) {
							if (!topping6Placed) {
								if(Input.GetKeyDown ("b")){
									if (!youWin == !grossBurger) {
										youWin = true;
										print ("Order completed!");
										ordersCompleted++;
										scoreCalculator = ordersCompleted;
										Scoring ();
										OrderReset ();
										BurgerGenerator ();
										DisplayOrdersCompleted.text = ordersCompleted.ToString();
									}
								}
							}
						}
					}
				}
			}
		}
	}

	void ErrorCheck(){
		if (!patty) {
			if (Input.GetKeyDown ("q")) {
				isHidingPatty.Hide ();
				print ("Gross! I don't want that!");
				grossBurger = true;
				calculate -= 0.37;
			}
			if (Input.GetKeyUp ("q")) {
				isHidingPatty.Show ();
				print ("That's better!");
				grossBurger = false;
			}
		}
		if (!lettuce) {
			if (Input.GetKeyDown ("w")) {
				isHidingLettuce.Hide ();
				print ("Gross! I don't want that!");
				grossBurger = true;
				calculate -= 0.37;
			}
			if (Input.GetKeyUp ("w")) {
				isHidingLettuce.Show ();
				print ("That's better!");
				grossBurger = false;
			}
		}
		if (!pickles) {
			if (Input.GetKeyDown ("e")) {
				isHidingPickles.Hide ();
				print ("Gross! I don't want that!");
				grossBurger = true;
				calculate -= 0.37;
			}
			if (Input.GetKeyUp ("e")) {
				isHidingPickles.Show ();
				print ("That's better!");
				grossBurger = false;
			}
		}
		if (!tomatoes) {
			if (Input.GetKeyDown ("r")) {
				isHidingTomatoes.Hide ();
				print ("Gross! I don't want that!");
				grossBurger = true;
				calculate -= 0.37;
			}
			if (Input.GetKeyUp ("r")) {
				isHidingTomatoes.Show ();
				print ("That's better!");
				grossBurger = false;
			}
		}
		if (!mushrooms) {
			if (Input.GetKeyDown ("t")) {
				isHidingMushrooms.Hide ();
				print ("Gross! I don't want that!");
				grossBurger = true;
				calculate -= 0.37;
			}
			if (Input.GetKeyUp ("t")) {
				isHidingMushrooms.Show ();
				print ("That's better!");
				grossBurger = false;
			}
		}
		if (!ketchup) {
			if (Input.GetKeyDown ("y")) {
				isHidingKetchup.Hide ();
				print ("Gross! I don't want that!");
				grossBurger = true;
				calculate -= 0.37;
			}
			if (Input.GetKeyUp ("y")) {
				isHidingKetchup.Show ();
				print ("That's better!");
				grossBurger = false;
			}
		}
		if (!mustard) {
			if (Input.GetKeyDown ("u")) {
				isHidingMustard.Hide ();
				print ("Gross! I don't want that!");
				grossBurger = true;
				calculate -= 0.37;
			}
			if (Input.GetKeyUp ("u")) {
				isHidingKetchup.Show ();
				print ("That's better!");
				grossBurger = false;
			}
		}
		if (!relish) {
			if (Input.GetKeyDown ("i")) {
				isHidingRelish.Hide ();
				print ("Gross! I don't want that!");
				grossBurger = true;
				calculate -= 0.37;
			}
			if (Input.GetKeyUp ("i")) {
				isHidingRelish.Show ();
				print ("That's better!");
				grossBurger = false;
			}
		}
		if (!onions) {
			if (Input.GetKeyDown ("o")) {
				isHidingOnions.Hide ();
				print ("Gross! I don't want that!");
				grossBurger = true;
				calculate -= 0.37;
			}
			if (Input.GetKeyUp ("o")) {
				isHidingOnions.Show ();
				print ("That's better!");
				grossBurger = false;
			}
		}
		if (!bacon) {
			if (Input.GetKeyDown ("p")) {
				isHidingBacon.Hide ();
				print ("Gross! I don't want that!");
				grossBurger = true;
				calculate -= 0.37;
			}
			if (Input.GetKeyUp ("p")) {
				isHidingBacon.Show ();
				print ("That's better!");
				grossBurger = false;
			}
		}
		MoneyEarned.text = "$"+calculate.ToString ();
	}

	void UIHider(){
		if (patty) {
			if(Input.GetKeyDown ("q")){
				isHidingPatty.Hide ();
			}
			if(Input.GetKeyUp ("q")){
				isHidingPatty.Show ();
			}
		}
		if (lettuce) {
			if (Input.GetKeyDown ("w")) {
				isHidingLettuce.Hide ();
			}
			if(Input.GetKeyUp ("w")){
				isHidingLettuce.Show ();
			}
		}
		if (pickles) {
			if (Input.GetKeyDown ("e")) {
				isHidingPickles.Hide ();
			}
			if(Input.GetKeyUp ("e")){
				isHidingPickles.Show ();
			}
		}
		if (tomatoes) {
			if (Input.GetKeyDown ("r")) {
				isHidingTomatoes.Hide ();
			}
			if(Input.GetKeyUp ("r")){
				isHidingTomatoes.Show ();
			}
		}
		if (mushrooms) {
			if (Input.GetKeyDown ("t")) {
				isHidingMushrooms.Hide ();
			}
			if(Input.GetKeyUp ("t")){
				isHidingMushrooms.Show ();
			}
		}
		if (ketchup) {
			if (Input.GetKeyDown ("y")) {
				isHidingKetchup.Hide ();
			}
			if(Input.GetKeyUp ("y")){
				isHidingKetchup.Show ();
			}
		}
		if (mustard) {
			if (Input.GetKeyDown ("u")) {
				isHidingMustard.Hide ();
			}
			if(Input.GetKeyUp ("u")){
				isHidingMustard.Show ();
			}
		}
		if (relish) {
			if (Input.GetKeyDown ("i")) {
				isHidingRelish.Hide ();
			}
			if(Input.GetKeyUp ("i")){
				isHidingRelish.Show ();
			}
		}
		if (onions) {
			if (Input.GetKeyDown ("o")) {
				isHidingOnions.Hide ();
			}
			if(Input.GetKeyUp ("o")){
				isHidingOnions.Show ();
			}
		}
		if (bacon) {
			if (Input.GetKeyDown ("p")) {
				isHidingBacon.Hide ();
			}
			if(Input.GetKeyUp ("p")){
				isHidingBacon.Show ();
			}
		}
	}
}