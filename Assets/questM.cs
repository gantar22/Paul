using System.Collections;
using System.Collections.Generic;
using UnityEngine;
      using UnityEngine.UI;



public class questM : MonoBehaviour {
	[TextArea(4,20)]
	public string[] quest_table;
	/*[TextArea(4,20)]
	public string[] quest_table; 

	public List<int> open_quests;

	public List<int> complete_quests;

	public RectTransform quest_button_holder;

	public Vector2 y_index;


	void Start(){
		y_index = new Vector2(quest_button_holder.rect.center.x,quest_button_holder.rect.yMax);
	}

	
	public void start_quest(int id){
		open_quests.Add(id);
		update_journal();
	}

	public void complete_quest(int id){
		open_quests.Remove(id);
		complete_quests.Add(id);
		update_journal();
	}


	void update_journal(){

		/*
		* use GUIStyle.CalcHeight(content,width)
		*
		string r;
		GUIContent content;
		foreach(int i in open_quests){
			content = new GUIContent(quest_table[i]);
			y_index += Vector2.down * CalcHeight(content,quest_button_holder.rect.width);
		}
		Text.text = r;
	}*/
}
