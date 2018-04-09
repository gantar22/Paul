using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent (typeof(NavMeshAgent))]
public class schedule : MonoBehaviour {

	public Transform[] dests;
	private int index;
	private bool _pause;

	
	// Update is called once per frame
	void Update () {
		if(dests == null) return;
		if(dests.Length == 0) return;
		if(index == 0){
			GetComponent<NavMeshAgent>().destination = dests[0].position;
		}

		if((transform.position - dests[index % dests.Length].position).sqrMagnitude < 1 && !_pause){
			index++;
			GetComponent<NavMeshAgent>().destination = dests[index % dests.Length].position;
		}
		
	}

	public void pause(){
		_pause = true;
		GetComponent<NavMeshAgent>().destination = transform.position;
	}

	public void unpause(){
		_pause = false;
		if(dests.Length == 0) return;
		GetComponent<NavMeshAgent>().destination = dests[index % dests.Length].position;
	}
}
