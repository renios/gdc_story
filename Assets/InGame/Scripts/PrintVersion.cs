using UnityEngine;
using System.Collections;

public class PrintVersion : MonoBehaviour {

	string verNumber;
	TextMesh textMesh;
	
	// Use this for initialization
	void Start () {
//		textMesh = GetComponentInParent<TextMesh> ();
//		verNumber = UnityEditor.PlayerSettings.bundleVersion;
//
//		textMesh.text = "Ver " + verNumber;
		Debug.Log (verNumber);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
