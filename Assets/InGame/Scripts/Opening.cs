using UnityEngine;
using System.Collections;

public class Opening : MonoBehaviour 
{
	GlobalVariables Variables = GlobalVariables.GetInstance ();

	public TextMesh Text;

	public BoxCollider2D Collider;

	int Page;

	void Start()
	{
		Text.text = "게임 개발 동아리 GDC.\n역사는 그리 길지 않지만, 재미있고 유명한 게임을 수없이 제작하여\n게임계에서는 떠오르는 샛별로 주목 받고 있는 동아리였다.\n교내외의 다양한 활동에 참가하여 명성을 드높였고,\n학교뿐만 아니라 많은 기업들의 후원을 받아\n빵빵한 시설과 회원들의 호화로운 생활을 자랑하며,\n안정적인 직장마저 보장 받는 최고 인기 동아리.\n그러나 GDC의 찬란한 시대도 이제 끝을 고하고 있었다…….";
	}

	void OnMouseDown()
	{
		Page += 1;
		if(Page == 1)
		{
			Text.text = "게임 규제의 강화와 계속해서 나빠져 가는 게임에 대한 인식 때문에\nGDC를 향한 지원금은 점차 줄어갔다. \n동아리방을 가득 채웠던 컴퓨터, 게임기기, 생활 용품들은\n눈물을 머금고 전부 처분해야만 했고,\n결국은 GDC가 자랑하던 넓디넓은 동아리방마저 \n월세를 내지 못해 다른 사람의 손에 넘어가게 된다.\n실적을 내지 못해 중앙 동아리 자리마저 박탈당하고\n지금까지 누려왔던 각종 특권도 전부 잃어버린다.";
		}
		else if(Page == 2)
		{
			Text.text = "“잠깐! 다들 어딜 가는 거야?”\n“죄송합니다, 회장. 하지만 이 동아리에는 미래가 없어요.”\n“차라리 치킨 개발 동아리 CDC에 들어가는 편이 취직이 잘될 겁니다.”\n“이번 달 회비는 드리겠습니다. 마지막 회식하는 데라도 쓰세요.”\n“크윽……. 우리 동아리가……. 이렇게 끝날 순 없어!”";
		}
		else if(Page == 3)
		{
			Text.text = "돈도 명예도 시설도 사람도 잃어버린 GDC…….\n이런 상황에서 막 회장이 된 당신…….\n당신은 결국 전 회장에게 동아리 운영을 배우기로 한다.";
		}
		else if(Page == 4)
		{
			Text.text = "과연 당신은 폐쇄 직전의 동아리를 이끌어\nGDC를 다시 영광의 동아리로 돌려놓을 수 있을까?\n지금 당신이 이끄는 GDC의 이야기가 시작된다.";
		}
		else if(Page == 5)
		{
			Application.LoadLevel("InGame");
		}
	}
}