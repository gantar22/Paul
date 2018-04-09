using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class isoPlacement : MonoBehaviour {

	public Transform feet;


	
	// Update is called once per frame
	void Update () {
			if(feet){
					GetComponent<SpriteRenderer>().sortingOrder	= -(int)((1000 * feet.position.y));
				} else {
					GetComponent<SpriteRenderer>().sortingOrder	= -(int)((1000 * (transform.position.y - transform.localScale.y/2)));
				}
			
	}
}
