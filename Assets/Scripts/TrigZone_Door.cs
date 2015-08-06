using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TrigZone_Door : MonoBehaviour {

    public enum TriggerZoneDoorType{
        CLOSER, OPENER, TOGGLER
    }

    public enum ColliderFacingDirection{
        DONTCARE, DOORBEHIND, DOORINFRONT, RAYCAST
    }

    public GameObject Door;
	public TriggerZoneDoorType Type;
	public ColliderFacingDirection FacingDirection = ColliderFacingDirection.DONTCARE;
    public int Usages = 1;
    [Range(0.0f, 1.0f)]
    public float Probability = 0.1f;


    void OnTriggerEnter(Collider other) {
        if(! other.CompareTag("Player")){
            return;
        }

        float rand = UnityEngine.Random.value;
        if(rand <= Probability){
            DoorOpen c = Door.GetComponentInChildren<DoorOpen>();

            Vector3 v = (other.transform.position - Door.transform.position).normalized; // direction from player to door
            float f = Vector3.Dot(v, Camera.main.transform.forward); // positive if looking in direction
            switch (FacingDirection){
                case(ColliderFacingDirection.DOORBEHIND):
                    if(f < 0) return; // the door could be seen!
                    break;
                case(ColliderFacingDirection.DOORINFRONT):
                    if(f >= 0) return; // its next to or behind the player
                    break;
                case(ColliderFacingDirection.RAYCAST):
                    if(f < 0){
                        RaycastHit hit;
                        int i = other.gameObject.layer;
                        other.gameObject.layer = 2; // ignore raycast - dont hit yourself
                        if(Physics.Raycast(other.transform.position, Door.transform.position, out hit)){
                            if(hit.collider != Door.transform){
                                other.gameObject.layer = i;
                                return; // theres something between
                            }
                        }
                        other.gameObject.layer = i;
                    }
                    break;
                default: break;
            }


            switch (Type){
                case(TriggerZoneDoorType.TOGGLER): c.Trigger(); break;
                case(TriggerZoneDoorType.OPENER):
                if(c != null && !c.Open){
                    c.Trigger();
                }
                break;
                case(TriggerZoneDoorType.CLOSER):
                if(c != null && c.Open){
                    c.Trigger();
                }
                break;
            }
			if((--Usages) <= 0){
                Destroy(gameObject);
            }
        }
	}
}
