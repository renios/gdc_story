using UnityEngine;
using System.Collections;

public class MemberInfoPrint : MonoBehaviour {

	GlobalVariables Variables = GlobalVariables.GetInstance ();

	public TextMesh Text;

	public GameObject SingleMemberInfoPrefab;
	
	public int IndexNumber;
	
	void Start()
	{
		for(IndexNumber=0;IndexNumber<Variables.Mems.Count;IndexNumber++)
		{
			Text.text += Variables.Mems [IndexNumber].Name + " 기획 : " + Variables.Mems [IndexNumber].Abilities[0] + " 프로그래밍 : " + Variables.Mems [IndexNumber].Abilities[1];
			Text.text += " 아트 : " + Variables.Mems [IndexNumber].Abilities[2] + " 사운드 : " + Variables.Mems [IndexNumber].Abilities[3]+" 충성도 : "+Variables.Mems[IndexNumber].Loyalty+"\n";
		}
	}
}