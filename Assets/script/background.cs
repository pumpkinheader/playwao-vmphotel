using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {

		SpriteRenderer r;
	// Use this for initialization
	void Start () {
				GameSceneManager.gmscript.back = this.gameObject;
				r = gameObject.GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void hide(int type){
				r.enabled = false;
				deq ();
		}
		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
}
