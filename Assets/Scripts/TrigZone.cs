using System;
using UnityEngine;
using UnityEngine.UI;

public class TrigZone : MonoBehaviour{

    public enum ColliderFacingDirection{
        DONTCARE, TARGETBEHIND, TARGETINFRONT, RAYCAST //, VISIBLERAYCAST
    }

    [Serializable]
    public class TriggerZoneEvent : UnityEngine.Events.UnityEvent{

    }

    public int Usages = 1;

    [Range(0.0f, 1.0f)]
    public float Probability = 0.1f;

    public ColliderFacingDirection FacingDirection = ColliderFacingDirection.DONTCARE;

    public TriggerZoneEvent events;

    void OnTriggerEnter(Collider other) {
        if (! other.CompareTag("Player")) { return; }
        if(UnityEngine.Random.value > Probability) return;

        for(int i = 0; i < events.GetPersistentEventCount(); ++i){
            if(! (events.GetPersistentTarget(i) is GameObject)) continue;
            GameObject go = (GameObject) events.GetPersistentTarget(i);
            if(! checkFacing(other, FacingDirection, go)) return;
        }
        events.Invoke();
        if((--Usages) <= 0){
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
