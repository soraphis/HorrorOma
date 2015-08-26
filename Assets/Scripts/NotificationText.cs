using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class NotificationText{

    private static GameObject TextPrefab;
    private static GameObject Canvas;
    private static List<GameObject> notes = new List<GameObject>();

    public static void Initialize(){
        TextPrefab = (GameObject)Resources.Load("Prefabs/Text");
        Canvas = GameObject.FindGameObjectWithTag("UICanvas");
    }


	public static void SimpleScreenText(String text){
		SimpleScreenText (text, 3.0f);
	}


    public static void SimpleScreenText(String text, float seconds){
        GameObject str = UnityEngine.Object.Instantiate(TextPrefab);
		str.transform.SetParent(Canvas.transform);

        str.GetComponent<Text>().text = text;
        str.GetComponent<EventHandler>().OnDestroyCallback += () => { notes.Remove(str); Rearrange(); };
        notes.Add(str);
        Rearrange();
        UnityEngine.Object.Destroy(str, seconds);

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
