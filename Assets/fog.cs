using UnityEngine;
using System.Collections;

public class fog : MonoBehaviour {
		bool on=false;
		bool switchfunc = true;
		float alpha = 0.32f;
		float goal = 0.42f;
		float time = 3.8f;

		GameObject fcam;


	// Use this for initialization
		void Start () {
				fcam = GameObject.Find ("FogCamera");
				GameSceneManager.gmscript.fogback = gameObject;
				fcam.camera.enabled = false;
				iTween.ColorTo (gameObject,iTween.Hash("a",alpha,"time",0.01f,"oncompletetarget",this.gameObject,"oncomplete","enable"));
	}
	
	// Update is called once per frame
	void Update () {

				if (on) {
						if (switchfunc) 
								iTween.ColorTo (gameObject, iTween.Hash ("a", goal, "time",time,"oncompletetarget",gameObject,"oncomplete","switchfunction"));
						else {
								iTween.ColorTo (gameObject, iTween.Hash ("a", alpha, "time", time,"oncompletetarget",gameObject,"oncomplete","switchfunction"));
						}
				}
	
	}


		void visible(int type){
				on = true;
				deq();
		}
		void hide(int type){
				on = false;
				deq ();
		}

		private void switchfunction (){
				switchfunc = !switchfunc;
		}

		void deq(){
				GameSceneManager.gm.SendMessage ("deq");
		}
		void enable(){
				Debug.Log ("enable");
				on = true;
				fcam.camera.enabled = true;
		}
}
