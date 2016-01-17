using UnityEngine;
using System.Collections;

public class TomatoesHider : MonoBehaviour {

	public void Hide()
	{
		gameObject.SetActive(false);
	}
	public void Show()
	{
		gameObject.SetActive(true);
	}
}