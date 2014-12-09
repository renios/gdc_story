using UnityEngine;
using System.Collections;

public class SaveSlots : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();
	
	public int SlotNumber;
	
	public NoticeMessage SaveNoticePf;
	NoticeMessage Notice;
	
	public SavePopup Parent;
	
	void OnMouseDown()
	{
		PlayerPrefs.SetInt("SaveSlot"+SlotNumber, 1);

		PlayerPrefs.SetInt ("Slot"+SlotNumber+"Year", Var.Year);
		PlayerPrefs.SetInt ("Slot"+SlotNumber+"Month", Var.Month);
		if(Var.Day == "초")
		{
			PlayerPrefs.SetInt ("Slot"+SlotNumber+"Day", 1);
		}
		else if(Var.Day == "중")
		{
			PlayerPrefs.SetInt ("Slot"+SlotNumber+"Day", 2);
		}
		else
		{
			PlayerPrefs.SetInt("Slot"+SlotNumber+"Day", 3);
		}
		
		if(Var.MenuActivated == true)
		{
			PlayerPrefs.SetInt ("Slot"+SlotNumber+"MenuActivated", 1);
		}
		else
		{
			PlayerPrefs.SetInt("Slot"+SlotNumber+"MenuActivated", 0);
		}
		
		PlayerPrefs.SetInt("Slot"+SlotNumber+"Semester", Var.Semester);
		PlayerPrefs.SetInt ("Slot" + SlotNumber + "PjStan", Var.PjStan);
		
		PlayerPrefs.SetFloat ("Slot"+SlotNumber+"Money", Var.Money);
		PlayerPrefs.SetInt ("Slot"+SlotNumber+"Fame", Var.Fame);
		PlayerPrefs.SetInt("Slot"+SlotNumber+"Members", Var.Mems.Count);
		
		PlayerPrefs.SetInt ("Slot"+SlotNumber+"RoomLV", Var.Mng.RoomObject.Level);
		PlayerPrefs.SetInt("Slot"+SlotNumber+"WBLV", Var.Mng.Wb.Level);
		PlayerPrefs.SetInt ("Slot"+SlotNumber+"CPULV", Var.Mng.Cpu.Level);
		PlayerPrefs.SetInt ("Slot"+SlotNumber+"SBLV", Var.Mng.Sb.Level);
		PlayerPrefs.SetInt("Slot"+SlotNumber+"CpsLV", Var.Mng.Cps.Level);
		PlayerPrefs.SetInt("Slot"+SlotNumber+"BGLV", Var.Mng.Bg.Level);
		PlayerPrefs.SetInt("Slot"+SlotNumber+"TVLV", Var.Mng.Tv.Level);
		PlayerPrefs.SetInt("Slot"+SlotNumber+"GameLV", Var.Mng.Gm.Level);
		PlayerPrefs.SetInt("Slot"+SlotNumber+"BookLV", Var.Mng.Bk.Level);
		PlayerPrefs.SetInt("Slot"+SlotNumber+"CookLV", Var.Mng.Ck.Level);
		PlayerPrefs.SetInt("Slot"+SlotNumber+"PiaLV", Var.Mng.Pia.Level);
		
		for(int i=0; i<7; i++)
		{
			PlayerPrefs.SetInt("Slot"+SlotNumber+"AchTimes"+i, Var.AchTimesList[i]);
		}
		for(int i=0; i<24; i++)
		{
			if(Var.AchBoolList[i] == true)
			{
				PlayerPrefs.SetInt("Slot"+SlotNumber+"AchBool"+i, 1);
			}
			else
			{
				PlayerPrefs.SetInt("Slot"+SlotNumber+"AchBool"+i, 0);
			}
		}
		
		for(int Order = 0; Order < Var.MaleNameList.Count; Order++)
		{
			string NameConvert = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes (Var.MaleNameList[Order]));
			PlayerPrefs.SetString("Slot"+SlotNumber+"MaleName"+Order, NameConvert);
		}
		for(int Order = 0; Order < Var.FemaleNameList.Count; Order++)
		{
			string NameConvert = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes (Var.FemaleNameList[Order]));
			PlayerPrefs.SetString("Slot"+SlotNumber+"FemaleName"+Order, NameConvert);
		}
		
		foreach(Character Mem in Var.Mems)
		{
			string NameConvert = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes (Mem.Name));
			PlayerPrefs.SetString("Slot"+SlotNumber+"Name"+Mem.MemberNumber, NameConvert);

			PlayerPrefs.SetInt("Slot"+SlotNumber+"Gender"+Mem.MemberNumber, BoolToInt(Mem.Gender));

			PlayerPrefs.SetInt("Slot"+SlotNumber+"Plan"+Mem.MemberNumber, Mem.Abilities[0]);
			PlayerPrefs.SetInt("Slot"+SlotNumber+"Programming"+Mem.MemberNumber, Mem.Abilities[1]);
			PlayerPrefs.SetInt("Slot"+SlotNumber+"Art"+Mem.MemberNumber, Mem.Abilities[2]);
			PlayerPrefs.SetInt("Slot"+SlotNumber+"Sound"+Mem.MemberNumber, Mem.Abilities[3]);
			PlayerPrefs.SetInt ("Slot"+SlotNumber+"Loyalty"+Mem.MemberNumber, Mem.Loyalty);
			PlayerPrefs.SetInt("Slot"+SlotNumber+"Number"+Mem.MemberNumber, Mem.MemberNumber);

			PlayerPrefs.SetInt("Slot"+SlotNumber+"PrevAct1"+Mem.MemberNumber, ActionToInt(Mem.PrevAct1));
			PlayerPrefs.SetInt("Slot"+SlotNumber+"PrevAct2"+Mem.MemberNumber, ActionToInt(Mem.PrevAct2));

			PlayerPrefs.SetInt("Slot"+SlotNumber+"Talent"+Mem.MemberNumber, TalentToInt(Mem.Tal));
			PlayerPrefs.SetInt("Slot"+SlotNumber+"UnTalent"+Mem.MemberNumber, TalentToInt(Mem.UnTal));

			PlayerPrefs.SetInt("Slot"+SlotNumber+"Controllable"+Mem.MemberNumber, BoolToInt(Mem.Controllable));
			PlayerPrefs.SetInt("Slot"+SlotNumber+"UnControllableDuration"+Mem.MemberNumber, Mem.UnControllableDuration);
			PlayerPrefs.SetInt("Slot"+SlotNumber+"DoubleBuff"+Mem.MemberNumber, BoolToInt(Mem.DoubleBuff));
			PlayerPrefs.SetInt("Slot"+SlotNumber+"BuffDuration"+Mem.MemberNumber, Mem.BuffDuration);

			for(int i=0; i<Var.Mems.Count; i++)
			{
				PlayerPrefs.SetInt("Slot"+SlotNumber+"RelationShip"+Mem.MemberNumber+"."+i, Mem.Relationship[i]);
			}

			PlayerPrefs.SetInt("Slot"+SlotNumber+"Special"+Mem.MemberNumber, BoolToInt(Mem.Special));
			if(Mem.Special == false)
			{
				SaveHairInfo(Mem);

				PlayerPrefs.SetFloat("Slot"+SlotNumber+"HairR"+Mem.MemberNumber, Mem.HairR);
				PlayerPrefs.SetFloat("Slot"+SlotNumber+"HairG"+Mem.MemberNumber, Mem.HairG);
				PlayerPrefs.SetFloat("Slot"+SlotNumber+"HairB"+Mem.MemberNumber, Mem.HairB);
				PlayerPrefs.SetFloat("Slot"+SlotNumber+"ShirtsR"+Mem.MemberNumber, Mem.ShirtsR);
				PlayerPrefs.SetFloat("Slot"+SlotNumber+"ShirtsG"+Mem.MemberNumber, Mem.ShirtsG);
				PlayerPrefs.SetFloat("Slot"+SlotNumber+"ShirtsB"+Mem.MemberNumber, Mem.ShirtsB);
				PlayerPrefs.SetFloat("Slot"+SlotNumber+"PantsR"+Mem.MemberNumber, Mem.PantsR);
				PlayerPrefs.SetFloat("Slot"+SlotNumber+"PantsG"+Mem.MemberNumber, Mem.PantsG);
				PlayerPrefs.SetFloat("Slot"+SlotNumber+"PantsB"+Mem.MemberNumber, Mem.PantsB);

				PlayerPrefs.SetInt ("Slot"+SlotNumber+"Violence"+Mem.MemberNumber, Mem.Violence);
				PlayerPrefs.SetInt ("Slot"+SlotNumber+"Emotion"+Mem.MemberNumber, Mem.Emotion);
				PlayerPrefs.SetInt ("Slot"+SlotNumber+"Strategy"+Mem.MemberNumber, Mem.Strategy);
				PlayerPrefs.SetInt ("Slot"+SlotNumber+"Control"+Mem.MemberNumber, Mem.Control);
				PlayerPrefs.SetInt ("Slot"+SlotNumber+"Liberty"+Mem.MemberNumber, Mem.Liberty);
				PlayerPrefs.SetInt ("Slot"+SlotNumber+"Puzzle"+Mem.MemberNumber, Mem.Puzzle);
				PlayerPrefs.SetInt ("Slot"+SlotNumber+"Simplity"+Mem.MemberNumber, Mem.Simplity);
				PlayerPrefs.SetInt ("Slot"+SlotNumber+"Story"+Mem.MemberNumber, Mem.Story);
			}
		}
		
		PlayerPrefs.SetInt("Slot"+SlotNumber+"DinCnt", Var.DrkCnt);
		PlayerPrefs.SetInt("Slot"+SlotNumber+"MTCnt", Var.MTCnt);

		PlayerPrefs.SetInt ("Slot" + SlotNumber + "TutorialPass", BoolToInt(Var.TutorialPass));
		
		Debug.Log ("Saved.");
		Notice = Instantiate(SaveNoticePf) as NoticeMessage;
		Notice.NoticeType = NoticeMessage.NoticeTypes.SaveMessage;
		
		Destroy (Parent.gameObject);
	}

	void SaveHairInfo(Character Member)
	{
		if(Member.Gender == true)
		{
			for(int i = 0; i < Member.MaleHairs.Length; i++)
			{
				if(Member.MaleHairs[i] == Member.HairRenderer.sprite)
				{
					PlayerPrefs.SetInt("Slot"+SlotNumber+"HairStyle"+Member.MemberNumber, i);
				}
			}
		}
		else
		{
			for(int i = 0; i < Member.FemaleHairs.Length; i++)
			{
				if(Member.FemaleHairs[i] == Member.HairRenderer.sprite)
				{
					PlayerPrefs.SetInt("Slot"+SlotNumber+"HairStyle"+Member.MemberNumber, i);
				}
			}
		}
	}

	int TalentToInt(Character.Talents Talent)
	{
		if(Talent == Character.Talents.Plan)
		{
			return 1;
		}
		else if(Talent == Character.Talents.Programming)
		{
			return 2;
		}
		else if(Talent == Character.Talents.Art)
		{
			return 3;
		}
		else if(Talent == Character.Talents.Sound)
		{
			return 4;
		}
		else
		{
			Debug.LogError("No (Un)Talent For this Member.");
			return 0;
		}
	}

	int BoolToInt(bool Boolean)
	{
		if(Boolean == true)
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}

	int ActionToInt(Character.ActionIndex Act)
	{
		if(Act == Character.ActionIndex.None)
		{
			return 0;
		}
		else if(Act == Character.ActionIndex.Plan)
		{
			return 1;
		}
		else if(Act == Character.ActionIndex.Programming)
		{
			return 2;
		}
		else if(Act == Character.ActionIndex.Draw)
		{
			return 3;
		}
		else if(Act == Character.ActionIndex.Compose)
		{
			return 4;
		}
		else if(Act == Character.ActionIndex.BdGm)
		{
			return 5;
		}
		else if(Act == Character.ActionIndex.Watch)
		{
			return 6;
		}
		else if(Act == Character.ActionIndex.Game)
		{
			return 7;
		}
		else if(Act == Character.ActionIndex.Book)
		{
			return 8;
		}
		else if(Act == Character.ActionIndex.Cook)
		{
			return 9;
		}
		else
		{
			return 10;
		}
	}
}