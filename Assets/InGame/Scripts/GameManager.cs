using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public GlobalVariables Var = GlobalVariables.GetInstance ();
	
	public Character Jiwon;
	public Character Chief;
	
	public Character NewMemPf;
	public Character NewMember;
	
	public NoticeMessage NoticePrefab;
	public NoticeMessage Notice;
	
	public Wall WallPrefab;
	public Wall WallInstance;
	public Calendar CalendarInstance;
	public TutorialText TutorialPrefab;
	public TutorialText Tutorial;
	public PjTutoText PjTutoPf;
	public PjTutoText PjTuto;
	public CallMenuButton MenuButton;
	public RoomObj Wb;
	public RoomObj Cpu;
	public RoomObj Sb;
	public RoomObj Cps;
	public RoomObj Bg;
	public RoomObj Tv;
	public RoomObj Gm;
	public RoomObj Bk;
	public RoomObj Ck;
	public RoomObj Pia;
	public RoomObj Vs;
	public RoomObj Pst;
	public RoomObj Sf;
	public RoomObj Hanger;
	public RoomObj Rfr;
	public Room Room;
	public RoomObj DoorInstance;
	public RoomObj Table;
	
	public Cancel Reset;
	
	public MenuChildMenuClose UpgPupCloser;
	
	public AudioClip[] Clips;
	public AudioSource[] AudioSources;

	public AudioSource BGM;
	
	void Awake()
	{
		int Slot = PlayerPrefs.GetInt ("LoadedSlot");
		
		if(PlayerPrefs.HasKey("NewGame") == true)
		{
			Var.Mems.Clear ();
			Var.Money = 25;
			Var.Fame = 100;
			Var.Semester = 0;
			Var.PjStan = 8;
			Var.MenuActivated = true;

			if(PlayerPrefs.GetInt("PassTuto") == 1)
			{
				Var.TutorialPass = true;
			}
			else if(PlayerPrefs.GetInt("PassTuto") == 0)
			{
				Var.TutorialPass = false;
			}

			PlayerPrefs.DeleteKey("PassTuto");

			if(Var.TutorialPass == false)
			{
				Var.OnTutorial = true;
				Tutorial = Instantiate(TutorialPrefab) as TutorialText;
				WallInstance = Instantiate(WallPrefab, new Vector3(WallPrefab.transform.position.x, WallPrefab.transform.position.y, -2), Quaternion.identity) as Wall;
			}
		}
		else
		{
			Var.Year = PlayerPrefs.GetInt("Slot"+Slot+"Year");
			Var.Month = PlayerPrefs.GetInt("Slot"+Slot+"Month");
			
			if(PlayerPrefs.GetInt("Slot"+Slot+"Day") == 1)
			{
				Var.Day = "초";
			}
			else if(PlayerPrefs.GetInt("Slot"+Slot+"Day") == 2)
			{
				Var.Day = "중";
			}
			else
			{
				Var.Day = "말";
			}
			
			if(PlayerPrefs.GetInt("Slot"+Slot+"MenuActivated") == 1)
			{
				Var.MenuActivated = true;
			}
			
			Var.Money = PlayerPrefs.GetFloat("Slot"+Slot+"Money");
			Var.Fame = PlayerPrefs.GetInt("Slot"+Slot+"Fame");
			Var.Semester = PlayerPrefs.GetInt ("Slot"+Slot+"Semester");
			Var.PjStan = PlayerPrefs.GetInt("Slot"+Slot+"PjStan");
			
			Debug.Log ("Loaded Member Number is "+PlayerPrefs.GetInt("Slot"+Slot+"Members"));
			
			Var.MaleNameList.Clear();
			int MaleNameCount = 0;
			while(PlayerPrefs.HasKey("Slot"+Slot+"MaleName"+MaleNameCount) == true)
			{
				Var.MaleNameList.Add (System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(PlayerPrefs.GetString("Slot"+Slot+"MaleName"+MaleNameCount))));
				MaleNameCount += 1;
			}
			Var.FemaleNameList.Clear();
			int FemaleNameCount = 0;
			while(PlayerPrefs.HasKey("Slot"+Slot+"FemaleName"+FemaleNameCount) == true)
			{
				Var.FemaleNameList.Add (System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(PlayerPrefs.GetString("Slot"+Slot+"FemaleName"+FemaleNameCount))));
				FemaleNameCount += 1;
			}
			
			for(int i = 0; i < PlayerPrefs.GetInt("Slot"+Slot+"Members"); i++)
			{
				NewMember = Instantiate(NewMemPf, new Vector3(Random.Range(-1.5f, 1.8f), Random.Range(-0.7f, 1.2f), NewMemPf.transform.position.z), Quaternion.identity) as Character;
				NewMember.SetPosition();
				NewMember.Loaded = true;
				
				NewMember.Name = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(PlayerPrefs.GetString("Slot"+Slot+"Name"+i)));
				
				NewMember.Abilities[0] = (PlayerPrefs.GetInt("Slot"+Slot+"Plan"+i));
				NewMember.Abilities[1] = (PlayerPrefs.GetInt("Slot"+Slot+"Programming"+i));
				NewMember.Abilities[2] = (PlayerPrefs.GetInt("Slot"+Slot+"Art"+i));
				NewMember.Abilities[3] = (PlayerPrefs.GetInt("Slot"+Slot+"Sound"+i));
				NewMember.Loyalty = PlayerPrefs.GetInt("Slot"+Slot+"Loyalty"+i);
				NewMember.MemberNumber = PlayerPrefs.GetInt("Slot"+Slot+"Number"+i);

				NewMember.Violence = PlayerPrefs.GetInt("Slot"+Slot+"Violence"+i);
				NewMember.Emotion = PlayerPrefs.GetInt("Slot"+Slot+"Emotion"+i);
				NewMember.Strategy = PlayerPrefs.GetInt("Slot"+Slot+"Strategy"+i);
				NewMember.Control = PlayerPrefs.GetInt("Slot"+Slot+"Control"+i);
				NewMember.Liberty = PlayerPrefs.GetInt("Slot"+Slot+"Liberty"+i);
				NewMember.Puzzle = PlayerPrefs.GetInt("Slot"+Slot+"Puzzle"+i);
				NewMember.Simplity = PlayerPrefs.GetInt("Slot"+Slot+"Simplity"+i);
				NewMember.Story = PlayerPrefs.GetInt("Slot"+Slot+"Story"+i);

				if(PlayerPrefs.GetInt("Slot"+Slot+"Controllabel"+i) == 1)
				{
					NewMember.Controllable = true;
				}
				else
				{
					NewMember.Controllable = false;
				}
				NewMember.UnControllableDuration = PlayerPrefs.GetInt("Slot"+Slot+"UnControllableDuration"+i);
				if(PlayerPrefs.GetInt("Slot"+Slot+"DoubleBuff"+i) == 1)
				{
					NewMember.DoubleBuff = true;
				}
				else
				{
					NewMember.DoubleBuff = false;
				}
				NewMember.UnControllableDuration = PlayerPrefs.GetInt("Slot"+Slot+"UnControllableDuration"+i);

				SetPrevActs(Slot, NewMember, i);
				
				for(int j=0; j<PlayerPrefs.GetInt("Slot"+Slot+"Members"); j++)
				{
					NewMember.Relationship.Add (PlayerPrefs.GetInt("Slot"+Slot+"RelationShip"+i+"."+j));
				}
				
				if(PlayerPrefs.GetInt("Slot"+Slot+"Gender"+i) == 1)
				{
					NewMember.Gender = true;
					Var.MaleMems.Add (NewMember);
				}
				else
				{
					NewMember.Gender = false;
					Var.FemaleMems.Add (NewMember);
				}
				
				if(PlayerPrefs.GetInt("Slot"+Slot+"Special"+i) == 1)
				{
					NewMember.SetSpecMemEtc();
					NewMember.Special = true;
				}
				else
				{
					if(PlayerPrefs.GetInt("Slot"+Slot+"Gender"+i) == 1)
					{
						NewMember.Renderer.sprite = NewMember.MaleBase.sprite;
						NewMember.HairRenderer.sprite = NewMember.MaleHair1.sprite;
						NewMember.ShirtsRenderer.sprite = NewMember.MaleShirts1.sprite;
						NewMember.PantsRenderer.sprite = NewMember.MalePants1.sprite;
					}
					else
					{
						NewMember.Renderer.sprite = NewMember.FemaleBase.sprite;
						NewMember.HairRenderer.sprite = NewMember.FemaleHair1.sprite;
						NewMember.ShirtsRenderer.sprite = NewMember.FemaleShirts1.sprite;
						NewMember.PantsRenderer.sprite = NewMember.FemalePants1.sprite;
					}
					
					NewMember.HairR = PlayerPrefs.GetFloat("Slot"+Slot+"HairR"+i);
					NewMember.HairG = PlayerPrefs.GetFloat("Slot"+Slot+"HairG"+i);
					NewMember.HairB = PlayerPrefs.GetFloat("Slot"+Slot+"HairB"+i);
					NewMember.ShirtsR = PlayerPrefs.GetFloat("Slot"+Slot+"ShirtsR"+i);
					NewMember.ShirtsG = PlayerPrefs.GetFloat("Slot"+Slot+"ShirtsG"+i);
					NewMember.ShirtsB = PlayerPrefs.GetFloat("Slot"+Slot+"ShirtsB"+i);
					NewMember.PantsR = PlayerPrefs.GetFloat("Slot"+Slot+"PantsR"+i);
					NewMember.PantsG = PlayerPrefs.GetFloat("Slot"+Slot+"PantsG"+i);
					NewMember.PantsB = PlayerPrefs.GetFloat("Slot"+Slot+"PantsB"+i);
					
					NewMember.SendMessage("SetRendererColors");
				}
				
				Var.Mems.Add(NewMember);
			}
		}
	}
	
	void Start () 
	{
		AudioSources = new AudioSource[Clips.Length];
		
		int j = 0;
		
		while (j < Clips.Length)
		{
			GameObject child = new GameObject("Sound");
			
			child.transform.parent = gameObject.transform;
			
			AudioSources[j] = child.AddComponent("AudioSource") as AudioSource;
			
			AudioSources[j].clip = Clips[j];
			
			j++;	
		}
		
		if(PlayerPrefs.HasKey("NewGame") == true)
		{
			Instantiate (Jiwon);

			CreateNormMem(2);
			Var.NewMembers.Clear();
			
			for(int i=0; i<7; i++)
			{
				Var.AchTimesList.Add(0);
			}
			for(int i=0; i<24; i++)
			{
				Var.AchBoolList.Add (false);
			}
			
			Var.Mng.Wb.Renderer.sprite = Var.Mng.Wb.Level1;
			Var.Mng.Cpu.Renderer.sprite = Var.Mng.Cpu.Level1;
			Var.Mng.Sb.Renderer.sprite = Var.Mng.Sb.Level1;
			Var.Mng.Cps.Renderer.sprite = Var.Mng.Cps.Level1;
			
			PlayerPrefs.DeleteKey("NewGame");
		}
		else
		{
			SetDataLoaded();
		}
	}
	
	void SetDataLoaded()
	{
		int Slot = PlayerPrefs.GetInt ("LoadedSlot");
		
		for(int i=0; i<7; i++)
		{
			Var.AchTimesList.Add (PlayerPrefs.GetInt("Slot"+Slot+"AchTimes"+i));
		}
		for(int i=0; i<24; i++)
		{
			if(PlayerPrefs.GetInt("Slot"+Slot+"AchBool"+i) == 1)
			{
				Var.AchBoolList.Add (true);
			}
			else
			{
				Var.AchBoolList.Add (false);
			}
		}
		
		Room.Level = PlayerPrefs.GetInt ("Slot"+Slot+"RoomLV");
		if(Room.Level == 1)
		{
			Room.Renderer.sprite = Room.Room1;
		}
		else if(Room.Level == 2)
		{
			Room.Renderer.sprite = Room.Room2;
		}
		else if(Room.Level == 3)
		{
			Room.Renderer.sprite = Room.Room3;
		}
		else
		{
			Room.Renderer.sprite = Room.Room4;
		}
		
		Wb.Level = PlayerPrefs.GetInt ("Slot"+Slot+"WBLV");
		if(Wb.Level == 1)
		{
			Wb.Renderer.sprite = Wb.Level1;
		}
		else if(Wb.Level == 2)
		{
			Wb.Renderer.sprite = Wb.Level2;
		}
		else
		{
			Wb.Renderer.sprite = Wb.Level3;
		}
		
		Cpu.Level = PlayerPrefs.GetInt ("Slot"+Slot+"CPULV");
		if(Cpu.Level == 1)
		{
			Cpu.Renderer.sprite = Cpu.Level1;
		}
		else if(Cpu.Level == 2)
		{
			Cpu.Renderer.sprite = Cpu.Level2;
		}
		else
		{
			Cpu.Renderer.sprite = Cpu.Level3;
		}
		
		Sb.Level = PlayerPrefs.GetInt ("Slot"+Slot+"SBLV");
		if(Sb.Level == 1)
		{
			Sb.Renderer.sprite = Sb.Level1;
		}
		else if(Sb.Level == 2)
		{
			Sb.Renderer.sprite = Sb.Level2;
		}
		else
		{
			Sb.Renderer.sprite = Sb.Level3;
		}
		
		Cps.Level = PlayerPrefs.GetInt ("Slot"+Slot+"CpsLV");
		if(Cps.Level == 1)
		{
			Cps.Renderer.sprite = Cps.Level1;
		}
		else if(Cps.Level == 2)
		{
			Cps.Renderer.sprite = Cps.Level2;
		}
		else
		{
			Cps.Renderer.sprite = Cps.Level3;
		}
		
		Bg.Level = PlayerPrefs.GetInt ("Slot"+Slot+"BGLV");
		if(Bg.Level == 1)
		{
			Bg.Renderer.sprite = Bg.Level1;
		}
		else if(Bg.Level == 2)
		{
			Bg.Renderer.sprite = Bg.Level2;
		}
		else
		{
			Bg.Renderer.sprite = Bg.Level3;
		}
		
		Tv.Level = PlayerPrefs.GetInt ("Slot"+Slot+"TVLV");
		if(Tv.Level == 1)
		{
			Tv.Renderer.sprite = Tv.Level1;
		}
		else if(Tv.Level == 2)
		{
			Tv.Renderer.sprite = Tv.Level2;
		}
		else
		{
			Tv.Renderer.sprite = Tv.Level3;
		}
		
		Gm.Level = PlayerPrefs.GetInt ("Slot"+Slot+"GameLV");
		if(Gm.Level == 1)
		{
			Gm.Renderer.sprite = Gm.Level1;
		}
		else if(Gm.Level == 2)
		{
			Gm.Renderer.sprite = Gm.Level2;
		}
		else
		{
			Gm.Renderer.sprite = Gm.Level3;
		}
		
		Bk.Level = PlayerPrefs.GetInt ("Slot"+Slot+"BookLV");
		if(Bk.Level == 1)
		{
			Bk.Renderer.sprite = Bk.Level1;
		}
		else if(Bk.Level == 2)
		{
			Bk.Renderer.sprite = Bk.Level2;
		}
		else
		{
			Bk.Renderer.sprite = Bk.Level3;
		}
		
		Ck.Level = PlayerPrefs.GetInt ("Slot"+Slot+"CookLV");
		if(Ck.Level == 1)
		{
			Ck.Renderer.sprite = Ck.Level1;
		}
		else if(Ck.Level == 2)
		{
			Ck.Renderer.sprite = Ck.Level2;
		}
		else
		{
			Ck.Renderer.sprite = Ck.Level3;
		}
		
		Pia.Level = PlayerPrefs.GetInt ("Slot"+Slot+"PiaLV");
		if(Pia.Level == 1)
		{
			Pia.Renderer.sprite = Pia.Level1;
		}
		else if(Pia.Level == 2)
		{
			Pia.Renderer.sprite = Pia.Level2;
		}
		else
		{
			Pia.Renderer.sprite = Pia.Level3;
		}
		
		SetPositionAll ();
		
		Var.DrkCnt = PlayerPrefs.GetInt ("Slot"+Slot+"DinCnt");
		Var.MTCnt = PlayerPrefs.GetInt ("Slot"+Slot+"MTCnt");
		if(PlayerPrefs.GetInt("Slot"+Slot+"TutorialPass") == 1)
		{
			Var.TutorialPass = true;
		}
		else 
		{
			Var.TutorialPass = false;
		}
	}
	
	public void SetPositionAll()
	{
		SetPositionItems ();
		
		foreach(Character Mem in Var.Mems)
		{
			Mem.SetPosition();
		}
	}

	public void SetPositionItems()
	{
		Room.transform.position = new Vector3 (0, 0, 1);
		Wb.SendMessage ("SetPosition");
		Cpu.SendMessage ("SetPosition");
		Table.SendMessage ("SetPosition");
		Sb.SendMessage ("SetPosition");
		Cps.SendMessage ("SetPosition");
		Vs.SendMessage ("SetPosition");
		DoorInstance.SendMessage ("SetPosition");
		CalendarInstance.SendMessage ("SetPosition");
		Bg.SendMessage ("SetPosition");
		Tv.SendMessage ("SetPosition");
		Pst.SendMessage ("SetPosition");
		Sf.SendMessage ("SetPosition");
		Hanger.SendMessage ("SetPosition");
		Gm.SendMessage ("SetPosition");
		Bk.SendMessage ("SetPosition");
		Rfr.SendMessage ("SetPosition");
		Ck.SendMessage ("SetPosition");
		Pia.SendMessage ("SetPosition");
	}
	
	public void RecordMoneyChange(float MoneyChange, string Reason)
	{
		Var.MoneyMonthLog.Add (Var.Month);
		Var.MoneyDayLog.Add(Var.Day);
		Var.MoneyReasonLog.Add (Reason);
		Var.MoneyChangeLog.Add (MoneyChange);
		Var.MoneyRemainLog.Add (Var.Money);
	}

	public void CreateNormMem(int Count)
	{
		for (int i = 0; i < Count; i++)
		{
			NewMember = Instantiate(NewMemPf, new Vector3(Random.Range(-1.5f, 1.8f), Random.Range(-0.7f, 1.2f), NewMemPf.transform.position.z), Quaternion.identity) as Character;
			
			int NewMemberGender = UnityEngine.Random.Range(0, 2);
			if(NewMemberGender == 0)
			{
				NewMember.Gender = true;
			}
			else
			{
				NewMember.Gender = false;
			}

			Var.NewMembers.Add (NewMember);
		}
	}

	void SetPrevActs(int Slot, Character Mem, int i)
	{
		if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct1"+i) == 0)
		{
			Mem.PrevAct1 = Character.ActionIndex.None;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct1"+i) == 1)
		{
			Mem.PrevAct1 = Character.ActionIndex.Plan;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct1"+i) == 2)
		{
			Mem.PrevAct1 = Character.ActionIndex.Programming;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct1"+i) == 3)
		{
			Mem.PrevAct1 = Character.ActionIndex.Draw;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct1"+i) == 4)
		{
			Mem.PrevAct1 = Character.ActionIndex.Compose;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct1"+i) == 5)
		{
			Mem.PrevAct1 = Character.ActionIndex.BdGm;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct1"+i) == 6)
		{
			Mem.PrevAct1 = Character.ActionIndex.Watch;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct1"+i) == 7)
		{
			Mem.PrevAct1 = Character.ActionIndex.Game;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct1"+i) == 8)
		{
			Mem.PrevAct1 = Character.ActionIndex.Book;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct1"+i) == 9)
		{
			Mem.PrevAct1 = Character.ActionIndex.Cook;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct1"+i) == 10)
		{
			Mem.PrevAct1 = Character.ActionIndex.Piano;
		}
		
		if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct2"+i) == 0)
		{
			Mem.PrevAct2 = Character.ActionIndex.None;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct2"+i) == 1)
		{
			Mem.PrevAct2 = Character.ActionIndex.Plan;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct2"+i) == 2)
		{
			Mem.PrevAct2 = Character.ActionIndex.Programming;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct2"+i) == 3)
		{
			Mem.PrevAct2 = Character.ActionIndex.Draw;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct2"+i) == 4)
		{
			Mem.PrevAct2 = Character.ActionIndex.Compose;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct2"+i) == 5)
		{
			Mem.PrevAct2 = Character.ActionIndex.BdGm;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct2"+i) == 6)
		{
			Mem.PrevAct2 = Character.ActionIndex.Watch;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct2"+i) == 7)
		{
			Mem.PrevAct2 = Character.ActionIndex.Game;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct2"+i) == 8)
		{
			Mem.PrevAct2 = Character.ActionIndex.Book;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct2"+i) == 9)
		{
			Mem.PrevAct2 = Character.ActionIndex.Cook;
		}
		else if(PlayerPrefs.GetInt("Slot"+Slot+"PrevAct2"+i) == 10)
		{
			Mem.PrevAct2 = Character.ActionIndex.Piano;
		}
	}

	public void GetAch(int Num, int FameChange)
	{
		if(Num <= 6)
		{
			Var.AchTimesList[Num] += 1;
		}
		else
		{
			Var.AchBoolList[Num-7] = true;
		}

		Var.NewAchs.Add (Num);
		Var.Fame += FameChange;
		PlayerPrefs.SetInt("Ach"+Num, 1);
	}

	public void MakeNewSpecMem(bool NewMemGender, Character.SpecialNameIndex EnumName, string StringName)
	{
		NewMember = Instantiate (NewMemPf) as Character;
		NewMember.Special = true;
		NewMember.Gender = NewMemGender;
		NewMember.SpecialName = EnumName;
		Var.NewSpecMems.Add (StringName);
	}
}