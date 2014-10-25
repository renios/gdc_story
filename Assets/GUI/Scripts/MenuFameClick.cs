using UnityEngine;
using System.Collections;

public class MenuFameClick : MonoBehaviour
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public GameObject popupPrefab;
	public GameObject popupInstance;

	void OnMouseDown()
	{
		if(Var.OnTutorial == false || Var.Mng.Tutorial.Page == 6)
		{
			renderer.material.color=Color.gray;
			popupInstance = Instantiate (popupPrefab) as GameObject;
			Destroy(GameObject.FindGameObjectWithTag("Menu"));
			
			if(Var.OnTutorial == true)
			{
				Var.Mng.Tutorial.Collider.enabled = true;
				Var.Mng.Tutorial.Page += 1;
			}
		}
	}
}
