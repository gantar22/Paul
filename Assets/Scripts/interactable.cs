using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour {

	public void act(){
		;
	}

	public Vector3 seat(){
		//see if the left or right spots are free or if the top or bottom ones are.
		Vector3 offset;
		offset = (Vector3.right + Vector3.forward) * transform.localScale.x;
		if(Physics.Raycast(transform.position,Vector3.right + Vector3.forward)){
			return transform.position + offset;
		}		
		offset = (Vector3.left + Vector3.forward) * transform.localScale.x;
		if(Physics.Raycast(transform.position,Vector3.left + Vector3.forward)){
			return transform.position + offset;
		}		
		offset = (Vector3.down + Vector3.forward) * transform.localScale.y;
		if(Physics.Raycast(transform.position,Vector3.down + Vector3.forward)){
			return transform.position + offset;
		}
		offset = (Vector3.up + Vector3.forward) * transform.localScale.y;
		if(Physics.Raycast(transform.position,Vector3.up + Vector3.forward)){
			return transform.position + offset;
		}
		return transform.position;

	}
}
