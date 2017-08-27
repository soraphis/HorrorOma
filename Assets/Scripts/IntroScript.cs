using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroScript : MonoBehaviour {

    [SerializeField] private Image[] images;
    [SerializeField] private float[] times;

    private int current = 0;

    void Update() {
        if (current >= times.Length) {
            LevelLoader.instance.ConditionToLoad = true;
            this.enabled = false;
            return;
        }
        times[current] -= Time.deltaTime;
        if (times[current] < -1) {
            current++;
            return;
        }
        if (times[current] < 0) {
            Color c = images[current].color;
            c.a = -times[current];
            images[current].color = c;
        }
    }

}
