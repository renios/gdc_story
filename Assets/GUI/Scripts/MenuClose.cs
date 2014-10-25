using UnityEngine;
using System.Collections;

public class MenuClose : MonoBehaviour
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public Character Chief;

	void OnMouseDown()
	{
		if(Var.OnTutorial == false || Var.Mng.Tutorial.Page == 18)
		{
			if(Var.OnTutorial == true)
			{
				Var.Mng.Tutorial.Page += 1;
				Var.Mng.Tutorial.Collider.enabled = true;
				Var.Mng.Chief = Instantiate(Chief) as Character;
				Destroy(Var.Mng.WallInstance.gameObject);
				Var.Mng.AudioSources [0].Play ();
			}

			CallMenuButton.display=true;
			Destroy (transform.parent.gameObject);
		}


	}
}