using UnityEngine;
using System.Collections;

/* 
 * version 0.1
 * return TouchObject : touchOnce,dragging
 */
public class TouchManager : SingletonMonoBehaviour<TouchManager> {

		static public string tests; 

	public void Awake()
	{
		if(this != Instance)
		{
			Destroy(this);
			return;
		}
		DontDestroyOnLoad(this.gameObject);
	}    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown (0))touchOnce ();
		//else if(Input.GetMouseButton (0))touchDrag ();
	}


	public void touchOnce(){
		touched (Input.GetMouseButtonDown (0),"touched");
	}
	/*public void touchEnd(){
		touched (Input.GetMouseButtonUp (0),"drag");
	}*/

	public void touchDrag(){
//		touched (Input.GetMouseButton (0),"draging");
	}


	private void touched(bool isTouched,string s){
		if (isTouched) hitObj( translatePosition(Input.mousePosition.x, Input.mousePosition.y),s);
	}

	private Vector2 translatePosition(float x,float y){
				//var screenSpace = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 pretap = new Vector3 (x,y, -1000.0f);
		Vector2 tapPoint = Camera.main.ScreenToWorldPoint (pretap);
		Vector2 truetap = new Vector2 (-tapPoint.x, -tapPoint.y);
		return truetap;
	}

	private void hitObj(Vector2 truetap,string s){
		RaycastHit2D hitObject = Physics2D.Raycast (truetap, -Vector2.zero);
		if (hitObject) {
			//print (tapPoint+" "+truetap);
			Debug.Log ("hit object is " + hitObject.collider.gameObject.name+"@"+truetap);
						tests = "hit object is " + hitObject.collider.gameObject.name + "@" + truetap;
			hitObject.collider.gameObject.SendMessage (s);
			//if(collition2d == this.gameObject.collider2D){print("hit");}
		}
	}



}
