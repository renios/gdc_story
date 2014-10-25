using UnityEngine;
using System.Collections;

public class BestEnding : MonoBehaviour 
{
	public TextMesh Text;
	
	int Page;
	
	void Start()
	{
		Text.text = "4년 동안, GDC는 게임성, 작화, 음악 모든 면에서 훌륭한 게임을 다수 발표하였다.\n국내에서 게임에 관심이 있는 사람이라면 GDC를 모르는 사람이 없었다.";
	}
	
	void OnMouseDown()
	{
		Page += 1;
		if(Page == 1)
		{
			Text.text = "GDC가 최근에 발표한 게임은 세계적 권위의 인디게임 페스티벌에서 대상을 탔다.\nGDC는 상금과 게임 판매 수익으로 동방을 50평형 오피스로 옮기고 호화롭게 꾸몄다.";
		}
		else if(Page == 2)
		{
			Text.text = "'회장님, 이번 달에 졸업하시는데 앞으로 뭘 하실 생각이신가요?'";
		}
		else if(Page == 3)
		{
			Text.text = "회장 : '실은 오래 전부터 생각해 둔 것이 있어.\n계속해서 게임을 만들고 싶어하는 친구들과 벤처 회사를 차릴 계획이야.'";
		}
		else if(Page == 4)
		{
			Text.text = "GDC의 회장을 비롯한 몇몇 졸업생들은 벤처 게임회사를 차렸다.\n소수의 인원임에도 불구하고 게임계에 혁신을 일으키며,\n점점 성장한 회사는 세계적인 명작들을 배출해 내었다.";
		}
		else if(Page == 5)
		{
			Text.text = "회장이 떠난 GDC도 새로운 회장과 함께 날로 번창해 갔다.";
		}
		else if(Page == 6)
		{
			Application.LoadLevel("Credit");
		}
	}
}