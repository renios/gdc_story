using UnityEngine;
using System.Collections;

public class MembersNumberPrint : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();
	
	public TextMesh Text;

	void Update () 
	{
		Text.text = "회원수 " + Var.Mems.Count + "명";
	}
}