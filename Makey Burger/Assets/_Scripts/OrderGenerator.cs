using UnityEngine;
using System.Collections;



public class OrderGenerator : MonoBehaviour {
	int burgCount = 0;
	bool meat = false;
	bool lettuce = false;
	bool pickles = false;
	bool tomatoes = false;
	bool mushrooms = false;
	bool ketchup = false;
	bool mustard = false;
	bool relish = false;
	bool onions = false;
	bool bacon = false;
	string orderUp = "Please make me a ";

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (burgCount < 6	) {
			OrderRandomizer ();
		} else if (burgCount == 6) {
			
		} else {
			OrderReset ();
		}
		print (orderUp);
	}

	void OrderRandomizer(){
		if (Random.Range (0, 2) == 1) {
			meat = true;
			burgCount++;
			orderUp = orderUp + "meat, ";
		}
		if (Random.Range (0, 2) == 1) {
			lettuce = true;
			burgCount++;
			orderUp = orderUp + "lettuce, ";
		}
		if (Random.Range (0, 2) == 1) {
			pickles = true;
			burgCount++;
			orderUp = orderUp + "pickles, ";
		}
		if (Random.Range (0, 2) == 1) {
			tomatoes = true;
			burgCount++;
			orderUp = orderUp + "tomatoes, ";
		}
		if (Random.Range (0, 2) == 1) {
			mushrooms = true;
			burgCount++;
			orderUp = orderUp + "mushrooms, ";
		}
		if (Random.Range (0, 2) == 1) {
			ketchup = true;
			burgCount++;
			orderUp = orderUp + "ketchup, ";
		}
		if (Random.Range (0, 2) == 1) {
			mustard = true;
			burgCount++;
			orderUp = orderUp + "mustard, ";
		}
		if (Random.Range (0, 2) == 1) {
			relish = true;
			burgCount++;
			orderUp = orderUp + "relish, ";
		}
		if (Random.Range (0, 2) == 1) {
			onions = true;
			burgCount++;
			orderUp = orderUp + "onions, ";
		}
		if (Random.Range (0, 2) == 1) {
			bacon = true;
			burgCount++;
			orderUp = orderUp + "bacon, ";
		}
	}
	void OrderReset(){
		burgCount = 0;
		meat = false;
		lettuce = false;
		pickles = false;
		tomatoes = false;
		mushrooms = false;
		ketchup = false;
		mustard = false;
		relish = false;
		onions = false;
		bacon = false;
		orderUp = "Please make me a ";
	}
}
