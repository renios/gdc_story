using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public int speed=1;
	public float endY=24;
	private float wait=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y >= endY) {
			wait+=Time.deltaTime;
		}
		else
			transform.Translate (Vector3.up*Time.deltaTime* speed);
		if(wait>=2)
			Application.LoadLevel ("Title");
	}
}
