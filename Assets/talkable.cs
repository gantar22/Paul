using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkable : MonoBehaviour {

	public Dialogue d;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void talk(){
		print("called");
		Camera.main.GetComponent<dialogueM>().start_dialogue(d,gameObject);
		GetComponent<schedule>().pause();
	}
}
