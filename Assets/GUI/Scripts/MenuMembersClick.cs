using UnityEngine;
using System.Collections;

public class MenuMembersClick : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public GameObject popupPrefab;
	public GameObject popupInstance;

	void OnMouseDown()
	{
		if(Var.OnTutorial == false || Var.Mng.Tutorial.Page == 4)
		{
			GetComponent<Renderer>().material.color=Color.gray;
			popupInstance = Instantiate (popupPrefab) as GameObject;
			Destroy(GameObject.FindGameObjectWithTag("Menu"));
			
			if(Var.OnTutorial == true)
			{
				Var.Mng.Tutorial.Page += 1;
			}
		}
	}
}