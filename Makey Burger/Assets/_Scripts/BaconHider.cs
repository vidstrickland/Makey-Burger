using UnityEngine;
using System.Collections;

public class BaconHider : MonoBehaviour {

	public void Hide()
	{
		gameObject.SetActive(false);
	}
	public void Show()
	{
		gameObject.SetActive(true);
	}
}