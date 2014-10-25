using UnityEngine;
using System.Collections;

public class MemberListPopup : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();
	
	public GameObject MenuPrefab;
	public GameObject MenuInstance;
	
	public int Page;

	void OnMouseDown()
	{
		if(Page*6 < Var.Mems.Count)
		{
			Page += 1;
		}
		else
		{
			if(Var.OnTutorial == true)
			{
				Var.Mng.Tutorial.Page += 1;
			}
			
			MenuInstance=Instantiate(MenuPrefab) as GameObject;
			Destroy(gameObject);
		}
	}
}