using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinishProject : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance();

	public ProjectBg Parent;
	public MakeProject Maker;

	public ProjectResult ResultPrefab;
	ProjectResult Result;
	public NoticeMessage NoticePrefab;
	NoticeMessage Notice;
	public SpecAbil SpecEffectPf;
	SpecAbil SpecEffect;

	int HighScore = 4;

	void OnMouseDown()
	{
		if(Var.OnTutorial == false)
		{
			Var.Stan1st = Var.PjStan*100;
			Var.Stan2nd = Var.PjStan*75;
			Var.Stan3rd = Var.PjStan*50;
			Var.Stan4th = Var.PjStan*30;
			Var.Stan5th = Var.PjStan*20;
			Var.Stan6th = Var.PjStan*10;
			
			Result = Instantiate (ResultPrefab) as ProjectResult;
			
			float MoneyChange = 0;
			int FameChange = 0;
			
			foreach(Project PJ in Maker.Projects)
			{
				List<int> PjScores = new List<int>();
						
				CheckSpecMemAbility(PJ);

				PjScores.Add (ComputeScore(PJ.PjMems[0], 0 ,PJ.Type)*2+ComputeScore(PJ.PjMems[1], 0, PJ.Type)+ComputeScore(PJ.PjMems[2], 0, PJ.Type)+ComputeScore(PJ.PjMems[3], 0, PJ.Type));
				PjScores.Add (ComputeScore(PJ.PjMems[0], 1 ,PJ.Type)+ComputeScore(PJ.PjMems[1], 1, PJ.Type)*2+ComputeScore(PJ.PjMems[2], 1, PJ.Type)+ComputeScore(PJ.PjMems[3], 1, PJ.Type));
				PjScores.Add (ComputeScore(PJ.PjMems[0], 2 ,PJ.Type)+ComputeScore(PJ.PjMems[1], 2, PJ.Type)+ComputeScore(PJ.PjMems[2], 2, PJ.Type)*2+ComputeScore(PJ.PjMems[3], 2, PJ.Type));
				PjScores.Add (ComputeScore(PJ.PjMems[0], 3 ,PJ.Type)+ComputeScore(PJ.PjMems[1], 3, PJ.Type)+ComputeScore(PJ.PjMems[2], 3, PJ.Type)+ComputeScore(PJ.PjMems[3], 3, PJ.Type)*2);
				
				int TotalScore = PjScores[0]+PjScores[1]+PjScores[2]+PjScores[3];
				
				if(TotalScore>= Var.Stan1st)
				{
					PJ.Rank = 1;
					HighScore = 1;
					Var.ProjectRanks.Add(1);
					MoneyChange += 100.0f;
				
					Var.Mng.GetAch(0, 100);

					if(Var.AchBoolList[7] == false)
					{
						Var.Mng.GetAch(14, 50);
						Var.Mng.MakeNewSpecMem(true, Character.SpecialNameIndex.오키드, "오키드");
					}
					if(Var.AchTimesList[0] == 4)
					{
						Var.Mng.GetAch(15, 250);
					}
				}
				else if(TotalScore >= Var.Stan2nd)
				{
					PJ.Rank = 2;
					if(HighScore > 2)
					{
						HighScore = 2;
					}
					Var.ProjectRanks.Add(2);
					MoneyChange += 50.0f;

					Var.Mng.GetAch(1, 60);

					if(Var.AchTimesList[1] == 4 && Var.AchTimesList[0] == 0)
					{
						Var.Mng.GetAch(16, 100);
					}
				}
				else if(TotalScore >= Var.Stan3rd)
				{
					PJ.Rank = 3;
					if(HighScore > 3)
					{
						HighScore = 3;
					}
					Var.ProjectRanks.Add(3);
					MoneyChange += 20.0f;

					Var.Mng.GetAch(2, 30);
				}
				else if(TotalScore >= Var.Stan4th)
				{
					PJ.Rank = 4;
					Var.ProjectRanks.Add(4);
				}
				else if(TotalScore >= Var.Stan5th)
				{
					PJ.Rank = 5;
					Var.ProjectRanks.Add (5);
				}
				else if(TotalScore >= Var.Stan6th)
				{
					PJ.Rank = 6;
					Var.ProjectRanks.Add (6);
				}
				else
				{
					PJ.Rank = 7;
					Var.ProjectRanks.Add (7);
				}

				int PjMemNum = 0;
				foreach(Character PjMem in PJ.PjMems)
				{
					if(PjMem != null)
					{
						PjMemNum += 1;
					}
				}

				if(PjMemNum == 4)
				{
					if(PjScores[0]*2 > TotalScore)
					{
						Var.Mng.GetAch(3, 40);
						CheckPalbangAch();
						
						if(Var.AchTimesList[3] == 3)
						{
							Var.Mng.GetAch(9, 100);
							CheckSuperAch();
						}
					}
					else if(PjScores[1]*2 > TotalScore)
					{
						Var.Mng.GetAch(4, 40);
						CheckPalbangAch();

						if(Var.AchTimesList[4] == 3)
						{
							Var.Mng.GetAch(10, 100);
							CheckSuperAch();
						}
					}
					else if(PjScores[2]*2 > TotalScore)
					{
						Var.Mng.GetAch(5, 40);
						CheckPalbangAch();

						if(Var.AchTimesList[5] == 3)
						{
							Var.Mng.GetAch(11, 100);
							Var.Mng.MakeNewSpecMem(false, Character.SpecialNameIndex.부렁봇, "부렁봇");
							CheckSuperAch();
						}
					}
					else if(PjScores[3]*2 > TotalScore)
					{
						Var.Mng.GetAch(6, 40);
						CheckPalbangAch();

						if(Var.AchTimesList[6] == 3)
						{
							Var.Mng.GetAch(12, 100);
							Var.Mng.MakeNewSpecMem(true, Character.SpecialNameIndex.쎈타, "쎈타");
							CheckSuperAch();
						}
					}
				}
				else if(PjMemNum == 1)
				{
					if(PJ.Rank <= 3)
					{
						Var.Mng.GetAch(7, 50);
					}
				}
				
				Destroy(PJ.gameObject);
			}
			
			if(HighScore < 4)
			{
				Var.Fame += FameChange;
				
				Var.MoneyReasonLog.Add ("게임 공모전");
				Var.MoneyMonthLog.Add (Var.Month);
				Var.MoneyDayLog.Add (Var.Day);
				Var.Money += MoneyChange;
				Var.MoneyChangeLog.Add (MoneyChange);
				Var.MoneyRemainLog.Add (Var.Money);

				Var.PjStan += 10-HighScore;
			}
			else
			{
				Var.PjStan += 6;
			}
			
			Var.ProjectHighScore = HighScore;
			
			Notice = Instantiate (NoticePrefab, new Vector3(0, -2.2f, NoticePrefab.transform.position.z), Quaternion.identity) as NoticeMessage;
			Notice.NoticeType = NoticeMessage.NoticeTypes.ProjectResult;
			Destroy (Var.Mng.WallInstance.gameObject);
			
			Destroy (Parent.gameObject);
		}
	}

	int ComputeScore(Character Mem, int Role, Project.Types Genre)
	{
		if(Mem == null)
		{
			return 0;
		}
		else
		{
			if(Genre == Project.Types.None)
			{
				return Mem.Abilities[Role]*9/10;
			}
			else if(Genre == Project.Types.Violence)
			{
				return Mem.Abilities[Role]*(Mem.Violence+5)/10;
			}
			else if(Genre == Project.Types.Emotion)
			{
				return Mem.Abilities[Role]*(Mem.Emotion+5)/10;
			}
			else if(Genre == Project.Types.Strategy)
			{
				return Mem.Abilities[Role]*(Mem.Strategy+5)/10;
			}
			else if(Genre == Project.Types.Control)
			{
				return Mem.Abilities[Role]*(Mem.Control+5)/10;
			}
			else if(Genre == Project.Types.Liberty)
			{
				return Mem.Abilities[Role]*(Mem.Liberty+5)/10;
			}
			else if(Genre == Project.Types.Puzzle)
			{
				return Mem.Abilities[Role]*(Mem.Puzzle+5)/10;
			}
			else if(Genre == Project.Types.Simplity)
			{
				return Mem.Abilities[Role]*(Mem.Simplity+5)/10;
			}
			else
			{
				return Mem.Abilities[Role]*(Mem.Story+5)/10;
			}
		}
	}

	void CheckSpecMemAbility(Project Pj)
	{
		List<Character> PjMems = new List<Character> ();

		if(Pj.PjMems[0] != null && Pj.PjMems[0].Name == "오키드")
		{
			if(Pj.PjMems[1] != null)
			{
				PjMems.Add(Pj.PjMems[1]);
			}
			if(Pj.PjMems[2] != null)
			{
				PjMems.Add(Pj.PjMems[2]);
			}
			if(Pj.PjMems[3] != null)
			{
				PjMems.Add (Pj.PjMems[3]);
			}
		}
		else if(Pj.PjMems[1] != null && Pj.PjMems[1].Name == "오키드")
		{
			if(Pj.PjMems[0] != null)
			{
				PjMems.Add(Pj.PjMems[0]);
			}
			if(Pj.PjMems[2] != null)
			{
				PjMems.Add(Pj.PjMems[2]);
			}
			if(Pj.PjMems[3] != null)
			{
				PjMems.Add (Pj.PjMems[3]);
			}
		}
		else if(Pj.PjMems[2] != null && Pj.PjMems[2].Name == "오키드")
		{
			if(Pj.PjMems[0] != null)
			{
				PjMems.Add(Pj.PjMems[0]);
			}
			if(Pj.PjMems[1] != null)
			{
				PjMems.Add(Pj.PjMems[1]);
			}
			if(Pj.PjMems[3] != null)
			{
				PjMems.Add (Pj.PjMems[3]);
			}
		}
		else if(Pj.PjMems[3] != null && Pj.PjMems[3].Name == "오키드")
		{
			if(Pj.PjMems[0] != null)
			{
				PjMems.Add(Pj.PjMems[0]);
			}
			if(Pj.PjMems[1] != null)
			{
				PjMems.Add(Pj.PjMems[1]);
			}
			if(Pj.PjMems[2] != null)
			{
				PjMems.Add(Pj.PjMems[2]);
			}
		}

		if(PjMems.Count > 1)
		{
			SpecEffect = Instantiate(SpecEffectPf) as SpecAbil;
			SpecEffect.Special = SpecAbil.SpecAbils.Orchid;

			PjMems[0].Relationship[PjMems[1].MemberNumber] += 20;
			PjMems[1].Relationship[PjMems[0].MemberNumber] += 20;
			if(PjMems[0].Relationship[PjMems[1].MemberNumber] >= 20 && PjMems[0].Relationship[PjMems[1].MemberNumber] <= 35)
			{
				Var.NewFriends.Add(PjMems[0]);
				Var.NewFriends.Add(PjMems[1]);
			}
		}
		if(PjMems.Count > 2)
		{
			PjMems[0].Relationship[PjMems[2].MemberNumber] += 20;
			PjMems[2].Relationship[PjMems[0].MemberNumber] += 20;
			if(PjMems[0].Relationship[PjMems[2].MemberNumber] >= 20 && PjMems[0].Relationship[PjMems[2].MemberNumber] <= 35)
			{
				Var.NewFriends.Add(PjMems[0]);
				Var.NewFriends.Add(PjMems[2]);
			}

			PjMems[2].Relationship[PjMems[1].MemberNumber] += 20;
			PjMems[1].Relationship[PjMems[2].MemberNumber] += 20;
			if(PjMems[2].Relationship[PjMems[1].MemberNumber] >= 20 && PjMems[2].Relationship[PjMems[1].MemberNumber] <= 35)
			{
				Var.NewFriends.Add(PjMems[2]);
				Var.NewFriends.Add(PjMems[1]);
			}
		}
	}

	void CheckPalbangAch()
	{
		if(Var.AchTimesList[3] != 0 && Var.AchTimesList[4] != 0 && Var.AchTimesList[5] != 0 && Var.AchTimesList[6] != 0)
		{
			Var.Mng.GetAch(8, 50);
		}
	}

	void CheckSuperAch()
	{
		if(Var.AchTimesList[3] >= 3 && Var.AchTimesList[4] >= 3 && Var.AchTimesList[5] >= 3 && Var.AchTimesList[6] >= 3)
		{
			Var.Mng.GetAch(13, 200);
		}
	}
}