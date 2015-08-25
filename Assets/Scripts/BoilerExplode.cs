using Assets.Scripts;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
    #endif
using UnityEngine;

public class BoilerExplode : MonoBehaviour {

    public bool Sleep = true;
	private float countDown = 15;

    [SerializeField] private GameObject SecretWall;
    [SerializeField] private GameObject Stairs;
    [SerializeField] private GameObject StairsBroken;

    private AudioSource audioSource;

    void Start(){
        if(Stairs == null || StairsBroken == null){
            Debug.Log("BoilerExplode.cs: Stairs is not Set");
        }
        audioSource = GetComponent<AudioSource>();
    }

	void Update(){
		if (Sleep)
			return;
		if(StateMachine.Instance.State == GameState.WaterBoiler03){
			countDown -= Time.deltaTime;
			if (countDown <= 0) {
                Explode();
			}

		}

	}


    public void IncreaseAudioPitch(float amount){
        StartCoroutine(AudioPitchCoroutine(amount));
    }

    private IEnumerator AudioPitchCoroutine(float seconds){
        float f = 0;
        while (f < seconds){
             f += Time.deltaTime;
            audioSource.pitch *= 1.001f;
            yield return null;
        }
    }

    // public because there are multiple ways to let it explode
    public void Explode(){
        Debug.Log ("EXPLOSION"); // TODO: PLAYSOUND
        GetComponentInChildren<AudioSource>().Play();

        Stairs.SetActive(false);
        StairsBroken.SetActive(true);
        SecretWall.SetActive(false);
        StateMachine.Instance.State = GameState.WaterRises04;
        WaterSystem.instance.WaterIncrease2 = true;

        Destroy(this.gameObject); // destroying this gameObject -> stopping all sounds from emiting and all scripts from executing
        Sleep = true; // should not be necessary
    }

	#if UNITY_EDITOR
	void OnDrawGizmos(){
		Gizmos.DrawLine (this.transform.position, this.transform.position + Vector3.up * countDown / 10F);
	}
#endif
}
