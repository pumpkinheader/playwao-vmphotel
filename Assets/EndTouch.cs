﻿using UnityEngine;
using System.Collections;

public class EndTouch : MonoBehaviour {

		private GameObject menucamobj;
		private Camera menucam;
		private BoxCollider2D bc;

		// Use this for initialization
		void Start () {
				GameSceneManager.gmscript.Endobj = this.gameObject;
				menucamobj = GameObject.Find ("GameendCamera");
				menucam = menucamobj.GetComponent<Camera> ();
				Debug.Log ("Menucamera is here : "+menucam.transform.position);
				bc = gameObject.GetComponent<BoxCollider2D> ();
				bc.enabled = false;
		}
		void enableColli(int type){
				bc.enabled = true;
				GameSceneManager.gm.SendMessage ("deq");
		}
		// Update is called once per frame
		void Update () {
				if(Input.GetMouseButtonDown (0))touchOnce ();
				//else if(Input.GetMouseButton (0))touchDrag ();
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
				//var screenSpace = Camera.main.WorldToScreenPoint (transform.position);
				Vector3 pretap = new Vector3 (x,y, -1000.0f);
				Vector2 tapPoint = Camera.main.ScreenToWorldPoint (pretap);
				Vector2 truetap = new Vector2 (-tapPoint.x, -tapPoint.y);
				return truetap;
		}

		private void hitObj(Vector2 truetap,string s){
				truetap = new Vector2 (truetap.x+menucam.transform.position.x,truetap.y+menucam.transform.position.y);
				RaycastHit2D hitObject = Physics2D.Raycast (truetap, -Vector2.zero);
				if (hitObject) {
						//print (tapPoint+" "+truetap);
						Debug.Log ("hit object is " + hitObject.collider.gameObject.name+"@"+truetap);
						//tests = "hit object is " + hitObject.collider.gameObject.name + "@" + truetap;
						//hitObject.collider.gameObject.SendMessage (s);
						//if(collition2d == this.gameObject.collider2D){print("hit");}
						Application.LoadLevel ("TitleScene");
				}
		}


}
