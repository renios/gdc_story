using UnityEngine;
using System.Collections;

public class MoneyPrint : MonoBehaviour {

	GlobalVariables Variables;
	
	public TextMesh Text;
	
	void Start () 
	{
		Variables = GlobalVariables.GetInstance ();
	}
	
	void Update () 
	{
		Text.text = "자금  " + Variables.Money+"만원";
	}
}
