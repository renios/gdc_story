using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CutScene : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public enum SceneTypes
	{
		Project1st,
		Project2nd,
		Project3rd,
		ProjectFail,
		Drop,
		NewFriend,
		NewLover,
		SpringPicnic,
		SummerPicnic,
		AutumnPicnic,
		WinterPicnic,
		Valentine,
		ClubIntroduce,
		Exam,
		Festival,
		Christmas,
		BoardGameJam,
		GStar,
		SpringMT,
		SummerMT,
		AutumnMT,
		WinterMT,
		Drink,
		Dinner,
		NewFriendForPj,
		NewLoverForPj,
	}
	public SceneTypes SceneType;

	public Sprite Project1st;
	public Sprite Project2nd;
	public Sprite Project3rd;
	public Sprite ProjectFail;
	public Sprite Drop;
	public Sprite NewFriend;
	public Sprite NewLover;
	public Sprite SpringPicnic;
	public Sprite SummerPicnic;
	public Sprite AutumnPicnic;
	public Sprite WinterPicnic;
	public Sprite Valentine;
	public Sprite ClubIntroduce;
	public Sprite Exam;
	public Sprite Festival;
	public Sprite Christmas;
	public Sprite BoardGameJam;
	public Sprite GStar;
	public Sprite SpringMT;
	public Sprite SummerMT;
	public Sprite AutumnMT;
	public Sprite WinterMT;
	public Sprite Drink;
	public Sprite Dinner;

	public NoticeMessage NoticePrefab;
	NoticeMessage Notice;
	public NewAch NewAchPF;
	NewAch NewAchIS;

	public SpriteRenderer Renderer;

	void Start()
	{
		ActivateCutSceneEffect ();

		Notice = Instantiate (NoticePrefab, new Vector3(NoticePrefab.transform.position.x, NoticePrefab.transform.position.y, -6), Quaternion.identity) as NoticeMessage;
		Notice.NoticeType = NoticeMessage.NoticeTypes.CutSceneText;
		Notice.Collider.enabled = false;

		SetCutSceneImage ();
		SetCutSceneText ();

		if(SceneType == SceneTypes.SpringPicnic)
		{
			Var.SprPic = true;
		}
		else if(SceneType == SceneTypes.SummerPicnic)
		{
			Var.SumPic = true;
		}
		else if(SceneType == SceneTypes.AutumnPicnic)
		{
			Var.AutPic = true;
		}
		else if(SceneType == SceneTypes.WinterPicnic)
		{
			Var.WinPic = true;
		}

		if(Var.AchBoolList[13] == false)
		{
			if(Var.SprPic == true && Var.SumPic == true && Var.AutPic == true && Var.WinPic == true)
			{
				Var.AchBoolList[13] = true;
				Var.NewAchs.Add(18);
				PlayerPrefs.SetInt("Ach18", 1);
				Var.Fame += 50;
			}
		}
	}

	void OnMouseDown()
	{
		if(SceneType == SceneTypes.NewFriend)
		{
			if(Var.NewFriends.Count > 3)
			{
				Var.NewFriends.Remove(Var.NewFriends[0]);
				Var.NewFriends.Remove(Var.NewFriends[1]);
				Destroy(Notice.gameObject);
				Start ();
			}
			else
			{
				Var.NewFriends.Clear();
				Notice.EndActionPhase();
				EndCutScene();
			}
		}
		else if(SceneType == SceneTypes.NewLover)
		{
			if(Var.NewLovers.Count > 3)
			{
				Var.NewLovers.Remove(Var.NewLovers[0]);
				Var.NewLovers.Remove(Var.NewLovers[1]);
				Destroy(Notice.gameObject);
				Start ();
			}
			else
			{
				Var.NewLovers.Clear();
				Notice.EndActionPhase();
				EndCutScene();
			}
		}
		else if(SceneType == SceneTypes.Drop)
		{
			Destroy(Notice.gameObject);
			Notice = Instantiate(NoticePrefab) as NoticeMessage;
			Notice.NoticeType = NoticeMessage.NoticeTypes.MemberLeave;
			Destroy(gameObject);

			if(Var.Mems.Count == 1)
			{
				Application.LoadLevel("SoloEnding");
			}
		}
		else if(SceneType == SceneTypes.ClubIntroduce)
		{
			Destroy(Notice.gameObject);
			Notice = Instantiate(NoticePrefab) as NoticeMessage;
			Notice.NoticeType = NoticeMessage.NoticeTypes.NewMember;
			Destroy(gameObject);
		}
		else if(SceneType == SceneTypes.Exam)
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
					Var.Month += 1;
				}
				else
				{
					Var.Month = 1;
					Var.Year += 1;
				}
			}
			EndCutScene();
		}
		else if(SceneType == SceneTypes.Project1st || SceneType == SceneTypes.Project2nd || SceneType == SceneTypes.Project3rd || SceneType == SceneTypes.ProjectFail)
		{
			Debug.Log ("Project CutScene.");
			Destroy(Notice.gameObject);
			Notice = Instantiate(NoticePrefab) as NoticeMessage;
			Notice.NoticeType = NoticeMessage.NoticeTypes.ProjectResult;

			EndCutScene();
		}
		else
		{
			EndCutScene();
		}
	}

	void SetCutSceneText()
	{
		int CutSceneTextType = UnityEngine.Random.Range (0, 5);

		List<Character> BeforeShuffle = new List<Character> ();
		foreach(Character Member in Var.Mems)
		{
			BeforeShuffle.Add (Member);
		}
		List<Character> AfterShuffle = new List<Character>();

		while (BeforeShuffle.Count > 0)
		{
			int RandomIndex = UnityEngine.Random.Range(0, BeforeShuffle.Count);
			AfterShuffle.Add(BeforeShuffle[RandomIndex]);
			BeforeShuffle.RemoveAt(RandomIndex);
		}

		if(SceneType == SceneTypes.Project1st)
		{
			Character SayMember = AfterShuffle[0];
			if(SayMember == Var.Mems[Var.Mems.Count-1])
			{
				SayMember = AfterShuffle[1];
			}

			if(CutSceneTextType == 0)
			{
				Notice.SceneText = SayMember.Name+" : 우리의 노력이 드디어 빛을 발했어!";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText = SayMember.Name+" : 이 상금, 내가 유용하게 써주도록 하지.";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = SayMember.Name+" : 이 게임, 우리의 승리다!";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText = SayMember.Name+" : 오늘 저녁은 소고기다!";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = SayMember.Name+" : 야호! 준비했던 샴페인을 터뜨리자!";
			}
		}
		else if(SceneType == SceneTypes.Project2nd)
		{
			if(CutSceneTextType == 0)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 금메달보다 값진 은메달도 있는 법이지...";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 오늘 점심은 칠리 콘 까르네다!";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 다음 목표는 1등이다!";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 오늘 저녁은 돼지고기다!";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 신난다! 오늘은 와인을 마시자!";
			}
		}
		else if(SceneType == SceneTypes.Project3rd)
		{
			if(CutSceneTextType == 0)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 와! 상금이다!";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 다음 학기에는 더욱 열심히 하자!";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 다음 목표는 2등이다!";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 오늘 저녁은 치킨이다!";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 와! 오늘은 우리 모두 맥주 파티다!";
			}
		}
		else if(SceneType == SceneTypes.ProjectFail)
		{
			if(CutSceneTextType == 0)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 우린 쓸모가 없다. 팝콘이나 가져와라 신입.";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 내가 무릎을 꿇은 건 추진력을 얻기 위함이다!";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 행복이 성적 순은 아니잖아요.";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 오늘 저녁은 컵라면이다!";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 야호! 준비했던 소주를 들이붓자!";
			}
		}
		else if(SceneType == SceneTypes.Drop)
		{
			int LeaveMemberNumber = UnityEngine.Random.Range(0, Var.LeaveMems.Count);
			Notice.SceneText = Var.LeaveMems[LeaveMemberNumber].Name+" : 이건 미친짓이야. 난 여기서 나가겠어.";
		}
		else if(SceneType == SceneTypes.NewFriend || SceneType == SceneTypes.NewFriendForPj)
		{
			if(CutSceneTextType == 0)
			{
				Notice.SceneText = Var.NewFriends[0].Name+"&"+Var.NewFriends[1].Name+" : 너와 나는 이제 영혼의 친구야.";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText = Var.NewFriends[0].Name+"&"+Var.NewFriends[1].Name+" : 우리는 비록 태어난 날은 달라도 같은 날 죽기로 맹세한다!";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = Var.NewFriends[0].Name+"&"+Var.NewFriends[1].Name+" : 우정의 문장이 각성하고 있어!";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText = Var.NewFriends[0].Name+"&"+Var.NewFriends[1].Name+" : 영혼의 파장이 맞춰졌다! 영혼의 공명!";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = Var.NewFriends[0].Name+"&"+Var.NewFriends[1].Name+" : 이제는 너의 취향마저도 이해할 수 있어.";
			}
			Notice.SceneText += "\n\n두 사람은 친구가 되었다!";
		}
		else if(SceneType == SceneTypes.NewLover || SceneType == SceneTypes.NewLoverForPj)
		{
			if(CutSceneTextType == 0)
			{
				Notice.SceneText = Var.NewLovers[0].Name+"&"+Var.NewLovers[1].Name+" : 일단 전화번호부터 교환하자...";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText = Var.NewLovers[0].Name+"&"+Var.NewLovers[1].Name+" : 잡았다! 넌 내 꺼야!";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = Var.NewLovers[0].Name+"&"+Var.NewLovers[1].Name+" : 고백을 받았으니 멀리 가진 못하겠지?";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText = Var.NewLovers[0].Name+"&"+Var.NewLovers[1].Name+" : I LOVE YOU";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = Var.NewLovers[0].Name+"&"+Var.NewLovers[1].Name+" : 우리 오늘부터 1일이야!";
			}
			Notice.SceneText += "\n\n두 사람은 연인이 되었다!";
		}
		else if(SceneType == SceneTypes.SpringPicnic)
		{
			if(CutSceneTextType == 0)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 벚꽃 보니까 연애하고 싶다...";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 여의도에 사람 너무 많아... 여기 소풍 오자고 한 사람 대체 누구야?";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 이렇게 밖에 누워서 벚꽃이 떨어지는 걸 보는 것도 나쁘진 않은 것 같아.";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 봄소풍에 참여하지 않은 커플충들을 처단하자!";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 다들 벚꽃 사이에 있으니까 화사해보이네! 다 같이 놀러 와서 기분 좋다.";
			}
		}
		else if(SceneType == SceneTypes.SummerPicnic)
		{
			if(CutSceneTextType == 0)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 나의 물총을 받아랏!";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 우리 실험 하나 해볼래? 악당이 주인공을 기습하면 누가 이길지!";
				//Notice.SceneText = AfterShuffle[0].Name+" : 우리 실험 하나 해볼래?\n악당역이랑 주인공역이랑 나눠서 악당역이 기습했을 때 누가 이길지!";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 후후 나의 크고 아름다운 물총에서 나오는 물세례를 받으시지!";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 으아 잠깐만! 여벌 옷 안 가져왔단 말이야! 잠깐만! 야!";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 젖었지만 시원한 것 같아! 기분좋은걸?";
			}
		}
		else if(SceneType == SceneTypes.AutumnPicnic)
		{
			if(CutSceneTextType == 0)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 하늘이 높고 푸르구나...야외에서 독서를 하니 한결 똑똑해진 느낌인걸.";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 낙엽으로 모닥불 지펴서 고구마 구워볼까? 방화범으로 잡혀가려나?";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 날씨가 맑고 선선한 것만으로도 좋은 기분인걸.";
				//Notice.SceneText = AfterShuffle[0].Name+" : 가을에는 물총놀이도, 눈싸움도 할 수 없지만...\n날씨가 맑고 선선한 것만으로도 좋은 기분인걸.";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 가을이 되니까 쓸쓸하군...김밥이라도 싸 줄 이성친구가 있었으면...";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 낙엽이 떨어진다... 나의 감수성이 폭.발.할.것.같.군.";
			}
		}
		else if(SceneType == SceneTypes.WinterPicnic)
		{
			if(CutSceneTextType == 0)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 누가 안에 돌 든 눈덩이 던졌어!";
			}
			else if(CutSceneTextType == 1)
			{
				//전하를 제외한 다른 회원으로
				if(AfterShuffle[0] != Var.Mems[0])
				{
					Notice.SceneText = AfterShuffle[0].Name;
				}
				else
				{
					Notice.SceneText = AfterShuffle[1].Name;
				}
				Notice.SceneText += " : 이 눈덩이가 회장님한테 맞으려면 어떻게 해야 할ㄲ...(퍽)";
			}
			else if(CutSceneTextType == 2)
			{
				//FIXME : 전하를 제외한 다른 회원으로
				if(AfterShuffle[0] != Var.Mems[0])
				{
					Notice.SceneText = AfterShuffle[0].Name;
				}
				else
				{
					Notice.SceneText = AfterShuffle[1].Name;
				}
				Notice.SceneText += " : 회장님만 공격해보는 건 어때? 눈싸움에서만이라도 반역을 성공하는거야!";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 상대팀이 너무 강력하잖아! 어떻게 반격할 방법이 없을까?";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 눈싸움이라니 유치하긴. 아아! 시몬 너는 아느냐? 눈자욱 밟는 소리를..";
			}
		}
		else if(SceneType == SceneTypes.Valentine)
		{
			if(CutSceneTextType == 0)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 다 같이 초콜릿을 만들어 서로에게 선물하도록 하자!";
			}
			else if(CutSceneTextType == 1)
			{
				if(Var.Mems.Count < 4)
				{
					Notice.SceneText = AfterShuffle[0].Name + "사람도 없는데 무슨 발렌타인이람...";
				}
				else if(Var.MaleMems.Count == 0)
				{
					Notice.SceneText = AfterShuffle[0].Name + "우리 동아리는 남자가 없다는 슬픈 전설이 있어...";
				}
				else if(Var.FemaleMems.Count == 0)
				{
					Notice.SceneText = AfterShuffle[0].Name + "우리 동아리는 여자가 없다는 슬픈 전설이 있어...";
				}
				else
				{
					int MaleMember = UnityEngine.Random.Range (0, Var.MaleMems.Count);
					int FemaleMember = UnityEngine.Random.Range (0, Var.FemaleMems.Count);
					if(Var.MaleMems[MaleMember] != AfterShuffle[0] && Var.FemaleMems[FemaleMember] != AfterShuffle[0])
					{
						Notice.SceneText = AfterShuffle[0].Name+" : 그거 들었어? 오늘 "+Var.MaleMems[MaleMember].Name;
						Notice.SceneText += Notice.CheckSubjectFinalConsonant2(Var.MaleMems[MaleMember].Name)+" "+Var.FemaleMems[FemaleMember].Name;
						Notice.SceneText += "에게 고백한다더라!";
					}
					else
					{
						Notice.SceneText = AfterShuffle[0].Name+" : 발렌타인데인데 누구 놀려먹을 사람 없나~";
					}
				}
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 발렌타인데이는 무슨... 우리 동아리에서 기념해야 할 건 블랙데이지";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 의리 초콜릿이야! 받으렴:) 고마워서 눈물 흘릴 필요는 없단다?";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 사겨라(짝) 사겨라(짝)";
			}
		}
		else if(SceneType == SceneTypes.ClubIntroduce)
		{
			Character PlanMaster = AfterShuffle[0];
			foreach(Character Member in Var.Mems)
			{
				if(Member.Plan > PlanMaster.Plan)
				{
					PlanMaster = Member;
				}
			}

			if(Var.Mems.Count == 1)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 첫 동소제라니 설렌다. 신입이 많아야 할 텐데...";
			}
			else if(Var.Mems.Count == 2)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 어떻게 하면 우리 동아리가 더 재밌어 보일까?";
			}
			else if(CutSceneTextType == 0)
			{
				Notice.SceneText = PlanMaster.Name+" : 동아리 마스코트를 만드는 게 어때요?";
				Notice.SceneText += "\n\n우리 동아리의 마스코트, 잉여잉문학과 김덕춘씨를 만들었다!";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 올해 동아리 소개제 이벤트는 뭘로 하지?\n";
				Notice.SceneText += AfterShuffle[1].Name+" : 마인크래프트 검과 곡괭이로 결투를 하는 건 어때?\n";
				if(Var.Mems.Count < 5)
				{
					Notice.SceneText += AfterShuffle[2].Name+" : 할 사람이 없어...";
				}
				else
				{
					Notice.SceneText += AfterShuffle[2].Name+" : "+AfterShuffle[3].Name+Notice.CheckTogetherFinalConsonant(AfterShuffle[3].Name)+" "+AfterShuffle[4].Name+"의 대결로 하자.";
				}
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = "동아리 소개제에서 지금까지 만들었던 게임들을 시연했다.\n\n작년 녹슨프로젝트 수상작이 큰 호응을 얻었다!";
			}
			else if(CutSceneTextType == 3)
			{
				if(AfterShuffle[0] == PlanMaster)
				{
					Notice.SceneText = AfterShuffle[1].Name+" : 우리 부스에 별로 사람이 안 오잖아.\n";
				}
				else
				{
					Notice.SceneText = AfterShuffle[0].Name+" : 우리 부스에 별로 사람이 안 오잖아.\n";
				}
				Notice.SceneText += PlanMaster.Name+" : 우리도 다른 동아리처럼 사탕으로 유혹하자.";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = AfterShuffle[0].Name+" : 열정 넘치는 신입회원들이 많이 들어왔으면 좋겠군!";
			}

			int NewMemberCount;

			NewMemberCount = 1 + ((Var.Fame)/300);

			if (NewMemberCount > 4)
			{
				NewMemberCount = 4;
			}

			/*if(Var.Fame >= 200)
			{
				NewMemberCount = 2;
			}
			else
			{
				NewMemberCount = 1;
			}*/

			/*for(int i = 0; NewMemberCount>i; i++)
			{
				Notice.NewMember = Instantiate(Notice.NewMemberPrefab, new Vector3(Random.Range(-1.5f, 1.8f), Random.Range(-0.7f, 1.2f), Notice.NewMemberPrefab.transform.position.z), Quaternion.identity) as Character;

				int NewMemberGender = UnityEngine.Random.Range(0, 2);
				if(NewMemberGender == 0)
				{
					Notice.NewMember.Gender = true;
				}
				else
				{
					Notice.NewMember.Gender = false;
				}

				Var.NewMembers.Add(Notice.NewMember);
			}*/
			Var.Mng.CreateNormMem(NewMemberCount);
		}
		else if(SceneType == SceneTypes.Exam)
		{
			Notice.SceneText = "회원들은 기말고사 대비를 하느라 10일 동안 동아리 활동을 못 했다.\n";
			if(CutSceneTextType == 0)
			{
				Notice.SceneText += "모두 열심히 기말고사 공부를 했다.";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText += AfterShuffle[0].Name+" : 아니, 벌써 기말고사가 10일 밖에 남지 않았네.";
			}
			else if(CutSceneTextType == 2)
			{
				Character ProgrammingMaster = AfterShuffle[0];
				foreach(Character Member in Var.Mems)
				{
					if(Member.Programming > ProgrammingMaster.Programming)
					{
						ProgrammingMaster = Member;
					}
				}

				if(ProgrammingMaster.Programming >= 30)
				{
					Notice.SceneText += ProgrammingMaster.Name+Notice.CheckSubjectFinalConsonant1(ProgrammingMaster.Name)+" 프로그래밍 과목에서 A+를 받았다.";
				}
				else
				{
					Notice.SceneText += "악명 높은 프밍수업에 고통받는 사람들이 보인다.";
				}
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText += AfterShuffle[0].Name+" : 이번 시험은 잘 봐야 하는데...";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText += AfterShuffle[0].Name+" : 공부를 열심히 하자.";
			}
		}
		else if(SceneType == SceneTypes.Festival)
		{
			Notice.SceneText = "학교 축제 기간이다.\n";
			if(CutSceneTextType == 0)
			{
				int OldMemberNumber = UnityEngine.Random.Range(0, Var.Mems.Count-1);
				Notice.SceneText += Var.Mems[Var.Mems.Count-1].Name+" : 대학교 축제는 처음이에요.\n";
				Notice.SceneText += Var.Mems[OldMemberNumber].Name+" : 우리 학교 축제는 별 게 없다는 걸 배우게 될 거야...";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText += "동아리 회원들은 같이 트램폴린을 타며 동심으로 돌아갔다.";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText += "동아리는 잔디밭에서 술과 안주를 같이 먹으며 놀았다.";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText += "동아리는 초청가수들의 공연을 감상했다.";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText += "부스에서 작년에 제작한 게임들을 시연했다.";
			}
		}
		else if(SceneType == SceneTypes.Christmas)
		{
			Notice.SceneText = "동아리에서 크리스마스 파티를 했다.\n";
			if(CutSceneTextType == 0)
			{
				Notice.SceneText += "케익을 같이 먹고 선물을 교환했다";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText += AfterShuffle[0].Name+" : 솔로끼리 즐거운 시간을 보내자. 하하하.";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText += AfterShuffle[0].Name+" : 크리스마스 트리가 반짝반짝 빛나서 예쁘군.";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText += AfterShuffle[0].Name+Notice.CheckSubjectFinalConsonant2(AfterShuffle[0].Name)+" 산타 옷을 입고 선물을 나눠줬다.";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText += AfterShuffle[0].Name+" : 이제 곧 "+Var.Year+"년도 끝이네.\n";
				if(Var.ProjectHighScore != 4)
				{
					Notice.SceneText += AfterShuffle[1].Name+" : 그래도 보람있는 한 해였어.";
				}
				else
				{
					Notice.SceneText += AfterShuffle[1].Name+" : 내년엔 더 열심히 하자.";
				}
			}
		}
		else if(SceneType == SceneTypes.BoardGameJam)
		{
			Notice.SceneText = "동아리 내에서 보드게임잼을 개최했다.\n";
			if(CutSceneTextType == 0)
			{
				Notice.SceneText += "주제어는 ‘참치’, ‘혼돈’, ‘꽃’이다.\n";
				Notice.SceneText += "우승작은 ‘꽃팜’이다.";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText += "‘재무’, ‘거짓말’, ‘동화’다.\n";
				Notice.SceneText += "우승작은 ‘Fairy Survivor’다.";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText += "주제어는 ‘가위바위보’, ‘도박’, ‘전쟁’이다.\n";
				Notice.SceneText += "‘카지노를 털어라’와 ‘트리니티’가 공동 우승작으로 뽑혔다.";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText += "주제어는 ‘연극’, ‘해킹’, 공격’이다.\n";
				Notice.SceneText += "우승작은 'Hack-me’다.";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText += "주제어는 ‘역사’, ‘시간’, ‘잠’이다.\n";
				Notice.SceneText += "우승작은 ‘Time Traveler’다.";
			}
		}
		else if(SceneType == SceneTypes.GStar)
		{
			Notice.SceneText = "동아리원들은 국제 게임 전시회 지스타에 참석했다.\n";
			if(CutSceneTextType == 0)
			{
				Notice.SceneText += AfterShuffle[0].Name+" : 부스에 예쁜 ";
				if(AfterShuffle[0].Gender == true)
				{
					Notice.SceneText += "누나";
				}
				else
				{
					Notice.SceneText += "언니";
				}
				Notice.SceneText += "들이 많네.\n";
				Notice.SceneText += AfterShuffle[1].Name+" : 이 날씨에 저렇게 코스프레하면 춥지 않을까?";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText += AfterShuffle[0].Name+" : 공짜로 상품을 많이 얻어왔네.\n";
				Notice.SceneText += AfterShuffle[1].Name+" : 티셔츠와 마우스패드를 획득했지!";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText += AfterShuffle[0].Name+" : 이번에 P모 게임은 완성도가 매우 높더군. 아마 성공할 것 같아.\n";
				Notice.SceneText += AfterShuffle[1].Name+" : (그럴 리가!)";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText += "다양한 신작 게임들을 체험할 수 있었다.";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText += AfterShuffle[0].Name+Notice.CheckSubjectFinalConsonant1(AfterShuffle[0].Name)+" 유저 플레이 이벤트에서 1등을 해서 상품을 받았다.";
			}
		}
		else if(SceneType == SceneTypes.SpringMT)
		{
			if(CutSceneTextType == 0)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 부어라! 마셔라! 죽어라!";
			}
			else if(CutSceneTextType == 1)
			{
				//전하를 제외한 다른 회원으로
				if(AfterShuffle[0] != Var.Mems[0])
				{
					Notice.SceneText = AfterShuffle[0].Name;
				}
				else
				{
					Notice.SceneText = AfterShuffle[1].Name;
				}
				Notice.SceneText += " : 크윽...다음 사람은 꼭 마리오카트에서 전하를 이겨주시오!";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 밤이 되었습니다...늑대인간, 눈을 뜨고 서로를 확인해주세요.";
			}
			else if(CutSceneTextType == 3)
			{
				//전하를 제외한 다른 회원으로
				if(AfterShuffle[0] != Var.Mems[0])
				{
					Notice.SceneText = AfterShuffle[0].Name;
				}
				else
				{
					Notice.SceneText = AfterShuffle[1].Name;
				}
				Notice.SceneText = " : 랜덤게임~ 랜덤게임~ 회장님이 좋아하는 랜덤게임~";
			}
			else if(CutSceneTextType == 4)
			{
				if(Var.Mems.Count > 2)
				{
					Notice.SceneText = AfterShuffle[2].Name + " : 안경쓴 사람 접어!\n";
					Notice.SceneText += AfterShuffle[1].Name + " : 금발 접어!\n";
				}
				else
				{
					Notice.SceneText = AfterShuffle[1].Name + " : 금발 접어!\n";
				}
				Notice.SceneText += AfterShuffle[0].Name + " : 포덕 접어! 다섯 개 접힌 사람 마셔라!";
			}
		}
		else if(SceneType == SceneTypes.SummerMT)
		{
			if(CutSceneTextType == 0)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : ...?! 수영하면서 3DS를 하고있어?!";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 이제 바다 구경은 다 했으니 들어가서 게임이나...어푸푸푸풒";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 얍! 물총이다!\n";
				Notice.SceneText += AfterShuffle[1].Name + " : 질 수 없지! 조립식 고압축 피스톤 물대포다!\n";
				Notice.SceneText += AfterShuffle[0].Name + " : ?!?!!!??";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 아아...이 맛은...염류의 맛이구나...";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 이거 봐, 낚시로 유리구슬을 낚았어!\n";
				Notice.SceneText += AfterShuffle[1].Name + " : 훗, 난 작은 빨간 구슬을 낚았지.";
			}
		}
		else if(SceneType == SceneTypes.AutumnMT)
		{
			if(CutSceneTextType == 0)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 내 폭죽을 봐줘...어떻게 생각해?\n";
				Notice.SceneText += AfterShuffle[1].Name + " : 밝고 아름다워요...";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 이런 건 보통 연인들끼리 오는거잖아?\n";
				Notice.SceneText += AfterShuffle[1].Name + " : 우린 안될꺼야 아마...";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 봐...빵빵 터지는게 마치 우리 미래같지 않니...?";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 여러분의 회비가 터져나가고 있습니다!\n";
				Notice.SceneText += AfterShuffle[1].Name + " : ...!!";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 네 가지 힘을 하나로 모으면~";
			}
		}
		else if(SceneType == SceneTypes.WinterMT)
		{
			if(CutSceneTextType == 0)
			{
				Notice.SceneText = "변회장 : 저 자를 눈밭에 던져라!";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 눈온다! 눈마시고 술싸움하자!";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 우리 눈싸움하자!\n";
				Notice.SceneText = AfterShuffle[1].Name + " : 밖은 추워...";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 야 고기 좀 그만 먹어!";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 패턴 적! 고기입니다!\n";
				Notice.SceneText += AfterShuffle[1].Name + " : 죄송합니다. 지금은 이용하실 수 없...덜 익었다고! 좀 기다려!";
			}
		}
		else if(SceneType == SceneTypes.Drink)
		{
			if(CutSceneTextType == 0)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 후후...오늘 밤은 음주 코딩이닷!";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 리미트 해제!\n";
				Notice.SceneText += AfterShuffle[1].Name + " : ?!";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 널 위해 준비했어...순도 100% 거품 한 잔.\n";
				Notice.SceneText += AfterShuffle[1].Name + " : 시...싫엇!";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText = "변회장 : 연료보급후엔 노동이다!";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = "변회장 : 맥주는 좋아. 리린이 낳은 음료의 극ㅊ...아...아니야";
			}
		}
		else if(SceneType == SceneTypes.Dinner)
		{
			if(CutSceneTextType == 0)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 숯불의 균형은 유지되어야 한다...\n";
				Notice.SceneText += AfterShuffle[1].Name + " : 아, 고기 타잖아. 쟤 리폿좀요.";
			}
			else if(CutSceneTextType == 1)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 고기! 고기를 보자! (덥썩)\n";
				Notice.SceneText += AfterShuffle[1].Name + " : (저거 아무리 봐도 덜 익었는데...)";
			}
			else if(CutSceneTextType == 2)
			{
				Notice.SceneText = "GDC의 회원들은 간만에 고기를 배불리 먹었다.\n\n";
				Notice.SceneText += AfterShuffle[1].Name + " : 쟤 술 먹고 이상한 나레이션 해...";
			}
			else if(CutSceneTextType == 3)
			{
				Notice.SceneText = AfterShuffle[0].Name + " : 고기에서 연기가 좀 많이 나는데.\n";
				Notice.SceneText += AfterShuffle[1].Name + " : 혼이 빠져나가는 거야...마치 우리처럼...";
			}
			else if(CutSceneTextType == 4)
			{
				Notice.SceneText = "변회장 : 동아리 카드를 제물로 고기를 소환하고 턴을 마친다!\n";
			}
		}
	}

	void SetCutSceneImage()
	{
		if(SceneType == SceneTypes.Project1st)
		{
			Renderer.sprite = Project1st;
		}
		else if(SceneType == SceneTypes.Project2nd)
		{
			Renderer.sprite = Project2nd;
		}
		else if(SceneType == SceneTypes.Project3rd)
		{
			Renderer.sprite = Project3rd;
		}
		else if(SceneType == SceneTypes.ProjectFail)
		{
			Renderer.sprite = ProjectFail;
		}
		else if(SceneType == SceneTypes.Drop)
		{
			Renderer.sprite = Drop;
		}
		else if(SceneType == SceneTypes.NewFriend || SceneType == SceneTypes.NewFriendForPj)
		{
			Renderer.sprite = NewFriend;
		}
		else if(SceneType == SceneTypes.NewLover || SceneType == SceneTypes.NewLoverForPj)
		{
			Renderer.sprite = NewLover;
		}
		else if(SceneType == SceneTypes.SpringPicnic)
		{
			Renderer.sprite = SpringPicnic;
		}
		else if(SceneType == SceneTypes.SummerPicnic)
		{
			Renderer.sprite = SummerPicnic;
		}
		else if(SceneType == SceneTypes.AutumnPicnic)
		{
			Renderer.sprite = AutumnPicnic;
		}
		else if(SceneType == SceneTypes.WinterPicnic)
		{
			Renderer.sprite = WinterPicnic;
		}
		else if(SceneType == SceneTypes.Valentine)
		{
			Renderer.sprite = Valentine;
		}
		else if(SceneType == SceneTypes.ClubIntroduce)
		{
			Renderer.sprite = ClubIntroduce;
		}
		else if(SceneType == SceneTypes.Exam)
		{
			Renderer.sprite = Exam;
		}
		else if(SceneType == SceneTypes.Festival)
		{
			Renderer.sprite = Festival;
		}
		else if(SceneType == SceneTypes.Christmas)
		{
			Renderer.sprite = Christmas;
		}
		else if(SceneType == SceneTypes.BoardGameJam)
		{
			Renderer.sprite = BoardGameJam;
		}
		else if(SceneType == SceneTypes.GStar)
		{
			Renderer.sprite = GStar;
		}
		else if(SceneType == SceneTypes.SpringMT)
		{
			Renderer.sprite = SpringMT;
		}
		else if(SceneType == SceneTypes.SummerMT)
		{
			Renderer.sprite = SummerMT;
		}
		else if(SceneType == SceneTypes.AutumnMT)
		{
			Renderer.sprite = AutumnMT;
		}
		else if(SceneType == SceneTypes.WinterMT)
		{
			Renderer.sprite = WinterMT;
		}
		else if(SceneType == SceneTypes.Drink)
		{
			Renderer.sprite = Drink;
		}
		else if(SceneType == SceneTypes.Dinner)
		{
			Renderer.sprite = Dinner;
		}
	}

	void ActivateCutSceneEffect()
	{
		if(SceneType == SceneTypes.Valentine)
		{
			foreach(Character Mem in Var.Mems)
			{
				if(Mem.Lovers.Count != 0)
				{
					Mem.Loyalty += 5;
				}
			}
		}
		else if(SceneType == SceneTypes.Festival)
		{
			foreach(Character Mem in Var.Mems)
			{
				Mem.Loyalty += Mem.Friends.Count*3;
			}
		}
		else if(SceneType == SceneTypes.Festival)
		{
			foreach(Character Mem in Var.Mems)
			{
				if(Mem.Lovers.Count == 0)
				{
					Mem.Loyalty += 10;
				}
			}
		}
		else if(SceneType == SceneTypes.BoardGameJam)
		{
			foreach(Character Mem in Var.Mems)
			{
				Mem.Plan += 3;
			}
		}
		else if(SceneType == SceneTypes.BoardGameJam)
		{
			foreach(Character Mem in Var.Mems)
			{
				Mem.Plan += 1;
				Mem.Programming += 1;
				Mem.Art += 1;
				Mem.Sound += 1;

				if(Mem.Tal == Character.Talents.Plan)
				{
					Mem.Plan += 1;
				}
				else if(Mem.Tal == Character.Talents.Programming)
				{
					Mem.Programming += 1;
				}
				else if(Mem.Tal == Character.Talents.Art)
				{
					Mem.Art += 1;
				}
				else if(Mem.Tal == Character.Talents.Sound)
				{
					Mem.Sound += 1;
				}
			}
		}
	}

	void EndCutScene()
	{
		Destroy (Notice.gameObject);
		Destroy (gameObject);
	}
}