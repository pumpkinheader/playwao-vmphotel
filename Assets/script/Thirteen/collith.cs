using UnityEngine;
using System;
using System.Collections;


public class collith : MonoBehaviour {

		BoxCollider2D bc;
		GameObject gsm;
		bool touchable=true;
	// Use this for initialization
	void Start () {
				bc = this.gameObject.GetComponent<BoxCollider2D> ();
				bc.enabled = false;
				gsm = GameObject.Find ("GameSceneManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void visible(){
				bc.enabled = true;
				//deq ();
		}

		void hide(){
				bc.enabled = false;
				//deq();
		}

		void touched(){
				//msearch ();
				if (touchable) {
						touchable = false;
						gsm.SendMessage ("touchth", name);
				}
		}

		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
		/*void msearch(){
				MessageState m = MessageState.CORRECT;
				var ms = Enum.GetNames (typeof(MessageState));
				int offset = Array.FindIndex(ms,mequal);
				if (offset != 0)
						for (int i = 0; i < offset; i++)
								m += 1;
				Debug.Log ("FIND:" + m.ToString ("F"));
				gm.SendMessage ("changeMessage",m);
		}

		private bool mequal(string s){
				if (s == name)
						return  true;
				else
						return false;
		}*/
}
