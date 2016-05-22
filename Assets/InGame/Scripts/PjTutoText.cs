using UnityEngine;
using System.Collections;

public class PjTutoText : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public MakeProject MakePj;
	public ResetProject ResetPj;
	
	public int Page;
	
	public TextMesh Text;

	public BoxCollider2D Collider;
	public Renderer OrchidRenderer;
	public Renderer TextBoxRenderer;

	void OnMouseDown()
	{
		Page += 1;
		if(Page == 3)
		{
			Collider.enabled = false;
			MakePj.SendMessage("Blink");
		}
		else if(Page == 6)
		{
			Collider.enabled = false;
			MakePj.Project1.SendMessage("Blink");
		}
		else if(Page == 10)
		{
			Collider.enabled = false;
			DeActivateRenderer();
		}
		else if(Page == 11 || Page == 15)
		{
			Collider.enabled = false;
		}
		else if(Page == 14)
		{
			ResetPj.SendMessage("Blink");
		}
		else if(Page == 22)
		{
			Var.OnTutorial = false;
			Destroy (gameObject);
		}
	}

	void Update()
	{
		if(Page == 0)
		{
			Text.text = "흠, 한 학기를 무사히 마치고 드디어 첫 프로젝트에 도전할 때가 왔군.";
		}
		else if(Page == 1)
		{
			Text.text = "응? 내가 누구냐고? 난 GDC스토리의 개발자, 코드네임 오키드-버드라고 하지.";
		}
		else if(Page == 2)
		{
			Text.text = "지금부터 프로젝트에 참가하는 법을 알려주겠다.\n반복은 하지 않으니 한번에 잘 듣도록 해.";
		}
		else if(Page == 3)
		{
			Text.text = "자, 우선 프로젝트 팀을 만드는 것부터 해야겠지? ‘프로젝트 팀 생성’을 눌러봐.";
		}
		else if(Page == 4)
		{
			Text.text = "좋아! 프로젝트는 같은 방법으로 총 5개까지 만들 수 있어.\n왜냐고? 그 이상 만들면 시간관계상 발표를 할 수가 없거든.";
		}
		else if(Page == 5)
		{
			Text.text = "프로젝트를 만들었으면 뭘 해야 하지?\n사람! 사람을 모아야지!\n그런 의미에서 이번엔 프로젝트에 회원을 배정해 볼까?";
		}
		else if(Page == 6)
		{
			Text.text = "방금 만들어진 따끈따끈한 ‘프로젝트1’이 보이지?\n저걸 누르면 그 프로젝트에 회원을 배정할 수 있어.";
		}
		else if(Page == 7)
		{
			Text.text = "우선 아래쪽에는 회원 목록이 나온 게 보일 거야.\n왼쪽과 오른쪽 화살표를 누르면 앞뒤로 넘길 수 있지.\n회원이 3명보다 많다면 필요한 기능이니까 알아둬.";
		}
		else if(Page == 8)
		{
			Text.text = "그런 식으로 원하는 회원을 찾은 다음,\n그 회원의 그림을 시키고 싶은 직군에 드래그해서 올려놓으면 끝! 쉽지?";
		}
		else if(Page == 9)
		{
			Text.text = "그럼, 원하는 회원을 아무데나 배치해볼래?";
		}
		else if(Page == 10)
		{
			Text.text = "좋았어! 이런 식으로 나머지 직군들도 배치하면 돼.\n물론 꽉 채울 필요는 없지만...\n4명이 다 있을 경우에 비해 게임의 질이 떨어지는 건 당연하겠지?";
		}
		else if(Page == 11)
		{
			Text.text = "그럼 다시 설정창을 빠져나가보자. 빈 곳을 누르면 사라질 거야.";
		}
		else if(Page == 12)
		{
			Text.text = "간단하지? 하다 말고 닫아도 나중에 다시 창을 열어서 배치할 수 있으니까,\n굳이 한번에 다 배정하려고 노력할 필요는 없어.";
		}
		else if(Page == 13)
		{
			Text.text = "자, 그러면 잘못 배치했을 때는 어떻게 하느냐고?\n그것도 다 방법이 있다는 말씀!";
		}
		else if(Page == 14)
		{
			Text.text = "저기 있는 '모든 팀 초기화' 버튼이 보일 거야.\n저걸 누르면 모든 회원 배치 설정과 프로젝트가 삭제돼.\n그러고 나서 처음부터 다시 프로젝트를 만들고 회원을 배정하면 되는 거지.";
		}
		else if(Page == 15)
		{
			Text.text = "그럼 한번 '모든 팀 초기화' 버튼도 눌러 보자.";
		}
		else if(Page == 16)
		{
			Text.text = "어때? 모든 프로젝트가 지워졌지?";
		}
		else if(Page == 17)
		{
			Text.text = "좋아! 이제 필요한 건 다 알려준 것 같군.\n지금까지 알려준 방법으로 프로젝트를 잘 만들어 봐.\n그리고 마무리로 '공모전 참가'를 누르면 돼.";
		}
		else if(Page == 18)
		{
			Text.text = "프로젝트 끝내기를 누르면 채점을 하게 될 거야.\n각 직군에 배정된 회원은 자기의 담당 능력치가 가장 중요하지만,\n나머지 능력치들도 점수에 어느 정도는 영향을 미치지.";
		}
		else if(Page == 19)
		{
			Text.text = "프로젝트가 여러 개라면 보상을 중첩해서 받을 수 있어.\n만약 3개의 프로젝트를 제출해서 하나는 1등, 두 개는 2등을 했다면,\n총 상금은 {(1등 상금) + 2 x (2등 상금)}이 되는 거지.";
		}
		else if(Page == 20)
		{
			Text.text = "예상했겠지만 명성도 똑같은 방식이야.\n그러니 좋은 인재가 넘쳐난다면 프로젝트를 많이 열어서 보상을 휩쓸 수 있겠지?";
		}
		else if(Page == 21)
		{
			Text.text = "...그럼 내 설명은 여기까지야. 행운을 빌지.\n네가 한 학기 동안 동아리를 잘 운영했다면 또 만나게 될 지도. 그럼 이만!";
		}
	}

	void ActivateRenderer()
	{
		GetComponent<Renderer>().enabled = true;
		OrchidRenderer.enabled = true;
		TextBoxRenderer.enabled = true;
	}
	
	void DeActivateRenderer()
	{
		GetComponent<Renderer>().enabled = false;
		OrchidRenderer.enabled = false;
		TextBoxRenderer.enabled = false;
	}
}