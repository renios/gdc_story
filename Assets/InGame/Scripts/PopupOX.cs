using UnityEngine;
using System.Collections;

public class PopupOX : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public CutScene ScenePF;
	CutScene SceneIS;

	public Question Parent;

	public NoticeMessage NoticePrefab;
	NoticeMessage Notice;
	public NewAch NewAchPF;
	NewAch NewAchIS;
	public SpecAbil SpecEffectPf;
	SpecAbil SpecEffect;

	public bool OX;

	float UsedMoney;

	void OnMouseDown()
	{
		float OreoMultiplier = 1;

		foreach(Character Mem in Var.Mems)
		{
			if(Mem.Name == "오레오")
			{
				OreoMultiplier = 0.8f;
			}
		}

		Var.Mng.AudioSources [2].Play ();
		if(Parent.QuestionType == Question.QuestionTypes.ClbIntro)
		{
			if(OX == true)
			{
				if(Var.Money >= 5)
				{
					SceneIS = Instantiate(ScenePF) as CutScene;
					SceneIS.SceneType = CutScene.SceneTypes.ClubIntroduce;

					Var.Money -= 5;
					Var.Mng.RecordMoneyChange(-5, "동아리소개제");

					if(Var.OnTutorial == true && Var.Mng.Tutorial.Page == 46)
					{
						Var.Mng.Tutorial.SendMessage("DeActivateRenderer");
					}
				}
				else
				{
					Notice = Instantiate(NoticePrefab, new Vector3(NoticePrefab.transform.position.x, NoticePrefab.transform.position.y, -4), Quaternion.identity) as NoticeMessage;
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
				}

				Destroy(Parent.gameObject);
			}
			else
			{
				if(Var.OnTutorial == false)
				{
					int NewMemberCount;
					NewMemberCount = (1 + (Var.Fame/300)) / 2;
					if(NewMemberCount > 4)
					{
						NewMemberCount = 4;
					}
					Var.Mng.CreateNormMem(NewMemberCount);
					Notice = Instantiate(NoticePrefab) as NoticeMessage;
					Notice.NoticeType = NoticeMessage.NoticeTypes.NewMember;
					Destroy(Parent.gameObject);
				}
			}
		}
		else if(Parent.QuestionType == Question.QuestionTypes.RoomUpg && OX == true)
		{
			Notice = Instantiate(NoticePrefab, new Vector3(NoticePrefab.transform.position.x, NoticePrefab.transform.position.y, -4), Quaternion.identity) as NoticeMessage;

			if(Var.Mng.Room.Level == 1)
			{
				if(Var.Fame >= 120)
				{
					if(Var.Money >= 25*OreoMultiplier)
					{
						Var.Money -= 25*OreoMultiplier;
						UsedMoney = 25*OreoMultiplier;
						Var.Mng.Room.Level = 2;
						Var.Mng.Room.Renderer.sprite = Var.Mng.Room.Room2;

						if(Var.AchBoolList[18] == false)
						{
							Var.AchBoolList[18] = true;
							Var.NewAchs.Add (25);
							PlayerPrefs.SetInt("Ach25", 1);
							Var.Fame += 50;

							Var.Mng.NewMember = Instantiate(Var.Mng.NewMemPf) as Character;
							Var.Mng.NewMember.Special = true;
							Var.Mng.NewMember.Gender = false;
							Var.Mng.NewMember.SpecialName = Character.SpecialNameIndex.이유진;
							Var.NewSpecMems.Add ("이유진");
						}

						Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
				}
			}
			else if(Var.Mng.Room.Level == 2)
			{
				if(Var.Fame >= 420)
				{
					if(Var.Money >= 40*OreoMultiplier)
					{
						Var.Money -= 40*OreoMultiplier;
						UsedMoney = 40*OreoMultiplier;
						Var.Mng.Room.Level = 3;
						Var.Mng.Room.Renderer.sprite = Var.Mng.Room.Room3;
						
						Var.AchBoolList[19] = true;
						Var.NewAchs.Add (26);
						PlayerPrefs.SetInt("Ach26", 1);
						Var.Fame += 100;

						Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
				}
			}
			else if(Var.Mng.Room.Level == 3)
			{
				if(Var.Fame >= 830)
				{
					if(Var.Money >= 55*OreoMultiplier)
					{
						Var.Money -= 55*OreoMultiplier;
						UsedMoney = 55*OreoMultiplier;
						Var.Mng.Room.Level = 4;
						Var.Mng.Room.Renderer.sprite = Var.Mng.Room.Room4;
						
						Var.AchBoolList[20] = true;
						Var.NewAchs.Add (27);
						PlayerPrefs.SetInt("Ach27", 1);

						Var.Fame += 200;

						Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
				}
			}

			Var.Mng.UpgPupCloser.SendMessage("OnMouseDown");
		}
		else if(Parent.QuestionType == Question.QuestionTypes.WbUpg && OX == true)
		{
			Notice = Instantiate(NoticePrefab, new Vector3(NoticePrefab.transform.position.x, NoticePrefab.transform.position.y, -4), Quaternion.identity) as NoticeMessage;

			if(Var.Mng.Wb.Level == 1)
			{
				if(Var.Mng.Room.Level >= 2)
				{
					if(Var.Fame >= 100)
					{
						if(Var.Money >= 5*OreoMultiplier)
						{
							Var.Money -= 5*OreoMultiplier;
							UsedMoney = 5*OreoMultiplier;
							Var.Mng.Wb.Renderer.sprite = Var.Mng.Wb.Level2;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Wb.Level = 2;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			else if(Var.Mng.Wb.Level == 2)
			{
				if(Var.Mng.Room.Level >= 3)
				{
					if(Var.Fame >= 350)
					{
						if(Var.Money >= 7*OreoMultiplier)
						{
							Var.Money -= 7*OreoMultiplier;
							UsedMoney = 7*OreoMultiplier;
							Var.Mng.Wb.Renderer.sprite = Var.Mng.Wb.Level3;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Wb.Level = 3;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}

			Var.Mng.UpgPupCloser.SendMessage("OnMouseDown");
			Var.Mng.Wb.SendMessage("SetPosition");
		}
		else if(Parent.QuestionType == Question.QuestionTypes.CpuUpg && OX == true)
		{
			Notice = Instantiate(NoticePrefab, new Vector3(NoticePrefab.transform.position.x, NoticePrefab.transform.position.y, -4), Quaternion.identity) as NoticeMessage;
			
			if(Var.Mng.Cpu.Level == 1)
			{
				if(Var.Mng.Room.Level >= 2)
				{
					if(Var.Fame >= 100)
					{
						if(Var.Money >= 5*OreoMultiplier)
						{
							Var.Money -= 5*OreoMultiplier;
							UsedMoney = 5*OreoMultiplier;
							Var.Mng.Cpu.Renderer.sprite = Var.Mng.Cpu.Level2;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Cpu.Level = 2;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			else if(Var.Mng.Cpu.Level == 2)
			{
				if(Var.Mng.Room.Level >= 3)
				{
					if(Var.Fame >= 350)
					{
						if(Var.Money >= 7*OreoMultiplier)
						{
							Var.Money -= 7*OreoMultiplier;
							UsedMoney = 7*OreoMultiplier;
							Var.Mng.Cpu.Renderer.sprite = Var.Mng.Cpu.Level3;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Cpu.Level = 3;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			
			Var.Mng.UpgPupCloser.SendMessage("OnMouseDown");
			Var.Mng.Cpu.SendMessage("SetPosition");
		}
		else if(Parent.QuestionType == Question.QuestionTypes.SbUpg && OX == true)
		{
			Notice = Instantiate(NoticePrefab, new Vector3(NoticePrefab.transform.position.x, NoticePrefab.transform.position.y, -4), Quaternion.identity) as NoticeMessage;
			
			if(Var.Mng.Sb.Level == 1)
			{
				if(Var.Mng.Room.Level >= 2)
				{
					if(Var.Fame >= 100)
					{
						if(Var.Money >= 5*OreoMultiplier)
						{
							Var.Money -= 5*OreoMultiplier;
							UsedMoney = 5*OreoMultiplier;
							Var.Mng.Sb.Renderer.sprite = Var.Mng.Sb.Level2;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Sb.Level = 2;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			else if(Var.Mng.Sb.Level == 2)
			{
				if(Var.Mng.Room.Level >= 3)
				{
					if(Var.Fame >= 350)
					{
						if(Var.Money >= 7*OreoMultiplier)
						{
							Var.Money -= 7*OreoMultiplier;
							UsedMoney = 7*OreoMultiplier;
							Var.Mng.Sb.Renderer.sprite = Var.Mng.Sb.Level3;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Sb.Level = 3;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			
			Var.Mng.UpgPupCloser.SendMessage("OnMouseDown");
			Var.Mng.Sb.SendMessage("SetPosition");
			Var.Mng.Table.SendMessage("SetPosition");
			Var.Mng.Cps.SendMessage("SetPosition");
		}
		else if(Parent.QuestionType == Question.QuestionTypes.CpsUpg && OX == true)
		{
			Notice = Instantiate(NoticePrefab, new Vector3(NoticePrefab.transform.position.x, NoticePrefab.transform.position.y, -4), Quaternion.identity) as NoticeMessage;

			if(Var.Mng.Cps.Level == 1)
			{
				if(Var.Mng.Room.Level >= 2)
				{
					if(Var.Fame >= 100)
					{
						if(Var.Money >= 5*OreoMultiplier)
						{
							Var.Money -= 5*OreoMultiplier;
							UsedMoney = 5*OreoMultiplier;
							Var.Mng.Cps.Renderer.sprite = Var.Mng.Cps.Level2;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Cps.Level = 2;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			else if(Var.Mng.Cps.Level == 2)
			{
				if(Var.Mng.Room.Level >= 3)
				{
					if(Var.Fame >= 350)
					{
						if(Var.Money >= 7*OreoMultiplier)
						{
							Var.Money -= 7*OreoMultiplier;
							UsedMoney = 7*OreoMultiplier;
							Var.Mng.Cps.Renderer.sprite = Var.Mng.Cps.Level3;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Cps.Level = 3;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			
			Var.Mng.UpgPupCloser.SendMessage("OnMouseDown");
			Var.Mng.Sb.SendMessage("SetPosition");
			Var.Mng.Table.SendMessage("SetPosition");
			Var.Mng.Cps.SendMessage("SetPosition");
		}
		else if(Parent.QuestionType == Question.QuestionTypes.BgUpg && OX == true)
		{
			Notice = Instantiate(NoticePrefab, new Vector3(NoticePrefab.transform.position.x, NoticePrefab.transform.position.y, -4), Quaternion.identity) as NoticeMessage;

			if(Var.Mng.Bg.Level == 0)
			{
				if(Var.Mng.Room.Level >= 2)
				{
					if(Var.Fame >= 150)
					{
						if(Var.Money >= 2*OreoMultiplier)
						{
							Var.Money -= 2*OreoMultiplier;
							UsedMoney = 2*OreoMultiplier;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Bg.Level = 1;
							Var.Mng.Bg.Renderer.sprite = Var.Mng.Bg.Level1;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			else if(Var.Mng.Bg.Level == 1)
			{
				if(Var.Mng.Room.Level >= 3)
				{
					if(Var.Fame >= 400)
					{
						if(Var.Money >= 2*OreoMultiplier)
						{
							Var.Money -= 2*OreoMultiplier;
							UsedMoney = 2*OreoMultiplier;
							Var.Mng.Bg.Renderer.sprite = Var.Mng.Bg.Level2;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Bg.Level = 2;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			else if(Var.Mng.Bg.Level == 2)
			{
				if(Var.Mng.Room.Level >= 4)
				{
					if(Var.Fame >= 650)
					{
						if(Var.Money >= 2*OreoMultiplier)
						{
							Var.Money -= 2*OreoMultiplier;
							UsedMoney = 2*OreoMultiplier;
							Var.Mng.Bg.Renderer.sprite = Var.Mng.Bg.Level3;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Bg.Level = 3;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			
			Var.Mng.UpgPupCloser.SendMessage("OnMouseDown");
			Var.Mng.Bg.SendMessage("SetPosition");
		}
		else if(Parent.QuestionType == Question.QuestionTypes.TvUpg && OX == true)
		{
			Notice = Instantiate(NoticePrefab, new Vector3(NoticePrefab.transform.position.x, NoticePrefab.transform.position.y, -4), Quaternion.identity) as NoticeMessage;
			
			if(Var.Mng.Tv.Level == 0)
			{
				if(Var.Mng.Room.Level >= 2)
				{
					if(Var.Fame >= 150)
					{
						if(Var.Money >= 8*OreoMultiplier)
						{
							Var.Money -= 8*OreoMultiplier;
							UsedMoney = 8*OreoMultiplier;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Tv.Level = 1;
							Var.Mng.Tv.Renderer.sprite = Var.Mng.Tv.Level1;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			else if(Var.Mng.Tv.Level == 1)
			{
				if(Var.Mng.Room.Level >= 3)
				{
					if(Var.Fame >= 450)
					{
						if(Var.Money >= 1*OreoMultiplier)
						{
							Var.Money -= 1*OreoMultiplier;
							UsedMoney = 1*OreoMultiplier;
							Var.Mng.Tv.Renderer.sprite = Var.Mng.Tv.Level2;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Tv.Level = 2;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			else if(Var.Mng.Tv.Level == 2)
			{
				if(Var.Mng.Room.Level >= 4)
				{
					if(Var.Fame >= 550)
					{
						if(Var.Money >= 10*OreoMultiplier)
						{
							Var.Money -= 10*OreoMultiplier;
							UsedMoney = 10*OreoMultiplier;
							Var.Mng.Tv.Renderer.sprite = Var.Mng.Tv.Level3;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Tv.Level = 3;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			
			Var.Mng.UpgPupCloser.SendMessage("OnMouseDown");
			Var.Mng.Tv.SendMessage("SetPosition");
		}
		else if(Parent.QuestionType == Question.QuestionTypes.GmUpg && OX == true)
		{
			Notice = Instantiate(NoticePrefab, new Vector3(NoticePrefab.transform.position.x, NoticePrefab.transform.position.y, -4), Quaternion.identity) as NoticeMessage;
			
			if(Var.Mng.Gm.Level == 0)
			{
				if(Var.Mng.Room.Level >= 3)
				{
					if(Var.Fame >= 500)
					{
						if(Var.Money >= 7*OreoMultiplier)
						{
							Var.Money -= 7*OreoMultiplier;
							UsedMoney = 7*OreoMultiplier;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Gm.Level = 1;
							Var.Mng.Gm.Renderer.sprite = Var.Mng.Gm.Level1;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			else if(Var.Mng.Gm.Level == 1)
			{
				if(Var.Mng.Room.Level >= 4)
				{
					if(Var.Fame >= 600)
					{
						if(Var.Money >= 7*OreoMultiplier)
						{
							Var.Money -= 7*OreoMultiplier;
							UsedMoney = 7*OreoMultiplier;
							Var.Mng.Gm.Renderer.sprite = Var.Mng.Gm.Level2;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Gm.Level = 2;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			else if(Var.Mng.Gm.Level == 2)
			{
				if(Var.Mng.Room.Level >= 4)
				{
					if(Var.Fame >= 700)
					{
						if(Var.Money >= 7*OreoMultiplier)
						{
							Var.Money -= 7*OreoMultiplier;
							UsedMoney = 7*OreoMultiplier;
							Var.Mng.Gm.Renderer.sprite = Var.Mng.Gm.Level3;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Gm.Level = 3;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			
			Var.Mng.UpgPupCloser.SendMessage("OnMouseDown");
			Var.Mng.Gm.SendMessage("SetPosition");
		}
		else if(Parent.QuestionType == Question.QuestionTypes.BkUpg && OX == true)
		{
			Notice = Instantiate(NoticePrefab, new Vector3(NoticePrefab.transform.position.x, NoticePrefab.transform.position.y, -4), Quaternion.identity) as NoticeMessage;
			
			if(Var.Mng.Bk.Level == 0)
			{
				if(Var.Mng.Room.Level >= 3)
				{
					if(Var.Fame >= 400)
					{
						if(Var.Money >= 7*OreoMultiplier)
						{
							Var.Money -= 7*OreoMultiplier;
							UsedMoney = 7*OreoMultiplier;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Bk.Level = 1;
							Var.Mng.Bk.Renderer.sprite = Var.Mng.Bk.Level1;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			else if(Var.Mng.Bk.Level == 1)
			{
				if(Var.Mng.Room.Level >= 4)
				{
					if(Var.Fame >= 500)
					{
						if(Var.Money >= 3.5f*OreoMultiplier)
						{
							Var.Money -= 3.5f*OreoMultiplier;
							UsedMoney = 3.5f*OreoMultiplier;
							Var.Mng.Bk.Renderer.sprite = Var.Mng.Bk.Level2;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Bk.Level = 2;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			else if(Var.Mng.Bk.Level == 2)
			{
				if(Var.Mng.Room.Level >= 4)
				{
					if(Var.Fame >= 600)
					{
						if(Var.Money >= 3.5f*OreoMultiplier)
						{
							Var.Money -= 3.5f*OreoMultiplier;
							UsedMoney = 3.5f*OreoMultiplier;
							Var.Mng.Bk.Renderer.sprite = Var.Mng.Bk.Level3;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Bk.Level = 3;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			
			Var.Mng.UpgPupCloser.SendMessage("OnMouseDown");
			Var.Mng.Bk.SendMessage("SetPosition");
		}
		else if(Parent.QuestionType == Question.QuestionTypes.PiaUpg && OX == true)
		{
			Notice = Instantiate(NoticePrefab, new Vector3(NoticePrefab.transform.position.x, NoticePrefab.transform.position.y, -4), Quaternion.identity) as NoticeMessage;
			
			if(Var.Mng.Pia.Level == 0)
			{
				if(Var.Mng.Room.Level >= 3)
				{
					if(Var.Fame >= 500)
					{
						if(Var.Money >= 5*OreoMultiplier)
						{
							Var.Money -= 5*OreoMultiplier;
							UsedMoney = 5*OreoMultiplier;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Pia.Level = 1;
							Var.Mng.Pia.Renderer.sprite = Var.Mng.Pia.Level1;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			else if(Var.Mng.Pia.Level == 1)
			{
				if(Var.Mng.Room.Level >= 4)
				{
					if(Var.Fame >= 600)
					{
						if(Var.Money >= 7*OreoMultiplier)
						{
							Var.Money -= 7*OreoMultiplier;
							UsedMoney = 7*OreoMultiplier;
							Var.Mng.Pia.Renderer.sprite = Var.Mng.Pia.Level2;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Pia.Level = 2;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			else if(Var.Mng.Pia.Level == 2)
			{
				if(Var.Mng.Room.Level >= 4)
				{
					if(Var.Fame >= 700)
					{
						if(Var.Money >= 10*OreoMultiplier)
						{
							Var.Money -= 10*OreoMultiplier;
							UsedMoney = 10*OreoMultiplier;
							Var.Mng.Pia.Renderer.sprite = Var.Mng.Pia.Level3;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Pia.Level = 3;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			
			Var.Mng.UpgPupCloser.SendMessage("OnMouseDown");
			Var.Mng.Pia.SendMessage("SetPosition");
		}
		else if(Parent.QuestionType == Question.QuestionTypes.CkUpg && OX == true)
		{
			Notice = Instantiate(NoticePrefab, new Vector3(NoticePrefab.transform.position.x, NoticePrefab.transform.position.y, -4), Quaternion.identity) as NoticeMessage;
			
			if(Var.Mng.Ck.Level == 0)
			{
				if(Var.Mng.Room.Level >= 3)
				{
					if(Var.Fame >= 500)
					{
						if(Var.Money >= 5*OreoMultiplier)
						{
							Var.Money -= 5*OreoMultiplier;
							UsedMoney = 5*OreoMultiplier;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Ck.Level = 1;
							Var.Mng.Ck.Renderer.sprite = Var.Mng.Ck.Level1;
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			else if(Var.Mng.Ck.Level == 1)
			{
				if(Var.Mng.Room.Level >= 4)
				{
					if(Var.Fame >= 700)
					{
						if(Var.Money >= 7*OreoMultiplier)
						{
							Var.Money -= 7*OreoMultiplier;
							UsedMoney = 7*OreoMultiplier;
							Var.Mng.Ck.Renderer.sprite = Var.Mng.Ck.Level2;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Ck.Level = 2;	
						}
						else
						{
							Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughMoney;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			else if(Var.Mng.Ck.Level == 2)
			{
				if(Var.Mng.Room.Level >= 4)
				{
					if(Var.Fame >= 800)
					{
						if(Var.Money >= 10*OreoMultiplier)
						{
							Var.Money -= 10*OreoMultiplier;
							UsedMoney = 10*OreoMultiplier;
							Var.Mng.Ck.Renderer.sprite = Var.Mng.Ck.Level3;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Ck.Level = 3;
						}
					}
					else
					{
						Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughFame;
					}
				}
				else
				{
					Notice.NoticeType = NoticeMessage.NoticeTypes.NotEnoughRoom;
				}
			}
			
			Var.Mng.UpgPupCloser.SendMessage("OnMouseDown");
			Var.Mng.Ck.SendMessage("SetPosition");
		}
		if (UsedMoney != 0) 
		{
			if(OreoMultiplier == 0.8f)
			{
				SpecEffect = Instantiate(SpecEffectPf) as SpecAbil;
				SpecEffect.Special = SpecAbil.SpecAbils.Oreo;
			}
			Var.Mng.RecordMoneyChange(UsedMoney*(-1), "업그레이드");
		}

		if(Var.OnTutorial == false || OX == true)
		{
			if(Parent.QuestionType == Question.QuestionTypes.RoomUpg)
			{	
				Var.Mng.SetPositionAll();
				Var.Mng.Reset.SendMessage("OnMouseDown");
			}

			Destroy (Parent.WallIs.gameObject);
			Destroy (Parent.gameObject);
		}
	}
}
