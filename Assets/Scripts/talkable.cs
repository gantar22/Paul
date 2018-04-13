using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkable : MonoBehaviour {

	public Dialogue d;
	public bool intro;

	// Use this for initialization
	void Start () {
		intro = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void talk(){
		Camera.main.GetComponent<dialogueM>().start_dialogue(d,gameObject,intro);
		intro = false;
		GetComponent<schedule>().pause();
	}
}
