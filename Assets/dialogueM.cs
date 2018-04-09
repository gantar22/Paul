using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueM : MonoBehaviour {

	public GameObject textPanel;
	public Text _text;
	public GameObject Paul;

	private int index = 0;
	private Dialogue _d;

	private GameObject participant;

	public void start_dialogue(Dialogue d,GameObject g){
		_d = d;
		textPanel.SetActive(true);
		_text.text = d.options[0].text;
		index = 0;
		participant = g;

	}

	public void next(){
		index++;
		if(index == _d.options.Length){
			index = 0;
			textPanel.SetActive(false);
			_d = null;
			Paul.GetComponent<clickToMove>().clickable = true;
			schedule s = participant.GetComponent<schedule>();
			if(s) s.unpause();
			return;

		}
		_text.text = _d.options[index].text;

	}

}
