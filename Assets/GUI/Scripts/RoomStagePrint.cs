using UnityEngine;
using System.Collections;

public class RoomStagePrint : MonoBehaviour {

	GlobalVariables Variables = GlobalVariables.GetInstance ();
	
	public TextMesh Text;
	
	void Update () 
	{
		Text.text = "업그레이드";
	}
}
