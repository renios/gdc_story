using UnityEngine;
using System.Collections;

public class AchDesc : MonoBehaviour 
{
	GlobalVariables Variables = GlobalVariables.GetInstance ();
	
	public TextMesh Text;

	public AchListPopup Parent;
	
	private int IndexNumber;
	
	void Update()
	{
		if(Parent.Page == 1)
		{
			Text.text = Variables.AchDescList [0] + "\n";
			Text.text += Variables.AchDescList [1] + "\n";
			Text.text += Variables.AchDescList [2] + "\n";
			Text.text += Variables.AchDescList [3] + "\n";
			Text.text += Variables.AchDescList [4];
		}
		else if(Parent.Page == 2)
		{
			Text.text = Variables.AchDescList [5] + "\n";
			Text.text += Variables.AchDescList [6] + "\n";
			Text.text += Variables.AchDescList [7] + "\n";
			Text.text += Variables.AchDescList [8] + "\n";
			Text.text += Variables.AchDescList [9] + "\n";
			Text.text += Variables.AchDescList [10];
		}
		else if(Parent.Page == 3)
		{
			Text.text = Variables.AchDescList [11] + "\n";
			Text.text += Variables.AchDescList [12] + "\n";
			Text.text += Variables.AchDescList [13] + "\n";
			Text.text += Variables.AchDescList [14] + "\n";
			Text.text += Variables.AchDescList [15];
		}
		else if(Parent.Page == 4)
		{
			Text.text = Variables.AchDescList [16] + "\n";
			Text.text += Variables.AchDescList [17] + "\n";
			Text.text += Variables.AchDescList [18] + "\n";
			Text.text += Variables.AchDescList [19] + "\n";
			Text.text += Variables.AchDescList [20] + "\n";
			Text.text += Variables.AchDescList [21];
		}
	}
}