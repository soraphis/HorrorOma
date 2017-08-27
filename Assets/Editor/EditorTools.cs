using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditorTools : Editor{

	[MenuItem("Custom/Set Decal Layer")]
	static void DecalFix(){
		Decal [] all = (Decal[])FindObjectsOfType(typeof(Decal));
		foreach (Decal d in all) {
			d.affectedLayers = 1 << 5;
		}
	}

    [MenuItem("Custom/RemoveHideFlags")]
    static void RemoveHideFlags() {
       Selection.activeObject.hideFlags = HideFlags.None;
    }

    [MenuItem("Custom/Orient On Ground")]
	static void OrientOnGround(){
		Transform t = Selection.activeGameObject.transform;

		RaycastHit hit;
		int layermask = (1 | 1 << 8 | 1 << 10);
		if(Physics.Raycast(t.position, Vector3.down, out hit, 0.8f, layermask)){
			RaycastHit hit2;
			if(Physics.Raycast(hit.point, Vector3.up, out hit2, 0.8f, layermask)){
				Vector3 pos = t.position;
				pos.y -= hit2.distance;
				t.position = pos;
			}
		}
	}


    [MenuItem("Custom/Load Scene Additive")]
    static void Apply(){
        String scenepath = AssetDatabase.GetAssetOrScenePath(Selection.activeObject);
        if(scenepath == null || !scenepath.Contains(".unity")){
            EditorUtility.DisplayDialog("Select Scene", "You Must Select a Scene!", "OK");
            EditorApplication.Beep();
            return;
        }
        Debug.Log("Opening " + scenepath + " additively");
        //EditorApplication.OpenSceneAdditive(scenepath);
        SceneManager.LoadScene(scenepath, LoadSceneMode.Additive);
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
