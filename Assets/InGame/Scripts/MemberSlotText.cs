using UnityEngine;
using System.Collections;

public class MemberSlotText : MonoBehaviour 
{
	GlobalVariables Variables = GlobalVariables.GetInstance ();

	public TextMesh Text;

	public MemberSlot Parent;

	void SetText()
	{
		Text.text = Variables.Mems [Parent.IndexNumber].Name + " 기획 : " + Variables.Mems [Parent.IndexNumber].Abilities[0] + " 프로그래밍 : " + Variables.Mems [Parent.IndexNumber].Abilities[1];
		Text.text += " 아트 : " + Variables.Mems [Parent.IndexNumber].Abilities[2] + " 사운드 : " + Variables.Mems [Parent.IndexNumber].Abilities[3];
	}
}