using UnityEngine;
using System.Collections;

public class KetchupHider : MonoBehaviour {

	public void Hide()
	{
		gameObject.SetActive(false);
	}
	public void Show()
	{
		gameObject.SetActive(true);
	}
}
