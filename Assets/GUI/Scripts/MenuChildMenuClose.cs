using UnityEngine;
using System.Collections;

public class MenuChildMenuClose : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public GameObject MenuPrefab;
	public GameObject MenuInstance;

	public AchListPopup Parent;

	public enum MenuChildTypes
	{
		Money,
		Members,
		Fame,
		Shop,
	}
	public MenuChildTypes MenuChildType;

	void Start()
	{
		if(MenuChildType != MenuChildTypes.Fame)
		{
			Var.Mng.UpgPupCloser = this;
		}
	}

	void OnMouseDown()
	{
		if(Var.OnTutorial == false || Var.Mng.Tutorial.Page == 3 || Var.Mng.Tutorial.Page == 5 || Var.Mng.Tutorial.Page == 11 || Var.Mng.Tutorial.Page == 17)
		{
			MenuInstance=Instantiate(MenuPrefab) as GameObject;

			if(Var.OnTutorial == true)
			{
				Var.Mng.Tutorial.Page += 1;
			}

			if(MenuChildType != MenuChildTypes.Fame)
			{
				Destroy (gameObject);
			}
			else
			{
				Destroy(Parent.gameObject);
			}
		}
	}
}
