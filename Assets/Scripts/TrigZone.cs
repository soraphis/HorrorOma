using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
using com.spacepuppyeditor.Inspectors;
#endif
using UnityEngine.UI;

public class TrigZone : MonoBehaviour{

    public enum ColliderFacingDirection{
        DONTCARE, TARGETBEHIND, TARGETINFRONT, RAYCAST //, VISIBLERAYCAST
    }

    [Serializable]
    public class TriggerZoneEvent : UnityEngine.Events.UnityEvent{

    }

    public int EnterUsages = 1; // -1 is unlimited
    public int ExitUsages = 1; // -1 is unlimited

    [Range(0.0f, 1.0f)]
    public float Probability = 0.1f;

    public ColliderFacingDirection FacingDirection = ColliderFacingDirection.DONTCARE;
    public int GameState = -1;

    public TriggerZoneEvent EnterEvents;
    #if UNITY_EDITOR
    [TagSelectorAttribute]
    #endif
    public String EnterObjectTag = "Player";

    public TriggerZoneEvent ExitEvents;
    #if UNITY_EDITOR
    [TagSelectorAttribute]
    #endif
    public String ExitObjectTag = "Player";

    void OnTriggerEnter(Collider other) {
        if(EnterUsages == 0) return;
        if (! other.CompareTag(EnterObjectTag))return;
        if (GameState != -1 && GameState != (int)StateMachine.Instance.State) return;
        if(UnityEngine.Random.value > Probability) return;

        for(int i = 0; i < EnterEvents.GetPersistentEventCount(); ++i){
            if(! (EnterEvents.GetPersistentTarget(i) is GameObject)) continue;
            GameObject go = (GameObject) EnterEvents.GetPersistentTarget(i);
            if(! checkFacing(other, FacingDirection, go)) return;
        }
        EnterEvents.Invoke();
        if((--EnterUsages) == 0){ // Usages = -1 should be (nearly) unlimited
            EnterEvents.RemoveAllListeners();
            //GameObject.Destroy(this.gameObject);
        }
    }

    void OnTriggerExit(Collider other) {
        if(ExitUsages == 0){
            if(EnterUsages == 0)
                GameObject.Destroy(this.gameObject);
            return;
        }
        if (! other.CompareTag(ExitObjectTag))return;
        if (GameState != -1 && GameState != (int)StateMachine.Instance.State) return;
        if(UnityEngine.Random.value > Probability) return;

        for(int i = 0; i < ExitEvents.GetPersistentEventCount(); ++i){
            if(! (ExitEvents.GetPersistentTarget(i) is GameObject)) continue;
            GameObject go = (GameObject) ExitEvents.GetPersistentTarget(i);
            if(! checkFacing(other, FacingDirection, go)) return;
        }
        ExitEvents.Invoke();
        if((--ExitUsages) == 0){ // Usages = -1 should be (nearly) unlimited
            ExitEvents.RemoveAllListeners();
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

#if UNITY_EDITOR
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow;
        for(int i = 0; i < EnterEvents.GetPersistentEventCount(); ++i){
            if(EnterEvents.GetPersistentTarget(i) == null || !(EnterEvents.GetPersistentTarget(i) is GameObject)) continue;
            GameObject go = (GameObject) EnterEvents.GetPersistentTarget(i);
            //Handles.DrawLine (this.transform.position, l.transform.position);
            Gizmos.DrawLine (this.transform.position, go.transform.position);
        }
        Gizmos.color = Color.blue;
        for(int i = 0; i < ExitEvents.GetPersistentEventCount(); ++i){
            if(ExitEvents.GetPersistentTarget(i) == null || !(ExitEvents.GetPersistentTarget(i) is GameObject)) continue;
            GameObject go = (GameObject) ExitEvents.GetPersistentTarget(i);
            //Handles.DrawLine (this.transform.position, l.transform.position);
            Gizmos.DrawLine (this.transform.position, go.transform.position);
        }

    }
#endif

}
