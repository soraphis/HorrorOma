using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class ElectroColliderHandler : MonoBehaviour {

    [SerializeField] Fuse WerkraumFuse;

    bool deadly = true;


    void Update() {
        deadly = WerkraumFuse.PowerAble & WerkraumFuse.powered;
        for(int i = 0; i < this.transform.childCount; ++i){
            this.transform.GetChild(i).gameObject.SetActive(deadly);
        }
    }

    void OnTriggerEnter(Collider other){
        if(deadly == false) return;
        if(other.CompareTag("Player")){ // player entered water
            other.GetComponent<GameOver>().Kill(GameOver.DeathType.ELECTRIFICATION);
        }
        if(other.gameObject.layer == 4) // water
            WaterSystem.instance.WaterElectrified = true;
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.layer == 4) // water
            WaterSystem.instance.WaterElectrified = false;
    }
}
