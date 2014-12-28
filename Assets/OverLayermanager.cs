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


		void visible(int type){
				sr.enabled = true;
				if (type == 1) {
						iTween.ColorTo (whiteObj, iTween.Hash ("a", 0.9f, "time", 3f, "easetype", iTween.EaseType.easeInExpo,"oncompletetarget",gameObject,"oncomplete","imhide"));
				} else {
						//iTween.ColorTo (gameObject, iTween.Hash ("a", 1f, "time", 3f, "easetype", iTween.EaseType.easeInExpo));
						deq ();
				}
		}
		void hide(int type){
		}
		void imhide(){
				iTween.ColorTo (whiteObj,iTween.Hash("a", 0f, "time", 0.4f,"oncompletetarget",gameObject,"oncomplete","deq"));
				//deq ();
		}

		void deq(){
				sr.enabled = false;
				GameSceneManager.gm.SendMessage ("deq");
		}
}
