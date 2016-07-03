using UnityEngine;
using System.Collections;

public class UICamera : MonoBehaviour {

		private Camera c;
		private GameObject Bats;
		private GameObject opbutton;
	// Use this for initialization
	void Start () {
				GameSceneManager.gmscript.UICamera = this.gameObject;
				c = this.gameObject.GetComponent<Camera> ();
				Bats = GameObject.Find ("Bat");
				opbutton = GameObject.Find ("optionbutton");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void hide(int i){
				iTween.ColorTo (Bats,iTween.Hash("a",0f,"time",0.8f));
				iTween.ColorTo (opbutton,iTween.Hash("a",0f,"time",0.8f,"oncompletetarget",this.gameObject,"oncomplete","camdisable"));
		}
		void camdisable(){
				c.enabled = false;
				deq ();
		}

		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
}
