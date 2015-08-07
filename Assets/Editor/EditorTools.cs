using System;
using UnityEditor;
using UnityEngine;

public class EditorTools : Editor{

    [MenuItem("Custom/Load Scene Additive")]
    static void Apply(){
        String scenepath = AssetDatabase.GetAssetOrScenePath(Selection.activeObject);
        if(scenepath == null || !scenepath.Contains(".unity")){
            EditorUtility.DisplayDialog("Select Scene", "You Must Select a Scene!", "OK");
            EditorApplication.Beep();
            return;
        }
        Debug.Log("Opening " + scenepath + " additively");
        EditorApplication.OpenSceneAdditive(scenepath);
    }

    [MenuItem("Custom/ProBuilder/Actions/Force Refresh Objects")]
    public static void Inuit()
    {

        pb_Object[] all = (pb_Object[])FindObjectsOfType(typeof(pb_Object));
        foreach(pb_Object pb in all)
            pb.MakeUnique();
    }

    public override void OnInspectorGUI ()
   {
     // Draw the default inspector
     DrawDefaultInspector();

     TrigZone tg = (TrigZone)target;
     tg.EnterObjectTag = EditorGUILayout.TagField("" , tg.EnterObjectTag);

     // Save the changes back to the object
     EditorUtility.SetDirty(target);
   }

}
