using UnityEngine;
using System.Collections;

public class Calendar : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public NoticeMessage NoticePrefab;
	NoticeMessage Notice;

	void OnMouseDown()
	{
		if(Var.OnTutorial == false || Var.Mng.Tutorial.Page == 36)
		{
			GoNextPeriod();
			Var.Mng.AudioSources[2].Play();

			if(Var.OnTutorial == true)
			{
				Var.Mng.Tutorial.Page += 1;
				Var.Mng.Tutorial.Collider.enabled = true;
			}
			else
			{
				foreach(Character PlanMember in Var.PlanMems)
				{
					if(PlanMember.Tal == Character.Talents.Plan)
					{
						PlanMember.Plan += (int)(Var.TalentModifier*(float)(Var.Mng.Wb.Level*5));
					}
					else if(PlanMember.UnTal == Character.Talents.Plan)
					{
						PlanMember.Plan += (int)(Var.UnTalentModifier*(float)(Var.Mng.Wb.Level*5));
					}
					else
					{
						PlanMember.Plan += Var.Mng.Wb.Level*5;
					}
					PlanMember.Loyalty -= Var.DecLoyalHard;
				}
				foreach(Character ProgrammingMember in Var.ProgramMems)
				{
					if(ProgrammingMember.Tal == Character.Talents.Programming)
					{
						ProgrammingMember.Programming += (int)(Var.TalentModifier*(float)(Var.Mng.Cpu.Level*5));
					}
					else if(ProgrammingMember.UnTal == Character.Talents.Programming)
					{
						ProgrammingMember.Programming += (int)(Var.UnTalentModifier*(float)(Var.Mng.Cpu.Level*5));
					}
					else
					{
						ProgrammingMember.Programming += Var.Mng.Cpu.Level*5;
					}
					ProgrammingMember.Loyalty -= Var.DecLoyalHard;
				}
				foreach(Character DrawMember in Var.DrawMems)
				{
					if(DrawMember.Tal == Character.Talents.Art)
					{
						DrawMember.Art += (int)(Var.TalentModifier*(float)(Var.Mng.Sb.Level*5));
					}
					else if(DrawMember.UnTal == Character.Talents.Art)
					{
						DrawMember.Art += (int)(Var.UnTalentModifier*(float)(Var.Mng.Sb.Level*5));
					}
					else
					{
						DrawMember.Art += Var.Mng.Sb.Level*5;
					}
					DrawMember.Loyalty -= Var.DecLoyalHard;
				}
				foreach(Character ComposeMember in Var.ComposeMems)
				{
					if(ComposeMember.Tal == Character.Talents.Sound)
					{
						ComposeMember.Sound += (int)(Var.TalentModifier*(float)(Var.Mng.Cps.Level*5));
					}
					else if(ComposeMember.UnTal == Character.Talents.Sound)
					{
						ComposeMember.Sound += (int)(Var.UnTalentModifier*(float)(Var.Mng.Cps.Level*5));
					}
					else
					{
						ComposeMember.Sound += Var.Mng.Cps.Level*5;
					}
					ComposeMember.Loyalty -= Var.DecLoyalHard;
				}
				foreach(Character BdGmMem in Var.BdGmMems)
				{
					if(BdGmMem.Tal == Character.Talents.Plan)
					{
						BdGmMem.Plan += (int)(Var.TalentModifier*(float)(Var.Mng.Bg.Level*4-1));
					}
					else if(BdGmMem.UnTal == Character.Talents.Plan)
					{
						BdGmMem.Plan += (int)(Var.UnTalentModifier*(float)(Var.Mng.Bg.Level*4-1));
					}
					else
					{
						BdGmMem.Plan += Var.Mng.Bg.Level*4-1;
					}
					if(BdGmMem.Tal == Character.Talents.Art)
					{
						BdGmMem.Art += (int)(Var.TalentModifier*(float)(Var.Mng.Bg.Level*4-1));
					}
					else if(BdGmMem.UnTal == Character.Talents.Art)
					{
						BdGmMem.Art += (int)(Var.UnTalentModifier*(float)(Var.Mng.Bg.Level*4-1));
					}
					else
					{
						BdGmMem.Art += Var.Mng.Bg.Level*4-1;
					}
					BdGmMem.Loyalty -= Var.DecLoyalEasy;
				}
				foreach(Character WatchMem in Var.WatchMems)
				{
					if(WatchMem.Tal == Character.Talents.Plan)
					{
						WatchMem.Sound += (int)(Var.TalentModifier*(float)(Var.Mng.Tv.Level*4-1));
					}
					else if(WatchMem.UnTal == Character.Talents.Plan)
					{
						WatchMem.Sound += (int)(Var.UnTalentModifier*(float)(Var.Mng.Tv.Level*4-1));
					}
					else
					{
						WatchMem.Sound += Var.Mng.Tv.Level*4-1;
					}
					if(WatchMem.Tal == Character.Talents.Art)
					{
						WatchMem.Art += (int)(Var.TalentModifier*(float)(Var.Mng.Tv.Level*4-1));
					}
					else if(WatchMem.UnTal == Character.Talents.Art)
					{
						WatchMem.Art += (int)(Var.UnTalentModifier*(float)(Var.Mng.Tv.Level*4-1));
					}
					else
					{
						WatchMem.Art += Var.Mng.Tv.Level*4-1;
					}
					WatchMem.Loyalty -= Var.DecLoyalEasy;
				}
				foreach(Character GameMem in Var.GameMems)
				{
					if(GameMem.Tal == Character.Talents.Sound)
					{
						GameMem.Sound += (int)(Var.TalentModifier*(float)(Var.Mng.Gm.Level*4-2));
					}
					else if(GameMem.UnTal == Character.Talents.Sound)
					{
						GameMem.Sound += (int)(Var.UnTalentModifier*(float)(Var.Mng.Gm.Level*4-2));
					}
					else
					{
						GameMem.Sound += Var.Mng.Gm.Level*4-2;
					}
					if(GameMem.Tal == Character.Talents.Plan)
					{
						GameMem.Plan += (int)(Var.TalentModifier*(float)(Var.Mng.Gm.Level*4-2));
					}
					else if(GameMem.UnTal == Character.Talents.Plan)
					{
						GameMem.Plan += (int)(Var.UnTalentModifier*(float)(Var.Mng.Gm.Level*4-2));
					}
					else
					{
						GameMem.Plan += Var.Mng.Gm.Level*4-2;
					}
					if(GameMem.Tal == Character.Talents.Art)
					{
						GameMem.Art += (int)(Var.TalentModifier*(float)(Var.Mng.Gm.Level*4-2));
					}
					else if(GameMem.UnTal == Character.Talents.Art)
					{
						GameMem.Art += (int)(Var.UnTalentModifier*(float)(Var.Mng.Gm.Level*4-2));
					}
					else
					{
						GameMem.Art += Var.Mng.Gm.Level*4-2;
					}
					GameMem.Loyalty -= Var.DecLoyalEasy;
				}
				foreach(Character BookMem in Var.BookMems)
				{
					if(BookMem.Tal == Character.Talents.Plan)
					{
						BookMem.Plan += (int)(Var.TalentModifier*(float)(Var.Mng.Gm.Level*4-2));
					}
					else if(BookMem.UnTal == Character.Talents.Plan)
					{
						BookMem.Plan += (int)(Var.UnTalentModifier*(float)(Var.Mng.Gm.Level*4-2));
					}
					else
					{
						BookMem.Plan += Var.Mng.Gm.Level*4-2;
					}
					if(BookMem.Tal == Character.Talents.Programming)
					{
						BookMem.Programming += (int)(Var.TalentModifier*(float)(Var.Mng.Cpu.Level*5));
					}
					else if(BookMem.UnTal == Character.Talents.Programming)
					{
						BookMem.Programming += (int)(Var.UnTalentModifier*(float)(Var.Mng.Cpu.Level*5));
					}
					else
					{
						BookMem.Programming += Var.Mng.Cpu.Level*5;
					}
					BookMem.Loyalty -= Var.DecLoyalEasy;
				}
				foreach(Character CookMem in Var.CookMems)
				{
					if(CookMem.Tal == Character.Talents.Art)
					{
						CookMem.Art += (int)(Var.TalentModifier*(float)(Var.Mng.Ck.Level*4));
					}
					else if(CookMem.UnTal == Character.Talents.Art)
					{
						CookMem.Art += (int)(Var.UnTalentModifier*(float)(Var.Mng.Ck.Level*4));
					}
					else
					{
						CookMem.Art += Var.Mng.Ck.Level*4;
					}
					CookMem.Loyalty -= Var.DecLoyalEasy;
				}
				foreach(Character PiaMem in Var.PiaMems)
				{
					if(PiaMem.Tal == Character.Talents.Sound)
					{
						PiaMem.Sound += (int)(Var.TalentModifier*(float)(Var.Mng.Pia.Level*4));
					}
					else if(PiaMem.UnTal == Character.Talents.Sound)
					{
						PiaMem.Sound += (int)(Var.UnTalentModifier*(float)(Var.Mng.Pia.Level*4));
					}
					else
					{
						PiaMem.Sound += Var.Mng.Pia.Level*4;
					}
					PiaMem.Loyalty += Var.DecLoyalEasy;
				}
				
				Notice = Instantiate (NoticePrefab) as NoticeMessage;
				if(Var.PlanMems.Count != 0)
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.PlanResult;
				}
				else if(Var.ProgramMems.Count != 0)
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.ProgrammingResult;
				}
				else if(Var.DrawMems.Count != 0)
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.DrawResult;
				}
				else if(Var.ComposeMems.Count != 0)
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.ComposeResult;
				}
				else if(Var.BdGmMems.Count != 0)
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.BdGmResult;
				}
				else if(Var.WatchMems.Count != 0)
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.TvResult;
				}
				else if(Var.GameMems.Count != 0)
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.GameResult;
				}
				else if(Var.BookMems.Count != 0)
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.BookResult;
				}
				else if(Var.CookMems.Count != 0)
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.CookResult;
				}
				else if(Var.PiaMems.Count != 0)
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.PiaResult;
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NothingResult;
				}
				Var.MenuActivated = true;
			}
		}

		foreach(Character Mem in Var.Mems)
		{
			if(Mem.PrevAct2 == Mem.PrevAct1 && Mem.PrevAct1 == Mem.CurrentAct && Mem.CurrentAct != Character.ActionIndex.None)
			{
				Mem.Loyalty -= 2;
			}

			Mem.PrevAct2 = Mem.PrevAct1;
			Mem.PrevAct1 = Mem.CurrentAct;
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

	void GoNextPeriod()
	{
		if(Var.Day == "초")
		{
			Var.Day = "중";
		}
		else if(Var.Day == "중")
		{
			Var.Day = "말";
		}
		else
		{
			Var.Day = "초";
			if(Var.Month != 12)
			{
				if(Var.Month == 2 || Var.Month == 8)
				{
					Var.Semester += 1;
				}
				Var.Month += 1;
			}
			else
			{
				Var.Month = 1;
				Var.Year += 1;
			}
		}
	}
}