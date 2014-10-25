using UnityEngine;
using System.Collections;

public class CallOptionButton : MonoBehaviour {

	public GameObject OptionPrefab;

	void OnMouseUpAsButton(){
		Instantiate (OptionPrefab);
		Destroy (gameObject);
	}
}