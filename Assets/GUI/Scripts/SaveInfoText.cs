using UnityEngine;
using System.Collections;

public class SaveInfoText : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();
	
	public TextMesh Text;

	public enum InfoTypes
	{
		Number,
		Time,
		Money,
		Members,
		Fame,
	}
	public InfoTypes InfoType;

	void Update()
	{
		if(InfoType == InfoTypes.Number)
		{
			Text.text = "슬롯1\n\n슬롯2\n\n슬롯3";
		}
		else if(InfoType == InfoTypes.Time)
		{
			if(PlayerPrefs.HasKey("SaveSlot1") == true)
			{
				Text.text = PlayerPrefs.GetInt("Slot1Year")+"년 "+PlayerPrefs.GetInt("Slot1Month")+"월 "+Day (1);

				if(PlayerPrefs.HasKey("SaveSlot2") == true)
				{
					Text.text += "\n\n"+PlayerPrefs.GetInt("Slot2Year")+"년 "+PlayerPrefs.GetInt("Slot2Month")+"월 "+Day (2);

					if(PlayerPrefs.HasKey("SaveSlot3") == true)
					{
						Text.text += "\n\n"+PlayerPrefs.GetInt("Slot3Year")+"년 "+PlayerPrefs.GetInt("Slot3Month")+"월 "+Day (3);
					}
				}
			}
		}
		else if(InfoType == InfoTypes.Money)
		{
			if(PlayerPrefs.HasKey("SaveSlot1") == true)
			{
				Text.text = PlayerPrefs.GetFloat("Slot1Money")+"만원";
				
				if(PlayerPrefs.HasKey("SaveSlot2") == true)
				{
					Text.text += "\n\n"+PlayerPrefs.GetFloat("Slot2Money")+"만원";
					
					if(PlayerPrefs.HasKey("SaveSlot3") == true)
					{
						Text.text += "\n\n"+PlayerPrefs.GetFloat("Slot3Money")+"만원";
					}
				}
			}
		}

		else if(InfoType == InfoTypes.Members)
		{
			if(PlayerPrefs.HasKey("SaveSlot1") == true)
			{
				Text.text = PlayerPrefs.GetInt("Slot1Members")+"명";
				
				if(PlayerPrefs.HasKey("SaveSlot2") == true)
				{
					Text.text += "\n\n"+PlayerPrefs.GetInt("Slot2Members")+"명";
					
					if(PlayerPrefs.HasKey("SaveSlot3") == true)
					{
						Text.text += "\n\n"+PlayerPrefs.GetInt("Slot3Members")+"명";
					}
				}
			}
		}

		else if(InfoType == InfoTypes.Fame)
		{
			if(PlayerPrefs.HasKey("SaveSlot1") == true)
			{
				Text.text = PlayerPrefs.GetInt("Slot1Fame")+"";
				
				if(PlayerPrefs.HasKey("SaveSlot2") == true)
				{
					Text.text += "\n\n"+PlayerPrefs.GetInt("Slot2Fame");
					
					if(PlayerPrefs.HasKey("SaveSlot3") == true)
					{
						Text.text += "\n\n"+PlayerPrefs.GetInt("Slot3Fame");
					}
				}
			}
		}
	}

	string Day(int SlotNum)
	{
		if(PlayerPrefs.GetInt("Slot"+SlotNum+"Day") == 1)
		{
			return "초";
		}
		else if(PlayerPrefs.GetInt("Slot"+SlotNum+"Day") == 2)
		{
			return "중";
		}
		else if(PlayerPrefs.GetInt("Slot"+SlotNum+"Day") == 3)
		{
			return "말";
		}
		else
		{
			return "";
		}
	}
}