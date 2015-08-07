using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using com.spacepuppyeditor.Inspectors;

public class TrigZone : MonoBehaviour{

    public enum ColliderFacingDirection{
        DONTCARE, TARGETBEHIND, TARGETINFRONT, RAYCAST //, VISIBLERAYCAST
    }

    [Serializable]
    public class TriggerZoneEvent : UnityEngine.Events.UnityEvent{

    }

    public int Usages = 1; // -1 is unlimited

    [Range(0.0f, 1.0f)]
    public float Probability = 0.1f;

    public ColliderFacingDirection FacingDirection = ColliderFacingDirection.DONTCARE;
    public TriggerZoneEvent EnterEvents;
    [TagSelectorAttribute]
    public String EnterObjectTag = "Player";

    public TriggerZoneEvent ExitEvents;
    [TagSelectorAttribute]
    public String ExitObjectTag = "Player";

    void OnTriggerEnter(Collider other) {
        if (! other.CompareTag(EnterObjectTag)) { return; }
        if(UnityEngine.Random.value > Probability) return;

        for(int i = 0; i < EnterEvents.GetPersistentEventCount(); ++i){
            if(! (EnterEvents.GetPersistentTarget(i) is GameObject)) continue;
            GameObject go = (GameObject) EnterEvents.GetPersistentTarget(i);
            if(! checkFacing(other, FacingDirection, go)) return;
        }
        EnterEvents.Invoke();
        if((--Usages) == 0){ // Usages = -1 should be (nearly) unlimited
            GameObject.Destroy(this.gameObject);
        }
    }

    protected bool checkFacing(Collider other, ColliderFacingDirection dir, GameObject target){
        if(dir == ColliderFacingDirection.DONTCARE) return true;

        Vector3 v = (other.transform.position - target.transform.position).normalized; // direction from player to door
        float f = Vector3.Dot(v, Camera.main.transform.forward); // positive if looking in direction

        switch (dir){
            case(ColliderFacingDirection.TARGETBEHIND):
            if(f < 0) return false; // the door could be seen!
            break;
            case(ColliderFacingDirection.TARGETINFRONT):
            if(f >= 0) return false; // its next to or behind the player
            break;
            case(ColliderFacingDirection.RAYCAST):
            if(f < 0){
                RaycastHit hit;
                int i = other.gameObject.layer;
                other.gameObject.layer = 2; // ignore raycast - dont hit yourself
                if(Physics.Raycast(other.transform.position, target.transform.position, out hit)){
                    if(hit.collider != target.transform){
                        other.gameObject.layer = i;
                        return false; // theres something between
                    }
                }
                other.gameObject.layer = i;
            }
            break;
        }
        return true;
    }

}
