using UnityEngine;
using System.Collections;

public class AchName : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();
	
	public TextMesh Text;

	public AchListPopup Parent;

	void Update()
	{
		if(Parent.Page == 1)
		{
			Text.text = Var.AchNameList [0] + "\n";
			Text.text += Var.AchNameList [1] + "\n";
			Text.text += Var.AchNameList [2] + "\n";
			Text.text += Var.AchNameList [3] + "\n";
			Text.text += Var.AchNameList [4];
		}
		else if(Parent.Page == 2)
		{
			Text.text = Var.AchNameList [5] + "\n";
			Text.text += Var.AchNameList [6] + "\n";
			Text.text += Var.AchNameList [7] + "\n";
			Text.text += Var.AchNameList [8] + "\n";
			Text.text += Var.AchNameList [9] + "\n";
			Text.text += Var.AchNameList [10];
		}
		else if(Parent.Page == 3)
		{
			Text.text = Var.AchNameList [11] + "\n";
			Text.text += Var.AchNameList [12] + "\n";
			Text.text += Var.AchNameList [13] + "\n";
			Text.text += Var.AchNameList [14] + "\n";
			Text.text += Var.AchNameList [15];
		}
		else if(Parent.Page == 4)
		{
			Text.text = Var.AchNameList [16] + "\n";
			Text.text += Var.AchNameList [17] + "\n";
			Text.text += Var.AchNameList [18] + "\n";
			Text.text += Var.AchNameList [19] + "\n";
			Text.text += Var.AchNameList [20] + "\n";
			Text.text += Var.AchNameList [21];
		}
	}
}