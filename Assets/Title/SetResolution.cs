using UnityEngine;
using System.Collections;

public class SetResolution : MonoBehaviour {

	void Awake () {
		Screen.SetResolution (Screen.height / 9 * 16, Screen.height, true);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
