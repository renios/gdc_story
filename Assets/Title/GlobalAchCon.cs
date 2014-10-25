using UnityEngine;
using System.Collections;

public class GlobalAchCon : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public TextMesh Text;
	
	public AchListPopup Parent;
	
	private int IndexNumber;
	
	void Update()
	{
		if(Parent.Page == 1)
		{
			Text.text = SetConditionText(0) + "\n";
			Text.text += SetConditionText(1) + "\n";
			Text.text += SetConditionText(2) + "\n";
			Text.text += SetConditionText(3) + "\n";
			Text.text += SetConditionText(4);
		}
		else if(Parent.Page == 2)
		{
			Text.text = SetConditionText(5) + "\n";
			Text.text += SetConditionText(6) + "\n";
			Text.text += SetConditionText(7) + "\n";
			Text.text += SetConditionText(8) + "\n";
			Text.text += SetConditionText(9) + "\n";
			Text.text += SetConditionText(10);
		}
		else if(Parent.Page == 3)
		{
			Text.text = SetConditionText(11) + "\n";
			Text.text += SetConditionText(12) + "\n";
			Text.text += SetConditionText(13) + "\n";
			Text.text += SetConditionText(14) + "\n";
			Text.text += SetConditionText(15);
		}
		else if(Parent.Page == 4)
		{
			Text.text = SetConditionText(16) + "\n";
			Text.text += SetConditionText(17) + "\n";
			Text.text += SetConditionText(18) + "\n";
			Text.text += SetConditionText(19) + "\n";
			Text.text += SetConditionText(20) + "\n";
			Text.text += SetConditionText(21);
		}
	}

	string SetConditionText(int AchNum)
	{
		if(PlayerPrefs.HasKey("Ach"+AchNum) == true)
		{
			return Var.AchConditionList[AchNum];
		}
		else
		{
			return "???";
		}
	}
}