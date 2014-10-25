using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();
	
	public enum SceneList
	{
		Achievements,
		AskPassTuto,
		Opening,
		InGame,
	}
	
	public SceneList Destination;
	
	void OnMouseDown()
	{
		if(Destination == SceneList.Opening)
		{
			Var.TutorialPass = false;
			PlayerPrefs.SetInt("NewGame", 1);
			PlayerPrefs.SetInt ("PassTuto", 0);
		}
		else if(Destination == SceneList.InGame)
		{
			Var.TutorialPass = true;
			PlayerPrefs.SetInt("NewGame", 1);
			PlayerPrefs.SetInt("PassTuto", 1);
		}
		Application.LoadLevel ("" + Destination);
	}
}