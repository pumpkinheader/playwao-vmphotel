using UnityEngine;
using System.Collections;

public class loadingBat : MonoBehaviour {

		private Renderer r;

		// Use this for initialization
		void Start () {
				DontDestroyOnLoad (this.gameObject);
				r = this.gameObject.GetComponent<Renderer>();
				r.enabled = false;
		}
	
	// Update is called once per frame
	void Update () {
	
	}
		void visible(){r.enabled = true;move ();}
		void move(){
				iTween.RotateTo(this.gameObject,iTween.Hash("name","move","y",360f,"looptype","pingpong","easetype","easeincirc","time",2f));
		}
		void hide(){
				iTween.StopByName ("move");
				iTween.ColorTo (this.gameObject, iTween.Hash ("a", 0f, "easetype", "easeincirc", "time", 0.4f,"oncompletetarget",this.gameObject,"oncomplete","disable"));
		}

		void disable(){
				r.enabled = false;
		}
}
