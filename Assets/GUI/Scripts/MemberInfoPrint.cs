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
			Text.text += Variables.Mems [IndexNumber].Name + " 기획 : " + Variables.Mems [IndexNumber].Plan + " 프로그래밍 : " + Variables.Mems [IndexNumber].Programming;
			Text.text += " 아트 : " + Variables.Mems [IndexNumber].Art + " 사운드 : " + Variables.Mems [IndexNumber].Sound+" 충성도 : "+Variables.Mems[IndexNumber].Loyalty+"\n";
		}
	}
}