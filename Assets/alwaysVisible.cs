using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Rigidbody))]
public class alwaysVisible : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			float dis = Vector3.Distance(Camera.main.transform.position,transform.position);

			Vector3 dir = -1 * Camera.main.transform.forward;
			RaycastHit[] hits = GetComponent<Rigidbody>().SweepTestAll(dir,dis);
			fade f = null;
			foreach(RaycastHit h in hits){
				if(f = h.transform.GetComponent<fade>()){
					f.fadeOut();
				}
			}


		
	}
}
