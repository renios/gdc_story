﻿using UnityEngine;
using System.Collections;

public class GaroFlow : MonoBehaviour {

	public float speed=3;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right*Time.deltaTime* speed);
	}
}
