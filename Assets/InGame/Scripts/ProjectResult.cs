using UnityEngine;
using System.Collections;

public class ProjectResult : MonoBehaviour 
{
	GlobalVariables Variables = GlobalVariables.GetInstance ();

	public CutScene ScenePF;
	CutScene SceneIS;

	void OnMouseDown()
	{
		if(Variables.ProjectHighScore == 1)
		{
			SceneIS = Instantiate(ScenePF) as CutScene;
			SceneIS.SceneType = CutScene.SceneTypes.Project1st;
		}
		else if(Variables.ProjectHighScore == 2)
		{
			SceneIS = Instantiate(ScenePF) as CutScene;
			SceneIS.SceneType = CutScene.SceneTypes.Project2nd;
		}
		else if(Variables.ProjectHighScore == 3)
		{
			SceneIS = Instantiate(ScenePF) as CutScene;
			SceneIS.SceneType = CutScene.SceneTypes.Project3rd;
		}
		else
		{
			SceneIS = Instantiate(ScenePF) as CutScene;
			SceneIS.SceneType = CutScene.SceneTypes.ProjectFail;
		}

		Destroy (gameObject);
	}
}