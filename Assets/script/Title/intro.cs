using UnityEngine;
using System.Collections;

public class intro : MonoBehaviour {

		public static bool touchable;
		private BoxCollider2D bc;
		public static MessageState m;
		public GameObject im;
	// Use this for initialization
	void Start () {
				touchable = false;
				//titleManager.gmscript.intr = this.gameObject;
				gameObject.renderer.enabled = false;
				bc = gameObject.GetComponent<BoxCollider2D> ();
				bc.enabled = false;
				var c = gameObject.GetComponent<SpriteRenderer> ().color;
				//gameObject.GetComponent<SpriteRenderer> ().color = new Color (c.r,c.g,c.b,0.1f);
				iTween.ColorTo (this.gameObject, iTween.Hash ("color", new Color(c.r,c.g,c.b,0.0f), "time", 0.01f, "easetype", "easeincirc"));
				im = GameObject.Find ("GameObject");
				m = MessageState.INTRO;
			
	}
	
	// Update is called once per frame
	void Update () {
				//Debug.Log ("alpha is "+gameObject.GetComponent<SpriteRenderer> ().color.a);
	}

		void visible(int type){
				bc.enabled = true;
				touchable = true;
				//im.SendMessage ("visible");
				/*Debug .Log("in");
				gameObject.renderer.enabled = true;

				if (type == 1)
						iTween.ColorTo (this.gameObject, iTween.Hash ("a", 1.0f, "time", 1.5f,"easetype", "easeincirc",  "oncompletetarget", this.gameObject, "oncomplete", "deq"));
				else {
						deq ();
						iTween.ColorTo (this.gameObject, iTween.Hash ("a", 1.0f, "time", 1.5f, "easetype", "easeincirc"));
				}*/
				deq ();
		}
		void hide(int type){
				touchable = false;
		}
				
		void touched(){

				/*if (touchable) {
						m++;
						Debug.Log ("TOUCHED:INTRO");
						hide (1);
						titleManager.gm.SendMessage (name + "Ev");
				}*/
		}

		void deq(){
				//titleManager.gm.SendMessage ("deq");
		}
}
