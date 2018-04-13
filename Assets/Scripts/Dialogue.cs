using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    #if UNITY_EDITOR
    using UnityEditor;
    #endif





	public enum QuestType {open,closed,item}

	[System.Serializable]
	public struct Conditions {
		[SerializeField]
		public string Next_Line_Name;
		
		[SerializeField]
		public QuestType quest;

		[SerializeField]
		public int quest_index;


		[SerializeField]
		public bool unique; //can only use this quest once
		[HideInInspector]
		public bool done;

		//[SerializeField]
		//string pauls_response;
	}

	[System.Serializable]
	public struct D_line {
		[SerializeField]
		public string name; //needs to be unique
		[SerializeField]
		[TextArea(7,20)]
		public string text;
		[SerializeField]
		string notes;
		[SerializeField]
		public string default_next_line;
		[SerializeField]
		public Conditions[] journal_options;
		[SerializeField]
		public int[] assign_quests;
		[SerializeField]
		public int[] finish_quests;
		[SerializeField]
		public int[] give_items;
		//take items?
	}

[System.Serializable]
public class Dialogue : ScriptableObject {


	 //[System.Serializable] public class DictLine : SerializableDictionary<string, D_line> {}





	public D_line[] options; //first and general intro;

}

