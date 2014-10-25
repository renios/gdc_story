using UnityEngine;
using System.Collections;

public class ResetProject : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public MakeProject Maker;

	void OnMouseDown()
	{
		if(Var.OnTutorial == false || Var.Mng.PjTuto.Page == 15)
		{
			Debug.Log ("Reset Project.");
			foreach(Project PJ in Maker.Projects)
			{
				Destroy(PJ.gameObject);
			}

			foreach(Character Mem in Var.Mems)
			{
				Mem.ProjectPosition = Character.ProjectPositionIndex.None;
			}
			
			Maker.Projects.Clear ();

			if(Var.OnTutorial == true)
			{
				Var.Mng.PjTuto.Page += 1;
				Var.Mng.PjTuto.Collider.enabled = true;
			}
		}
	}

	IEnumerator Blink()
	{
		renderer.enabled = false;
		yield return new WaitForSeconds(0.5f);
		renderer.enabled = true;
		yield return new WaitForSeconds(0.5f);
		renderer.enabled = false;
		yield return new WaitForSeconds(0.5f);
		renderer.enabled = true;
		yield return new WaitForSeconds(0.5f);
		renderer.enabled = false;
		yield return new WaitForSeconds(0.5f);
		renderer.enabled = true;
	}
}