using UnityEngine;
using System.Collections;

public class backth : MonoBehaviour {

	// Use this for initialization
	void Start () {
				this.gameObject.renderer.enabled = false;
				GameSceneManager.gmscript.backth = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void visible(int type){
				this.gameObject.renderer.enabled = true;
				deq ();
		}
		void hide(int type){
				this.gameObject.renderer.enabled = false;
				deq ();
		}


		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
}
