using UnityEngine;

public class GameResetHider : MonoBehaviour {
	
	public void Hide()
	{
		gameObject.SetActive(false);
	}
	public void Show()
	{
		gameObject.SetActive(true);
	}
}