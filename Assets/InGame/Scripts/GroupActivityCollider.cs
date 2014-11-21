using UnityEngine;
using System.Collections;

public class GroupActivityCollider : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public NoticeMessage NoticePrefab;
	NoticeMessage Notice;
	public NewAch NewAchPF;
	NewAch NewAchIS;

	public GroupActivity Parent;

	CutScene SceneIS;

	public enum GroupActivityTypes
	{
		Picnic,
		Drink,
		Dinner,
		MT,
	}
	public GroupActivityTypes Type;

	void OnMouseDown()
	{
		if(Var.OnTutorial == false)
		{
			Var.Mng.AudioSources[0].Play ();
			if(Type == GroupActivityTypes.Picnic)
			{
				if(Var.Money >= GroupActivityCost())
				{
					if(Var.Month >= 3 && Var.Month <= 5)
					{
						SceneIS = Instantiate(Parent.ScenePF) as CutScene;
						SceneIS.SceneType = CutScene.SceneTypes.SpringPicnic;
					}
					else if(Var.Month >= 6 && Var.Month <= 8)
					{
						SceneIS = Instantiate(Parent.ScenePF) as CutScene;
						SceneIS.SceneType = CutScene.SceneTypes.SummerPicnic;
					}
					else if(Var.Month >= 9 && Var.Month <= 11)
					{
						SceneIS = Instantiate(Parent.ScenePF) as CutScene;
						SceneIS.SceneType = CutScene.SceneTypes.AutumnPicnic;
					}
					else
					{
						SceneIS = Instantiate(Parent.ScenePF) as CutScene;
						SceneIS.SceneType = CutScene.SceneTypes.WinterPicnic;
					}
					Var.MoneyReasonLog.Add ("소풍");
				}
				Var.GroupActivityType = GlobalVariables.GroupActivityTypes.Picnic;
			}
			else if(Type == GroupActivityTypes.Drink)
			{
				if(Var.Money >= GroupActivityCost())
				{
					SceneIS = Instantiate(Parent.ScenePF) as CutScene;
					SceneIS.SceneType = CutScene.SceneTypes.Drink;
					Var.MoneyReasonLog.Add ("음주");

					Var.DrkCnt += 1;

					if(Var.DrkCnt == 15)
					{
						Var.AchBoolList[15] = true;
						
						Var.NewAchs.Add (22);
						PlayerPrefs.SetInt("Ach22", 1);
						
						Var.Fame += 50;
					}
				}

				Var.GroupActivityType = GlobalVariables.GroupActivityTypes.Drink;
			}
			else if(Type == GroupActivityTypes.Dinner)
			{
				if(Var.Money >= GroupActivityCost())
				{
					SceneIS = Instantiate(Parent.ScenePF) as CutScene;
					SceneIS.SceneType = CutScene.SceneTypes.Dinner;
					Var.MoneyReasonLog.Add ("회식");
				}

				Var.GroupActivityType = GlobalVariables.GroupActivityTypes.Dinner;
			}
			else if(Type == GroupActivityTypes.MT)
			{
				if(Var.Money >= GroupActivityCost())
				{
					if(Var.Month >= 3 && Var.Month <= 5)
					{
						SceneIS = Instantiate(Parent.ScenePF) as CutScene;
						SceneIS.SceneType = CutScene.SceneTypes.SpringMT;
					}
					else if(Var.Month >= 6 && Var.Month <= 8)
					{
						SceneIS = Instantiate(Parent.ScenePF) as CutScene;
						SceneIS.SceneType = CutScene.SceneTypes.SummerMT;
					}
					else if(Var.Month >= 9 && Var.Month <= 11)
					{
						SceneIS = Instantiate(Parent.ScenePF) as CutScene;
						SceneIS.SceneType = CutScene.SceneTypes.AutumnMT;
					}
					else
					{
						SceneIS = Instantiate(Parent.ScenePF) as CutScene;
						SceneIS.SceneType = CutScene.SceneTypes.WinterMT;
					}
					Var.MoneyReasonLog.Add ("엠티");

					Var.MTCnt += 1;
					if(Var.MTCnt == 5)
					{
						Var.AchBoolList[16] = true;
						Var.NewAchs.Add (23);
						PlayerPrefs.SetInt("Ach23", 1);
						
						Var.Fame += 100;
						
						Var.Mng.NewMember = Instantiate(Var.Mng.NewMemPf) as Character;
						Var.Mng.NewMember.Special = true;
						Var.Mng.NewMember.Gender = true;
						Var.Mng.NewMember.SpecialName = Character.SpecialNameIndex.김고니;
						Var.NewSpecMems.Add ("김고니");
					}
				}

				Var.GroupActivityType = GlobalVariables.GroupActivityTypes.MT;
			}

			Notice = Instantiate(NoticePrefab) as NoticeMessage;
			Notice.NoticeType = NoticeMessage.NoticeTypes.GroupActivity;
			
			Destroy (Parent.gameObject);
		}
		else if(Type == GroupActivityTypes.Dinner && Var.Mng.Tutorial.Page == 44)
		{
			Var.GroupActivityType = GlobalVariables.GroupActivityTypes.Dinner;
			Var.MoneyReasonLog.Add ("회식");

			Var.Mng.Tutorial.SendMessage("DeActivateRenderer");

			Notice = Instantiate(NoticePrefab) as NoticeMessage;
			Notice.NoticeType = NoticeMessage.NoticeTypes.GroupActivity;
			
			Destroy (Parent.gameObject);
		}

		if(Var.NewAchs.Count != 0)
		{
			NewAchIS = Instantiate(NewAchPF) as NewAch;
		}
	}

	float GroupActivityCost()
	{
		if(Type == GroupActivityTypes.Picnic)
		{
			return (float)Var.Mems.Count*Var.PicnicCost;
		}
		else if(Type == GroupActivityTypes.Drink)
		{
			return (float)Var.Mems.Count*Var.DrinkCost;
		}
		else if(Type == GroupActivityTypes.Dinner)
		{
			return (float)Var.Mems.Count*Var.DinnerCost;
		}
		else
		{
			return (float)Var.Mems.Count*Var.MTCost;
		}
	}
}
