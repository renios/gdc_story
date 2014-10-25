using UnityEngine;
using System.Collections;

public class LowerText : MonoBehaviour {
	private string text;
	private bool display=false;
	public GUIStyle guistyle;
		
	// Use this for initialization
	void Start () {
		text="Hello world!\nhmmm...\nAhhhhhhh";
	}

	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){
		if (display) {
			GUI.Box (new Rect (Screen.width*0.07f, Screen.height*0.7f, Screen.width*0.85f, Screen.height*0.25f), text,guistyle);
		}
	}
}
