using UnityEngine;
using System.Collections;

public class FinishProject : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance();

	public ProjectBg Parent;
	public MakeProject Maker;

	public ProjectResult ResultPrefab;
	ProjectResult Result;
	public NoticeMessage NoticePrefab;
	NoticeMessage Notice;

	int HighScore = 4;

	void OnMouseDown()
	{
		if(Var.OnTutorial == false)
		{
			Var.Stan1st = (Var.Semester * 900) - 100;
			Var.Stan2nd = (Var.Stan1st / 4) * 3;
			Var.Stan3rd = (Var.Stan1st / 2);
			Var.Stan4th = (Var.Stan1st / 10) * 3;
			Var.Stan5th = (Var.Stan1st / 5);
			Var.Stan6th = (Var.Stan1st / 10);
			
			Result = Instantiate (ResultPrefab) as ProjectResult;
			
			float MoneyChange = 0;
			int FameChange = 0;
			
			foreach(Project PJ in Maker.Projects)
			{
				int PMScore;
				int DVScore;
				int ArtScore;
				int SoundScore;
				
				if(PJ.ProjectManager != null)
				{
					PMScore = PJ.ProjectManager.Plan*2+PJ.ProjectManager.Programming+PJ.ProjectManager.Art+PJ.ProjectManager.Sound;
				}
				else
				{
					PMScore = 0;
				}
				if(PJ.Programmer != null)
				{
					DVScore = PJ.Programmer.Plan + PJ.Programmer.Programming*2+PJ.Programmer.Art+PJ.Programmer.Sound;
				}
				else
				{
					DVScore = 0;
				}
				if(PJ.ArtDirecter != null)
				{
					ArtScore = PJ.ArtDirecter.Plan+PJ.ArtDirecter.Programming+PJ.ArtDirecter.Art*2+PJ.ArtDirecter.Sound;
				}
				else
				{
					ArtScore = 0;
				}
				if(PJ.SoundDirecter != null)
				{
					SoundScore = PJ.SoundDirecter.Plan+PJ.SoundDirecter.Programming+PJ.SoundDirecter.Art+PJ.SoundDirecter.Sound*2;
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
					FameChange += 100;
					Var.AchTimesList[0] += 1;

					Var.NewAchs.Add (0);
					PlayerPrefs.SetInt("Ach0", 1);
					
					if(PMScore != 0 && DVScore != 0 && ArtScore != 0 && SoundScore != 0 && ArtScore*2 >= TotalScore)
					{
						Var.AchTimesList[3] += 1;
						FameChange += 40;

						Var.NewAchs.Add (3);
						PlayerPrefs.SetInt("Ach3", 1);
						
						if(Var.AchTimesList[3] == 2)
						{
							Var.AchBoolList[2] = true;
							FameChange += 50;

							Var.NewAchs.Add (7);
							PlayerPrefs.SetInt("Ach7", 1);
							
							Var.Mng.NewMember = Instantiate(Var.Mng.NewMemberPrefab) as Character;
							Var.Mng.NewMember.Special = true;
							Var.Mng.NewMember.Gender = false;
							Var.Mng.NewMember.SpecialName = Character.SpecialNameIndex.부렁봇;
							Var.NewSpecMems.Add ("부렁봇");
						}
						else if(Var.AchTimesList[3] == 4)
						{
							Var.AchBoolList[4] = true;
							FameChange += 200;

							Var.NewAchs.Add (9);
							PlayerPrefs.SetInt("Ach9", 1);
						}
					}
					if(PMScore != 0 && DVScore != 0 && ArtScore != 0 && SoundScore != 0 && SoundScore*2 >= TotalScore)
					{
						Var.AchTimesList[4] += 1;
						FameChange += 40;

						Var.NewAchs.Add (4);
						PlayerPrefs.SetInt("Ach4", 1);
						
						if(Var.AchTimesList[4] == 2)
						{
							Var.AchBoolList[3] = true;
							FameChange += 50;

							Var.NewAchs.Add (8);
							PlayerPrefs.SetInt("Ach8", 1);
							
							Var.Mng.NewMember = Instantiate(Var.Mng.NewMemberPrefab) as Character;
							Var.Mng.NewMember.Special = true;
							Var.Mng.NewMember.Gender = true;
							Var.Mng.NewMember.SpecialName = Character.SpecialNameIndex.쎈타;
							Var.NewSpecMems.Add ("쎈타");
						}
						else if(Var.AchTimesList[4] == 4)
						{
							Var.AchBoolList[5] = true;
							FameChange += 200;

							Var.NewAchs.Add (10);
							PlayerPrefs.SetInt("Ach10", 1);
						}
					}
					if(Var.AchBoolList[0] == false)
					{
						Var.AchBoolList[0] = true;
						FameChange += 50;

						Var.NewAchs.Add (5);
						PlayerPrefs.SetInt("Ach5", 1);
						
						Var.Mng.NewMember = Instantiate(Var.Mng.NewMemberPrefab) as Character;
						Var.Mng.NewMember.Special = true;
						Var.Mng.NewMember.Gender = false;
						Var.Mng.NewMember.SpecialName = Character.SpecialNameIndex.오키드;
						Var.NewSpecMems.Add ("오키드");
					}
					if(Var.AchTimesList[0] == 4)
					{
						Var.AchBoolList[1] = true;
						FameChange += 250;

						Var.NewAchs.Add (6);
						PlayerPrefs.SetInt("Ach6", 1);
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
					FameChange += 60;
					Var.AchTimesList[1] += 1;

					Var.NewAchs.Add (1);
					PlayerPrefs.SetInt("Ach1", 1);
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
					FameChange += 30;
					Var.AchTimesList[2] += 1;

					Var.NewAchs.Add (2);
					PlayerPrefs.SetInt("Ach2", 1);
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
				
				Destroy(PJ.gameObject);
			}
			
			if(HighScore > 4)
			{
				Var.Fame += FameChange;
				
				Var.MoneyReasonLog.Add ("게임 공모전");
				Var.MoneyMonthLog.Add (Var.Month);
				Var.MoneyDayLog.Add (Var.Day);
				Var.Money += MoneyChange;
				Var.MoneyChangeLog.Add (MoneyChange);
				Var.MoneyRemainLog.Add (Var.Money);
			}
			
			Var.ProjectHighScore = HighScore;
			
			Notice = Instantiate (NoticePrefab, new Vector3(0, -2.2f, NoticePrefab.transform.position.z), Quaternion.identity) as NoticeMessage;
			Notice.NoticeType = NoticeMessage.NoticeTypes.ProjectResult;
			Destroy (Var.Mng.WallInstance.gameObject);
			
			Destroy (Parent.gameObject);
			//Destroy (gameObject);
		}
	}
}