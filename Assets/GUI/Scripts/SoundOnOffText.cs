using UnityEngine;
using System.Collections;

public class SoundOnOffText : MonoBehaviour
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public TextMesh Text;
	
	void Update()
	{
		if(Var.Mng.BGM.enabled == true)
		{
			Text.text = "            끄기";	
		}
		else
		{
			Text.text = "            켜기";
		}
	}
}