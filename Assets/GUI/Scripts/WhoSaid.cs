using UnityEngine;
using System.Collections;

public class WhoSaid : MonoBehaviour {
	private string speaker;
	private bool display=false;
	public GUIStyle guistyle;
	
	// Use this for initialization
	void Start () {
		speaker="전회장";
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI(){
		if (display) {
			GUI.Box (new Rect (Screen.width*0.05f, Screen.height*0.6f, Screen.width*0.3f, Screen.height*0.1f),speaker,guistyle);
		}
	}
}
