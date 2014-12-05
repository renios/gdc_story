using UnityEngine;
using System.Collections;

public class SpecAbil : MonoBehaviour
{
	GlobalVariables Var = GlobalVariables.GetInstance ();
	
	public TextMesh Text;

	public enum SpecAbils
	{
		Orchid,
		Burung,
		Gon,
		Eugene,
		Center,
		Oreo,
		Worker,
		Bridge,
		M,
		Yomi,
		Tuna,
		Soon,
		PenPen,
		Nemo,
		Troll,
	}

	public SpecAbils Special;

	public int BrokenPjNum;

	IEnumerator Start()
	{
		if(Special == SpecAbils.Orchid)
		{
			Text.text = "오키드를 제외한 팀원들 사이의 친밀도가 증가합니다!";
		}
		else if(Special == SpecAbils.Burung)
		{
			Text.text = "부렁봇의 충성도가 크게 증가합니다!";
		}
		else if(Special == SpecAbils.Eugene)
		{
			Text.text = "이유진이 방학 동안 사라집니다!";
		}
		else if(Special == SpecAbils.Center)
		{
			Text.text = "쎈타가 롤을 하느라 일을 하지 않습니다!";
		}
		else if(Special == SpecAbils.Oreo)
		{
			Text.text = "오레오의 능력으로 더 저렴하게 구입합니다!";
		}
		else if(Special == SpecAbils.Worker)
		{
			Text.text = "??";
		}
		else if(Special == SpecAbils.Yomi)
		{
			Text.text = "요미가 일하다 말고 징징거리느라 능력치가 떨어집니다!";
		}
		else if(Special == SpecAbils.PenPen)
		{
			Text.text = "펜펜이 술을 마시고 한동안 각성 상태가 됩니다!";
		}
		else if(Special == SpecAbils.Troll)
		{
			Text.text = "트롤러가 "+BrokenPjNum+"번째 프로젝트를 폭파시킵니다!";
		}
		
		yield return new WaitForSeconds(2.0f);
		
		Destroy (gameObject);
	}
}