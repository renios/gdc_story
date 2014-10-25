using UnityEngine;
using System.Collections;

public class GlobalAchBools : MonoBehaviour 
{
	public TextMesh Text;
	
	public AchListPopup Parent;
	
	private int IndexNumber;
	
	void Update()
	{
		if(Parent.Page == 1)
		{
			Text.text = BoolToString(0) + "\n";
			Text.text += BoolToString(1) + "\n";
			Text.text += BoolToString(2) + "\n";
			Text.text += BoolToString(3) + "\n";
			Text.text += BoolToString(4);
		}
		else if(Parent.Page == 2)
		{
			Text.text = BoolToString(5) + "\n";
			Text.text += BoolToString(6) + "\n";
			Text.text += BoolToString(7) + "\n";
			Text.text += BoolToString(8) + "\n";
			Text.text += BoolToString(9) + "\n";
			Text.text += BoolToString(10);
		}
		else if(Parent.Page == 3)
		{
			Text.text = BoolToString(11) + "\n";
			Text.text += BoolToString(12) + "\n";
			Text.text += BoolToString(13) + "\n";
			Text.text += BoolToString(14) + "\n";
			Text.text += BoolToString(15);
		}
		else if(Parent.Page == 4)
		{
			Text.text = BoolToString(16) + "\n";
			Text.text += BoolToString(17) + "\n";
			Text.text += BoolToString(18) + "\n";
			Text.text += BoolToString(19) + "\n";
			Text.text += BoolToString(20) + "\n";
			Text.text += BoolToString(21);
		}
	}
	
	string BoolToString(int AchNum)
	{
		if(PlayerPrefs.HasKey("Ach"+AchNum) == true)
		{
			return "O";
		}
		else
		{
			return "X";
		}
	}
}