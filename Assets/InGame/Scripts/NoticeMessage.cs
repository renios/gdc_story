﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoticeMessage : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public TextMesh Text;

	public NoticeMessage NoticePrefab;
	NoticeMessage Notice;

	public Character InfoMember;

	public Character NewMemberPrefab;
	public Character NewMember;

	public Wall ProjectWallPrefab;
	public ProjectBg ProjectBgPf;
	ProjectBg ProjectBgIs;

	public CutScene ScenePF;
	CutScene SceneIS;
	public string SceneText;

	public NewAch NewAchPF;
	NewAch NewAchIS;

	public Question QuePf;
	Question QueIs;

	int Page;

	public BoxCollider2D Collider;

	public enum NoticeTypes
	{
		None,
		Support,
		NewMember,
		PlanResult,
		ProgrammingResult,
		DrawResult,
		ComposeResult,
		BdGmResult,
		TvResult,
		GameResult,
		BookResult,
		CookResult,
		PiaResult,
		NothingResult,
		MemberLeave,
		MemberInfo,
		GroupActivity,
		NoxenProjectStart,
		ProjectResult,
		ProjectResult2,
		CutSceneText,
		NotEnoughMoney,
		NotEnoughFame,
		NotEnoughRoom,
		RoomUpgrade,
		SaveMessage,
		AlreadyGroupActivity,
	}
	public NoticeTypes NoticeType;

	void Start () 
	{
		SetMessageText ();

		if(Var.NewAchs.Count != 0 && NoticeType != NoticeTypes.ProjectResult)
		{
			NewAchIS = Instantiate(NewAchPF) as NewAch;
		}
	}

	void OnMouseDown()
	{
		if(NoticeType == NoticeTypes.Support)
		{
			QueIs = Instantiate(QuePf) as Question;
			QueIs.QuestionType = Question.QuestionTypes.ClbIntro;
		}
		else if (NoticeType == NoticeTypes.PlanResult) 
		{
			if(Var.ProgramMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.ProgrammingResult;
			}
			else if(Var.DrawMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.DrawResult;
			}
			else if(Var.ComposeMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.ComposeResult;
			}
			else if(Var.BdGmMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.BdGmResult;
			}
			else if(Var.WatchMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.TvResult;
			}
			else if(Var.GameMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.GameResult;
			}
			else if(Var.BookMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.BookResult;
			}
			else if(Var.CookMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.CookResult;
			}
			else if(Var.PiaMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.PiaResult;
			}
			else
			{
				EndActionPhase();
			}
		}
		else if (NoticeType == NoticeTypes.ProgrammingResult) 
		{
			if(Var.DrawMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.DrawResult;
			}
			else if(Var.ComposeMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.ComposeResult;
			}
			else if(Var.BdGmMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.BdGmResult;
			}
			else if(Var.WatchMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.TvResult;
			}
			else if(Var.GameMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.GameResult;
			}
			else if(Var.BookMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.BookResult;
			}
			else if(Var.CookMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.CookResult;
			}
			else if(Var.PiaMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.PiaResult;
			}
			else
			{
				EndActionPhase();
			}
		}
		else if (NoticeType == NoticeTypes.DrawResult) 
		{
			if(Var.ComposeMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.ComposeResult;
			}
			else if(Var.BdGmMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.BdGmResult;
			}
			else if(Var.WatchMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.TvResult;
			}
			else if(Var.GameMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.GameResult;
			}
			else if(Var.BookMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.BookResult;
			}
			else if(Var.CookMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.CookResult;
			}
			else if(Var.PiaMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.PiaResult;
			}
			else
			{
				EndActionPhase();
			}
		}
		else if (NoticeType == NoticeTypes.ComposeResult) 
		{
			if(Var.BdGmMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.BdGmResult;
			}
			else if(Var.WatchMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.TvResult;
			}
			else if(Var.GameMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.GameResult;
			}
			else if(Var.BookMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.BookResult;
			}
			else if(Var.CookMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.CookResult;
			}
			else if(Var.PiaMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.PiaResult;
			}
			else
			{
				EndActionPhase();
			}
		}
		else if (NoticeType == NoticeTypes.BdGmResult) 
		{
			if(Var.WatchMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.TvResult;
			}
			else if(Var.GameMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.GameResult;
			}
			else if(Var.BookMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.BookResult;
			}
			else if(Var.CookMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.CookResult;
			}
			else if(Var.PiaMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.PiaResult;
			}
			else
			{
				EndActionPhase();
			}
		}
		else if (NoticeType == NoticeTypes.TvResult) 
		{
			if(Var.GameMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.GameResult;
			}
			else if(Var.BookMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.BookResult;
			}
			else if(Var.CookMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.CookResult;
			}
			else if(Var.PiaMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.PiaResult;
			}
			else
			{
				EndActionPhase();
			}
		}
		else if (NoticeType == NoticeTypes.GameResult) 
		{
			if(Var.BookMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.BookResult;
			}
			else if(Var.CookMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.CookResult;
			}
			else if(Var.PiaMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.PiaResult;
			}
			else
			{
				EndActionPhase();
			}
		}
		else if (NoticeType == NoticeTypes.BookResult) 
		{
			if(Var.CookMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.CookResult;
			}
			else if(Var.PiaMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.PiaResult;
			}
			else
			{
				EndActionPhase();
			}
		}
		else if (NoticeType == NoticeTypes.CookResult) 
		{
			if(Var.PiaMems.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.PiaResult;
			}
			else
			{
				EndActionPhase();
			}
		}
		else if (NoticeType == NoticeTypes.PiaResult) 
		{
			EndActionPhase();
		}
		else if(NoticeType == NoticeTypes.NothingResult)
		{
			EndActionPhase();
		}
		else if(NoticeType == NoticeTypes.MemberLeave)
		{
			CheckSoloEnding();

			if(Var.Month == 7 && Var.Day == "초")
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.NoxenProjectStart;
			}
		}
		else if(NoticeType == NoticeTypes.NoxenProjectStart)
		{
			Var.Mng.WallInstance = Instantiate(ProjectWallPrefab) as Wall;

			if(Var.Year == 2014 && Var.Month == 7 && Var.TutorialPass == false)
			{
				Var.OnTutorial = true;
				Var.Mng.PjTuto = Instantiate(Var.Mng.PjTutoPf) as PjTutoText;

				ProjectBgIs = Instantiate(ProjectBgPf) as ProjectBg;
				Var.Mng.PjTuto.MakePj = ProjectBgIs.Make;
				Var.Mng.PjTuto.ResetPj = ProjectBgIs.Reset;
			}
			else
			{
				Instantiate(ProjectBgPf);
			}
		}
		else if(NoticeType == NoticeTypes.ProjectResult)
		{
			foreach(Character Member in Var.Mems)
			{
				Member.ProjectPosition = Character.ProjectPositionIndex.None;
			}

			if(Var.ProjectRanks.Count != 0)
			{
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeTypes.ProjectResult2;
			}
		}
		else if(NoticeType == NoticeTypes.MemberInfo)
		{
			Var.MemberInfoOn = false;
			if(Var.OnTutorial == true && Var.Mng.Tutorial.Page == 32)
			{
				Var.Mng.Tutorial.Page += 1;

				Var.Mng.Tutorial.Collider.enabled = false;
				GameObject.FindGameObjectWithTag("Reset").SendMessage("Blink");
			}
		}
		else if(Var.OnTutorial == true)
		{
			if(NoticeType == NoticeTypes.GroupActivity && Var.Mng.Tutorial.Page == 44)
			{
				Var.Mng.Tutorial.Page += 1;
				Var.Mng.Tutorial.SendMessage("ActivateRenderer");
				Var.Mng.Tutorial.Collider.enabled = true;
			}
			else if(NoticeType == NoticeTypes.NewMember && Var.Mng.Tutorial.Page == 46)
			{
				Var.Mng.Tutorial.Page += 1;
				Var.Mng.Tutorial.SendMessage("ActivateRenderer");
				Var.Mng.Tutorial.Collider.enabled = true;
			}
		}

		Destroy (gameObject);
	}

	//마지막 글자의 받침 유무에 따라 조사를 결정하는 코드.
	public string CheckSubjectFinalConsonant1(string Word)
	{
		char[] WordDivision = Word.ToCharArray ();
		char FinalLetter = WordDivision [WordDivision.Length-1];
		if((FinalLetter - '가')% 28 != 0)
		{
			return "은";
		}
		else
		{
			return "는";
		}
	}
	public string CheckSubjectFinalConsonant2(string Word)
	{
		char[] WordDivision = Word.ToCharArray ();
		char FinalLetter = WordDivision [WordDivision.Length - 1];
		if((FinalLetter - '가') % 28 != 0)
		{
			return "이";
		}
		else
		{
			return "가";
		}
	}
	public string CheckTogetherFinalConsonant(string Word)
	{
		char[] WordDivision = Word.ToCharArray ();
		char FinalLetter = WordDivision [WordDivision.Length - 1];
		if((FinalLetter - '가') % 28 != 0)
		{
			return "과";
		}
		else
		{
			return "와";
		}
	}
	public string CheckObjectFinalConsonant(string Word)
	{
		char[] WordDivision = Word.ToCharArray ();
		char FinalLetter = WordDivision [WordDivision.Length - 1];
		if((FinalLetter - '가') % 28 != 0)
		{
			return "을";
		}
		else
		{
			return "를";
		}
	}

	//그룹활동에서 반복되는 코드를 빼놓은 것
	string GroupResult(GlobalVariables.GroupActivityTypes Type)
	{
		if(Type == GlobalVariables.GroupActivityTypes.Picnic)
		{
			return "소풍을 갔다.";
		}
		else if(Type == GlobalVariables.GroupActivityTypes.Drink)
		{
			return "술을 마셨다.";
		}
		else if(Type == GlobalVariables.GroupActivityTypes.Dinner)
		{
			return "회식을 했다.";
		}
		else
		{
			return "엠티를 갔다.";
		}
	}

	//그룹활동 시 비용과 충성도를 불러온다
	float GroupActivityCost(GlobalVariables.GroupActivityTypes Type)
	{
		if(Type == GlobalVariables.GroupActivityTypes.Picnic)
		{
			return (float)Var.Mems.Count*Var.PicnicCost;
		}
		else if(Type == GlobalVariables.GroupActivityTypes.Drink)
		{
			return (float)Var.Mems.Count*Var.DrinkCost;
		}
		else if(Type == GlobalVariables.GroupActivityTypes.Dinner)
		{
			return (float)Var.Mems.Count*Var.DinnerCost;
		}
		else
		{
			return (float)Var.Mems.Count*Var.MTCost;
		}
	}

	int GroupActivityLoyalty(GlobalVariables.GroupActivityTypes Type)
	{
		if(Type == GlobalVariables.GroupActivityTypes.Picnic)
		{
			return Var.PicnicLoyalty;
		}
		else if(Type == GlobalVariables.GroupActivityTypes.Drink)
		{
			return Var.DrinkLoyalty;
		}
		else if(Type == GlobalVariables.GroupActivityTypes.Dinner)
		{
			return Var.DinnerLoyalty;
		}
		else
		{
			return Var.MTLoyalty;
		}
	}

	//랜덤 대사 출현 함수. 각 활동당 하나씩의 함수가 배정됨
	void AddRandomFeedbackText_Plan(Character Member)
	{
		Text.text += Member.Name+" : ";
		
		int RandomTextNumber = UnityEngine.Random.Range(1, 6);
		if(Member.Tal == Character.Talents.Plan)
		{
			if(RandomTextNumber == 1)
			{
				Text.text += "그래! 이것이 바로 죽음으로 완성되는 카타르시스!\n";
			}
			else if(RandomTextNumber == 2)
			{
				Text.text += "일단 옆집 누나를 넣음으로써 게임은 완벽해집니다.\n";
			}
			else if(RandomTextNumber == 3)
			{
				Text.text += "이 완벽한 확률이면 돈을 지르지 않고는 못 버티겠지!\n";
			}
			else if(RandomTextNumber == 4)
			{
				Text.text += "머리를 너무 썼더니 머리가 자꾸 빠지는군...\n";
			}
			else if(RandomTextNumber == 5)
			{
				Text.text += "아이디어가 고갈됐어... 그만 쉬어야지...\n";
			}
		}
		else if(Member.UnTal == Character.Talents.Plan)
		{
			if(RandomTextNumber == 1)
			{
				Text.text += "뭔가 빨간 모자를 쓴 배관공이 나오는 게임을 만들고 싶어!\n";
			}
			else if(RandomTextNumber == 2)
			{
				Text.text += "분홍 찐빵이 적들을 모두 삼켜버리는 게임은 어떨까?\n";
			}
			else if(RandomTextNumber == 3)
			{
				Text.text += "파란 고슴도치가 음속으로 달리는 게임, 획기적이지?\n";
			}
			else if(RandomTextNumber == 4)
			{
				Text.text += "치타 인간이 악의 과학자를 물리치는 게임을 만들자!\n";
			}
			else if(RandomTextNumber == 5)
			{
				Text.text += "광속으로 달릴 수 있는 트럭 시뮬레이션 게임! 대작의 냄새가 나는군!\n";
			}
		}
		else
		{
			if(RandomTextNumber == 1)
			{
				Text.text += "어떻게 하면 최소한의 리소스로 최대한의 재미를 얻을 수 있을까?\n";
			}
			else if(RandomTextNumber == 2)
			{
				Text.text += "가격을 더 낮추고 적들을 더 강하게 만들면 밸런스가 맞춰지겠지?\n";
			}
			else if(RandomTextNumber == 3)
			{
				Text.text += "장르를 이것저것 섞어서 새로운 장르를 만들어 볼까.\n";
			}
			else if(RandomTextNumber == 4)
			{
				Text.text += "기존의 게임들이 인기 있는 이유가 바로 이것이군!\n";
			}
			else if(RandomTextNumber == 5)
			{
				Text.text += "내 게임은 왜 이렇게 재미가 없을까...\n";
			}
		}
	}

	void AddRandomFeedbackText_Programming(Character Member)
	{
		Text.text += Member.Name+" : ";
		
		int RandomTextNumber = UnityEngine.Random.Range(1, 6);
		if(Member.Tal == Character.Talents.Programming)
		{
			if(RandomTextNumber == 1)
			{
				Text.text += "흠, 코딩이란 거 재밌군.\n";
			}
			else if(RandomTextNumber == 2)
			{
				Text.text += "내가 설계한 대로 프로그램이 작동하다니, 멋진데!\n";
			}
			else if(RandomTextNumber == 3)
			{
				Text.text += "......(키보드 소리만 들려온다. 불타오르고 있다)\n";
			}
			else if(RandomTextNumber == 4)
			{
				Text.text += "그냥 알고리즘만 떠올리면 되는 문제로군.\n";
			}
			else if(RandomTextNumber == 5)
			{
				Text.text += "이제 코딩하면서 좀 쉬어야지~\n";
			}
		}
		else if(Member.UnTal == Character.Talents.Programming)
		{
			if(RandomTextNumber == 1)
			{
				Text.text += "대소문자 때문에 코드가 안 돌아가다니, 암 걸린다...\n";
			}
			else if(RandomTextNumber == 2)
			{
				Text.text += "왜 에러가 나는 건지 도저히 모르겠어!\n";
			}
			else if(RandomTextNumber == 3)
			{
				Text.text += "아무리 해도 실력이 안 느는 것 같아...\n";
			}
			else if(RandomTextNumber == 4)
			{
				Text.text += "Zzz...\n";
			}
			else if(RandomTextNumber == 5)
			{
				Text.text += "경험삼아 해 봤지만 그다지 재미없는 걸.\n";
			}
		}
		else
		{
			if(RandomTextNumber == 1)
			{
				Text.text += "오오, 그냥 따라하니까 되네. 신기하다.\n";
			}
			else if(RandomTextNumber == 2)
			{
				Text.text += "끙... 머리가 아프지만 그럭저럭 할 만은 하네.\n";
			}
			else if(RandomTextNumber == 3)
			{
				Text.text += "유니티쨩 귀엽다.\n";
			}
			else if(RandomTextNumber == 4)
			{
				Text.text += "이렇게 선언하고 저렇게 명령하면... 되려나?\n";
			}
			else if(RandomTextNumber == 5)
			{
				Text.text += "후... 해결하고 나니 단순한 실수였다니, 허탈해.\n";
			}
		}
	}

	void AddRandomFeedbackText_Draw(Character Member)
	{
		Text.text += Member.Name+" : ";
		
		int RandomTextNumber = UnityEngine.Random.Range(1, 6);
		if(Member.Tal == Character.Talents.Art)
		{
			if(RandomTextNumber == 1)
			{
				Text.text += "나는 그냥 붓을 가져다 댔을 뿐인데 작품이 완성되었네?\n";
			}
			else if(RandomTextNumber == 2)
			{
				Text.text += "내 작품 전시회라도 열지 않으면 안 되겠어.\n";
			}
			else if(RandomTextNumber == 3)
			{
				Text.text += "이 정도라면 바하무트에서 외주를 줄 것 같아.\n";
			}
			else if(RandomTextNumber == 4)
			{
				Text.text += "그림이 없다면 내 인생은 없는 것과 같아.\n";
			}
			else if(RandomTextNumber == 5)
			{
				Text.text += "나는 내 그림에 만족할 수 없어!\n";
			}
		}
		else if(Member.UnTal == Character.Talents.Art)
		{
			if(RandomTextNumber == 1)
			{
				Text.text += "인체는 어떻게 그려야 하는 거야?\n";
			}
			else if(RandomTextNumber == 2)
			{
				Text.text += "왼쪽 옆얼굴 말고는 그리는 법을 몰라...\n";
			}
			else if(RandomTextNumber == 3)
			{
				Text.text += "앗! 물통을 엎질렀다!\n";
			}
			else if(RandomTextNumber == 4)
			{
				Text.text += "찢어버리고 싶다.\n";
			}
			else if(RandomTextNumber == 5)
			{
				Text.text += "내가 그린 건 추상화야. 절대 그림을 망친 게 아니라구!\n";
			}
		}
		else
		{
			if(RandomTextNumber == 1)
			{
				Text.text += "깊이감 있는 그림을 그리기 위해 진한 색을 써보자.\n";
			}
			else if(RandomTextNumber == 2)
			{
				Text.text += "색조가 너무 탁한 느낌이 들어. 고쳐야겠어.\n";
			}
			else if(RandomTextNumber == 3)
			{
				Text.text += "이 그림에는 파스텔같은 느낌이 나게 가볍게 터치를 해야겠어.\n";
			}
			else if(RandomTextNumber == 4)
			{
				Text.text += "조금만 더 하면 뭔가 알 것도 같은데.\n";
			}
			else if(RandomTextNumber == 5)
			{
				Text.text += "기본기를 탄탄하게 익혀두면 더 좋아질 것 같아.\n";
			}
		}
	}

	void AddRandomFeedbackText_Compose(Character Member)
	{
		Text.text += Member.Name+" : ";
		
		int RandomTextNumber = UnityEngine.Random.Range(1, 6);
		if(Member.Tal == Character.Talents.Sound)
		{
			if(RandomTextNumber == 1)
			{
				Text.text += "음악의 신 뮤즈가 내게 강림했다!\n";
			}
			else if(RandomTextNumber == 2)
			{
				Text.text += "요한 제바스티안 바흐도 울고 갈 일렉트로니카가 완성되었군.\n";
			}
			else if(RandomTextNumber == 3)
			{
				Text.text += "내 노래를 들어!\n";
			}
			else if(RandomTextNumber == 4)
			{
				Text.text += "요동친다 하트! 불타버릴만큼 히트! 새긴다 혈액의 비트!\n";
			}
			else if(RandomTextNumber == 5)
			{
				Text.text += "OST만 따로 팔아도 되겠는걸?\n";
			}
		}
		else if(Member.UnTal == Character.Talents.Sound)
		{
			if(RandomTextNumber == 1)
			{
				Text.text += "떴다↗ 떴다↗ 비행기↘ 날아라↗ 날아라↑\n";
			}
			else if(RandomTextNumber == 2)
			{
				Text.text += "......(4분 33초)\n";
			}
			else if(RandomTextNumber == 3)
			{
				Text.text += "크큭… 콩나물이 보인다!\n";
			}
			else if(RandomTextNumber == 4)
			{
				Text.text += "일단은 8bit부터 차근차근...\n";
			}
			else if(RandomTextNumber == 5)
			{
				Text.text += "무료 음원 사이트를 이용해야겠다...\n";
			}
		}
		else
		{
			if(RandomTextNumber == 1)
			{
				Text.text += "음계에 대해 배우니 마치 모차르트가 된 기분이군!\n";
			}
			else if(RandomTextNumber == 2)
			{
				Text.text += "훌륭한 노래가 만들어졌다, 역시 국산 보컬로이드야.\n";
			}
			else if(RandomTextNumber == 3)
			{
				Text.text += "영상과 음악이 딱 맞아떨어지게 편집됐어!\n";
			}
			else if(RandomTextNumber == 4)
			{
				Text.text += "이런 게임에는 오케스트라가 어울리려나.\n";
			}
			else if(RandomTextNumber == 5)
			{
				Text.text += "여기에 드럼이 빠질 수 없지!\n";
			}
		}
	}

	void AddRandomFeedbackText_BdGm(Character Member)
	{
		Text.text += Member.Name+" : ";
		
		int RanTextNum = UnityEngine.Random.Range(1, 6);
		if(RanTextNum == 1)
		{
			Text.text += "밤이 되었습니다. 늑대인간은 눈을 떠주세요.\n";
		}
		else if(RanTextNum == 2)
		{
			Text.text += "일단 보안관부터 죽이고 시작합시다.\n";
		}
		else if(RanTextNum == 3)
		{
			Text.text += "알았다! 범인은 거실에서 숟가락으로 죽였어!\n";
		}
		else if(RanTextNum == 4)
		{
			Text.text += "금화 여섯 개를 지불하고 드래곤 게이트를 건설한다!\n";
		}
		else if(RanTextNum == 5)
		{
			Text.text += "UNO!\n";
		}
	}

	void AddRandomFeedbackText_Cook(Character Member)
	{
		Text.text += Member.Name+" : ";
		
		int RanTextNum = UnityEngine.Random.Range(1, 6);
		if(RanTextNum == 1)
		{
			Text.text += "배고픈데 저녁이나 만들어먹을까.\n";
		}
		else if(RanTextNum == 2)
		{
			Text.text += "오늘은 내가 짜파게티 요리사!\n";
		}
		else if(RanTextNum == 3)
		{
			Text.text += "美味!\n";
		}
		else if(RanTextNum == 4)
		{
			Text.text += "이런, 다 타버렸네... 그냥 먹자.\n";
		}
		else if(RanTextNum == 5)
		{
			Text.text += "이 요리, 제가 한 번 먹어보겠습니다.\n";
		}
	}

	void AddRandomFeedbackText_TV(Character Member)
	{
		Text.text += Member.Name+" : ";
		
		int RanTextNum = UnityEngine.Random.Range(1, 6);
		if(RanTextNum == 1)
		{
			Text.text += "그래, 교육 방송은 역시 EBS지.\n";
		}
		else if(RanTextNum == 2)
		{
			Text.text += "사랑과 전쟁을 보니 약농도가 상승한다.\n";
		}
		else if(RanTextNum == 3)
		{
			Text.text += "무한~ 도전~!\n";
		}
		else if(RanTextNum == 4)
		{
			Text.text += "셜록을 TV에서 해주다니... KBS 상냥해...\n";
		}
		else if(RanTextNum == 5)
		{
			Text.text += "오오 역시 페이커! 저걸 이기다니?!\n";
		}
	}

	void AddRandomFeedbackText_Piano(Character Member)
	{
		Text.text += Member.Name+" : ";
		
		int RanTextNum = UnityEngine.Random.Range(1, 6);
		if(RanTextNum == 1)
		{
			Text.text += "게임 개발 동아리인데 악기가 있다니 참 좋네.\n";
		}
		else if(RanTextNum == 2)
		{
			Text.text += "열정을 쏟은 연주는 내가 생각해도 훌륭했다.\n";
		}
		else if(RanTextNum == 3)
		{
			Text.text += "좋아하는 게임의 OST를 연주하니 즐겁군.\n";
		}
		else if(RanTextNum == 4)
		{
			Text.text += "...(새로운 곡을 더듬더듬 치고 있다)\n";
		}
		else if(RanTextNum == 5)
		{
			Text.text += "음, 나도 악기 좀 잘 다뤄보고 싶다.\n";
		}
	}

	void AddRandomFeedbackText_Book(Character Member)
	{
		Text.text += Member.Name+" : ";
		
		int RanTextNum = UnityEngine.Random.Range(1, 6);
		if(RanTextNum == 1)
		{
			Text.text += "전문서적을 읽고 있으면 있어 보이겠지?\n";
		}
		else if(RanTextNum == 2)
		{
			Text.text += "송시열을 모티브로 한 라이트노벨이 나온다고?\n";
		}
		else if(RanTextNum == 3)
		{
			Text.text += "추리소설이라면 역시 <그리고 아무도 없었다>지.\n";
		}
		else if(RanTextNum == 4)
		{
			Text.text += "만연체는 멋지긴 하지만 읽기는 힘들잖아.\n";
		}
		else if(RanTextNum == 5)
		{
			Text.text += "너무 두꺼운 책이라 흉기로 써도 될 것 같다.\n";
		}
	}

	public void EndActionPhase()
	{
		if(Var.NewFriends.Count > 1)
		{
			SceneIS = Instantiate(ScenePF) as CutScene;
			SceneIS.SceneType = CutScene.SceneTypes.NewFriend;
		}
		else if(Var.NewLovers.Count > 1)
		{
			SceneIS = Instantiate(ScenePF) as CutScene;
			SceneIS.SceneType = CutScene.SceneTypes.NewLover;
		}
		else
		{
			foreach(Character Member in Var.Mems)
			{
				if(Member.Loyalty < 0)
				{
					Var.LeaveMems.Add (Member);
				}
			}
			if(Var.LeaveMems.Count != 0)
			{
				SceneIS = Instantiate(ScenePF) as CutScene;
				SceneIS.SceneType = CutScene.SceneTypes.Drop;
			}
			else if(Var.Day == "초")
			{
				if(Var.Month == 1 || Var.Month == 7)
				{
					Notice = Instantiate(NoticePrefab) as NoticeMessage;
					Notice.NoticeType = NoticeTypes.NoxenProjectStart;
				}
				else if(Var.Month == 9 || Var.Month == 3)
				{
					Notice = Instantiate(NoticePrefab) as NoticeMessage;
					Notice.NoticeType = NoticeTypes.Support;
				}
				else if(Var.Month == 6 || Var.Month == 12)
				{
					SceneIS = Instantiate(ScenePF) as CutScene;
					SceneIS.SceneType = CutScene.SceneTypes.Exam;
				}
			}
			else if(Var.Day == "중")
			{
				if(Var.Month == 2)
				{
					SceneIS = Instantiate(ScenePF) as CutScene;
					SceneIS.SceneType = CutScene.SceneTypes.Valentine;
				}
				else if(Var.Month == 5)
				{
					SceneIS = Instantiate(ScenePF) as CutScene;
					SceneIS.SceneType = CutScene.SceneTypes.Festival;
				}
				else if(Var.Month == 9)
				{
					SceneIS = Instantiate(ScenePF) as CutScene;
					SceneIS.SceneType = CutScene.SceneTypes.BoardGameJam;
				}
			}
			else if(Var.Day == "말")
			{
				if(Var.Month == 12)
				{
					SceneIS = Instantiate(ScenePF) as CutScene;
					SceneIS.SceneType = CutScene.SceneTypes.Christmas;
				}
				else if(Var.Month == 11)
				{
					SceneIS = Instantiate(ScenePF) as CutScene;
					SceneIS.SceneType = CutScene.SceneTypes.GStar;
				}
			}
		}

		Var.AlreadySupport = false;
		CheckAchs ();

		if(Var.Year == 2018 && Var.Month == 3 && Var.Day == "초")
		{
			if(Var.Fame >= 800 && Var.Mems.Count >= 8)
			{
				Application.LoadLevel("BestEnding");
			}
			else if(Var.Fame <= 150 || Var.Mems.Count <= 4)
			{
				Application.LoadLevel("BadEnding");
			}
			else
			{
				Application.LoadLevel("NormalEnding");
			}
		}
	}

	void CheckAchs()
	{
		if(Var.AchBoolList[6] == false)
		{
			int CpMem = 0;
			foreach(Character Mem in Var.Mems)
			{
				if(Mem.Lovers.Count != 0)
				{
					CpMem += 1;
				}
			}

			if(CpMem >= 8)
			{
				Var.AchBoolList[6] = true;
				Var.Fame += 50;
				Var.NewAchs.Add (11);
				PlayerPrefs.SetInt("Ach11", 1);

				Var.Mng.NewMember = Instantiate(Var.Mng.NewMemberPrefab, new Vector3(0, 0, -2-(Var.Mems.Count*0.02f)), Quaternion.identity) as Character;
				Var.Mng.NewMember.Special = true;
				Var.Mng.NewMember.Gender = true;
				Var.Mng.NewMember.SpecialName = Character.SpecialNameIndex.오레오;
				Var.NewSpecMems.Add ("오레오");
			}
		}
		if(Var.AchBoolList[7] == false)
		{
			bool Clr = true;
			foreach(Character Mem in Var.Mems)
			{
				if(Mem.Friends.Count < 2)
				{
					Clr = false;
				}
			}

			if(Clr == true)
			{
				Var.AchBoolList[7] = true;
				Var.NewAchs.Add (12);
				PlayerPrefs.SetInt("Ach12", 1);
				Var.Fame += 30;
			}
		}
		if(Var.AchBoolList[8] == false)
		{
			if(Var.Mems.Count >= 10)
			{
				bool Clr = true;
				foreach(Character Mem in Var.Mems)
				{
					if(Mem.Lovers.Count != 0)
					{
						Clr = false;
					}
				}

				if(Clr == true)
				{
					Var.AchBoolList[8] = true;
					Var.NewAchs.Add (13);
					PlayerPrefs.SetInt("Ach13", 1);
					Var.Fame += 70;
				}
			}
		}

		if(Var.NewAchs.Count != 0)
		{
			NewAchIS = Instantiate(NewAchPF) as NewAch;
		}
	}

	void CheckSoloEnding()
	{
		if(Var.Mems.Count == 1)
		{
			Application.LoadLevel("SoloEnding");
		}
	}

	string PjResultMessage(int Order)
	{
		if(Var.ProjectRanks[Order-1] < 4)
		{
			return Order + "번째 프로젝트는 " + Var.ProjectRanks [Order - 1] + "등을 했다!\n";
		}
		else
		{
			return Order + "번째 프로젝트는 " + Var.ProjectRanks [Order - 1] + "등을 했다...\n";
		}
	}

	void SetMessageText()
	{
		if(NoticeType == NoticeTypes.Support)
		{
			Var.Money += Var.Support;
			Var.AlreadySupport = true;
			
			Var.MoneyReasonLog.Add("지원금");
			Var.MoneyMonthLog.Add (Var.Month);
			Var.MoneyDayLog.Add (Var.Day);
			Var.MoneyChangeLog.Add (Var.Support);
			Var.MoneyRemainLog.Add (Var.Money);
			
			Text.text = "새로운 학기가 시작되었다.\n\n동아리에 "+Var.Support+"만원의 지원금이 들어왔다.";
		}
		else if(NoticeType == NoticeTypes.NewMember)
		{
			if(Var.NewMembers.Count != 0)
			{
				Text.text = "\n";
				for(int i = 0; i < Var.NewMembers.Count; i++)
				{
					Text.text += "신입 "+Var.NewMembers[i].Name+CheckSubjectFinalConsonant2(Var.NewMembers[i].Name)+" 가입했다!\n";
				}
			}
			else
			{
				Text.text = "새로 가입한 회원이 없다...";
			}

			Var.NewMembers.Clear();
		}
		else if(NoticeType == NoticeTypes.PlanResult)
		{
			Text.text = "\n";
			if(Var.PlanMems.Count == 1)
			{
				Text.text += Var.PlanMems[0].Name+CheckSubjectFinalConsonant1(Var.PlanMems[0].Name)+" 혼자 기획을 했다.\n";
			}
			else if(Var.PlanMems.Count == 2)
			{
				Text.text += Var.PlanMems[0].Name+CheckSubjectFinalConsonant1(Var.PlanMems[0].Name)+" "+Var.PlanMems[1].Name;
				Text.text += CheckTogetherFinalConsonant(Var.PlanMems[1].Name)+" 함께 기획을 했다.\n";
				Var.PlanMems[0].Relationship[Var.PlanMems[1].MemberNumber] += 5;
				Var.PlanMems[1].Relationship[Var.PlanMems[0].MemberNumber] += 5;
				
				if(Var.PlanMems[0].Relationship[Var.PlanMems[1].MemberNumber] == 20)
				{
					Var.NewFriends.Add (Var.PlanMems[0]);
					Var.NewFriends.Add (Var.PlanMems[1]);
					Var.PlanMems[0].Friends.Add (Var.PlanMems[1]);
					Var.PlanMems[1].Friends.Add (Var.PlanMems[0]);
				}
				else if(Var.PlanMems[0].Relationship[Var.PlanMems[1].MemberNumber] == 70)
				{
					Var.NewLovers.Add (Var.PlanMems[0]);
					Var.NewLovers.Add (Var.PlanMems[1]);
					Var.PlanMems[0].Lovers.Add (Var.PlanMems[1]);
					Var.PlanMems[1].Lovers.Add (Var.PlanMems[0]);
					
					if(Var.AchBoolList[9] == false)
					{
						if(Var.PlanMems[0].Lovers.Count == 2 || Var.PlanMems[1].Lovers.Count == 2)
						{
							Var.AchBoolList[9] = true;
							Var.NewAchs.Add (14);
							PlayerPrefs.SetInt("Ach14", 1);

							Var.Fame -= 20;
						}
					}
					if(Var.AchBoolList[10] == false)
					{
						if(Var.PlanMems[0].Gender == Var.PlanMems[1].Gender)
						{
							Var.AchBoolList[10] = true;
							Var.NewAchs.Add (15);
							PlayerPrefs.SetInt("Ach15", 1);
							Var.Fame += 30;
						}
					}
				}
			}
			foreach(Character PlanMember in Var.PlanMems)
			{
				AddRandomFeedbackText_Plan(PlanMember);
			}
		}
		else if(NoticeType == NoticeTypes.ProgrammingResult)
		{
			Text.text = "\n";
			if(Var.ProgramMems.Count == 1)
			{
				Text.text += Var.ProgramMems[0].Name+CheckSubjectFinalConsonant1(Var.ProgramMems[0].Name)+" 혼자 프로그래밍 공부를 하였다.\n";
			}
			else if(Var.ProgramMems.Count == 2)
			{
				Text.text += Var.ProgramMems[0].Name+CheckSubjectFinalConsonant1(Var.ProgramMems[0].Name)+" "+Var.ProgramMems[1].Name;
				Text.text += CheckTogetherFinalConsonant(Var.ProgramMems[1].Name)+" 함께 프로그래밍 공부를 하였다.\n";
				Var.ProgramMems[0].Relationship[Var.ProgramMems[1].MemberNumber] += 5;
				Var.ProgramMems[1].Relationship[Var.ProgramMems[0].MemberNumber] += 5;
				
				if(Var.ProgramMems[0].Relationship[Var.ProgramMems[1].MemberNumber] == 20)
				{
					Var.NewFriends.Add (Var.ProgramMems[0]);
					Var.NewFriends.Add (Var.ProgramMems[1]);
					Var.ProgramMems[0].Friends.Add (Var.ProgramMems[1]);
					Var.ProgramMems[1].Friends.Add (Var.ProgramMems[0]);
				}
				else if(Var.ProgramMems[0].Relationship[Var.ProgramMems[1].MemberNumber] == 70)
				{
					Var.NewLovers.Add (Var.ProgramMems[0]);
					Var.NewLovers.Add (Var.ProgramMems[1]);
					Var.ProgramMems[0].Lovers.Add (Var.ProgramMems[1]);
					Var.ProgramMems[1].Lovers.Add (Var.ProgramMems[0]);
					
					if(Var.AchBoolList[9] == false)
					{
						if(Var.ProgramMems[0].Lovers.Count == 2 || Var.ProgramMems[1].Lovers.Count == 2)
						{
							Var.AchBoolList[9] = true;
							Var.NewAchs.Add (14);
							PlayerPrefs.SetInt("Ach14", 1);
							Var.Fame -= 20;
						}
					}
					if(Var.AchBoolList[10] == false)
					{
						if(Var.ProgramMems[0].Gender == Var.ProgramMems[1].Gender)
						{
							Var.AchBoolList[10] = true;
							Var.NewAchs.Add (15);
							PlayerPrefs.SetInt("Ach15", 1);
							Var.Fame += 30;
						}
					}
				}
			}
			foreach(Character ProgrammingMember in Var.ProgramMems)
			{
				AddRandomFeedbackText_Programming(ProgrammingMember);
			}
		}
		else if(NoticeType == NoticeTypes.DrawResult)
		{
			Text.text = "\n";
			if(Var.DrawMems.Count == 1)
			{
				Text.text += Var.DrawMems[0].Name+CheckSubjectFinalConsonant1(Var.DrawMems[0].Name)+" 혼자 그림을 그렸다.\n";
			}
			else if(Var.DrawMems.Count == 2)
			{
				Text.text += Var.DrawMems[0].Name+CheckSubjectFinalConsonant1(Var.DrawMems[0].Name)+" "+Var.DrawMems[1].Name;
				Text.text += CheckTogetherFinalConsonant(Var.DrawMems[1].Name)+" 함께 그림을 그렸다.\n";
				Var.DrawMems[0].Relationship[Var.DrawMems[1].MemberNumber] += 5;
				Var.DrawMems[1].Relationship[Var.DrawMems[0].MemberNumber] += 5;
				
				if(Var.DrawMems[0].Relationship[Var.DrawMems[1].MemberNumber] == 20)
				{
					Var.NewFriends.Add (Var.DrawMems[0]);
					Var.NewFriends.Add (Var.DrawMems[1]);
					Var.DrawMems[0].Friends.Add (Var.DrawMems[1]);
					Var.DrawMems[1].Friends.Add (Var.DrawMems[0]);
				}
				else if(Var.DrawMems[0].Relationship[Var.DrawMems[1].MemberNumber] == 70)
				{
					Var.NewLovers.Add (Var.DrawMems[0]);
					Var.NewLovers.Add (Var.DrawMems[1]);
					Var.DrawMems[0].Lovers.Add (Var.DrawMems[1]);
					Var.DrawMems[1].Lovers.Add (Var.DrawMems[0]);
					
					if(Var.AchBoolList[9] == false)
					{
						if(Var.DrawMems[0].Lovers.Count == 2 || Var.DrawMems[1].Lovers.Count == 2)
						{
							Var.AchBoolList[9] = true;
							Var.NewAchs.Add (14);
							PlayerPrefs.SetInt("Ach14", 1);
							Var.Fame -= 20;
						}
					}
					if(Var.AchBoolList[10] == false)
					{
						if(Var.DrawMems[0].Gender == Var.DrawMems[1].Gender)
						{
							Var.AchBoolList[10] = true;
							Var.NewAchs.Add (15);
							PlayerPrefs.SetInt("Ach15", 1);
							Var.Fame += 30;
						}
					}
				}
			}
			foreach(Character DrawMember in Var.DrawMems)
			{
				AddRandomFeedbackText_Draw(DrawMember);
			}	
		}
		else if(NoticeType == NoticeTypes.ComposeResult)
		{
			Text.text = "\n";
			if(Var.ComposeMems.Count == 1)
			{
				Text.text += Var.ComposeMems[0].Name+CheckSubjectFinalConsonant1(Var.ComposeMems[0].Name)+" 혼자 작곡을 했다.\n";
			}
			else if(Var.ComposeMems.Count == 2)
			{
				Text.text += Var.ComposeMems[0].Name+CheckSubjectFinalConsonant1(Var.ComposeMems[0].Name)+" "+Var.ComposeMems[1].Name;
				Text.text += CheckTogetherFinalConsonant(Var.ComposeMems[1].Name)+" 함께 작곡을 했다.\n";
				Var.ComposeMems[0].Relationship[Var.ComposeMems[1].MemberNumber] += 5;
				Var.ComposeMems[1].Relationship[Var.ComposeMems[0].MemberNumber] += 5;
				
				if(Var.ComposeMems[0].Relationship[Var.ComposeMems[1].MemberNumber] == 20)
				{
					Var.NewFriends.Add (Var.ComposeMems[0]);
					Var.NewFriends.Add (Var.ComposeMems[1]);
					Var.ComposeMems[0].Friends.Add (Var.ComposeMems[1]);
					Var.ComposeMems[1].Friends.Add (Var.ComposeMems[0]);
				}
				else if(Var.ComposeMems[0].Relationship[Var.ComposeMems[1].MemberNumber] == 70)
				{
					Var.NewLovers.Add (Var.ComposeMems[0]);
					Var.NewLovers.Add (Var.ComposeMems[1]);
					Var.ComposeMems[0].Lovers.Add (Var.ComposeMems[1]);
					Var.ComposeMems[1].Lovers.Add (Var.ComposeMems[0]);
					
					if(Var.AchBoolList[9] == false)
					{
						if(Var.ComposeMems[0].Lovers.Count == 2 || Var.ComposeMems[1].Lovers.Count == 2)
						{
							Var.AchBoolList[9] = true;
							Var.NewAchs.Add (14);
							PlayerPrefs.SetInt("Ach14", 1);
							Var.Fame -= 20;
						}
					}
					if(Var.AchBoolList[10] == false)
					{
						if(Var.ComposeMems[0].Gender == Var.ComposeMems[1].Gender)
						{
							Var.AchBoolList[10] = true;
							Var.NewAchs.Add (15);
							PlayerPrefs.SetInt("Ach15", 1);
							Var.Fame += 30;
						}
					}
				}
			}
			foreach(Character ComposeMember in Var.ComposeMems)
			{
				AddRandomFeedbackText_Compose(ComposeMember);
			}
		}
		else if(NoticeType == NoticeTypes.BdGmResult)
		{
			Text.text = "\n";
			if(Var.BdGmMems.Count == 1)
			{
				Text.text += Var.BdGmMems[0].Name+CheckSubjectFinalConsonant1(Var.BdGmMems[0].Name)+" 혼자 보드게임을 했다.\n";
			}
			else if(Var.BdGmMems.Count == 2)
			{
				Text.text += Var.BdGmMems[0].Name+CheckSubjectFinalConsonant1(Var.BdGmMems[0].Name)+" "+Var.BdGmMems[1].Name;
				Text.text += CheckTogetherFinalConsonant(Var.BdGmMems[1].Name)+" 함께 보드게임을 했다.\n";
				Var.BdGmMems[0].Relationship[Var.BdGmMems[1].MemberNumber] += 5;
				Var.BdGmMems[1].Relationship[Var.BdGmMems[0].MemberNumber] += 5;
				
				if(Var.BdGmMems[0].Relationship[Var.BdGmMems[1].MemberNumber] == 20)
				{
					Var.NewFriends.Add (Var.BdGmMems[0]);
					Var.NewFriends.Add (Var.BdGmMems[1]);
					Var.BdGmMems[0].Friends.Add (Var.BdGmMems[1]);
					Var.BdGmMems[1].Friends.Add (Var.BdGmMems[0]);
				}
				else if(Var.BdGmMems[0].Relationship[Var.BdGmMems[1].MemberNumber] == 70)
				{
					Var.NewLovers.Add (Var.BdGmMems[0]);
					Var.NewLovers.Add (Var.BdGmMems[1]);
					Var.BdGmMems[0].Lovers.Add (Var.BdGmMems[1]);
					Var.BdGmMems[1].Lovers.Add (Var.BdGmMems[0]);
					
					if(Var.AchBoolList[9] == false)
					{
						if(Var.BdGmMems[0].Lovers.Count == 2 || Var.BdGmMems[1].Lovers.Count == 2)
						{
							Var.AchBoolList[9] = true;
							Var.NewAchs.Add (14);
							PlayerPrefs.SetInt("Ach14", 1);
							Var.Fame -= 20;
						}
					}
					if(Var.AchBoolList[10] == false)
					{
						if(Var.BdGmMems[0].Gender == Var.BdGmMems[1].Gender)
						{
							Var.AchBoolList[10] = true;
							Var.NewAchs.Add (15);
							PlayerPrefs.SetInt("Ach15", 1);
							Var.Fame += 30;
						}
					}
				}
			}
			foreach(Character BdGmMem in Var.BdGmMems)
			{
				AddRandomFeedbackText_BdGm(BdGmMem);
			}
		}
		else if(NoticeType == NoticeTypes.TvResult)
		{
			Text.text = "\n";
			if(Var.WatchMems.Count == 1)
			{
				Text.text += Var.WatchMems[0].Name+CheckSubjectFinalConsonant1(Var.WatchMems[0].Name)+" 혼자 TV를 봤다.\n";
			}
			else if(Var.WatchMems.Count == 2)
			{
				Text.text += Var.WatchMems[0].Name+CheckSubjectFinalConsonant1(Var.WatchMems[0].Name)+" "+Var.WatchMems[1].Name;
				Text.text += CheckTogetherFinalConsonant(Var.WatchMems[1].Name)+" 함께 TV를 봤다.\n";
				Var.WatchMems[0].Relationship[Var.WatchMems[1].MemberNumber] += 5;
				Var.WatchMems[1].Relationship[Var.WatchMems[0].MemberNumber] += 5;
				
				if(Var.WatchMems[0].Relationship[Var.WatchMems[1].MemberNumber] == 20)
				{
					Var.NewFriends.Add (Var.WatchMems[0]);
					Var.NewFriends.Add (Var.WatchMems[1]);
					Var.WatchMems[0].Friends.Add (Var.WatchMems[1]);
					Var.WatchMems[1].Friends.Add (Var.WatchMems[0]);
				}
				else if(Var.WatchMems[0].Relationship[Var.WatchMems[1].MemberNumber] == 70)
				{
					Var.NewLovers.Add (Var.WatchMems[0]);
					Var.NewLovers.Add (Var.WatchMems[1]);
					Var.WatchMems[0].Lovers.Add (Var.WatchMems[1]);
					Var.WatchMems[1].Lovers.Add (Var.WatchMems[0]);
					
					if(Var.AchBoolList[9] == false)
					{
						if(Var.WatchMems[0].Lovers.Count == 2 || Var.WatchMems[1].Lovers.Count == 2)
						{
							Var.AchBoolList[9] = true;
							Var.NewAchs.Add (14);
							PlayerPrefs.SetInt("Ach14", 1);
							Var.Fame -= 20;
						}
					}
					if(Var.AchBoolList[10] == false)
					{
						if(Var.WatchMems[0].Gender == Var.WatchMems[1].Gender)
						{
							Var.AchBoolList[10] = true;
							Var.NewAchs.Add (15);
							PlayerPrefs.SetInt("Ach15", 1);
							Var.Fame += 30;
						}
					}
				}
			}
			foreach(Character WatchMem in Var.WatchMems)
			{
				AddRandomFeedbackText_TV(WatchMem);
			}
		}
		else if(NoticeType == NoticeTypes.GameResult)
		{
			Text.text = "\n";
			if(Var.GameMems.Count == 1)
			{
				Text.text += Var.GameMems[0].Name+CheckSubjectFinalConsonant1(Var.GameMems[0].Name)+" 혼자 게임을 했다.\n";
			}
			else if(Var.GameMems.Count == 2)
			{
				Text.text += Var.GameMems[0].Name+CheckSubjectFinalConsonant1(Var.GameMems[0].Name)+" "+Var.GameMems[1].Name;
				Text.text += CheckTogetherFinalConsonant(Var.GameMems[1].Name)+" 함께 게임을 했다.\n";
				Var.GameMems[0].Relationship[Var.GameMems[1].MemberNumber] += 5;
				Var.GameMems[1].Relationship[Var.GameMems[0].MemberNumber] += 5;
				
				if(Var.GameMems[0].Relationship[Var.GameMems[1].MemberNumber] == 20)
				{
					Var.NewFriends.Add (Var.GameMems[0]);
					Var.NewFriends.Add (Var.GameMems[1]);
					Var.GameMems[0].Friends.Add (Var.GameMems[1]);
					Var.GameMems[1].Friends.Add (Var.GameMems[0]);
				}
				else if(Var.GameMems[0].Relationship[Var.GameMems[1].MemberNumber] == 70)
				{
					Var.NewLovers.Add (Var.GameMems[0]);
					Var.NewLovers.Add (Var.GameMems[1]);
					Var.GameMems[0].Lovers.Add (Var.GameMems[1]);
					Var.GameMems[1].Lovers.Add (Var.GameMems[0]);
					
					if(Var.AchBoolList[9] == false)
					{
						if(Var.GameMems[0].Lovers.Count == 2 || Var.GameMems[1].Lovers.Count == 2)
						{
							Var.AchBoolList[9] = true;
							Var.NewAchs.Add (14);
							PlayerPrefs.SetInt("Ach14", 1);
							Var.Fame -= 20;
						}
					}
					if(Var.AchBoolList[10] == false)
					{
						if(Var.GameMems[0].Gender == Var.GameMems[1].Gender)
						{
							Var.AchBoolList[10] = true;
							Var.NewAchs.Add (15);
							PlayerPrefs.SetInt("Ach15", 1);
							Var.Fame += 30;
						}
					}
				}
			}
			foreach(Character GameMem in Var.GameMems)
			{
				//AddRandomFeedbackText_Game(GameMem);
			}
		}
		else if(NoticeType == NoticeTypes.BookResult)
		{
			Text.text = "\n";
			if(Var.BookMems.Count == 1)
			{
				Text.text += Var.BookMems[0].Name+CheckSubjectFinalConsonant1(Var.BookMems[0].Name)+" 혼자 독서를 했다.\n";
			}
			else if(Var.BookMems.Count == 2)
			{
				Text.text += Var.BookMems[0].Name+CheckSubjectFinalConsonant1(Var.BookMems[0].Name)+" "+Var.BookMems[1].Name;
				Text.text += CheckTogetherFinalConsonant(Var.BookMems[1].Name)+" 함께 독서를 했다.\n";
				Var.BookMems[0].Relationship[Var.BookMems[1].MemberNumber] += 5;
				Var.BookMems[1].Relationship[Var.BookMems[0].MemberNumber] += 5;
				
				if(Var.BookMems[0].Relationship[Var.BookMems[1].MemberNumber] == 20)
				{
					Var.NewFriends.Add (Var.BookMems[0]);
					Var.NewFriends.Add (Var.BookMems[1]);
					Var.BookMems[0].Friends.Add (Var.BookMems[1]);
					Var.BookMems[1].Friends.Add (Var.BookMems[0]);
				}
				else if(Var.BookMems[0].Relationship[Var.BookMems[1].MemberNumber] == 70)
				{
					Var.NewLovers.Add (Var.BookMems[0]);
					Var.NewLovers.Add (Var.BookMems[1]);
					Var.BookMems[0].Lovers.Add (Var.BookMems[1]);
					Var.BookMems[1].Lovers.Add (Var.BookMems[0]);
					
					if(Var.AchBoolList[9] == false)
					{
						if(Var.BookMems[0].Lovers.Count == 2 || Var.BookMems[1].Lovers.Count == 2)
						{
							Var.AchBoolList[9] = true;
							Var.NewAchs.Add (14);
							PlayerPrefs.SetInt("Ach14", 1);
							Var.Fame -= 20;
						}
					}
					if(Var.AchBoolList[10] == false)
					{
						if(Var.BookMems[0].Gender == Var.BookMems[1].Gender)
						{
							Var.AchBoolList[10] = true;
							Var.NewAchs.Add (15);
							PlayerPrefs.SetInt("Ach15", 1);
							Var.Fame += 30;
						}
					}
				}
			}
			foreach(Character BookMem in Var.BookMems)
			{
				AddRandomFeedbackText_Book(BookMem);
			}
		}
		else if(NoticeType == NoticeTypes.CookResult)
		{
			Text.text = "\n";
			if(Var.CookMems.Count == 1)
			{
				Text.text += Var.CookMems[0].Name+CheckSubjectFinalConsonant1(Var.CookMems[0].Name)+" 혼자 요리를 했다.\n";
			}
			else if(Var.CookMems.Count == 2)
			{
				Text.text += Var.CookMems[0].Name+CheckSubjectFinalConsonant1(Var.CookMems[0].Name)+" "+Var.CookMems[1].Name;
				Text.text += CheckTogetherFinalConsonant(Var.CookMems[1].Name)+" 함께 요리를 했다.\n";
				Var.CookMems[0].Relationship[Var.CookMems[1].MemberNumber] += 5;
				Var.CookMems[1].Relationship[Var.CookMems[0].MemberNumber] += 5;
				
				if(Var.CookMems[0].Relationship[Var.CookMems[1].MemberNumber] == 20)
				{
					Var.NewFriends.Add (Var.CookMems[0]);
					Var.NewFriends.Add (Var.CookMems[1]);
					Var.CookMems[0].Friends.Add (Var.CookMems[1]);
					Var.CookMems[1].Friends.Add (Var.CookMems[0]);
				}
				else if(Var.CookMems[0].Relationship[Var.CookMems[1].MemberNumber] == 70)
				{
					Var.NewLovers.Add (Var.CookMems[0]);
					Var.NewLovers.Add (Var.CookMems[1]);
					Var.CookMems[0].Lovers.Add (Var.CookMems[1]);
					Var.CookMems[1].Lovers.Add (Var.CookMems[0]);
					
					if(Var.AchBoolList[9] == false)
					{
						if(Var.CookMems[0].Lovers.Count == 2 || Var.CookMems[1].Lovers.Count == 2)
						{
							Var.AchBoolList[9] = true;
							Var.NewAchs.Add (14);
							PlayerPrefs.SetInt("Ach14", 1);
							Var.Fame -= 20;
						}
					}
					if(Var.AchBoolList[10] == false)
					{
						if(Var.CookMems[0].Gender == Var.CookMems[1].Gender)
						{
							Var.AchBoolList[10] = true;
							Var.NewAchs.Add (15);
							PlayerPrefs.SetInt("Ach15", 1);
							Var.Fame += 30;
						}
					}
				}
			}
			foreach(Character CookMem in Var.CookMems)
			{
				AddRandomFeedbackText_Cook(CookMem);
			}
		}
		else if(NoticeType == NoticeTypes.PiaResult)
		{
			Text.text = "\n";
			if(Var.PiaMems.Count == 1)
			{
				Text.text += Var.PiaMems[0].Name+CheckSubjectFinalConsonant1(Var.PiaMems[0].Name)+" 혼자 피아노를 쳤다.\n";
			}
			else if(Var.PiaMems.Count == 2)
			{
				Text.text += Var.PiaMems[0].Name+CheckSubjectFinalConsonant1(Var.PiaMems[0].Name)+" "+Var.PiaMems[1].Name;
				Text.text += CheckTogetherFinalConsonant(Var.PiaMems[1].Name)+" 함께 피아노를 쳤다.\n";
				Var.PiaMems[0].Relationship[Var.PiaMems[1].MemberNumber] += 5;
				Var.PiaMems[1].Relationship[Var.PiaMems[0].MemberNumber] += 5;
				
				if(Var.PiaMems[0].Relationship[Var.PiaMems[1].MemberNumber] == 20)
				{
					Var.NewFriends.Add (Var.PiaMems[0]);
					Var.NewFriends.Add (Var.PiaMems[1]);
					Var.PiaMems[0].Friends.Add (Var.PiaMems[1]);
					Var.PiaMems[1].Friends.Add (Var.PiaMems[0]);
				}
				else if(Var.PiaMems[0].Relationship[Var.PiaMems[1].MemberNumber] == 70)
				{
					Var.NewLovers.Add (Var.PiaMems[0]);
					Var.NewLovers.Add (Var.PiaMems[1]);
					Var.PiaMems[0].Lovers.Add (Var.PiaMems[1]);
					Var.PiaMems[1].Lovers.Add (Var.PiaMems[0]);
					
					if(Var.AchBoolList[9] == false)
					{
						if(Var.PiaMems[0].Lovers.Count == 2 || Var.PiaMems[1].Lovers.Count == 2)
						{
							Var.AchBoolList[9] = true;
							Var.NewAchs.Add (14);
							PlayerPrefs.SetInt("Ach14", 1);
							Var.Fame -= 20;
						}
					}
					if(Var.AchBoolList[10] == false)
					{
						if(Var.PiaMems[0].Gender == Var.PiaMems[1].Gender)
						{
							Var.AchBoolList[10] = true;
							Var.NewAchs.Add (15);
							PlayerPrefs.SetInt("Ach15", 1);
							Var.Fame += 30;
						}
					}
				}
			}
			foreach(Character PiaMem in Var.PiaMems)
			{
				AddRandomFeedbackText_Piano(PiaMem);
			}
		}
		else if(NoticeType == NoticeTypes.NothingResult)
		{
			Text.text = "모든 회원들은 아무것도 하지 않고 잉여롭게 시간을 때웠다!";
		}
		else if(NoticeType == NoticeTypes.MemberLeave)
		{
			Text.text = "";
			foreach(Character LeaveMember in Var.LeaveMems)
			{
				Text.text += LeaveMember.Name+CheckSubjectFinalConsonant2(LeaveMember.Name)+" 동아리를 떠났다...\n";
				
				foreach(Character Member in Var.Mems)
				{
					if(Member.MemberNumber > LeaveMember.MemberNumber)
					{
						Member.MemberNumber -= 1;
					}
					Member.Loyalty -= 10;
				}
				if(LeaveMember.Gender == true)
				{
					Var.MaleMems.Remove(LeaveMember);
					foreach(Character MaleMember in Var.MaleMems)
					{
						if(MaleMember.GenderMemberNumber > LeaveMember.GenderMemberNumber)
						{
							MaleMember.GenderMemberNumber -= 1;
						}
					}
				}
				else
				{
					Var.FemaleMems.Remove(LeaveMember);
					foreach(Character FemaleMember in Var.FemaleMems)
					{
						if(FemaleMember.GenderMemberNumber > LeaveMember.GenderMemberNumber)
						{
							FemaleMember.GenderMemberNumber -= 1;
						}
					}
				}
				Var.Mems.Remove(LeaveMember);
				
				if(LeaveMember.CurrentAct == Character.ActionIndex.Game)
				{
					Var.GameMems.Remove(LeaveMember);
				}
				else if(LeaveMember.CurrentAct == Character.ActionIndex.Programming)
				{
					Var.ProgramMems.Remove(LeaveMember);
				}
				else if(LeaveMember.CurrentAct == Character.ActionIndex.BdGm)
				{
					Var.BdGmMems.Remove(LeaveMember);
				}
				else if(LeaveMember.CurrentAct == Character.ActionIndex.Draw)
				{
					Var.DrawMems.Remove(LeaveMember);
				}
				else if(LeaveMember.CurrentAct == Character.ActionIndex.Compose)
				{
					Var.ComposeMems.Remove(LeaveMember);
				}
				else if(LeaveMember.CurrentAct == Character.ActionIndex.Book)
				{
					Var.BookMems.Remove(LeaveMember);
				}
				else if(LeaveMember.CurrentAct == Character.ActionIndex.Watch)
				{
					Var.WatchMems.Remove(LeaveMember);
				}
				else if(LeaveMember.CurrentAct == Character.ActionIndex.Plan)
				{
					Var.PlanMems.Remove(LeaveMember);
				}
				
				Destroy(LeaveMember.gameObject);
			}
			
			Var.LeaveMems.Clear();
		}
		else if(NoticeType == NoticeTypes.MemberInfo)
		{
			if(InfoMember.Chief == false)
			{
				Text.text = InfoMember.Name+"\n\n\n\n\n"+InfoMember.Plan+"\n"+InfoMember.Programming+"\n"+InfoMember.Art+"\n"+InfoMember.Sound+"\n\n"+InfoMember.Loyalty;
			}
			else
			{
				Text.text = "전회장\n\n\n\n\n???\n???\n???\n???\n\n???";
			}
		}
		else if(NoticeType == NoticeTypes.GroupActivity)
		{
			if(Var.Money >= GroupActivityCost(Var.GroupActivityType))
			{
				Var.MenuActivated = false;

				foreach(Character Member in Var.Mems)
				{
					Member.Loyalty += GroupActivityLoyalty(Var.GroupActivityType);
				}
				Var.Money -= GroupActivityCost(Var.GroupActivityType);
				Text.text = "동아리 회원들은 "+GroupResult(Var.GroupActivityType);
				Text.text += "\n총 "+GroupActivityCost(Var.GroupActivityType)+"만 원의 돈을 사용했다.";
				Text.text += "\n모두의 충성도가 각각 "+GroupActivityLoyalty(Var.GroupActivityType)+"만큼 올랐다.";
				Var.MoneyMonthLog.Add (Var.Month);
				Var.MoneyDayLog.Add(Var.Day);
				Var.MoneyChangeLog.Add (GroupActivityCost(Var.GroupActivityType)*(-1));
				Var.MoneyRemainLog.Add (Var.Money);
			}
			else
			{
				Text.text = "돈이 부족하다...";
			}
		}
		else if(NoticeType == NoticeTypes.NoxenProjectStart)
		{
			Text.text = "NOXEN프로젝트를 시작했다!";
		}
		else if(NoticeType == NoticeTypes.ProjectResult)
		{
			Text.text = "\nNOXEN프로젝트가 끝났다!\n";
			if(Var.ProjectRanks.Count > 0)
			{
				Text.text += PjResultMessage(1);
			}
			if(Var.ProjectRanks.Count > 1)
			{
				Text.text += PjResultMessage(2);
			}
			if(Var.ProjectRanks.Count < 3)
			{
				Var.ProjectRanks.Clear();
			}
		}
		else if(NoticeType == NoticeTypes.ProjectResult2)
		{
			Text.text = "\n";
			if(Var.ProjectRanks.Count > 2)
			{
				Text.text += PjResultMessage(3);
			}
			if(Var.ProjectRanks.Count > 3)
			{
				Text.text += PjResultMessage(4);
			}
			if(Var.ProjectRanks.Count > 4)
			{
				Text.text += PjResultMessage(5);
			}
			Var.ProjectRanks.Clear();
		}
		else if(NoticeType == NoticeTypes.CutSceneText)
		{
			Text.text = SceneText;
		}
		else if(NoticeType == NoticeTypes.NotEnoughRoom)
		{
			Text.text = "동아리방에 공간이 부족하다...";
		}
		else if(NoticeType == NoticeTypes.NotEnoughFame)
		{
			Text.text = "명성이 부족하다...";
		}
		else if(NoticeType == NoticeTypes.NotEnoughMoney)
		{
			Text.text = "돈이 부족하다...";
		}
		else if(NoticeType == NoticeTypes.RoomUpgrade)
		{
			Text.text = "업그레이드를 완료했다!!";
		}
		else if(NoticeType == NoticeTypes.SaveMessage)
		{
			Text.text = "저장되었습니다.";
		}
		else if(NoticeType == NoticeTypes.AlreadyGroupActivity)
		{
			Text.text = "변회장 : 이번 주는 이미 놀러갔다 왔으니까, 다음 주를 기약하자.";
		}
	}
}