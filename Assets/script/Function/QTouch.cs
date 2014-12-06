using UnityEngine;
using System.Collections;

public class QTouch : MonoBehaviour {

		private GameObject menucamobj;
		private Camera menucam;

		private Vector2 before = Vector2.zero;
		private GameObject obj=null;


		// Use this for initialization
		void Start () {
				menucamobj = GameObject.Find ("QCamera");
				menucam = menucamobj.GetComponent<Camera> ();
				Debug.Log ("Menucamera is here : "+menucam.transform.position);
		}

		// Update is called once per frame
		void Update () {
				if(Input.GetMouseButtonDown (0))touchOnce ();
				if(GameSceneManager.gstate == GameSceneManager.state.Q && GameSceneManager.floorNum ==11 && obj != null){
						if(Input.GetMouseButton(0))
								moveObj (translatePosition(Input.mousePosition.x, Input.mousePosition.y),"dragging");
						if (Input.GetMouseButtonUp (0))
								moveObj (translatePosition(Input.mousePosition.x, Input.mousePosition.y),"draged");
				}
		}


		public void touchOnce(){
				touched (Input.GetMouseButtonDown (0),"touched");
		}
		/*				public void touchEnd(){
		touched (Input.GetMouseButtonUp (0),"drag");
	}*/

		public void touchDrag(){
//		touched (Input.GetMouseButton (0),"draging");
		}


		private void touched(bool isTouched,string s){
				if (isTouched) hitObj( translatePosition(Input.mousePosition.x, Input.mousePosition.y),s);
		}

		private Vector2 translatePosition(float x,float y){
				//var screenSpace = menucam.WorldToScreenPoint (transform.position);
				Vector3 pretap = new Vector3 (x,y, -1000.0f);
				Vector2 tapPoint = menucam.ScreenToWorldPoint (pretap);
				Vector2 truetap = new Vector2 (-tapPoint.x, -tapPoint.y);
				return truetap;
		}

		private void hitObj(Vector2 truetap,string s){
				truetap = new Vector2 (truetap.x+menucamobj.transform.position.x*2f,truetap.y);
				RaycastHit2D hitObject = Physics2D.Raycast (truetap, -Vector2.zero);
				if (hitObject) {
						//print (tapPoint+" "+truetap);
						Debug.Log ("hit object is " + hitObject.collider.gameObject.transform.parent.gameObject.name + "@" + truetap);
						obj = hitObject.collider.gameObject.transform.parent.gameObject;
						before = new Vector2 (obj.transform.position.x, obj.transform.position.y);
						//obj.SendMessage (s);
				} else
						Debug.Log ("no Object @ " + truetap);
		}

		void moveObj(Vector2 truetap,string s){
				if (s == "dragging") {
						float d = Vector2.Distance (truetap, before);
						if (d > 5.0f) {
								obj.transform.position = new Vector3 (truetap.x+menucamobj.transform.position.x*2f, truetap.y, 0f);
								before = truetap;
						}
				} else {
						obj = null;
						before = Vector2.zero;
				}
		}

}
