using UnityEngine;
using System.Collections;

public class FamePrint : MonoBehaviour {

	GlobalVariables Variables;
	
	public TextMesh Text;
	
	void Start () 
	{
		Variables = GlobalVariables.GetInstance ();
	}
	
	void Update () 
	{
		Text.text = "명성  " + Variables.Fame;
	}
}
