using UnityEngine;
using System.Collections;

public class ToOption : MonoBehaviour {

	void Update () {
	
	}
	void OnMouseUpAsButton(){
		Destroy(transform.parent.gameObject);
	}
}
