using UnityEngine;
using System.Collections;

public class blackboad : MonoBehaviour {
		private Renderer r;
	// Use this for initialization
	void Start () {
				r = this.gameObject.renderer;
				r.material.color = new Color (255f,255f,255f,1.0f);
				r.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void visible(){
				r.enabled = true;
		}
		void hide(){
				//iTween.StopByName ("move");
				//iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0f, "easetype", "easeincirc", "time", 0.2f,"oncompletetarget",this.gameObject,"oncomplete","disable"));
		}

		void disable(){
				Debug.Log ("DISABLE BACK");
				r.enabled = false;
		}
}
