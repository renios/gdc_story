using UnityEngine;
using System.Collections;

public class CloseOption : MonoBehaviour {

	public GameObject OptionButtonPrefab;

	void OnMouseUpAsButton()
	{
		Instantiate (OptionButtonPrefab);
		Destroy(transform.parent.gameObject);
	}
}
