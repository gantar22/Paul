using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent (typeof(NavMeshAgent))]
public class clickToMove : MonoBehaviour {

	public int click = 1;
	public bool clickable = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(click) && clickable){
			

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if (Physics.Raycast(ray,out hit,Mathf.Infinity,1<<8)) {
					GetComponent<NavMeshAgent>().destination = hit.point;
					talkable t;
					if(t = hit.transform.GetComponent<talkable>()){
						t.talk();
						clickable = false;
					}
					interactable ia;
					if(ia = hit.transform.GetComponent<interactable>()){
						ia.act();
						GetComponent<NavMeshAgent>().destination = ia.seat();
					}
			 }




		}
		
	}
}
