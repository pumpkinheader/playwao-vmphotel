using UnityEngine;
using System.Collections;

public class optionmenu : MonoBehaviour {

		SpriteRenderer s;
		BoxCollider2D b;
	// Use this for initialization
	void Start () {
				this.gameObject.renderer.enabled = false;
				s = this.gameObject.GetComponent<SpriteRenderer> ();
				b = this.gameObject.GetComponent<BoxCollider2D> ();
				b.enabled = false;
				iTween.ColorTo (this.gameObject, iTween.Hash ("color", new Color(s.color.r,s.color.g,s.color.b,0.0f), "time", 0.01f, "easetype", "easeincirc"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void visible(){
				this.gameObject.renderer.enabled = true;
				b.enabled = true;
				iTween.ColorTo (this.gameObject, iTween.Hash ("a", 1.0f, "time", 0.8f, "easetype", "easeincirc"));
		}

		void hide(int type){
				b.enabled = false;
				if (type == 1) {
						Debug.Log ("hide sequence");
						iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0.0f, "time", 0.8f, "easetype", "easeincirc", "oncompletetarget", this.gameObject, "oncomplete", "deqwithfalse"));
				}else {
						deq ();
						iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0.0f, "time", 0.8f, "easetype", "easeincirc"));
				}

		}
		void hidenodeq(){
				b.enabled = false;
				iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0.0f, "time", 0.8f, "easetype", "easeincirc","oncompletetarget", this.gameObject, "oncomplete", "renderfalse"));
		}

		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
		void deqwithfalse(){
				Debug.Log ("deq with false");
				this.gameObject.renderer.enabled = false;
				GameSceneManager.gm.SendMessage ("deq");
		}
		void renderfalse(){
				this.gameObject.renderer.enabled = false;
		}

		void touched(){
				GameSceneManager.gm.SendMessage (name + "Ev");
		}
}
