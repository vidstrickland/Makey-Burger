using UnityEngine;

public class LettuceHider : MonoBehaviour {

	public void Hide()
	{
		gameObject.SetActive(false);
	}
	public void Show()
	{
		gameObject.SetActive(true);
	}
}