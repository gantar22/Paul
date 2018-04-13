using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class questM : MonoBehaviour {
	[TextArea(4,20)]
	public string[] quest_table;

	[TextArea(4,20)]
	public string[] item_table;

	public List<int> open_quests;

	public List<int> complete_quests;

	public GameObject quest_box; //for the love of god make this just a single text box

	public GameObject item_box;

	public List<int> inventory;

	private dialogueM d;


	void Start(){

		
	}


	public void handle_item(Transform t){
		if(!d) 		d = GetComponent<dialogueM>();
		int id = inventory[t.GetSiblingIndex()];
		if(d.textPanel.activeInHierarchy){
			if(d.get_item(id)){
				take_item(id);
			}
		}
	

	}

	
	public void start_quest(int id){
		GameObject quest_button;
		quest_button = quest_box.transform.GetChild(open_quests.Count).gameObject;
		quest_button.SetActive(true);
		if(quest_button.transform.childCount > 0 && quest_button.transform.GetChild(0).GetComponent<Text>())
			quest_button.transform.GetChild(0).GetComponent<Text>().text = quest_table[id];

		open_quests.Add(id);
	}

	public void get_item(int id){
		GameObject item_button;
		if(item_box.transform.childCount > inventory.Count) item_button = item_box.transform.GetChild(inventory.Count).gameObject;
		else return; //make new page
		item_button.SetActive(true);
		if(item_button.transform.childCount > 0 && item_button.transform.GetChild(0).GetComponent<Text>())
			item_button.transform.GetChild(0).GetComponent<Text>().text = item_table[id];

		inventory.Add(id);
	}

	public void complete_quest(int id){
		open_quests.Remove(id);
		complete_quests.Add(id);
		update_quest();
	}

	public void take_item(int id){
		inventory.Remove(id);
		update_inventory();
	}

	public void update_quest(){
		foreach(Transform button in quest_box.transform){
			button.gameObject.SetActive(false);
		}
		GameObject quest_button;
		for(int i = 0; i < open_quests.Count; i++){
			quest_button = quest_box.transform.GetChild(i).gameObject;
			quest_button.SetActive(true);
			if(quest_button.transform.childCount > 0 && quest_button.transform.GetChild(0).GetComponent<Text>())
				quest_button.transform.GetChild(0).GetComponent<Text>().text = quest_table[open_quests[i]];
		}

	}

	public void update_inventory(){
		foreach(Transform button in item_box.transform){
			button.gameObject.SetActive(false);
		}
		GameObject item_button;
		for(int i = 0; i < inventory.Count; i++){
			item_button = item_box.transform.GetChild(i).gameObject;
			item_button.SetActive(true);
			if(item_button.transform.childCount > 0 && item_button.transform.GetChild(0).GetComponent<Text>())
				item_button.transform.GetChild(0).GetComponent<Text>().text = item_table[inventory[i]];
		}

	}


}
