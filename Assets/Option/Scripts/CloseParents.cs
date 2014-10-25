using UnityEngine;
using System.Collections;

public class CloseParents : MonoBehaviour {

	void OnMouseUpAsButton(){
		Destroy(transform.parent.gameObject);
	}
}
