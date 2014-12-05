using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GlobalVariables
{
	static GlobalVariables Instance;
	
	public static GlobalVariables GetInstance()
	{
		if(Instance == null)
		{
			Instance = new GlobalVariables();
		}
		return Instance;
	}
	
	public GameManager Mng;
	
	public int Year;
	public int Month; 
	public string Day;
	public float Support;
	public float Money;
	public int Fame;
	
	public int Semester;
	public int PjStan;
	
	public int DecLoyalHard = 5;
	public int DecLoyalEasy = 3;
	
	public int DrkCnt;
	public int MTCnt;
	
	public float TalentModifier = 1.3f;
	public float UnTalentModifier = 0.8f;
	
	public enum GroupActivityTypes
	{
		Picnic,
		Drink,
		Dinner,
		MT,
	}
	public GroupActivityTypes GroupActivityType;
	
	public ProjectSelectedMember.ProjectRoleTypes ProjectRoleType;
	
	public int PicnicLoyalty = 3;
	public float PicnicCost = 0.5f;
	public int DrinkLoyalty = 7;
	public float DrinkCost = 1.0f;
	public int DinnerLoyalty = 15;
	public float DinnerCost = 2.0f;
	public int MTLoyalty = 40;
	public float MTCost = 5.0f;
	
	public int Stan1st;
	public int Stan2nd;
	public int Stan3rd;
	public int Stan4th;
	public int Stan5th;
	public int Stan6th;
	
	public List <Character> Mems = new List<Character>();
	public List<Character> MaleMems = new List<Character> ();
	public List<Character> FemaleMems = new List<Character> ();
	
	public List <Character> SpecialMemsList = new List<Character>();
	
	public List <Character> LeaveMems = new List<Character>();
	public List <Character> NewFriends = new List<Character> ();
	public List <Character> NewLovers = new List<Character> ();
	public List <Character> NewMembers = new List<Character> ();
	
	public List <Character> GameMems = new List<Character>();
	public List <Character> ProgramMems = new List<Character>();
	public List <Character> BdGmMems = new List<Character>();
	public List <Character> DrawMems = new List<Character>();
	public List <Character> ComposeMems = new List<Character>();
	public List <Character> BookMems = new List<Character>();
	public List <Character> WatchMems = new List<Character>();
	public List <Character> PlanMems = new List<Character>();
	public List <Character> CookMems = new List<Character>();
	public List <Character> PiaMems = new List<Character>();
	
	public List <int> ProjectRanks = new List<int> ();
	public int ProjectHighScore;

	public List <int> AchFames = new List<int> ();
	
	public List <int> NewAchs = new List<int> ();
	public List <string> NewSpecMems = new List<string> ();
	
	public List <string> MoneyReasonLog = new List<string> ();
	public List <int> MoneyMonthLog = new List<int> ();
	public List <string> MoneyDayLog = new List<string> ();
	public List <float> MoneyChangeLog = new List<float> ();
	public List <float> MoneyRemainLog = new List<float> ();
	
	public List<string> MaleNameList = new List<string>();
	public List<string> FemaleNameList = new List<string>();
	
	public List<string> AchNameList = new List<string> ();
	public List<string> AchDescList = new List<string> ();
	public List<string> AchConditionList = new List<string> ();
	public List<bool> AchBoolList = new List<bool> ();
	public List<int> AchTimesList = new List<int> ();
	
	public bool MenuActivated = true;
	public bool MemberInfoOn = false;
	public bool OnTutorial = false;
	public bool AlreadySupport = false;
	public bool TutorialPass;
	
	public bool SprPic = false;
	public bool SumPic = false;
	public bool AutPic = false;
	public bool WinPic = false;
	
	public Character DraggingMem;
	
	public float TextSpeed = 0.05f;
}