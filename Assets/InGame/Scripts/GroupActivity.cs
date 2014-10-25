using UnityEngine;
using System.Collections;

public class GroupActivity : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public CutScene ScenePF;

	void OnMouseDown()
	{
		if(Var.OnTutorial == false)
		{
			Var.MenuActivated = true;
			Destroy (gameObject);
		}
	}
}
