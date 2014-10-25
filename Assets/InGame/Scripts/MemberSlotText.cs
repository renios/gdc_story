using UnityEngine;
using System.Collections;

public class MemberSlotText : MonoBehaviour 
{
	GlobalVariables Variables = GlobalVariables.GetInstance ();

	public TextMesh Text;

	public MemberSlot Parent;

	void SetText()
	{
		Text.text = Variables.Mems [Parent.IndexNumber].Name + " 기획 : " + Variables.Mems [Parent.IndexNumber].Plan + " 프로그래밍 : " + Variables.Mems [Parent.IndexNumber].Programming;
		Text.text += " 아트 : " + Variables.Mems [Parent.IndexNumber].Art + " 사운드 : " + Variables.Mems [Parent.IndexNumber].Sound;
	}
}