using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[ExecuteInEditMode]
public class twodorient : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.LookAt(Camera.main.transform.position,Vector3.up);
		transform.eulerAngles = Camera.main.transform.eulerAngles;
	}
}
