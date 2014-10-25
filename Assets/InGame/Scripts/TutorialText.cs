using UnityEngine;
using System.Collections;

public class TutorialText : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public int Page;

	public TextMesh Text;

	public BoxCollider2D Collider;
	public Renderer ChiefRenderer;
	public Renderer TextBoxRenderer;

	public Question QuestionPrefab;
	Question QuestionInstance;

	void OnMouseDown()
	{
		Page += 1;
		if(Page == 1)
		{
			Collider.enabled = false;
			Var.Mng.MenuButton.SendMessage("Blink");
		}
		else if(Page == 11 || Page == 17 || Page == 22 || Page == 31)
		{
			Collider.enabled = false;
		}
		else if(Page == 20)
		{
			Collider.enabled = false;
			Var.Mng.Wb.SendMessage("Blink");
		}
		else if(Page == 28)
		{
			Collider.enabled = false;
			Var.Mng.Sb.SendMessage("Blink");
		}
		else if(Page == 36)
		{
			Collider.enabled = false;

			GameObject[] Calendars = GameObject.FindGameObjectsWithTag("Calendar");
			foreach(GameObject Calendar in Calendars)
			{
				Calendar.SendMessage("Blink");
			}
		}
		else if(Page == 43)
		{
			Collider.enabled = false;
			GameObject.FindGameObjectWithTag("Door").SendMessage("Blink");
		}
		else if(Page == 46)
		{
			Collider.enabled = false;
			QuestionInstance = Instantiate(QuestionPrefab) as Question;
			QuestionInstance.QuestionType = Question.QuestionTypes.ClbIntro;
		}
		else if(Page == 53)
		{
			Var.OnTutorial = false;
			Destroy(gameObject);
			Destroy(Var.Mng.Chief.gameObject);
		}
	}

	void Update()
	{
		if(Page == 0)
		{
			Text.text = "이런... 이제 회원도 3명 밖에 남지 않았구나...\n그래도 힘내보자 회장! 긍정적으로 생각하자!\n어중이떠중이들이 걸러지고 진짜배기만 남았을 테니까!";
		}
		else if(Page == 1)
		{
			Text.text = "자, 그러면 기초적인 설명을 해줄게.\n메뉴 탭을 눌러볼래?\n메뉴 탭은 왼쪽에 길게 있을 거야.";
		}
		else if(Page == 2)
		{
			Text.text = "맨 위에 있는 '자금'은 GDC가 가진 현재 자금을 보여줘. 자금 탭을 눌러볼래?";
		}
		else if(Page == 3)
		{
			Text.text = "짠! 가계부가 나온다구? 여기에서는 지금까지 수입과 지출 내역을 확인할 수 있어.\n지금은 아무것도 없지만, 앞으로 돈을 벌고 쓰게 되면 채워질 거야.\n아무데나 누르면 사라져. 닫아 볼래?";
		}
		else if(Page == 4)
		{
			Text.text = "그러면 이번에는 회원 탭을 눌러봐.";
		}
		else if(Page == 5)
		{
			Text.text = "여기서는 현재 동아리 회원에 대한 정보를 한 눈에 볼 수 있지.\n마찬가지로 아무데나 누르면 닫을 수 있어. 쉽지?";
		}
		else if(Page == 6)
		{
			Text.text = "자! 그럼 이번엔 명성 탭을 확인해보자.";
		}
		else if(Page == 7)
		{
			Text.text = "여기서는 지금까지 이룩한 업적을 볼 수 있어.\n당연히 업적 달성은 좋은 게임을 만드는 게 핵심이지만,\n잘 찾아보면 그것 말고도 생각보다 다양한 길이 있다는 걸 알아둬.";
		}
		else if(Page == 8)
		{
			Text.text = "아, 업적 창은 종류별로 하나씩 총 4페이지야.\n업적 창의 아무데나 누르면 다음 페이지로 넘어가지.\n마지막 페이지에서 다시 누르면 저절로 닫혀.";
		}
		else if(Page == 9)
		{
			Text.text = "끝까지 보지 않고 바로 닫으려면 창 바깥을 누르면 돼.";
		}
		else if(Page == 10)
		{
			Text.text = "참고로 첫 페이지에 있는 것들은 반복 달성이 가능해서 달성 횟수가 표시되고,\n나머지 것들은 한 번만 달성할 수 있어서 OX로 달성여부만 표시돼.";
		}
		else if(Page == 11)
		{
			Text.text = "그럼 업적 확인하는 방법도 알려줬으니 이제 업적창도 끄자.\n어느 쪽 방법이든 좋으니 편한 대로 해 봐.";
		}
		else if(Page == 12)
		{
			Text.text = "자, 그럼 메뉴 설명의 마지막.\n업그레이드 탭을 눌러볼래?";
		}
		else if(Page == 13)
		{
			Text.text = "여기에서는 새로운 물건을 사거나 기존의 물건을 업그레이드할 수 있어.\n일종의 상점과 같지!\n여기 있는 것들은 돈뿐만 아니라 명성도 정해진 수준을 넘어야 살 수 있어.";
		}
		else if(Page == 14)
		{
			Text.text = "살 때 돈은 없어지지만 명성은 사라지지 않으니 걱정 말라구?\n동아리방 크기는 최대 동아리원 수 제한과 관련이 있을 뿐만 아니라,\n가구 업그레이드에도 필요하니 되도록 잘 하는 게 좋을 거야.";
		}
		else if(Page == 15)
		{
			Text.text = "가구를 업그레이드하면 같은 행동을 해도 능력치가 더 많이 오르지!\n효율이 좋아진다구.\n그러니 되도록 많이 투자하도록!";
		}
		else if(Page == 16)
		{
			Text.text = "물건 그림을 누르면 지를지 말지를 묻는 창이 뜨고, 그 다음은 알지?\n어차피 지금은 살 수 있는 게 없지만 말이지...";
		}
		else if(Page == 17)
		{
			Text.text = "그럼 업그레이드에 대한 설명도 끝이야.\n이것도 아무데나 빈 곳을 누르면 닫혀.\n참고로 앞으로도 대부분의 팝업창은 그냥 빈 곳을 누르면 닫힐 거야.";
		}
		else if(Page == 18)
		{
			Text.text = "자, 그럼 여기까지. 메뉴에 대한 설명은 끝이야. 자, 메뉴는 닫아두자구.\n메뉴를 편 상태에서 빈 곳을 아무데나 누르면 닫히니까.";
		}
		else if(Page == 19)
		{
			Text.text = "그럼 이번엔 회원들에게 활동을 시켜보자.\n방금 화면에 새로 들어온 내가 보이니?";
		}
		else if(Page == 20)
		{
			Text.text = "연습해 보는 거야. 나를 저기 있는 칠판으로 드래그해 줘.";
		}
		else if(Page == 21)
		{
			Text.text = "잘했어! 활동을 설정한 회원은 '...'이라는 말풍선이 떠.\n구분하기 쉽지?\n활동을 해야 능력치가 올라가니까, 모두에게 가능한 한 뭔가를 시키는 게 좋아.";
		}
		else if(Page == 22)
		{
			Text.text = "그런데, 혹시 2명이 같은 활동을 할 수 있다는 것도 알고 있니?\n역시 해보는 게 가장 좋겠지.\n이번엔 나 말고 다른 애를 아무나 칠판으로 데려와 볼래?";
		}
		else if(Page == 23)
		{
			Text.text = "이렇게 하면 나랑 이 친구는 같은 활동을 하게 되는 거야.\n이 때는 둘의 능력치뿐만 아니라, 오르는 게 하나 더 있어.";
		}
		else if(Page == 24)
		{
			Text.text = "바로 '관계도'야! 둘이 얼마나 사이가 좋은지를 의미하지.\n사이가 좋아지면 친구나 연인이 되는데, 그러면 좋은 게 있어.\n어떤 이벤트랑 효과냐고? 안 가르쳐 주지! 직접 해 보면서 익히도록!";
		}
		else if(Page == 25)
		{
			Text.text = "관계도는 동아리 전체에 대한 것이 아니고 모든 캐릭터와 캐릭터 사이마다 존재해.\n회원이 3명이라면 A와 B, B와 C, 그리고 C와 A 사이에 총 3개의 관계도가 있는 거지!\n마찬가지로 4명이라면 6개, 5명이면 10개... 이해가 되니?";
		}
		else if(Page == 26)
		{
			Text.text = "다음은 활동 변경이야.\n이미 활동을 시켰는데, 생각이 바뀌어서 다른 걸 시키고 싶을 수도 있잖아?\n그럴 때를 위해서 다 방법이 있지!";
		}
		else if(Page == 27)
		{
			Text.text = "방법은 간단해.\n활동 설정과 마찬가지로 이미 설정된 회원을 드래그해서 옮기기만 하면 끝!";
		}
		else if(Page == 28)
		{
			Text.text = "직접 해 보는 게 중요하지!\n이번엔 나를 저기 탁자에 있는 스케치북으로 옮겨 줘.";
		}
		else if(Page == 29)
		{
			Text.text = "자, 엄청 쉽지? 참고로, 행동을 아예 취개개해서 아무것도 시키지 않을 수도 있어.\n이것도 마찬가지 방법으로 드래그를 해서, 가구가 없는 땅바닥에 내려놓으면 돼.\n이건 직접 시키진 않을 테니까, 그냥 알아둬.";
		}
		else if(Page == 30)
		{
			Text.text = "그러고 보니 깜빡했네. 지금 회원이 누가 누군지도 모르는구나?\n아까 메뉴에서 회원 목록을 보는 방법은 배웠지?\n그럼 이번엔 회원 각자를 확인할 거야.";
		}
		else if(Page == 31)
		{
			Text.text = "더블클릭! 회원을 더블클릭하면 상세 정보를 볼 수 있지!\n아무나 붙잡고 정보를 한번 확인해봐.";
		}
		else if(Page == 32)
		{
			Text.text = "쉽지? 정보창도 그냥 누르면 사라져.\n자, 앞으로도 알려줄 거 꽤 많이 남았으니 빨리 하자.\n정보창도 다시 끄렴.";
		}
		else if(Page == 33)
		{
			Text.text = "하다 보면 행동에 문제가 생기거나 할 때가 있어.\n그럴 땐 오른쪽 위의 새로고침을 누르면 돼.\n그러면 모든 회원의 활동이 취소되지. 해볼까?";
		}
		else if(Page == 34)
		{
			Text.text = "짠! 모든 회원들의 말풍선이 사라졌지?\n모든 회원들의 활동이 취소됐다는 증거야.";
		}
		else if(Page == 35)
		{
			Text.text = "아! 그러고 보니 말을 안 했네.\n오른쪽 아래에 있는 톱니바퀴를 누르면 메뉴가 나올 거야.\n여기서 세이브/로드도 할 수 있는데, 이 때도 모든 회원들의 활동이 취소돼. 알아둬.";
		}
		else if(Page == 36)
		{
			Text.text = "자, 드디어 진행을 할 때가 왔어.\n지금까지 배운 방법으로 배정했던 활동을 직접 시키는 거지.\n동아리방 안에 있는 달력, 또는 바깥에 있는 진행 버튼을 누르면 돼. 직접 해보자.";
		}
		else if(Page == 37)
		{
			Text.text = "혹시 위에 있던 '2월 말'이 '3월 초'로 바뀐 거 눈치챘니?\n시간이 지나간 거야.\n한 달은 초, 중, 말, 3개로 나뉘어.";
		}
		else if(Page == 38)
		{
			Text.text = "따라서 1년에 최대 36번의 활동을 할 수 있는 거지.\n물론 시험기간 같은 때는 못 할 수도 있지만...";
		}
		else if(Page == 39)
		{
			Text.text = "아까 활동을 하면 능력치가 오른다고 이야기했지?\n동아리원의 능력치는 총 4가지야. 기획, 개발, 아트, 사운드.\n어떤 활동을 하느냐에 따라 오르는 능력치도 달라지지.";
		}
		else if(Page == 40)
		{
			Text.text = "칠판은 기획, 컴퓨터는 개발, 스케치북은 아트, 악보책은 사운드!\n직관적으로 이해할 수 있을 거야.\n나중에는 다른 가구도 생길 텐데, 그것들은 여러 능력치가 복합적으로 올라가.";
		}
		else if(Page == 41)
		{
			Text.text = "그러니까 부지런히 공부하고 열심히 게임을 만들어야지!\n그래서 상금과 명성을 얻고, 그걸 바탕으로 더 좋은 동아리를 만들고!\n그럼 더 좋은 게임이 나오고! 무한한 선순환! 이것이 궁극적인 목표다!";
		}
		else if(Page == 42)
		{
			Text.text = "하지만 주의해. 활동을 하게 되면 충성도가 줄어들게 돼...\n회원의 충성도가 얼마인지는 더블클릭의 상세정보창에서 확인할 수 있어.";
		}
		else if(Page == 42)
		{
			Text.text = "충성도가 0 미만이 될 경우 그 회원은 동아리를 떠나버리게 되니까 조심해.\n회원이 탈퇴하면 남은 회원들의 충성도도 떨어져.\n게다가 회원이 다 떠나버리면 동아리는 폐부되어 버린다구?";
		}
		else if(Page == 43)
		{
			Text.text = "그러니까 충성도 관리를 잘 해야겠지?\n충성도를 올리고 싶으면 단체 활동을 할 수 있어.\n단체활동을 하려면 일단 밖으로 나가야겠지? 문을 눌러봐.";
		}
		else if(Page == 44)
		{
			Text.text = "일단 회식을 해볼까?";
		}
		else if(Page == 45)
		{
			Text.text = "충성도를 올리는 것도 다 돈이야. 명심하도록 해!";
		}
		else if(Page == 46)
		{
			Text.text = "이제 새 학기가 되었으니 동아리 홍보를 해보자!\n'예'를 눌러봐.";
		}
		else if(Page == 47)
		{
			Text.text = "오오! 게임 개발을 하겠다는 신입이 들어왔어! 힘내자!\n신입 회원은 매 학기 초에 모집할 수 있어.";
		}
		else if(Page == 48)
		{
			Text.text = "홍보를 하지 않아도 신입은 들어오긴 해.\n그래도 홍보를 하면 신입이 더 많이 올 가능성이 생기지.\n5만원이 드니까 비용을 잘 고려해서 결정하면 될 거야.";
		}
		else if(Page == 49)
		{
			Text.text = "우선 우리의 목표는 <NOXEN 게임 공모전>이야.\n매 학기 말에 회원 네 명이 팀을 이뤄서 도전할 수 있지.\n네 명이 아니어도 참가할 수는 있지만, 우승하기는 힘들겠지?";
		}
		else if(Page == 50)
		{
			Text.text = "네 명은 각자 기획, 코딩, 아트, 사운드 분야를 담당하게 돼.\n각자 잘 하는 분야에 사람을 배치하면 유리하겠지?\n우승하면 상금과 명성을 얻을 수 있어! 대단하지?";
		}
		else if(Page == 51)
		{
			Text.text = "훌륭한 게임을 만들어서 수상을 하면 상금과 명성을 얻을 수 있어.\n동아리 부흥과 직결되는 아주 중요한 일이야!! 알겠지?";
		}
		else if(Page == 52)
		{
			Text.text = "자, 그러면 이제 직접 동아리를 운영해볼까 차기 회장?\n그럼 나는 이만!";
		}
	}

	void ActivateRenderer()
	{
		renderer.enabled = true;
		ChiefRenderer.enabled = true;
		TextBoxRenderer.enabled = true;
	}

	void DeActivateRenderer()
	{
		renderer.enabled = false;
		ChiefRenderer.enabled = false;
		TextBoxRenderer.enabled = false;
	}
}
