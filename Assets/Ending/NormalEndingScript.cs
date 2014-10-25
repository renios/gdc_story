using UnityEngine;
using System.Collections;

public class NormalEndingScript : MonoBehaviour 
{
	public TextMesh Text;
	
	int Page;
	
	void Start()
	{
		Text.text = "4년 동안, GDC는 조금씩이나마 괜찮은 게임을 만들기 시작하였고,\n무난하게 운영되어 정착에 성공하였다.";
	}
	
	void OnMouseDown()
	{
		Page += 1;
		if(Page == 1)
		{
			Text.text = "(오랜 시간이 흘렀다. 내가 처음 회장이 되었을 때에는 정말 암울한 동아리였는데...\n어떻게든 잘 살려낸 것 같군.";
		}
		else if(Page == 2)
		{
			Text.text = "'회장님, 어서 총회를 시작하시죠.'";
		}
		else if(Page == 3)
		{
			Text.text = "회장 : '그래야지. 자, 신입 분들부터 자기소개를 해 주세요.'";
		}
		else if(Page == 4)
		{
			Text.text = "'네, 저는 18학번 김정열입니다.\n어렸을 때부터 게임을 만드는 게 꿈이라서 가입했어요!'";
		}
		else if(Page == 5)
		{
			Application.LoadLevel("Credit");
		}
	}
}