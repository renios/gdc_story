using UnityEngine;
using System.Collections;

public class QuitPopup : MonoBehaviour {

	void OnMouseDown ()
	{
		gameObject.SetActive (false);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{ 
			QuitGame();
		} 
	}
	
	void QuitGame()
	{
		if(Application.platform == RuntimePlatform.Android)
		{
			Application.Quit();
			return;
		}
		else 
		{
			Debug.Log("Pushed BackButton");
			gameObject.SetActive (false);
		}
	}
}
