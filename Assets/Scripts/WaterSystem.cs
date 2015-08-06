using Mono.Xml.Xsl;
using System.Collections;
using UnityEngine;

public class WaterSystem : MonoBehaviour {

    public static WaterSystem instance{
        get;
        private set;
    }

    protected WaterSystem(){

    }

    public bool WaterActivated = true; // so lange wahr, bis am rad abgedreht wurde
    public bool WaterIncrease1 = false; // wird true, wenn Wasser im Werkraum einlaeuft
    public float WaterIncrease1Amount = 2f; // Liter pro sekunde

    public bool WaterIncrease2 = false; // wird true, wenn Wasser im Boilerraum einlaeuft
    public float WaterIncrease2Amount = 6f; // Liter pro sekunde

    public bool WaterDecrease = true; // TODO: false bis abfluss frei
    public bool WaterOverDrain = false; // true wenn wasser oberhalb des abflusses ist
    public float WaterDecreaseAmount = 4f; // Liter pro Sekunde

    public float MaxLitre = 600;
    public AnimationCurve AreaOverLitre = null;

    public GameObject Water = null;

    public float WaterAmount = 0f;
    private float MaxHeight;
    private float WaterBaseHeight;

    void Awake(){
        WaterSystem.instance = this;
    }

	// Use this for initialization
	void Start () {
        if(Water == null){
            Debug.LogError("Water is not set to an instance of an object");
            return;
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        MaxHeight = (player.transform.position - Water.transform.position).y;
        WaterBaseHeight = Water.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if(Water == null) return; // do not spam errors

        if(WaterActivated){
            if(WaterIncrease1){
                WaterAmount += WaterIncrease1Amount * Time.deltaTime;
            }
            if(WaterIncrease2){
                WaterAmount += WaterIncrease2Amount * Time.deltaTime;
            }
        }
        if(WaterDecrease && WaterOverDrain){
            WaterAmount -= WaterDecreaseAmount * Time.deltaTime;
        }

        float percentual = WaterAmount / MaxLitre;
        Vector3 w = Water.transform.position;
        w.y = WaterBaseHeight + AreaOverLitre.Evaluate(percentual) * MaxHeight;
        Water.transform.position = w;

	}
}
