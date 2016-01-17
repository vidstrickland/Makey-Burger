using UnityEngine;

public class PicklesHider : MonoBehaviour {

	public void Hide()
	{
		gameObject.SetActive(false);
	}
	public void Show()
	{
		gameObject.SetActive(true);
	}
}