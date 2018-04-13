using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueM : MonoBehaviour {

	public GameObject textPanel;
	public Text _text;
	public GameObject Paul;
	public questM qm;

	private Dialogue _d;
	private D_line l;

	private GameObject participant;

	public void start_dialogue(Dialogue d,GameObject g,bool intro){
		_d = d;
		textPanel.SetActive(true);
		l =  d.options[intro ? 0 : 1];
		_text.text = l.text;

	
		participant = g;

	}

	private void goto_line(string name){
		int index = -1;
		for(int i = 0; i < _d.options.Length; i++){
			if(_d.options[i].name == name){
				index = i;
			}
		}		
		if(index == -1){
			textPanel.SetActive(false);
			_d = null;
			Paul.GetComponent<clickToMove>().clickable = true;
			schedule s = participant.GetComponent<schedule>();
			if(s) s.unpause();
			return;
		}
		l = _d.options[index];
		_text.text = l.text;
	}

	public void next(){
		foreach(int id in l.assign_quests){
			qm.start_quest(id);
		}
		foreach(int id in l.finish_quests){
			qm.complete_quest(id);
		}
		foreach(int id in l.give_items){
			qm.get_item(id);
		}
		string name = "-1";
		Conditions finish = new Conditions();
		finish.Next_Line_Name = "-1";
		foreach(Conditions c in l.journal_options){
			if(c.quest == QuestType.open && qm.open_quests.Contains(c.quest_index) && unique(c)){
				finish = c;
				goto_line(c.Next_Line_Name);
			}
			if(c.quest == QuestType.closed && qm.complete_quests.Contains(c.quest_index) && unique(c)){
				finish = c;
				goto_line(c.Next_Line_Name);
			}
		}
		if(finish.Next_Line_Name == "-1") finish.done = true;
		if(name == "-1")
			goto_line(l.default_next_line);
	}


	public bool get_item(int id){ //call from questM cause questM has all the buttons
		string name = "-1";
		Conditions finish = new Conditions();
		finish.Next_Line_Name = "-1";
		foreach(Conditions c in l.journal_options){
			if(c.quest == QuestType.item && c.quest_index == id && unique(c)){
				name = c.Next_Line_Name;
				finish = c;
				if(name == "-1") print("wtf Jonathon, that's not a quest name");
			}
		}
		if(finish.Next_Line_Name == "-1") finish.done = true;
		if(name != "-1") {
			goto_line(name);
			return true;
		}
		return false;

	}

	public bool unique(Conditions c){
		return !(c.unique && c.done);
	}

}
