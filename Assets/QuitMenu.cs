using UnityEngine;
using System.Collections;

public class QuitMenu : MonoBehaviour {

	public GameObject QuitPopup;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{ 
			PopQuitMessage();
		} 	
	}

	void PopQuitMessage()
	{
		QuitPopup.SetActive (true);
	}
}
