using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Calendar : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public NoticeMessage NoticePrefab;
	NoticeMessage Notice;

	public SpecAbil SpecEffectPf;
	SpecAbil SpecEffect;

	void OnMouseDown()
	{
		if(Var.OnTutorial == false || Var.Mng.Tutorial.Page == 36)
		{
			GoNextPeriod();
			Var.Mng.AudioSources[2].Play();

			foreach(Character Mem in Var.Mems)
			{
				if(Mem.Name == "쎈타")
				{
					int LOL = UnityEngine.Random.Range (0, 3);

					if(LOL == 2)
					{
						SpecEffect = Instantiate(SpecEffectPf) as SpecAbil;
						SpecEffect.Special = SpecAbil.SpecAbils.Center;

						Mem.CurrentAct = Character.ActionIndex.None;
						Mem.Balloon.enabled = false;
					}
				}
			}

			if(Var.OnTutorial == true)
			{
				Var.Mng.Tutorial.Page += 1;
				Var.Mng.Tutorial.Collider.enabled = true;
			}
			else
			{
				foreach(Character PlanMember in Var.PlanMems)
				{
					float SpecialMultiplier = ReturnSpecialMultiplier(PlanMember);
					AbilityUp(PlanMember, Character.Talents.Plan, 0, SpecialMultiplier, Var.Mng.Sb.Level*5);

					PlanMember.Loyalty -= Var.DecLoyalHard;
					CheckSpecialAbilityForLoyalty(Var.PlanMems, true);

				}
				foreach(Character ProgrammingMember in Var.ProgramMems)
				{
					float SpecialMultiplier = ReturnSpecialMultiplier(ProgrammingMember);
					AbilityUp(ProgrammingMember, Character.Talents.Programming, 1, SpecialMultiplier, Var.Mng.Cpu.Level*5);

					ProgrammingMember.Loyalty -= Var.DecLoyalHard;
					CheckSpecialAbilityForLoyalty(Var.ProgramMems, true);
				}
				foreach(Character DrawMember in Var.DrawMems)
				{
					float SpecialMultiplier = ReturnSpecialMultiplier(DrawMember);
					AbilityUp(DrawMember, Character.Talents.Art, 2, SpecialMultiplier, Var.Mng.Sb.Level*5);

					DrawMember.Loyalty -= Var.DecLoyalHard;
					CheckSpecialAbilityForLoyalty(Var.DrawMems, true);
				}
				foreach(Character ComposeMember in Var.ComposeMems)
				{
					float SpecialMultiplier = ReturnSpecialMultiplier(ComposeMember);
					AbilityUp(ComposeMember, Character.Talents.Sound, 3, SpecialMultiplier, Var.Mng.Cps.Level*5);

					ComposeMember.Loyalty -= Var.DecLoyalHard;
					CheckSpecialAbilityForLoyalty(Var.ComposeMems, true);
				}
				foreach(Character BdGmMem in Var.BdGmMems)
				{
					float SpecialMultiplier = ReturnSpecialMultiplier(BdGmMem);
					AbilityUp(BdGmMem, Character.Talents.Plan, 0, SpecialMultiplier, Var.Mng.Bg.Level*4-1);
					AbilityUp(BdGmMem, Character.Talents.Art, 2, SpecialMultiplier, Var.Mng.Bg.Level*4-1);

					BdGmMem.Loyalty -= Var.DecLoyalEasy;
					CheckSpecialAbilityForLoyalty(Var.BdGmMems, false);
				}
				foreach(Character WatchMem in Var.WatchMems)
				{
					float SpecialMultiplier = ReturnSpecialMultiplier(WatchMem);
					AbilityUp(WatchMem, Character.Talents.Sound, 3, SpecialMultiplier, Var.Mng.Tv.Level*4-1);
					AbilityUp(WatchMem, Character.Talents.Art, 2, SpecialMultiplier, Var.Mng.Tv.Level*4-1);

					WatchMem.Loyalty -= Var.DecLoyalEasy;
					CheckSpecialAbilityForLoyalty(Var.WatchMems, false);
				}
				foreach(Character GameMem in Var.GameMems)
				{
					float SpecialMultiplier = ReturnSpecialMultiplier(GameMem);
					AbilityUp(GameMem, Character.Talents.Sound, 3, SpecialMultiplier, Var.Mng.Gm.Level*4-2);
					AbilityUp(GameMem, Character.Talents.Plan, 0, SpecialMultiplier, Var.Mng.Gm.Level*4-2);
					AbilityUp(GameMem, Character.Talents.Art, 2, SpecialMultiplier, Var.Mng.Gm.Level*4-2);

					GameMem.Loyalty -= Var.DecLoyalEasy;
					CheckSpecialAbilityForLoyalty(Var.GameMems, false);
				}
				foreach(Character BookMem in Var.BookMems)
				{
					float SpecialMultiplier = ReturnSpecialMultiplier(BookMem);
					AbilityUp(BookMem, Character.Talents.Plan, 0, SpecialMultiplier, Var.Mng.Bk.Level*4-2);
					AbilityUp(BookMem, Character.Talents.Programming, 1, SpecialMultiplier, Var.Mng.Bk.Level*4-2);

					BookMem.Loyalty -= Var.DecLoyalEasy;
					CheckSpecialAbilityForLoyalty(Var.GameMems, false);
				}
				foreach(Character CookMem in Var.CookMems)
				{
					float SpecialMultiplier = ReturnSpecialMultiplier(CookMem);
					AbilityUp(CookMem, Character.Talents.Art, 2, SpecialMultiplier, Var.Mng.Ck.Level*4);

					CookMem.Loyalty -= Var.DecLoyalEasy;
					CheckSpecialAbilityForLoyalty(Var.CookMems, false);
				}
				foreach(Character PiaMem in Var.PiaMems)
				{
					float SpecialMultiplier = ReturnSpecialMultiplier(PiaMem);
					AbilityUp(PiaMem, Character.Talents.Sound, 3, SpecialMultiplier, Var.Mng.Pia.Level*4);
					
					PiaMem.Loyalty += Var.DecLoyalEasy;
					CheckSpecialAbilityForLoyalty(Var.PiaMems, false);
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

			if(Mem.Name == "이유진")
			{
				if(Var.Day == "초")
				{
					if(Var.Month == 1 || Var.Month == 7)
					{
						SpecEffect = Instantiate(SpecEffectPf) as SpecAbil;
						SpecEffect.Special = SpecAbil.SpecAbils.Eugene;

						Mem.Collider.enabled = false;
						Mem.Renderer.enabled = false;
						Mem.Balloon.enabled = false;
						Mem.CurrentAct = Character.ActionIndex.None;
					}
					else if(Var.Month == 3 || Var.Month == 9)
					{
						Mem.Collider.enabled = true;
						Mem.Renderer.enabled = true;
						Mem.Balloon.enabled = true;
					}
				}
			}
		}
	}

	void CheckYomiAbilityActivated(float SpecialMultiplier)
	{
		if(SpecialMultiplier == -1)
		{
			SpecEffect = Instantiate(SpecEffectPf) as SpecAbil;
			SpecEffect.Special = SpecAbil.SpecAbils.Yomi;
		}
	}

	void AbilityUp(Character Mem, Character.Talents TalentForCheck, int AbilityNumber, float SpecialMultiplier, int Default)
	{
		if(Mem.Tal == TalentForCheck)
		{
			Mem.Abilities[AbilityNumber] += (int)(Var.TalentModifier*(float)(Var.Mng.Wb.Level*5)*SpecialMultiplier);
		}
		else if(Mem.UnTal == TalentForCheck)
		{
			Mem.Abilities[AbilityNumber] += (int)(Var.UnTalentModifier*(float)(Var.Mng.Wb.Level*5)*SpecialMultiplier);
		}
		else
		{
			Mem.Abilities[AbilityNumber] += (int)((float)(Var.Mng.Wb.Level*5)*SpecialMultiplier);
		}
	}

	float ReturnSpecialMultiplier(Character Mem)
	{
		if(Mem.Name == "M")
		{
			return 1+(0.1f*Var.FemaleMems.Count);
		}
		else if(Mem.Name == "요미")
		{
			int JingJing = UnityEngine.Random.Range(0, 3);
			{
				if(JingJing == 2)
				{
					return -1;
				}
				else
				{
					return 1;
				}
			}
		}
		else if(Mem.Name == "강참치" && Mem.CurrentAct == Character.ActionIndex.Game)
		{
			return 2;
		}
		else
		{
			return 1;
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

	void CheckSpecialAbilityForLoyalty(List<Character> ActMemList, bool Hard)
	{
		foreach(Character Mem in ActMemList)
		{
			if(Mem.Name == "퐝순" && ActMemList[0].Gender == ActMemList[1].Gender)
			{
				if(Hard == true)
				{
					Mem.Loyalty += Var.DecLoyalHard;
				}
				else
				{
					Mem.Loyalty += Var.DecLoyalEasy;
				}
			}
			else if(Mem.Name == "다리")
			{
				int CoupleCount = 0;
				foreach(Character Member in Var.Mems)
				{
					if(Member.Lovers.Count != 0)
					{
						CoupleCount += 1;
					}
				}

				if(CoupleCount != 0)
				{
					if(Hard == true)
					{
						Mem.Loyalty -= Var.DecLoyalHard*CoupleCount/10;
					}
					else
					{
						Mem.Loyalty -= Var.DecLoyalEasy*CoupleCount/10;
					}
				}
			}
		}
	}
}