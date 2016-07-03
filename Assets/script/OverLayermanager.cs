using UnityEngine;
using System.Collections;

public class OverLayermanager : MonoBehaviour {

		GameObject whiteObj;
		SpriteRenderer sr;
	// Use this for initialization
	void Start () {
				whiteObj = new GameObject ();
				sr = new SpriteRenderer ();
				GameSceneManager.gmscript.overlayer = gameObject;
				whiteObj = GameObject.Find ("white");
				sr = whiteObj.GetComponent<SpriteRenderer> ();
				sr.enabled = false;
				iTween.ColorTo (whiteObj,iTween.Hash("a",0f,"time",0.01f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void visibleslow(int type){
				sr.enabled = true;
				if (type == 1) {
						iTween.ColorTo (whiteObj, iTween.Hash ("a", 1.0f, "time", 5.6f, "easetype", iTween.EaseType.easeInExpo,"oncompletetarget",gameObject,"oncomplete","deq"));
				} else {
						iTween.ColorTo (whiteObj, iTween.Hash ("a", 1.0f, "time", 5.6f, "easetype", iTween.EaseType.easeInExpo));
						deq ();
				}
		}

		void visible(int type){
				sr.enabled = true;
				if (type == 1) {
						iTween.ColorTo (whiteObj, iTween.Hash ("a", 1.0f, "time", 3f, "easetype", iTween.EaseType.easeInExpo,"oncompletetarget",gameObject,"oncomplete","deq"));
				} else {
						iTween.ColorTo (whiteObj, iTween.Hash ("a", 1.0f, "time", 3f, "easetype", iTween.EaseType.easeInExpo));
						deq ();
				}
		}
		void hide(int type){
				if (type == 1) {
						iTween.ColorTo (whiteObj,iTween.Hash("a", 0f, "time", 2.4f,"delay",0.2f,"oncompletetarget",gameObject,"oncomplete","disable","oncompleteparams",type));
				} else {
						deq();
						iTween.ColorTo (whiteObj,iTween.Hash("a", 0f, "time", 2.4f,"delay",0.2f,"oncompletetarget",gameObject,"oncomplete","disable","oncompleteparams",type));
				}

		}
		void disable(int type){
				if (type == 1)deq ();
				sr.enabled = false;
		}

		void deq(){
				//sr.enabled = false;
				GameSceneManager.gm.SendMessage ("deq");
		}
}
