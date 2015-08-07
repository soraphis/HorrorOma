using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class NotificationText{

    private static GameObject TextPrefab = (GameObject)Resources.Load("Prefabs/Text");
    private static List<GameObject> notes = new List<GameObject>();
    
    public static void SimpleScreenText(String text){
        GameObject canvas = GameObject.FindGameObjectWithTag("UICanvas");
        GameObject str = UnityEngine.Object.Instantiate(TextPrefab);
		str.transform.SetParent(canvas.transform);

        str.GetComponent<Text>().text = text;
        str.GetComponent<EventHandler>().OnDestroyCallback += () => { notes.Remove(str); Rearrange(); };
        notes.Add(str);
        Rearrange();
        UnityEngine.Object.Destroy(str, 1);
        
    }

    private static void Rearrange(){
        float y = -15;
        foreach (var note in notes){
			Vector3 v = ((RectTransform)note.transform).anchoredPosition;
			v.y = y;
			v.x = 100;
			((RectTransform)note.transform).anchoredPosition = v;
            y -= 30;
        }
    }

}
