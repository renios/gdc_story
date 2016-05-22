using UnityEngine;
using System.Collections;

public class MenuMoneyClick : MonoBehaviour 
{
	GlobalVariables Variables = GlobalVariables.GetInstance ();

	public GameObject popupPrefab;
	public GameObject popupInstance;

	void OnMouseDown()
	{
		if(Variables.OnTutorial == false || Variables.Mng.Tutorial.Page == 2)
		{
			GetComponent<Renderer>().material.color=Color.gray;
			popupInstance = Instantiate (popupPrefab) as GameObject;
			Destroy(GameObject.FindGameObjectWithTag("Menu"));

			if(Variables.OnTutorial == true)
			{
				Variables.Mng.Tutorial.Page += 1;
			}
		}
	}
}
