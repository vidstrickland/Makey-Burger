using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//TODO
//Add UI elements for toppings
//Toggle UI elements as toppings are used
//How to reset game using burger controller?
//ART ALL OF THE THINGS

public class OrderGenerator : MonoBehaviour {

	public Text DisplayOrderText;
	public Text DisplayOrdersCompleted;
	public Text MoneyEarned;
	public Text Timer;
	public Text OrderTimer;

	//Time to play game
	private float timeLeft = 90.0f;

	//Time taken on current order
	private float timeTaken = 0.0f;

	private double calculate;

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

	bool youWin = false;

	double scoreCalculator;


	// Use this for initialization
	void Start () {
		BurgerGenerator ();
		orderUp = "Please make me a burger with ";
	}
	
	// Update is called once per frame
	void Update () {
		scoreCalculator = ordersCompleted;

		timeLeft -= Time.deltaTime;
		timeTaken += Time.deltaTime;
		Timer.text = "Time Left:" + Mathf.Round(timeLeft);
		OrderTimer.text = "This Order:" + Mathf.Round (timeTaken);

		if(timeLeft < 0)
		{
			gameEnd ();
		}

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
		//calculate = scoreCalculator * 5.98;
		//MoneyEarned.text = calculate.ToString ();
		WinCheck ();
	}

	void BurgerGenerator(){
		
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
			calculate += 4.98;
		}else if(Mathf.Round(timeTaken) < fastBonus){
			print("That was fast!");
			calculate += 4.36;
		}else if(Mathf.Round(timeTaken) < standardTime){
			print ("Thanks for the burger!");
			calculate += 3.98;
		}else{
			print ("You took so long! I'm not even hungry now!");
			calculate -= 0.29;
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
	}

	void gameEnd(){
		gameReset ();
	}

	void gameReset(){
		ordersCompleted = 0;
		DisplayOrdersCompleted.text = ordersCompleted.ToString();
		timeLeft = 10.0f;
		OrderReset ();
		BurgerGenerator ();
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