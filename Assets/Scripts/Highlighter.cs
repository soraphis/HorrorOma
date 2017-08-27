using UnityEngine;


public class Highlighter : MonoBehaviour {
    public GameObject Player;

    public bool Highlighted { private set; get; }
    private HighlightObjects highlightObjects;
    // Use this for initialization
    void Start () {
        highlightObjects = Camera.main.GetComponent<HighlightObjects>();
    }

	// Update is called once per frame
	void Update () {
    }

    public void HighlightToggle(bool b) {
        Highlighted = b;
        if(Highlighted) {
            highlightObjects.addToHighlight(this.gameObject);
        } else {
            highlightObjects.removeToHighlight(this.gameObject);
        }
    }

    public void HighlightToggle() {
        HighlightToggle(!Highlighted);
    }

}
