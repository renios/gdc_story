using UnityEngine;
using System.Collections;

public class AchTimes : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();
	
	public TextMesh Text;

	public AchListPopup Parent;

	private int IndexNumber;
	
	void Update()
	{
		if(Parent.Page == 1)
		{
			Text.text = Var.AchTimesList [0] + "\n";
			Text.text += Var.AchTimesList [1] + "\n";
			Text.text += Var.AchTimesList [2] + "\n";
			Text.text += Var.AchTimesList [3] + "\n";
			Text.text += Var.AchTimesList [4];
		}
		else if(Parent.Page == 2)
		{
			Text.text = BoolToString(Var.AchBoolList [0]) + "\n";
			Text.text += BoolToString(Var.AchBoolList [1]) + "\n";
			Text.text += BoolToString(Var.AchBoolList [2]) + "\n";
			Text.text += BoolToString(Var.AchBoolList [3]) + "\n";
			Text.text += BoolToString(Var.AchBoolList [4]) + "\n";
			Text.text += BoolToString(Var.AchBoolList [5]);
		}
		else if(Parent.Page == 3)
		{
			Text.text = BoolToString(Var.AchBoolList [6]) + "\n";
			Text.text += BoolToString(Var.AchBoolList [7]) + "\n";
			Text.text += BoolToString(Var.AchBoolList [8]) + "\n";
			Text.text += BoolToString(Var.AchBoolList [9]) + "\n";
			Text.text += BoolToString(Var.AchBoolList [10]);
		}
		else if(Parent.Page == 4)
		{
			Text.text = BoolToString(Var.AchBoolList [11]) + "\n";
			Text.text += BoolToString(Var.AchBoolList [12]) + "\n";
			Text.text += BoolToString(Var.AchBoolList [13]) + "\n";
			Text.text += BoolToString(Var.AchBoolList [14]) + "\n";
			Text.text += BoolToString(Var.AchBoolList [15]) + "\n";
			Text.text += BoolToString(Var.AchBoolList [16]);
		}
	}

	string BoolToString(bool Check)
	{
		if(Check == true)
		{
			return "O";
		}
		else
		{
			return "X";
		}
	}
}