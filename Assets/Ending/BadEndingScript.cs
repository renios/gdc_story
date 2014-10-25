using UnityEngine;
using System.Collections;

public class BadEndingScript : MonoBehaviour 
{
	public TextMesh Text;
	
	int Page;
	
	void Start()
	{
		Text.text = "4년 동안, GDC는 제대로 된 결과물도 내지 못한 채 근근이 운영되었다.";
	}
	
	void OnMouseDown()
	{
		Page += 1;
		if(Page == 1)
		{
			Text.text = "학교 내에 이름도 알려지지 않았기 때문에 신입도 거의 들어오지 않았다.";
		}
		else if(Page == 2)
		{
			Text.text = "회장 : '지금까지 버텨온 것도 기적이다. 아무래도 동아리 부흥은 무리였던 건가...'";
		}
		else if(Page == 3)
		{
			Text.text = "'열정만 가지고 이 동아리에 가입했지만 역시 여기에는 희망이 없군요.\n저는 나가겠습니다.'";
		}
		else if(Page == 4)
		{
			Text.text = "'저도 여기에서 대체 뭘 했는지 모르겠군요.\n녹슨프로젝트에서 한 번이라도 우승하고 싶었는데...\n시간낭비는 그만두겠습니다.'";
		}
		else if(Page == 5)
		{
			Text.text = "회장 : '안 돼... GDC는 망했다...'";
		}
		else if(Page == 6)
		{
			Text.text = "'그렇습니다. 우리는 망했습니다...'";
		}
		else if(Page == 7)
		{
			Application.LoadLevel("Credit");
		}
	}
}