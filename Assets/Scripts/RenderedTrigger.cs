using UnityEngine;
using UnityEngine.UI;

public class RenderedTrigger : MonoBehaviour{

	public delegate void looked();
	public event looked OnWatchStart;
	public event looked OnWatchStop;

    private bool isRendered = false;
	private bool isLookedAt = false;

    private GameObject canvas;
	private Color col;
	public Renderer rend;

	public bool checkLineOfSight = false;
	public float maxRange = 15f;

	void Start (){
		rend = GetComponent<Renderer>();
		col = Color.white;
    }
	
	void Update () {
	    if(isRendered) UpdateRendered();
	}

	void OnDrawGizmos(){
		Vector3 center = rend.bounds.center;
		float radius = rend.bounds.extents.magnitude;
		Gizmos.color = col;
		Gizmos.DrawWireSphere(center, radius);
	}

    void UpdateRendered(){
		Vector3 center = rend.bounds.center;
		float radius = rend.bounds.extents.magnitude;

		Vector3 screenPosCenter = Camera.main.WorldToScreenPoint(center);
		screenPosCenter.z = 0;
		Vector3 screenPosEdge = Camera.main.WorldToScreenPoint(center + new Vector3(radius, 0 ,0));

		float screenradius = Vector3.Distance(screenPosCenter, screenPosEdge);
		if(screenradius*2 > 40 ){ // px
			// large enough to be looked at
			col = Color.blue;

			screenPosCenter.x = (screenPosCenter.x - Camera.main.pixelWidth/2 );
			screenPosCenter.y = (screenPosCenter.y - Camera.main.pixelHeight/2);
			if (Mathf.Abs(screenPosCenter.x) < screenradius &&
			    Mathf.Abs(screenPosCenter.y) < screenradius ){
				// centered enough
				col = Color.red;

				/// line of sight free?
				bool b = false;
				if(checkLineOfSight){
					RaycastHit hit;
					if(Physics.Raycast(Camera.main.transform.position, 
				                 		this.transform.position - Camera.main.transform.position, out hit, maxRange)){
						if(hit.transform == this.transform){
							b = true;
						}
					}
				}else{
					b = true;
				}

				if(b && isLookedAt == false){
					if(OnWatchStart != null) OnWatchStart();
					isLookedAt = true;
				}
			}else if(isLookedAt == true){
				if(OnWatchStop != null) OnWatchStop();
				isLookedAt = false;
			}
		}else{
			col = Color.white;
			if(isLookedAt == true){
				if(OnWatchStop != null) OnWatchStop();
				isLookedAt = false;
			}
		}

    }

    void OnBecameVisible(){
        isRendered = true;
    }
    void OnBecameInvisible() {
        isRendered = false;
		if(isLookedAt == true){
			if(OnWatchStop != null) OnWatchStop();
			isLookedAt = false;
		}
    }
}
