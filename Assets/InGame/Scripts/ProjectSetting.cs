using UnityEngine;
using System.Collections;

public class ProjectSetting : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public Project ParentProject;

	public int Page;

	public ProjectSelectedMember Plan;
	public ProjectSelectedMember Programming;
	public ProjectSelectedMember Art;
	public ProjectSelectedMember Sound;

	void OnMouseDown()
	{
		if(Var.OnTutorial == false || Var.Mng.PjTuto.Page == 11)
		{
			//Var.Mng.WallInstance.transform.Translate (Var.Mng.WallInstance.transform.position.x, Var.Mng.WallInstance.transform.position.y, 1.5f);
			Destroy (gameObject);

			if(Var.OnTutorial == true)
			{
				Var.Mng.PjTuto.Page += 1;
				Var.Mng.PjTuto.Collider.enabled = true;
			}
		}
	}
}