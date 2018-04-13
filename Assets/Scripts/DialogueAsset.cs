using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class DialogueAsset {

	[MenuItem("Assets/Create/Dialogue")]
    public static void CreateAsset ()
    {
        ScriptableObjectUtility.CreateAsset<Dialogue>(); //set intro
    }

}
