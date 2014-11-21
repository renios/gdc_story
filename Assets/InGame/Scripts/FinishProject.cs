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
				int PMScore;
				int DVScore;
				int ArtScore;
				int SoundScore;
						
				CheckSpecMemAbility(PJ);

				if(PJ.ProjectManager != null)
				{
					PMScore = ComputeScore(PJ.ProjectManager, 1, PJ.Type);
					//PMScore = PJ.ProjectManager.Plan*2+PJ.ProjectManager.Programming+PJ.ProjectManager.Art+PJ.ProjectManager.Sound;
				}
				else
				{
					PMScore = 0;
				}
				if(PJ.Programmer != null)
				{
					DVScore = ComputeScore(PJ.Programmer, 2, PJ.Type);
					//DVScore = PJ.Programmer.Plan + PJ.Programmer.Programming*2+PJ.Programmer.Art+PJ.Programmer.Sound;
				}
				else
				{
					DVScore = 0;
				}
				if(PJ.ArtDirecter != null)
				{
					ArtScore = ComputeScore(PJ.ArtDirecter, 3, PJ.Type);
					//ArtScore = PJ.ArtDirecter.Plan+PJ.ArtDirecter.Programming+PJ.ArtDirecter.Art*2+PJ.ArtDirecter.Sound;
				}
				else
				{
					ArtScore = 0;
				}
				if(PJ.SoundDirecter != null)
				{
					SoundScore = ComputeScore(PJ.SoundDirecter, 4, PJ.Type);
					//SoundScore = PJ.SoundDirecter.Plan+PJ.SoundDirecter.Programming+PJ.SoundDirecter.Art+PJ.SoundDirecter.Sound*2;
				}
				else
				{
					SoundScore = 0;
				}
				
				int TotalScore = PMScore+DVScore+ArtScore+SoundScore;
				
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

				if(PMScore != 0 && DVScore != 0 && ArtScore != 0 && SoundScore != 0 && PMScore*2 >= TotalScore)
				{
					Var.Mng.GetAch(3, 40);

					if(Var.AchTimesList[3] == 3)
					{
						Var.Mng.GetAch(9, 100);
					}
				}

				if(PMScore != 0 && DVScore != 0 && ArtScore != 0 && SoundScore != 0 && DVScore*2 >= TotalScore)
				{
					Var.Mng.GetAch(4, 40);
					
					if(Var.AchTimesList[4] == 3)
					{
						Var.Mng.GetAch(10, 100);
					}
				}

				if(PMScore != 0 && DVScore != 0 && ArtScore != 0 && SoundScore != 0 && ArtScore*2 >= TotalScore)
				{
					Var.Mng.GetAch(5, 40);
					
					if(Var.AchTimesList[5] == 3)
					{
						Var.Mng.GetAch(11, 100);
						Var.Mng.MakeNewSpecMem(false, Character.SpecialNameIndex.부렁봇, "부렁봇");
					}
				}
				if(PMScore != 0 && DVScore != 0 && ArtScore != 0 && SoundScore != 0 && SoundScore*2 >= TotalScore)
				{
					Var.Mng.GetAch(6, 40);
					
					if(Var.AchTimesList[6] == 3)
					{
						Var.Mng.GetAch(12, 100);
						Var.Mng.MakeNewSpecMem(true, Character.SpecialNameIndex.쎈타, "쎈타");
					}
				}

				int PjMems = 0;
				
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
				if(Role == 1)
				{
					return Mem.Plan*9/10;
				}
				else if(Role == 2)
				{
					return (Mem.Plan+Mem.Programming*2+Mem.Art+Mem.Sound)*9/10;
				}
				else if(Role == 3)
				{
					return (Mem.Plan+Mem.Programming+Mem.Art*2+Mem.Sound)*9/10;
				}
				else
				{
					return (Mem.Plan+Mem.Programming+Mem.Art+Mem.Sound*2)*9/10;
				}
			}
			else if(Genre == Project.Types.Violence)
			{
				if(Role == 1)
				{
					return (Mem.Plan*2+Mem.Programming+Mem.Art+Mem.Sound)*(Mem.Violence+5)/10;
				}
				else if(Role == 2)
				{
					return (Mem.Plan+Mem.Programming*2+Mem.Art+Mem.Sound)*(Mem.Violence+5)/10;
				}
				else if(Role == 3)
				{
					return (Mem.Plan+Mem.Programming+Mem.Art*2+Mem.Sound)*(Mem.Violence+5)/10;
				}
				else
				{
					return (Mem.Plan+Mem.Programming+Mem.Art+Mem.Sound*2)*(Mem.Violence+5)/10;
				}
			}
			else if(Genre == Project.Types.Emotion)
			{
				if(Role == 1)
				{
					return (Mem.Plan*2+Mem.Programming+Mem.Art+Mem.Sound)*(Mem.Emotion+5)/10;
				}
				else if(Role == 2)
				{
					return (Mem.Plan+Mem.Programming*2+Mem.Art+Mem.Sound)*(Mem.Emotion+5)/10;
				}
				else if(Role == 3)
				{
					return (Mem.Plan+Mem.Programming+Mem.Art*2+Mem.Sound)*(Mem.Emotion+5)/10;
				}
				else
				{
					return (Mem.Plan+Mem.Programming+Mem.Art+Mem.Sound*2)*(Mem.Emotion+5)/10;
				}
			}
			else if(Genre == Project.Types.Strategy)
			{
				if(Role == 1)
				{
					return (Mem.Plan*2+Mem.Programming+Mem.Art+Mem.Sound)*(Mem.Strategy+5)/10;
				}
				else if(Role == 2)
				{
					return (Mem.Plan+Mem.Programming*2+Mem.Art+Mem.Sound)*(Mem.Strategy+5)/10;
				}
				else if(Role == 3)
				{
					return (Mem.Plan+Mem.Programming+Mem.Art*2+Mem.Sound)*(Mem.Strategy+5)/10;
				}
				else
				{
					return (Mem.Plan+Mem.Programming+Mem.Art+Mem.Sound*2)*(Mem.Strategy+5)/10;
				}
			}
			else if(Genre == Project.Types.Control)
			{
				if(Role == 1)
				{
					return (Mem.Plan*2+Mem.Programming+Mem.Art+Mem.Sound)*(Mem.Control+5)/10;
				}
				else if(Role == 2)
				{
					return (Mem.Plan+Mem.Programming*2+Mem.Art+Mem.Sound)*(Mem.Control+5)/10;
				}
				else if(Role == 3)
				{
					return (Mem.Plan+Mem.Programming+Mem.Art*2+Mem.Sound)*(Mem.Control+5)/10;
				}
				else
				{
					return (Mem.Plan+Mem.Programming+Mem.Art+Mem.Sound*2)*(Mem.Control+5)/10;
				}
			}
			else if(Genre == Project.Types.Liberty)
			{
				if(Role == 1)
				{
					return (Mem.Plan*2+Mem.Programming+Mem.Art+Mem.Sound)*(Mem.Liberty+5)/10;
				}
				else if(Role == 2)
				{
					return (Mem.Plan+Mem.Programming*2+Mem.Art+Mem.Sound)*(Mem.Liberty+5)/10;
				}
				else if(Role == 3)
				{
					return (Mem.Plan+Mem.Programming+Mem.Art*2+Mem.Sound)*(Mem.Liberty+5)/10;
				}
				else
				{
					return (Mem.Plan+Mem.Programming+Mem.Art+Mem.Sound*2)*(Mem.Liberty+5)/10;
				}
			}
			else if(Genre == Project.Types.Puzzle)
			{
				if(Role == 1)
				{
					return (Mem.Plan*2+Mem.Programming+Mem.Art+Mem.Sound)*(Mem.Puzzle+5)/10;
				}
				else if(Role == 2)
				{
					return (Mem.Plan+Mem.Programming*2+Mem.Art+Mem.Sound)*(Mem.Puzzle+5)/10;
				}
				else if(Role == 3)
				{
					return (Mem.Plan+Mem.Programming+Mem.Art*2+Mem.Sound)*(Mem.Puzzle+5)/10;
				}
				else
				{
					return (Mem.Plan+Mem.Programming+Mem.Art+Mem.Sound*2)*(Mem.Puzzle+5)/10;
				}
			}
			else if(Genre == Project.Types.Simplity)
			{
				if(Role == 1)
				{
					return (Mem.Plan*2+Mem.Programming+Mem.Art+Mem.Sound)*(Mem.Simplity+5)/10;
				}
				else if(Role == 2)
				{
					return (Mem.Plan+Mem.Programming*2+Mem.Art+Mem.Sound)*(Mem.Simplity+5)/10;
				}
				else if(Role == 3)
				{
					return (Mem.Plan+Mem.Programming+Mem.Art*2+Mem.Sound)*(Mem.Simplity+5)/10;
				}
				else
				{
					return (Mem.Plan+Mem.Programming+Mem.Art+Mem.Sound*2)*(Mem.Simplity+5)/10;
				}
			}
			else
			{
				if(Role == 1)
				{
					return (Mem.Plan*2+Mem.Programming+Mem.Art+Mem.Sound)*(Mem.Story+5)/10;
				}
				else if(Role == 2)
				{
					return (Mem.Plan+Mem.Programming*2+Mem.Art+Mem.Sound)*(Mem.Story+5)/10;
				}
				else if(Role == 3)
				{
					return (Mem.Plan+Mem.Programming+Mem.Art*2+Mem.Sound)*(Mem.Story+5)/10;
				}
				else
				{
					return (Mem.Plan+Mem.Programming+Mem.Art+Mem.Sound*2)*(Mem.Story+5)/10;
				}
			}
		}
	}

	void CheckSpecMemAbility(Project Pj)
	{
		List<Character> PjMems = new List<Character> ();

		if(Pj.ProjectManager != null && Pj.ProjectManager.Name == "오키드")
		{
			if(Pj.Programmer != null)
			{
				PjMems.Add(Pj.Programmer);
			}
			if(Pj.ArtDirecter != null)
			{
				PjMems.Add(Pj.ArtDirecter);
			}
			if(Pj.SoundDirecter != null)
			{
				PjMems.Add (Pj.SoundDirecter);
			}
		}
		else if(Pj.Programmer != null && Pj.Programmer.Name == "오키드")
		{
			if(Pj.ProjectManager != null)
			{
				PjMems.Add(Pj.ProjectManager);
			}
			if(Pj.ArtDirecter != null)
			{
				PjMems.Add(Pj.ArtDirecter);
			}
			if(Pj.SoundDirecter != null)
			{
				PjMems.Add (Pj.SoundDirecter);
			}
		}
		else if(Pj.ArtDirecter != null && Pj.ArtDirecter.Name == "오키드")
		{
			if(Pj.ProjectManager != null)
			{
				PjMems.Add(Pj.ProjectManager);
			}
			if(Pj.Programmer != null)
			{
				PjMems.Add(Pj.Programmer);
			}
			if(Pj.SoundDirecter != null)
			{
				PjMems.Add (Pj.SoundDirecter);
			}
		}
		else if(Pj.SoundDirecter != null && Pj.SoundDirecter.Name == "오키드")
		{
			if(Pj.ProjectManager != null)
			{
				PjMems.Add(Pj.ProjectManager);
			}
			if(Pj.Programmer != null)
			{
				PjMems.Add(Pj.Programmer);
			}
			if(Pj.ArtDirecter != null)
			{
				PjMems.Add(Pj.ArtDirecter);
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
}