using System.Collections;
using UnityEngine;

public class WaterMainValve : MonoBehaviour, IViewOver {

	#region IViewOver implementation
    public void fireSelect ()
    {
    }

    public void fireAction ()
    {
        if(! rotating){
			WaterSystem.instance.WaterActivated = !WaterSystem.instance.WaterActivated;
			this.GetComponent<AudioSource>().Play();
			StartCoroutine(rotate());
        }
    }
    #endregion

    private IEnumerator rotate(){
		int dir = WaterSystem.instance.WaterActivated ? 1 : -1;
        this.rotating = true;
		this.GetComponent<Highlighter>().enabled = false;
        for(int i = 0; i < 100; ++i){
        	this.transform.Rotate(Vector3.forward, dir * 30 * Time.deltaTime);
        	yield return null;
        }
        this.GetComponent<Highlighter>().enabled = true;
        this.rotating = false;
    }


    private bool rotating = false;
}
