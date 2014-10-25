using UnityEngine;
using System.Collections;

public class Cancel : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	void OnMouseDown()
	{
		if(Var.OnTutorial == false || Var.Mng.Tutorial.Page == 33)
		{
			Var.Mng.AudioSources[2].Play ();
			foreach(Character Member in Var.Mems)
			{
				Member.CurrentAct = Character.ActionIndex.None;
				Member.Balloon.enabled = false;
			}
			
			Var.GameMems.Clear ();
			Var.ProgramMems.Clear ();
			Var.BdGmMems.Clear ();
			Var.DrawMems.Clear ();
			Var.ComposeMems.Clear ();
			Var.BookMems.Clear ();
			Var.WatchMems.Clear ();
			Var.PlanMems.Clear ();
			Var.PiaMems.Clear ();
			Var.CookMems.Clear ();

			if(Var.OnTutorial == true)
			{
				Var.Mng.Tutorial.Page += 1;
				Var.Mng.Tutorial.Collider.enabled = true;
				Var.Mng.Chief.Balloon.enabled = false;
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
