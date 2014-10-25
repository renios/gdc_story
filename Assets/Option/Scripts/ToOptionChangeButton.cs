using UnityEngine;
using System.Collections;

public class ToOptionChangeButton : MonoBehaviour {

	public GameObject ChangeOptionPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseUpAsButton(){
		Instantiate (ChangeOptionPrefab);
	}
}
