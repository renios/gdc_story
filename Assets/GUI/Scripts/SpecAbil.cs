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
	}

	public SpecAbils Special;

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
		else if(Special == SpecAbils.Gon)
		{
			Text.text = "김고니가 제멋대로 행동합니다!";
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
		
		yield return new WaitForSeconds(2.0f);
		
		Destroy (gameObject);
	}
}