using UnityEngine;
using System.Collections;

public class Parameters : MonoBehaviour 
{
	GlobalVariables Variables;

	public TextMesh Text;

	void Start () 
	{
		Variables = GlobalVariables.GetInstance ();
	}

	void Update () 
	{
		Text.text = Variables.Year + "년 " + Variables.Month + "월 " + Variables.Day;
	}
}
