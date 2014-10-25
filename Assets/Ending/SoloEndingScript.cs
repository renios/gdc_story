using UnityEngine;
using System.Collections;

public class SoloEndingScript : MonoBehaviour 
{
	public TextMesh Text;

	int Page;

	void Start()
	{
		Text.text = "회장 : 그럼 총회를 시작하겠습니다.";
	}

	void OnMouseDown()
	{
		Page += 1;
		if(Page == 1)
		{
			Text.text = "회장 : ...아무도 없나...";
		}
		else if(Page == 2)
		{
			Text.text = "회장 : 나밖에 남지 않은 건가...";
		}
		else if(Page == 3)
		{
			Text.text = "회장 : 으흑흑...";
		}
		else if(Page == 4)
		{
			Text.text = "회장은 동아리 자금으로 혼자 마지막 회식을 하고 동아리를 그만두었다.";
		}
		else if(Page == 5)
		{
			Text.text = "GDC는 그렇게 역사의 뒤안길로 사라졌다...";
		}
		else if(Page == 6)
		{
			Application.LoadLevel("Credit");
		}
	}
}