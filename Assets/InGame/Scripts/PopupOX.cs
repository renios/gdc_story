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

	public bool OX;

	float UsedMoney;

	void OnMouseDown()
	{
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
			}
			else
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
		else if(Parent.QuestionType == Question.QuestionTypes.RoomUpg && OX == true)
		{
			Notice = Instantiate(NoticePrefab, new Vector3(NoticePrefab.transform.position.x, NoticePrefab.transform.position.y, -4), Quaternion.identity) as NoticeMessage;

			if(Var.Mng.Room.Level == 1)
			{
				if(Var.Fame >= 120)
				{
					if(Var.Money >= 25)
					{
						Var.Money -= 25;
						UsedMoney = 25;
						Var.Mng.Room.Level = 2;
						Var.Mng.Room.Renderer.sprite = Var.Mng.Room.Room2;

						if(Var.AchBoolList[14] == false)
						{
							Var.AchBoolList[14] = true;
							Var.NewAchs.Add (19);
							PlayerPrefs.SetInt("Ach19", 1);
							Var.Fame += 50;

							Var.Mng.NewMember = Instantiate(Var.Mng.NewMemberPrefab) as Character;
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
					if(Var.Money >= 40)
					{
						Var.Money -= 40;
						UsedMoney = 40;
						Var.Mng.Room.Level = 3;
						Var.Mng.Room.Renderer.sprite = Var.Mng.Room.Room3;
						
						Var.AchBoolList[15] = true;
						Var.NewAchs.Add (20);
						PlayerPrefs.SetInt("Ach20", 1);
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
					if(Var.Money >= 55)
					{
						Var.Money -= 55;
						UsedMoney = 55;
						Var.Mng.Room.Level = 4;
						Var.Mng.Room.Renderer.sprite = Var.Mng.Room.Room4;
						
						Var.AchBoolList[16] = true;
						Var.NewAchs.Add (21);
						PlayerPrefs.SetInt("Ach21", 1);

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
						if(Var.Money >= 5)
						{
							Var.Money -= 5;
							UsedMoney = 5;
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
						if(Var.Money >= 7)
						{
							Var.Money -= 7;
							UsedMoney = 7;
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
						if(Var.Money >= 5)
						{
							Var.Money -= 5;
							UsedMoney = 5;
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
						if(Var.Money >= 7)
						{
							Var.Money -= 7;
							UsedMoney = 7;
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
						if(Var.Money >= 5)
						{
							Var.Money -= 5;
							UsedMoney = 5;
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
						if(Var.Money >= 7)
						{
							Var.Money -= 7;
							UsedMoney = 7;
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
						if(Var.Money >= 5)
						{
							Var.Money -= 5;
							UsedMoney = 5;
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
						if(Var.Money >= 7)
						{
							Var.Money -= 7;
							UsedMoney = 7;
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
						if(Var.Money >= 2)
						{
							Var.Money -= 2;
							UsedMoney = 2;
							Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
							Var.Mng.Bg.Level = 1;
							Var.Mng.Bg.Renderer.sprite = Var.Mng.Bg.Level1;
							/*if(Var.Mng.Room.Level > 2)
							{
								Var.Mng.Bg.transform.position = new Vector3(0, -0.4f, 0);
							}
							else
							{
								Var.Mng.Bg.transform.position = new Vector3(0, -2, 0);
							}*/
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
						if(Var.Money >= 2)
						{
							Var.Money -= 2;
							UsedMoney = 2;
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
						if(Var.Money >= 2)
						{
							Var.Money -= 2;
							UsedMoney = 2;
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
						if(Var.Money >= 8)
						{
							Var.Money -= 8;
							UsedMoney = 8;
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
						if(Var.Money >= 1)
						{
							Var.Money -= 1;
							UsedMoney = 1;
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
						if(Var.Money >= 10)
						{
							Var.Money -= 10;
							UsedMoney = 10;
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
						if(Var.Money >= 7)
						{
							Var.Money -= 7;
							UsedMoney = 7;
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
						if(Var.Money >= 7)
						{
							Var.Money -= 7;
							UsedMoney = 7;
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
						if(Var.Money >= 7)
						{
							Var.Money -= 7;
							UsedMoney = 7;
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
						if(Var.Money >= 7)
						{
							Var.Money -= 7;
							UsedMoney = 7;
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
						if(Var.Money >= 3.5f)
						{
							Var.Money -= 3.5f;
							UsedMoney = 3.5f;
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
						if(Var.Money >= 3.5f)
						{
							Var.Money -= 3.5f;
							UsedMoney = 3.5f;
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
						if(Var.Money >= 5)
						{
							Var.Money -= 5;
							UsedMoney = 5;
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
						if(Var.Money >= 7)
						{
							Var.Money -= 7;
							UsedMoney = 7;
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
						if(Var.Money >= 10)
						{
							Var.Money -= 10;
							UsedMoney = 10;
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
						if(Var.Money >= 5)
						{
							Var.Money -= 5;
							UsedMoney = 5;
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
						Var.Money -= 7;
						UsedMoney = 7;
						Var.Mng.Ck.Renderer.sprite = Var.Mng.Ck.Level2;
						Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
						Var.Mng.Ck.Level = 2;	
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
						Var.Money -= 10;
						UsedMoney = 10;
						Var.Mng.Ck.Renderer.sprite = Var.Mng.Ck.Level3;
						Notice.NoticeType = NoticeMessage.NoticeTypes.RoomUpgrade;
						Var.Mng.Ck.Level = 3;
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
		}
		if (UsedMoney != 0) 
		{
			Var.Mng.RecordMoneyChange(UsedMoney*(-1), "업그레이드");
		}

		if(Var.OnTutorial == false || OX == true)
		{
			Var.Mng.SendMessage ("SetPositionAll");
			Var.Mng.Reset.SendMessage("OnMouseDown");
			Destroy (Parent.WallIs.gameObject);
			Destroy (Parent.gameObject);
		}
	}
}
